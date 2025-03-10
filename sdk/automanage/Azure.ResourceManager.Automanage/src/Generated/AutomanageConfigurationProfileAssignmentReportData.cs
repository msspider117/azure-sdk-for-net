// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Automanage
{
    /// <summary> A class representing the AutomanageConfigurationProfileAssignmentReport data model. </summary>
    public partial class AutomanageConfigurationProfileAssignmentReportData : ResourceData
    {
        /// <summary> Initializes a new instance of AutomanageConfigurationProfileAssignmentReportData. </summary>
        public AutomanageConfigurationProfileAssignmentReportData()
        {
            Resources = new ChangeTrackingList<ConfigurationProfileAssignmentReportResourceDetails>();
        }

        /// <summary> Initializes a new instance of AutomanageConfigurationProfileAssignmentReportData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="startOn"> Start time of the configuration profile assignment processing. </param>
        /// <param name="endOn"> End time of the configuration profile assignment processing. </param>
        /// <param name="lastModifiedOn"> Last modified time of the configuration profile assignment processing. </param>
        /// <param name="duration"> Duration of the configuration profile assignment processing. </param>
        /// <param name="configurationProfileAssignmentProcessingType"> Type of the configuration profile assignment processing (Initial/Consistency). </param>
        /// <param name="status"> The status of the configuration profile assignment. </param>
        /// <param name="configurationProfile"> The configurationProfile linked to the assignment. </param>
        /// <param name="resources"> List of resources processed by the configuration profile assignment. </param>
        /// <param name="error"> Error message, if any, returned by the configuration profile assignment processing. </param>
        /// <param name="reportFormatVersion"> Version of the report format. </param>
        internal AutomanageConfigurationProfileAssignmentReportData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? startOn, DateTimeOffset? endOn, DateTimeOffset? lastModifiedOn, TimeSpan? duration, string configurationProfileAssignmentProcessingType, string status, string configurationProfile, IReadOnlyList<ConfigurationProfileAssignmentReportResourceDetails> resources, ResponseError error, string reportFormatVersion) : base(id, name, resourceType, systemData)
        {
            StartOn = startOn;
            EndOn = endOn;
            LastModifiedOn = lastModifiedOn;
            Duration = duration;
            ConfigurationProfileAssignmentProcessingType = configurationProfileAssignmentProcessingType;
            Status = status;
            ConfigurationProfile = configurationProfile;
            Resources = resources;
            Error = error;
            ReportFormatVersion = reportFormatVersion;
        }

        /// <summary> Start time of the configuration profile assignment processing. </summary>
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> End time of the configuration profile assignment processing. </summary>
        public DateTimeOffset? EndOn { get; set; }
        /// <summary> Last modified time of the configuration profile assignment processing. </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary> Duration of the configuration profile assignment processing. </summary>
        public TimeSpan? Duration { get; }
        /// <summary> Type of the configuration profile assignment processing (Initial/Consistency). </summary>
        public string ConfigurationProfileAssignmentProcessingType { get; }
        /// <summary> The status of the configuration profile assignment. </summary>
        public string Status { get; }
        /// <summary> The configurationProfile linked to the assignment. </summary>
        public string ConfigurationProfile { get; }
        /// <summary> List of resources processed by the configuration profile assignment. </summary>
        public IReadOnlyList<ConfigurationProfileAssignmentReportResourceDetails> Resources { get; }
        /// <summary> Error message, if any, returned by the configuration profile assignment processing. </summary>
        public ResponseError Error { get; }
        /// <summary> Version of the report format. </summary>
        public string ReportFormatVersion { get; }
    }
}
