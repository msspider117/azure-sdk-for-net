// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecurityConnectorEnvironment : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("environmentType"u8);
            writer.WriteStringValue(EnvironmentType.ToString());
            writer.WriteEndObject();
        }

        internal static SecurityConnectorEnvironment DeserializeSecurityConnectorEnvironment(JsonElement element)
        {
            if (element.TryGetProperty("environmentType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AwsAccount": return AwsEnvironment.DeserializeAwsEnvironment(element);
                    case "AzureDevOpsScope": return AzureDevOpsScopeEnvironment.DeserializeAzureDevOpsScopeEnvironment(element);
                    case "GcpProject": return GcpProjectEnvironment.DeserializeGcpProjectEnvironment(element);
                    case "GithubScope": return GithubScopeEnvironment.DeserializeGithubScopeEnvironment(element);
                }
            }
            return UnknownEnvironmentData.DeserializeUnknownEnvironmentData(element);
        }
    }
}
