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
    /// Specifies the meta-data associated with entity such as the list of attributes and time series data.
    /// </summary>
    [DataContract]
    public partial class EntitySchemaProto :  IEquatable<EntitySchemaProto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySchemaProto" /> class.
        /// </summary>
        /// <param name="attributesDescriptor">attributesDescriptor.</param>
        /// <param name="flushIntervalSecs">Defines the interval used to flush in memory stats to scribe table. During this time if the stats server is down before flushing, it could loose some of the stats. Modules can flush any critical stats via AddEntitiesStats API. But this  should be used very judiciously as it causes lot of overhead for stats..</param>
        /// <param name="isInternalSchema">Specifies if this schema should be displayed in Advanced Diagnostics of the Cohesity Dashboard. If false, the schema is displayed..</param>
        /// <param name="largestFlushIntervalSecs">Use can change the flush interval secs via gflag and this store the largest interval seconds set. This is used to round up the timestamp to this flush interval secs during range scan..</param>
        /// <param name="name">Specifies a name that uniquely identifies an entity schema such as &#39;kBridgeClusterStats&#39;..</param>
        /// <param name="schemaDescriptiveName">Specifies the name of the Schema as displayed in Advanced Diagnostics of the Cohesity Dashboard. For example for the &#39;kBridgeClusterStats&#39; Schema, the descriptive name is &#39;Cluster Physical Stats&#39;..</param>
        /// <param name="schemaHelpText">Specifies an optional informational description about the schema..</param>
        /// <param name="timeSeriesDescriptorVec">Array of Time Series.  List of time series of data (set of data points) for metrics..</param>
        /// <param name="version">Specifies the version of the entity schema..</param>
        public EntitySchemaProto(EntitySchemaProtoAttributesDescriptor attributesDescriptor = default(EntitySchemaProtoAttributesDescriptor), int? flushIntervalSecs = default(int?), bool? isInternalSchema = default(bool?), int? largestFlushIntervalSecs = default(int?), string name = default(string), string schemaDescriptiveName = default(string), string schemaHelpText = default(string), List<EntitySchemaProtoTimeSeriesDescriptor> timeSeriesDescriptorVec = default(List<EntitySchemaProtoTimeSeriesDescriptor>), long? version = default(long?))
        {
            this.FlushIntervalSecs = flushIntervalSecs;
            this.IsInternalSchema = isInternalSchema;
            this.LargestFlushIntervalSecs = largestFlushIntervalSecs;
            this.Name = name;
            this.SchemaDescriptiveName = schemaDescriptiveName;
            this.SchemaHelpText = schemaHelpText;
            this.TimeSeriesDescriptorVec = timeSeriesDescriptorVec;
            this.Version = version;
            this.AttributesDescriptor = attributesDescriptor;
            this.FlushIntervalSecs = flushIntervalSecs;
            this.IsInternalSchema = isInternalSchema;
            this.LargestFlushIntervalSecs = largestFlushIntervalSecs;
            this.Name = name;
            this.SchemaDescriptiveName = schemaDescriptiveName;
            this.SchemaHelpText = schemaHelpText;
            this.TimeSeriesDescriptorVec = timeSeriesDescriptorVec;
            this.Version = version;
        }
        
        /// <summary>
        /// Gets or Sets AttributesDescriptor
        /// </summary>
        [DataMember(Name="attributesDescriptor", EmitDefaultValue=false)]
        public EntitySchemaProtoAttributesDescriptor AttributesDescriptor { get; set; }

        /// <summary>
        /// Defines the interval used to flush in memory stats to scribe table. During this time if the stats server is down before flushing, it could loose some of the stats. Modules can flush any critical stats via AddEntitiesStats API. But this  should be used very judiciously as it causes lot of overhead for stats.
        /// </summary>
        /// <value>Defines the interval used to flush in memory stats to scribe table. During this time if the stats server is down before flushing, it could loose some of the stats. Modules can flush any critical stats via AddEntitiesStats API. But this  should be used very judiciously as it causes lot of overhead for stats.</value>
        [DataMember(Name="flushIntervalSecs", EmitDefaultValue=true)]
        public int? FlushIntervalSecs { get; set; }

        /// <summary>
        /// Specifies if this schema should be displayed in Advanced Diagnostics of the Cohesity Dashboard. If false, the schema is displayed.
        /// </summary>
        /// <value>Specifies if this schema should be displayed in Advanced Diagnostics of the Cohesity Dashboard. If false, the schema is displayed.</value>
        [DataMember(Name="isInternalSchema", EmitDefaultValue=true)]
        public bool? IsInternalSchema { get; set; }

        /// <summary>
        /// Use can change the flush interval secs via gflag and this store the largest interval seconds set. This is used to round up the timestamp to this flush interval secs during range scan.
        /// </summary>
        /// <value>Use can change the flush interval secs via gflag and this store the largest interval seconds set. This is used to round up the timestamp to this flush interval secs during range scan.</value>
        [DataMember(Name="largestFlushIntervalSecs", EmitDefaultValue=true)]
        public int? LargestFlushIntervalSecs { get; set; }

        /// <summary>
        /// Specifies a name that uniquely identifies an entity schema such as &#39;kBridgeClusterStats&#39;.
        /// </summary>
        /// <value>Specifies a name that uniquely identifies an entity schema such as &#39;kBridgeClusterStats&#39;.</value>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the name of the Schema as displayed in Advanced Diagnostics of the Cohesity Dashboard. For example for the &#39;kBridgeClusterStats&#39; Schema, the descriptive name is &#39;Cluster Physical Stats&#39;.
        /// </summary>
        /// <value>Specifies the name of the Schema as displayed in Advanced Diagnostics of the Cohesity Dashboard. For example for the &#39;kBridgeClusterStats&#39; Schema, the descriptive name is &#39;Cluster Physical Stats&#39;.</value>
        [DataMember(Name="schemaDescriptiveName", EmitDefaultValue=true)]
        public string SchemaDescriptiveName { get; set; }

        /// <summary>
        /// Specifies an optional informational description about the schema.
        /// </summary>
        /// <value>Specifies an optional informational description about the schema.</value>
        [DataMember(Name="schemaHelpText", EmitDefaultValue=true)]
        public string SchemaHelpText { get; set; }

        /// <summary>
        /// Array of Time Series.  List of time series of data (set of data points) for metrics.
        /// </summary>
        /// <value>Array of Time Series.  List of time series of data (set of data points) for metrics.</value>
        [DataMember(Name="timeSeriesDescriptorVec", EmitDefaultValue=true)]
        public List<EntitySchemaProtoTimeSeriesDescriptor> TimeSeriesDescriptorVec { get; set; }

        /// <summary>
        /// Specifies the version of the entity schema.
        /// </summary>
        /// <value>Specifies the version of the entity schema.</value>
        [DataMember(Name="version", EmitDefaultValue=true)]
        public long? Version { get; set; }

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
            return this.Equals(input as EntitySchemaProto);
        }

        /// <summary>
        /// Returns true if EntitySchemaProto instances are equal
        /// </summary>
        /// <param name="input">Instance of EntitySchemaProto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntitySchemaProto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AttributesDescriptor == input.AttributesDescriptor ||
                    (this.AttributesDescriptor != null &&
                    this.AttributesDescriptor.Equals(input.AttributesDescriptor))
                ) && 
                (
                    this.FlushIntervalSecs == input.FlushIntervalSecs ||
                    (this.FlushIntervalSecs != null &&
                    this.FlushIntervalSecs.Equals(input.FlushIntervalSecs))
                ) && 
                (
                    this.IsInternalSchema == input.IsInternalSchema ||
                    (this.IsInternalSchema != null &&
                    this.IsInternalSchema.Equals(input.IsInternalSchema))
                ) && 
                (
                    this.LargestFlushIntervalSecs == input.LargestFlushIntervalSecs ||
                    (this.LargestFlushIntervalSecs != null &&
                    this.LargestFlushIntervalSecs.Equals(input.LargestFlushIntervalSecs))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.SchemaDescriptiveName == input.SchemaDescriptiveName ||
                    (this.SchemaDescriptiveName != null &&
                    this.SchemaDescriptiveName.Equals(input.SchemaDescriptiveName))
                ) && 
                (
                    this.SchemaHelpText == input.SchemaHelpText ||
                    (this.SchemaHelpText != null &&
                    this.SchemaHelpText.Equals(input.SchemaHelpText))
                ) && 
                (
                    this.TimeSeriesDescriptorVec == input.TimeSeriesDescriptorVec ||
                    this.TimeSeriesDescriptorVec != null &&
                    input.TimeSeriesDescriptorVec != null &&
                    this.TimeSeriesDescriptorVec.SequenceEqual(input.TimeSeriesDescriptorVec)
                ) && 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
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
                if (this.AttributesDescriptor != null)
                    hashCode = hashCode * 59 + this.AttributesDescriptor.GetHashCode();
                if (this.FlushIntervalSecs != null)
                    hashCode = hashCode * 59 + this.FlushIntervalSecs.GetHashCode();
                if (this.IsInternalSchema != null)
                    hashCode = hashCode * 59 + this.IsInternalSchema.GetHashCode();
                if (this.LargestFlushIntervalSecs != null)
                    hashCode = hashCode * 59 + this.LargestFlushIntervalSecs.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.SchemaDescriptiveName != null)
                    hashCode = hashCode * 59 + this.SchemaDescriptiveName.GetHashCode();
                if (this.SchemaHelpText != null)
                    hashCode = hashCode * 59 + this.SchemaHelpText.GetHashCode();
                if (this.TimeSeriesDescriptorVec != null)
                    hashCode = hashCode * 59 + this.TimeSeriesDescriptorVec.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                return hashCode;
            }
        }

    }

}

