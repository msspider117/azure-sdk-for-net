// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.LoadTesting.Models
{
    public partial class LoadTestingEndpointDependency
    {
        internal static LoadTestingEndpointDependency DeserializeLoadTestingEndpointDependency(JsonElement element)
        {
            Optional<string> domainName = default;
            Optional<string> description = default;
            Optional<IReadOnlyList<LoadTestingEndpointDetail>> endpointDetails = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainName"u8))
                {
                    domainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("endpointDetails"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<LoadTestingEndpointDetail> array = new List<LoadTestingEndpointDetail>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(LoadTestingEndpointDetail.DeserializeLoadTestingEndpointDetail(item));
                    }
                    endpointDetails = array;
                    continue;
                }
            }
            return new LoadTestingEndpointDependency(domainName.Value, description.Value, Optional.ToList(endpointDetails));
        }
    }
}
