// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class RegionalReplicationStatus
    {
        internal static RegionalReplicationStatus DeserializeRegionalReplicationStatus(JsonElement element)
        {
            Optional<string> region = default;
            Optional<RegionalReplicationState> state = default;
            Optional<string> details = default;
            Optional<int> progress = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("region"u8))
                {
                    region = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    state = new RegionalReplicationState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("details"u8))
                {
                    details = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("progress"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    progress = property.Value.GetInt32();
                    continue;
                }
            }
            return new RegionalReplicationStatus(region.Value, Optional.ToNullable(state), details.Value, Optional.ToNullable(progress));
        }
    }
}
