// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    internal partial class DistributionPolicyCollection
    {
        internal static DistributionPolicyCollection DeserializeDistributionPolicyCollection(JsonElement element)
        {
            IReadOnlyList<DistributionPolicyItem> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<DistributionPolicyItem> array = new List<DistributionPolicyItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DistributionPolicyItem.DeserializeDistributionPolicyItem(item));
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
            return new DistributionPolicyCollection(value, nextLink.Value);
        }
    }
}
