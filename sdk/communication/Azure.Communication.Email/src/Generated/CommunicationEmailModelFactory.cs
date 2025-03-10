// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Communication.Email.Models;

namespace Azure.Communication.Email
{
    /// <summary> Model factory for models. </summary>
    public static partial class CommunicationEmailModelFactory
    {
        /// <summary> Initializes a new instance of SendStatusResult. </summary>
        /// <param name="messageId"> System generated id of an email message sent. </param>
        /// <param name="status"> The type indicating the status of a request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="messageId"/> is null. </exception>
        /// <returns> A new <see cref="Models.SendStatusResult"/> instance for mocking. </returns>
        public static SendStatusResult SendStatusResult(string messageId = null, SendStatus status = default)
        {
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            return new SendStatusResult(messageId, status);
        }
    }
}
