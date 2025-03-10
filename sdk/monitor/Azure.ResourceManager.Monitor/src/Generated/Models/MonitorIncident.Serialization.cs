// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class MonitorIncident
    {
        internal static MonitorIncident DeserializeMonitorIncident(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> ruleName = default;
            Optional<bool> isActive = default;
            Optional<DateTimeOffset> activatedTime = default;
            Optional<DateTimeOffset> resolvedTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ruleName"u8))
                {
                    ruleName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isActive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isActive = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("activatedTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    activatedTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("resolvedTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    resolvedTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new MonitorIncident(name.Value, ruleName.Value, Optional.ToNullable(isActive), Optional.ToNullable(activatedTime), Optional.ToNullable(resolvedTime));
        }
    }
}
