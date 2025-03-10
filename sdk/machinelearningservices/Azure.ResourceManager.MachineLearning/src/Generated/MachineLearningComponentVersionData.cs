// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary> A class representing the MachineLearningComponentVersion data model. </summary>
    public partial class MachineLearningComponentVersionData : ResourceData
    {
        /// <summary> Initializes a new instance of MachineLearningComponentVersionData. </summary>
        /// <param name="properties"> [Required] Additional attributes of the entity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public MachineLearningComponentVersionData(MachineLearningComponentVersionProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }

        /// <summary> Initializes a new instance of MachineLearningComponentVersionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> [Required] Additional attributes of the entity. </param>
        internal MachineLearningComponentVersionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, MachineLearningComponentVersionProperties properties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> [Required] Additional attributes of the entity. </summary>
        public MachineLearningComponentVersionProperties Properties { get; set; }
    }
}
