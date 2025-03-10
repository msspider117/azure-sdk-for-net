// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Synapse;

namespace Azure.ResourceManager.Synapse.Models
{
    internal partial class SynapseExtendedSqlPoolBlobAuditingPolicyListResult
    {
        internal static SynapseExtendedSqlPoolBlobAuditingPolicyListResult DeserializeSynapseExtendedSqlPoolBlobAuditingPolicyListResult(JsonElement element)
        {
            Optional<IReadOnlyList<SynapseExtendedSqlPoolBlobAuditingPolicyData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SynapseExtendedSqlPoolBlobAuditingPolicyData> array = new List<SynapseExtendedSqlPoolBlobAuditingPolicyData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SynapseExtendedSqlPoolBlobAuditingPolicyData.DeserializeSynapseExtendedSqlPoolBlobAuditingPolicyData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SynapseExtendedSqlPoolBlobAuditingPolicyListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
