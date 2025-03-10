// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Synapse.Models
{
    internal partial class SynapseDataSourceResourceSkuListResult
    {
        internal static SynapseDataSourceResourceSkuListResult DeserializeSynapseDataSourceResourceSkuListResult(JsonElement element)
        {
            Optional<IReadOnlyList<SynapseDataSourceResourceSku>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SynapseDataSourceResourceSku> array = new List<SynapseDataSourceResourceSku>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SynapseDataSourceResourceSku.DeserializeSynapseDataSourceResourceSku(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new SynapseDataSourceResourceSkuListResult(Optional.ToList(value));
        }
    }
}
