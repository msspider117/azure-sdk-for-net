// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.MediaComposition
{
    public partial class TeamsMeetingInput : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("teamsJoinUrl"u8);
            writer.WriteStringValue(TeamsJoinUrl);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            if (Optional.IsDefined(PlaceholderImageUri))
            {
                writer.WritePropertyName("placeholderImageUri"u8);
                writer.WriteStringValue(PlaceholderImageUri);
            }
            writer.WriteEndObject();
        }

        internal static TeamsMeetingInput DeserializeTeamsMeetingInput(JsonElement element)
        {
            string teamsJoinUrl = default;
            MediaInputType kind = default;
            Optional<string> placeholderImageUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("teamsJoinUrl"u8))
                {
                    teamsJoinUrl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = new MediaInputType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("placeholderImageUri"u8))
                {
                    placeholderImageUri = property.Value.GetString();
                    continue;
                }
            }
            return new TeamsMeetingInput(kind, placeholderImageUri.Value, teamsJoinUrl);
        }
    }
}
