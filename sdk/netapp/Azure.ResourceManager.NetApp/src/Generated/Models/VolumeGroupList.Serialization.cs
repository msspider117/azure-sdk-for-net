// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    internal partial class VolumeGroupList
    {
        internal static VolumeGroupList DeserializeVolumeGroupList(JsonElement element)
        {
            Optional<IReadOnlyList<NetAppVolumeGroupResult>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<NetAppVolumeGroupResult> array = new List<NetAppVolumeGroupResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NetAppVolumeGroupResult.DeserializeNetAppVolumeGroupResult(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new VolumeGroupList(Optional.ToList(value));
        }
    }
}
