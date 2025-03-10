// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AutoHealTriggers : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Requests))
            {
                writer.WritePropertyName("requests"u8);
                writer.WriteObjectValue(Requests);
            }
            if (Optional.IsDefined(PrivateBytesInKB))
            {
                writer.WritePropertyName("privateBytesInKB"u8);
                writer.WriteNumberValue(PrivateBytesInKB.Value);
            }
            if (Optional.IsCollectionDefined(StatusCodes))
            {
                writer.WritePropertyName("statusCodes"u8);
                writer.WriteStartArray();
                foreach (var item in StatusCodes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(SlowRequests))
            {
                writer.WritePropertyName("slowRequests"u8);
                writer.WriteObjectValue(SlowRequests);
            }
            if (Optional.IsCollectionDefined(SlowRequestsWithPath))
            {
                writer.WritePropertyName("slowRequestsWithPath"u8);
                writer.WriteStartArray();
                foreach (var item in SlowRequestsWithPath)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(StatusCodesRange))
            {
                writer.WritePropertyName("statusCodesRange"u8);
                writer.WriteStartArray();
                foreach (var item in StatusCodesRange)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static AutoHealTriggers DeserializeAutoHealTriggers(JsonElement element)
        {
            Optional<RequestsBasedTrigger> requests = default;
            Optional<int> privateBytesInKB = default;
            Optional<IList<StatusCodesBasedTrigger>> statusCodes = default;
            Optional<SlowRequestsBasedTrigger> slowRequests = default;
            Optional<IList<SlowRequestsBasedTrigger>> slowRequestsWithPath = default;
            Optional<IList<StatusCodesRangeBasedTrigger>> statusCodesRange = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requests"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    requests = RequestsBasedTrigger.DeserializeRequestsBasedTrigger(property.Value);
                    continue;
                }
                if (property.NameEquals("privateBytesInKB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    privateBytesInKB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("statusCodes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<StatusCodesBasedTrigger> array = new List<StatusCodesBasedTrigger>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StatusCodesBasedTrigger.DeserializeStatusCodesBasedTrigger(item));
                    }
                    statusCodes = array;
                    continue;
                }
                if (property.NameEquals("slowRequests"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    slowRequests = SlowRequestsBasedTrigger.DeserializeSlowRequestsBasedTrigger(property.Value);
                    continue;
                }
                if (property.NameEquals("slowRequestsWithPath"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SlowRequestsBasedTrigger> array = new List<SlowRequestsBasedTrigger>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SlowRequestsBasedTrigger.DeserializeSlowRequestsBasedTrigger(item));
                    }
                    slowRequestsWithPath = array;
                    continue;
                }
                if (property.NameEquals("statusCodesRange"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<StatusCodesRangeBasedTrigger> array = new List<StatusCodesRangeBasedTrigger>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StatusCodesRangeBasedTrigger.DeserializeStatusCodesRangeBasedTrigger(item));
                    }
                    statusCodesRange = array;
                    continue;
                }
            }
            return new AutoHealTriggers(requests.Value, Optional.ToNullable(privateBytesInKB), Optional.ToList(statusCodes), slowRequests.Value, Optional.ToList(slowRequestsWithPath), Optional.ToList(statusCodesRange));
        }
    }
}
