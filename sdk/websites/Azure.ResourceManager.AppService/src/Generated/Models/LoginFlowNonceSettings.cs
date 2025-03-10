// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> The configuration settings of the nonce used in the login flow. </summary>
    public partial class LoginFlowNonceSettings
    {
        /// <summary> Initializes a new instance of LoginFlowNonceSettings. </summary>
        public LoginFlowNonceSettings()
        {
        }

        /// <summary> Initializes a new instance of LoginFlowNonceSettings. </summary>
        /// <param name="validateNonce"> &lt;code&gt;false&lt;/code&gt; if the nonce should not be validated while completing the login flow; otherwise, &lt;code&gt;true&lt;/code&gt;. </param>
        /// <param name="nonceExpirationInterval"> The time after the request is made when the nonce should expire. </param>
        internal LoginFlowNonceSettings(bool? validateNonce, string nonceExpirationInterval)
        {
            ValidateNonce = validateNonce;
            NonceExpirationInterval = nonceExpirationInterval;
        }

        /// <summary> &lt;code&gt;false&lt;/code&gt; if the nonce should not be validated while completing the login flow; otherwise, &lt;code&gt;true&lt;/code&gt;. </summary>
        public bool? ValidateNonce { get; set; }
        /// <summary> The time after the request is made when the nonce should expire. </summary>
        public string NonceExpirationInterval { get; set; }
    }
}
