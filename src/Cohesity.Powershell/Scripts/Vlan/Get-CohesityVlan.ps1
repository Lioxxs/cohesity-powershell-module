function Get-CohesityVlan {
    <#
        .SYNOPSIS
        Request to fetch all Vlan configuration filtered by specified parameters.
        .DESCRIPTION
        The Get-CohesityVlan function is used to fetch list of all configured Vlan information using REST API or specific Vlan information based on specified parameters.
        .EXAMPLE
        Get-CohesityVlan
        List all configured Vlans
        .EXAMPLE
        Get-CohesityVlan -SkipPrimaryAndBondIface <boolean>
        SkipPrimaryAndBondIface is to filter interfaces entries which are primary interface or bond interfaces
        .EXAMPLE
        Get-CohesityVlan -VlanId <integer>
        Returns the VLAN corresponding to the specified VLAN ID or a specified vlan interface group name.
        .EXAMPLE
        Get-CohesityVlan -TenantIds [<string>]
        Retuns the Vlan that are configured for the specific tenant. TenantIds contains list of/specific id(s) of the tenants for which configured Vlans are to be returned.
    #>
    [CmdletBinding()]
    Param(
        # Filter interfaces entries which are primary interface or bond interfaces.
        [Parameter(Mandatory = $false)][ValidateSet("true", "false")]
        [String]$SkipPrimaryAndBondIface,
        # TenantIds contains ids of the tenants for which objects are to be returned.
        [Parameter(Mandatory = $false)]
        [String[]]$TenantIds = $null,
        [Parameter(Mandatory = $false)]
        [Int64]$VlanId
    )

    Begin {
        if (-not (Test-Path -Path "$HOME/.cohesity")) {
            throw "Failed to authenticate. Please connect to the Cohesity Cluster using 'Connect-CohesityCluster'"
        }
        $session = Get-Content -Path $HOME/.cohesity | ConvertFrom-Json

        $server = $session.ClusterUri

        $token = $session.Accesstoken.Accesstoken
    }

    Process {
        # Form query parameters
        $Parameters = [ordered]@{}
        $Parameters.Add('allUnderHierarchy', $true)
        if ($SkipPrimaryAndBondIface) {
            $Parameters.Add('skipPrimaryAndBondIface', [System.Convert]::ToBoolean($SkipPrimaryAndBondIface))
        }
        if ($null -ne $TenantIds) {
            $Parameters.Add('tenantIds', $TenantIds -join ',')
        }

        $queryString = $null
        if ($null -ne $Parameters.Keys) {
            $queryString = '?' + ($Parameters.Keys.ForEach({"$_=$($Parameters.$_)"}) -join '&')
        }

        # Construct URL & header
        $url = $server + '/irisservices/api/v1/public/vlans'
        if($VlanId) {
            $url = $url + '/' + $VlanId
        }
        $url = $url + $queryString

        $headers = @{'Authorization' = 'Bearer ' + $token }

        $vlanList = Invoke-RestApi -Method 'Get' -Uri $url -Headers $headers
        $vlanList

        if ($null -eq $vlanList) {
            if ($Global:CohesityAPIError) {
                if ($Global:CohesityAPIError.StatusCode -eq 'NotFound') {
                    $errorMsg = "Vlan doesn't exist."
                    Write-Warning $errorMsg
                } else {
                    $errorMsg = "Failed to fetch Vlan information with an error : " + $Global:CohesityAPIError
                }
            } else {
                $errorMsg = "Vlan doesn't exist."
                Write-Warning $errorMsg
            }
            CSLog -Message $errorMsg
        }
    } # End of process
} # End of function
