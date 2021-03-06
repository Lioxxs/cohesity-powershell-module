﻿// Copyright 2018 Cohesity Inc.
using System.Management.Automation;
using Cohesity.Powershell.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cohesity.Powershell.Cmdlets.ProtectionSource
{
    /// <summary>
    /// <para type="synopsis">
    /// Registers a new NFS mount point as protection source with the Cohesity Cluster.
    /// </para>
    /// <para type="description">
    /// Registers a new NFS mount point as protection source with the Cohesity Cluster.
    /// </para>
    /// </summary>
    /// <example>
    /// <para>PS&gt;</para>
    /// <code>
    /// Register-CohesityProtectionSourceNFS -MountPath "file-server.example.com:/sourcevol"
    /// </code>
    /// <para>
    /// Registers a new NFS mount point with mount path "file-server.example.com:/sourcevol" with the Cohesity Cluster.
    /// </para>
    /// </example>
    [Cmdlet(VerbsLifecycle.Register, "CohesityProtectionSourceNFS")]
    [OutputType(typeof(Model.ProtectionSource))]
    public class RegisterCohesityProtectionSourceNFS : PSCmdlet
    {
        private Session Session
        {
            get
            {
                if (!(SessionState.PSVariable.GetValue("Session") is Session result))
                {
                    result = new Session();
                    SessionState.PSVariable.Set("Session", result);
                }
                return result;
            }
        }

        #region Params

        /// <summary>
        /// <para type="description">
        /// NFS Mount path.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true)]
        public string MountPath { get; set; } = null;

        #endregion

        #region Processing

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            Session.AssertAuthentication();
        }

        protected override void ProcessRecord()
        {

            var requestData = JsonConvert.SerializeObject(new {
                entity = new {
                    type = 11,
                    genericNasEntity = new {
                        protocol = 1,
                        type = 1,
                        path = MountPath
                    }
                },
                entityInfo = new {
                    endpoint = MountPath,
                    type = 11
                }
            });

            // POST /backupsources
            var registerUrl = $"/backupsources";
            var result = Session.ApiClient.Post(registerUrl, requestData);

            JObject protectionSourceObject = JObject.Parse(result);
            string protectionSourceId = (string)protectionSourceObject["id"];

            if (!string.IsNullOrEmpty(protectionSourceId))
            {
                // GET /protectionSources/{id}
                var getProtectionSourcesUrl = $"/public/protectionSources/objects/{protectionSourceId}";
                var response = Session.ApiClient.Get<Model.ProtectionSource>(getProtectionSourcesUrl);

                WriteObject(response);
            }
            else
            {
                WriteObject($"Registered {MountPath} Successfully");
            }
        }

        #endregion
    }
}