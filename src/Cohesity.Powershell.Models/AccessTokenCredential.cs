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
    /// Specifies the Cohesity credentials required for generating an access token.
    /// </summary>
    [DataContract]
    public partial class AccessTokenCredential :  IEquatable<AccessTokenCredential>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenCredential" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccessTokenCredential() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenCredential" /> class.
        /// </summary>
        /// <param name="domain">Specifies the domain the user is logging in to. For a Local user model, the domain is always LOCAL. For LDAP/AD user models, the domain will map to an LDAP connection string. A user is uniquely identified by a combination of username and domain. If this is not set, LOCAL is assumed..</param>
        /// <param name="password">Specifies the password of the Cohesity user account. (required).</param>
        /// <param name="username">Specifies the login name of the Cohesity user. (required).</param>
        public AccessTokenCredential(string domain = default(string), string password = default(string), string username = default(string))
        {
            this.Domain = domain;
            this.Password = password;
            this.Username = username;
            this.Domain = domain;
        }
        
        /// <summary>
        /// Specifies the domain the user is logging in to. For a Local user model, the domain is always LOCAL. For LDAP/AD user models, the domain will map to an LDAP connection string. A user is uniquely identified by a combination of username and domain. If this is not set, LOCAL is assumed.
        /// </summary>
        /// <value>Specifies the domain the user is logging in to. For a Local user model, the domain is always LOCAL. For LDAP/AD user models, the domain will map to an LDAP connection string. A user is uniquely identified by a combination of username and domain. If this is not set, LOCAL is assumed.</value>
        [DataMember(Name="domain", EmitDefaultValue=true)]
        public string Domain { get; set; }

        /// <summary>
        /// Specifies the password of the Cohesity user account.
        /// </summary>
        /// <value>Specifies the password of the Cohesity user account.</value>
        [DataMember(Name="password", EmitDefaultValue=true)]
        public string Password { get; set; }

        /// <summary>
        /// Specifies the login name of the Cohesity user.
        /// </summary>
        /// <value>Specifies the login name of the Cohesity user.</value>
        [DataMember(Name="username", EmitDefaultValue=true)]
        public string Username { get; set; }

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
            return this.Equals(input as AccessTokenCredential);
        }

        /// <summary>
        /// Returns true if AccessTokenCredential instances are equal
        /// </summary>
        /// <param name="input">Instance of AccessTokenCredential to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccessTokenCredential input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Domain == input.Domain ||
                    (this.Domain != null &&
                    this.Domain.Equals(input.Domain))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
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
                if (this.Domain != null)
                    hashCode = hashCode * 59 + this.Domain.GetHashCode();
                if (this.Password != null)
                    hashCode = hashCode * 59 + this.Password.GetHashCode();
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
                return hashCode;
            }
        }

    }

}

