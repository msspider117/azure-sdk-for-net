// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CassandraCertificate : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Pem))
            {
                writer.WritePropertyName("pem"u8);
                writer.WriteStringValue(Pem);
            }
            writer.WriteEndObject();
        }

        internal static CassandraCertificate DeserializeCassandraCertificate(JsonElement element)
        {
            Optional<string> pem = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("pem"u8))
                {
                    pem = property.Value.GetString();
                    continue;
                }
            }
            return new CassandraCertificate(pem.Value);
        }
    }
}
