// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService
{
    public partial class PublishingUserData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Kind))
            {
                writer.WritePropertyName("kind"u8);
                writer.WriteStringValue(Kind);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(PublishingUserName))
            {
                writer.WritePropertyName("publishingUserName"u8);
                writer.WriteStringValue(PublishingUserName);
            }
            if (Optional.IsDefined(PublishingPassword))
            {
                writer.WritePropertyName("publishingPassword"u8);
                writer.WriteStringValue(PublishingPassword);
            }
            if (Optional.IsDefined(PublishingPasswordHash))
            {
                writer.WritePropertyName("publishingPasswordHash"u8);
                writer.WriteStringValue(PublishingPasswordHash);
            }
            if (Optional.IsDefined(PublishingPasswordHashSalt))
            {
                writer.WritePropertyName("publishingPasswordHashSalt"u8);
                writer.WriteStringValue(PublishingPasswordHashSalt);
            }
            if (Optional.IsDefined(ScmUri))
            {
                writer.WritePropertyName("scmUri"u8);
                writer.WriteStringValue(ScmUri.AbsoluteUri);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static PublishingUserData DeserializePublishingUserData(JsonElement element)
        {
            Optional<string> kind = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> publishingUserName = default;
            Optional<string> publishingPassword = default;
            Optional<string> publishingPasswordHash = default;
            Optional<string> publishingPasswordHashSalt = default;
            Optional<Uri> scmUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("publishingUserName"u8))
                        {
                            publishingUserName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("publishingPassword"u8))
                        {
                            publishingPassword = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("publishingPasswordHash"u8))
                        {
                            publishingPasswordHash = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("publishingPasswordHashSalt"u8))
                        {
                            publishingPasswordHashSalt = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("scmUri"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                scmUri = null;
                                continue;
                            }
                            scmUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PublishingUserData(id, name, type, systemData.Value, publishingUserName.Value, publishingPassword.Value, publishingPasswordHash.Value, publishingPasswordHashSalt.Value, scmUri.Value, kind.Value);
        }
    }
}
