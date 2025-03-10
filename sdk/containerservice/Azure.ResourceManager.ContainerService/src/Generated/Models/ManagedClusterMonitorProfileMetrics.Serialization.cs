// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterMonitorProfileMetrics : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("enabled"u8);
            writer.WriteBooleanValue(IsEnabled);
            if (Optional.IsDefined(KubeStateMetrics))
            {
                writer.WritePropertyName("kubeStateMetrics"u8);
                writer.WriteObjectValue(KubeStateMetrics);
            }
            writer.WriteEndObject();
        }

        internal static ManagedClusterMonitorProfileMetrics DeserializeManagedClusterMonitorProfileMetrics(JsonElement element)
        {
            bool enabled = default;
            Optional<ManagedClusterMonitorProfileKubeStateMetrics> kubeStateMetrics = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("kubeStateMetrics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    kubeStateMetrics = ManagedClusterMonitorProfileKubeStateMetrics.DeserializeManagedClusterMonitorProfileKubeStateMetrics(property.Value);
                    continue;
                }
            }
            return new ManagedClusterMonitorProfileMetrics(enabled, kubeStateMetrics.Value);
        }
    }
}
