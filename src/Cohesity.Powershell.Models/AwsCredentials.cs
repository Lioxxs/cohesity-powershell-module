// Copyright 2019 Cohesity Inc.

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cohesity.Model
{
    /// <summary>
    /// Specifies the credentials to authenticate with AWS Cloud Platform.
    /// </summary>
    [DataContract]
    public partial class AwsCredentials :  IEquatable<AwsCredentials>
    {
        /// <summary>
        /// Specifies the entity type such as &#39;kIAMUser&#39; if the environment is kAWS. Specifies the type of an AWS source entity. &#39;kIAMUser&#39; indicates a unique user within an AWS account. &#39;kRegion&#39; indicates a geographical region in the global infrastructure. &#39;kAvailabilityZone&#39; indicates an availability zone within a region. &#39;kEC2Instance&#39; indicates a Virtual Machine running in AWS environment. &#39;kVPC&#39; indicates a virtual private cloud (VPC) network within AWS. &#39;kSubnet&#39; indicates a subnet inside the VPC. &#39;kNetworkSecurityGroup&#39; represents a network security group. &#39;kInstanceType&#39; represents various machine types. &#39;kKeyPair&#39; represents a pair of public and private key used to login into a Virtual Machine. &#39;kTag&#39; represents a tag attached to EC2 instance. &#39;kRDSOptionGroup&#39; represents a RDS option group for configuring database features. &#39;kRDSParameterGroup&#39; represents a RDS parameter group. &#39;kRDSInstance&#39; represents a RDS DB instance. &#39;kRDSSubnet&#39; represents a RDS subnet. &#39;kRDSTag&#39; represents a tag attached to RDS instance.
        /// </summary>
        /// <value>Specifies the entity type such as &#39;kIAMUser&#39; if the environment is kAWS. Specifies the type of an AWS source entity. &#39;kIAMUser&#39; indicates a unique user within an AWS account. &#39;kRegion&#39; indicates a geographical region in the global infrastructure. &#39;kAvailabilityZone&#39; indicates an availability zone within a region. &#39;kEC2Instance&#39; indicates a Virtual Machine running in AWS environment. &#39;kVPC&#39; indicates a virtual private cloud (VPC) network within AWS. &#39;kSubnet&#39; indicates a subnet inside the VPC. &#39;kNetworkSecurityGroup&#39; represents a network security group. &#39;kInstanceType&#39; represents various machine types. &#39;kKeyPair&#39; represents a pair of public and private key used to login into a Virtual Machine. &#39;kTag&#39; represents a tag attached to EC2 instance. &#39;kRDSOptionGroup&#39; represents a RDS option group for configuring database features. &#39;kRDSParameterGroup&#39; represents a RDS parameter group. &#39;kRDSInstance&#39; represents a RDS DB instance. &#39;kRDSSubnet&#39; represents a RDS subnet. &#39;kRDSTag&#39; represents a tag attached to RDS instance.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AwsTypeEnum
        {
            /// <summary>
            /// Enum KIAMUser for value: kIAMUser
            /// </summary>
            [EnumMember(Value = "kIAMUser")]
            KIAMUser = 1,

            /// <summary>
            /// Enum KRegion for value: kRegion
            /// </summary>
            [EnumMember(Value = "kRegion")]
            KRegion = 2,

            /// <summary>
            /// Enum KAvailabilityZone for value: kAvailabilityZone
            /// </summary>
            [EnumMember(Value = "kAvailabilityZone")]
            KAvailabilityZone = 3,

            /// <summary>
            /// Enum KEC2Instance for value: kEC2Instance
            /// </summary>
            [EnumMember(Value = "kEC2Instance")]
            KEC2Instance = 4,

            /// <summary>
            /// Enum KVPC for value: kVPC
            /// </summary>
            [EnumMember(Value = "kVPC")]
            KVPC = 5,

            /// <summary>
            /// Enum KSubnet for value: kSubnet
            /// </summary>
            [EnumMember(Value = "kSubnet")]
            KSubnet = 6,

            /// <summary>
            /// Enum KNetworkSecurityGroup for value: kNetworkSecurityGroup
            /// </summary>
            [EnumMember(Value = "kNetworkSecurityGroup")]
            KNetworkSecurityGroup = 7,

            /// <summary>
            /// Enum KInstanceType for value: kInstanceType
            /// </summary>
            [EnumMember(Value = "kInstanceType")]
            KInstanceType = 8,

            /// <summary>
            /// Enum KKeyPair for value: kKeyPair
            /// </summary>
            [EnumMember(Value = "kKeyPair")]
            KKeyPair = 9,

            /// <summary>
            /// Enum KTag for value: kTag
            /// </summary>
            [EnumMember(Value = "kTag")]
            KTag = 10,

            /// <summary>
            /// Enum KRDSOptionGroup for value: kRDSOptionGroup
            /// </summary>
            [EnumMember(Value = "kRDSOptionGroup")]
            KRDSOptionGroup = 11,

            /// <summary>
            /// Enum KRDSParameterGroup for value: kRDSParameterGroup
            /// </summary>
            [EnumMember(Value = "kRDSParameterGroup")]
            KRDSParameterGroup = 12,

            /// <summary>
            /// Enum KRDSInstance for value: kRDSInstance
            /// </summary>
            [EnumMember(Value = "kRDSInstance")]
            KRDSInstance = 13,

            /// <summary>
            /// Enum KRDSSubnet for value: kRDSSubnet
            /// </summary>
            [EnumMember(Value = "kRDSSubnet")]
            KRDSSubnet = 14,

            /// <summary>
            /// Enum KRDSTag for value: kRDSTag
            /// </summary>
            [EnumMember(Value = "kRDSTag")]
            KRDSTag = 15

        }

        /// <summary>
        /// Specifies the entity type such as &#39;kIAMUser&#39; if the environment is kAWS. Specifies the type of an AWS source entity. &#39;kIAMUser&#39; indicates a unique user within an AWS account. &#39;kRegion&#39; indicates a geographical region in the global infrastructure. &#39;kAvailabilityZone&#39; indicates an availability zone within a region. &#39;kEC2Instance&#39; indicates a Virtual Machine running in AWS environment. &#39;kVPC&#39; indicates a virtual private cloud (VPC) network within AWS. &#39;kSubnet&#39; indicates a subnet inside the VPC. &#39;kNetworkSecurityGroup&#39; represents a network security group. &#39;kInstanceType&#39; represents various machine types. &#39;kKeyPair&#39; represents a pair of public and private key used to login into a Virtual Machine. &#39;kTag&#39; represents a tag attached to EC2 instance. &#39;kRDSOptionGroup&#39; represents a RDS option group for configuring database features. &#39;kRDSParameterGroup&#39; represents a RDS parameter group. &#39;kRDSInstance&#39; represents a RDS DB instance. &#39;kRDSSubnet&#39; represents a RDS subnet. &#39;kRDSTag&#39; represents a tag attached to RDS instance.
        /// </summary>
        /// <value>Specifies the entity type such as &#39;kIAMUser&#39; if the environment is kAWS. Specifies the type of an AWS source entity. &#39;kIAMUser&#39; indicates a unique user within an AWS account. &#39;kRegion&#39; indicates a geographical region in the global infrastructure. &#39;kAvailabilityZone&#39; indicates an availability zone within a region. &#39;kEC2Instance&#39; indicates a Virtual Machine running in AWS environment. &#39;kVPC&#39; indicates a virtual private cloud (VPC) network within AWS. &#39;kSubnet&#39; indicates a subnet inside the VPC. &#39;kNetworkSecurityGroup&#39; represents a network security group. &#39;kInstanceType&#39; represents various machine types. &#39;kKeyPair&#39; represents a pair of public and private key used to login into a Virtual Machine. &#39;kTag&#39; represents a tag attached to EC2 instance. &#39;kRDSOptionGroup&#39; represents a RDS option group for configuring database features. &#39;kRDSParameterGroup&#39; represents a RDS parameter group. &#39;kRDSInstance&#39; represents a RDS DB instance. &#39;kRDSSubnet&#39; represents a RDS subnet. &#39;kRDSTag&#39; represents a tag attached to RDS instance.</value>
        [DataMember(Name="awsType", EmitDefaultValue=true)]
        public AwsTypeEnum? AwsType { get; set; }
        /// <summary>
        /// Specifies the subscription type of AWS such as &#39;kAWSCommercial&#39; or &#39;kAWSGovCloud&#39;. Specifies the subscription type of an AWS source entity. &#39;kAWSCommercial&#39; indicates a standard AWS subscription. &#39;kAWSGovCloud&#39; indicates a govt AWS subscription.
        /// </summary>
        /// <value>Specifies the subscription type of AWS such as &#39;kAWSCommercial&#39; or &#39;kAWSGovCloud&#39;. Specifies the subscription type of an AWS source entity. &#39;kAWSCommercial&#39; indicates a standard AWS subscription. &#39;kAWSGovCloud&#39; indicates a govt AWS subscription.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubscriptionTypeEnum
        {
            /// <summary>
            /// Enum KAWSCommercial for value: kAWSCommercial
            /// </summary>
            [EnumMember(Value = "kAWSCommercial")]
            KAWSCommercial = 1,

            /// <summary>
            /// Enum KAWSGovCloud for value: kAWSGovCloud
            /// </summary>
            [EnumMember(Value = "kAWSGovCloud")]
            KAWSGovCloud = 2

        }

        /// <summary>
        /// Specifies the subscription type of AWS such as &#39;kAWSCommercial&#39; or &#39;kAWSGovCloud&#39;. Specifies the subscription type of an AWS source entity. &#39;kAWSCommercial&#39; indicates a standard AWS subscription. &#39;kAWSGovCloud&#39; indicates a govt AWS subscription.
        /// </summary>
        /// <value>Specifies the subscription type of AWS such as &#39;kAWSCommercial&#39; or &#39;kAWSGovCloud&#39;. Specifies the subscription type of an AWS source entity. &#39;kAWSCommercial&#39; indicates a standard AWS subscription. &#39;kAWSGovCloud&#39; indicates a govt AWS subscription.</value>
        [DataMember(Name="subscriptionType", EmitDefaultValue=true)]
        public SubscriptionTypeEnum? SubscriptionType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsCredentials" /> class.
        /// </summary>
        /// <param name="accessKey">Specifies Access key of the AWS account..</param>
        /// <param name="amazonResourceName">Specifies Amazon Resource Name (owner ID) of the IAM user, act as an unique identifier of as AWS entity..</param>
        /// <param name="awsType">Specifies the entity type such as &#39;kIAMUser&#39; if the environment is kAWS. Specifies the type of an AWS source entity. &#39;kIAMUser&#39; indicates a unique user within an AWS account. &#39;kRegion&#39; indicates a geographical region in the global infrastructure. &#39;kAvailabilityZone&#39; indicates an availability zone within a region. &#39;kEC2Instance&#39; indicates a Virtual Machine running in AWS environment. &#39;kVPC&#39; indicates a virtual private cloud (VPC) network within AWS. &#39;kSubnet&#39; indicates a subnet inside the VPC. &#39;kNetworkSecurityGroup&#39; represents a network security group. &#39;kInstanceType&#39; represents various machine types. &#39;kKeyPair&#39; represents a pair of public and private key used to login into a Virtual Machine. &#39;kTag&#39; represents a tag attached to EC2 instance. &#39;kRDSOptionGroup&#39; represents a RDS option group for configuring database features. &#39;kRDSParameterGroup&#39; represents a RDS parameter group. &#39;kRDSInstance&#39; represents a RDS DB instance. &#39;kRDSSubnet&#39; represents a RDS subnet. &#39;kRDSTag&#39; represents a tag attached to RDS instance..</param>
        /// <param name="secretAccessKey">Specifies Secret Access key of the AWS account..</param>
        /// <param name="subscriptionType">Specifies the subscription type of AWS such as &#39;kAWSCommercial&#39; or &#39;kAWSGovCloud&#39;. Specifies the subscription type of an AWS source entity. &#39;kAWSCommercial&#39; indicates a standard AWS subscription. &#39;kAWSGovCloud&#39; indicates a govt AWS subscription..</param>
        public AwsCredentials(string accessKey = default(string), string amazonResourceName = default(string), AwsTypeEnum? awsType = default(AwsTypeEnum?), string secretAccessKey = default(string), SubscriptionTypeEnum? subscriptionType = default(SubscriptionTypeEnum?))
        {
            this.AccessKey = accessKey;
            this.AmazonResourceName = amazonResourceName;
            this.AwsType = awsType;
            this.SecretAccessKey = secretAccessKey;
            this.SubscriptionType = subscriptionType;
            this.AccessKey = accessKey;
            this.AmazonResourceName = amazonResourceName;
            this.AwsType = awsType;
            this.SecretAccessKey = secretAccessKey;
            this.SubscriptionType = subscriptionType;
        }
        
        /// <summary>
        /// Specifies Access key of the AWS account.
        /// </summary>
        /// <value>Specifies Access key of the AWS account.</value>
        [DataMember(Name="accessKey", EmitDefaultValue=true)]
        public string AccessKey { get; set; }

        /// <summary>
        /// Specifies Amazon Resource Name (owner ID) of the IAM user, act as an unique identifier of as AWS entity.
        /// </summary>
        /// <value>Specifies Amazon Resource Name (owner ID) of the IAM user, act as an unique identifier of as AWS entity.</value>
        [DataMember(Name="amazonResourceName", EmitDefaultValue=true)]
        public string AmazonResourceName { get; set; }

        /// <summary>
        /// Specifies Secret Access key of the AWS account.
        /// </summary>
        /// <value>Specifies Secret Access key of the AWS account.</value>
        [DataMember(Name="secretAccessKey", EmitDefaultValue=true)]
        public string SecretAccessKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString() { return ToJson(); }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AwsCredentials);
        }

        /// <summary>
        /// Returns true if AwsCredentials instances are equal
        /// </summary>
        /// <param name="input">Instance of AwsCredentials to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AwsCredentials input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccessKey == input.AccessKey ||
                    (this.AccessKey != null &&
                    this.AccessKey.Equals(input.AccessKey))
                ) && 
                (
                    this.AmazonResourceName == input.AmazonResourceName ||
                    (this.AmazonResourceName != null &&
                    this.AmazonResourceName.Equals(input.AmazonResourceName))
                ) && 
                (
                    this.AwsType == input.AwsType ||
                    this.AwsType.Equals(input.AwsType)
                ) && 
                (
                    this.SecretAccessKey == input.SecretAccessKey ||
                    (this.SecretAccessKey != null &&
                    this.SecretAccessKey.Equals(input.SecretAccessKey))
                ) && 
                (
                    this.SubscriptionType == input.SubscriptionType ||
                    this.SubscriptionType.Equals(input.SubscriptionType)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AccessKey != null)
                    hashCode = hashCode * 59 + this.AccessKey.GetHashCode();
                if (this.AmazonResourceName != null)
                    hashCode = hashCode * 59 + this.AmazonResourceName.GetHashCode();
                hashCode = hashCode * 59 + this.AwsType.GetHashCode();
                if (this.SecretAccessKey != null)
                    hashCode = hashCode * 59 + this.SecretAccessKey.GetHashCode();
                hashCode = hashCode * 59 + this.SubscriptionType.GetHashCode();
                return hashCode;
            }
        }

    }

}

