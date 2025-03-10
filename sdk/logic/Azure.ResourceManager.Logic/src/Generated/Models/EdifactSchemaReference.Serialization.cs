// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Logic.Models
{
    public partial class EdifactSchemaReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("messageId"u8);
            writer.WriteStringValue(MessageId);
            writer.WritePropertyName("messageVersion"u8);
            writer.WriteStringValue(MessageVersion);
            writer.WritePropertyName("messageRelease"u8);
            writer.WriteStringValue(MessageRelease);
            if (Optional.IsDefined(SenderApplicationId))
            {
                writer.WritePropertyName("senderApplicationId"u8);
                writer.WriteStringValue(SenderApplicationId);
            }
            if (Optional.IsDefined(SenderApplicationQualifier))
            {
                writer.WritePropertyName("senderApplicationQualifier"u8);
                writer.WriteStringValue(SenderApplicationQualifier);
            }
            if (Optional.IsDefined(AssociationAssignedCode))
            {
                writer.WritePropertyName("associationAssignedCode"u8);
                writer.WriteStringValue(AssociationAssignedCode);
            }
            writer.WritePropertyName("schemaName"u8);
            writer.WriteStringValue(SchemaName);
            writer.WriteEndObject();
        }

        internal static EdifactSchemaReference DeserializeEdifactSchemaReference(JsonElement element)
        {
            string messageId = default;
            string messageVersion = default;
            string messageRelease = default;
            Optional<string> senderApplicationId = default;
            Optional<string> senderApplicationQualifier = default;
            Optional<string> associationAssignedCode = default;
            string schemaName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("messageId"u8))
                {
                    messageId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("messageVersion"u8))
                {
                    messageVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("messageRelease"u8))
                {
                    messageRelease = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("senderApplicationId"u8))
                {
                    senderApplicationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("senderApplicationQualifier"u8))
                {
                    senderApplicationQualifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("associationAssignedCode"u8))
                {
                    associationAssignedCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("schemaName"u8))
                {
                    schemaName = property.Value.GetString();
                    continue;
                }
            }
            return new EdifactSchemaReference(messageId, messageVersion, messageRelease, senderApplicationId.Value, senderApplicationQualifier.Value, associationAssignedCode.Value, schemaName);
        }
    }
}
