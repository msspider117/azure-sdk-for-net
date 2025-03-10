# Azure Cognitive Language Services Conversations client library for .NET

Conversational Language Understanding - aka CLU for short - is a cloud-based conversational AI service which provides many language understanding capabilities like:

- Conversation App: It's used in extracting intents and entities in conversations
- Workflow app: Acts like an orchestrator to select the best candidate to analyze conversations to get best response from apps like Qna, Luis, and Conversation App

[Source code][conversationanalysis_client_src] | [Package (NuGet)][conversationanalysis_nuget_package] | [API reference documentation][conversationanalysis_refdocs] | [Samples][conversationanalysis_samples] | [Product documentation][conversationanalysis_docs] | [Analysis REST API documentation][conversationanalysis_restdocs] | [Authoring REST API documentation][conversationanalysis_restdocs_authoring]

## Getting started

### Install the package

Install the Azure Cognitive Language Services Conversations client library for .NET with [NuGet][nuget]:

```powershell
dotnet add package Azure.AI.Language.Conversations
```

### Prerequisites

- An [Azure subscription][azure_subscription]
- An existing Azure Language Service Resource

Though you can use this SDK to create and import conversation projects, [Language Studio][language_studio] is the preferred method for creating projects.

### Authenticate the client

In order to interact with the Conversations service, you'll need to create an instance of the [`ConversationAnalysisClient`][conversationanalysis_client_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Cognitive Services resource in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] command shown below to get the API key from the Cognitive Service resource.

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Namespaces

Start by importing the namespace for the [`ConversationAnalysisClient`][conversationanalysis_client_class] and related class:

```C# Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.AI.Language.Conversations;
```

#### Create a ConversationAnalysisClient

Once you've determined your **endpoint** and **API key** you can instantiate a `ConversationAnalysisClient`:

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

#### Create a ConversationAuthoringClient

To use the `ConversationAuthoringClient`, use the following namespace in addition to those above, if needed.

```C# Snippet:ConversationAuthoringClient_Namespace
using Azure.AI.Language.Conversations.Authoring;
```

With your **endpoint** and **API key**, you can instantiate a `ConversationAuthoringClient`:

```C# Snippet:ConversationAuthoringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAuthoringClient client = new ConversationAuthoringClient(endpoint, credential);
```

#### Create a client using Azure Active Directory authentication

You can also create a `ConversationAnalysisClient` or `ConversationAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Conversation_Identity_Namespace
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:ConversationAnalysisClient_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

## Key concepts

### ConversationAnalysisClient

The [`ConversationAnalysisClient`][conversationanalysis_client_class] is the primary interface for making predictions using your deployed Conversations models. It provides both synchronous and asynchronous APIs to submit queries.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The Azure.AI.Language.Conversations client library provides both synchronous and asynchronous APIs.

The following examples show common scenarios using the `client` [created above](#create-a-conversationanalysisclient).

### Analyze a conversation

To analyze a conversation, you can call the `AnalyzeConversation()` method:

```C# Snippet:ConversationAnalysis_AnalyzeConversation
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Send an email to Carol about tomorrow's demo",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

Console.WriteLine($"Top intent: {conversationPrediction.GetProperty("topIntent").GetString()}");

Console.WriteLine("Intents:");
foreach (JsonElement intent in conversationPrediction.GetProperty("intents").EnumerateArray())
{
    Console.WriteLine($"Category: {intent.GetProperty("category").GetString()}");
    Console.WriteLine($"Confidence: {intent.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();
}

Console.WriteLine("Entities:");
foreach (JsonElement entity in conversationPrediction.GetProperty("entities").EnumerateArray())
{
    Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
    Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
    Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
    Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
    Console.WriteLine($"Confidence: {entity.GetProperty("confidenceScore").GetSingle()}");
    Console.WriteLine();

    if (entity.TryGetProperty("resolutions", out JsonElement resolutions))
    {
        foreach (JsonElement resolution in resolutions.EnumerateArray())
        {
            if (resolution.GetProperty("resolutionKind").GetString() == "DateTimeResolution")
            {
                Console.WriteLine($"Datetime Sub Kind: {resolution.GetProperty("dateTimeSubKind").GetString()}");
                Console.WriteLine($"Timex: {resolution.GetProperty("timex").GetString()}");
                Console.WriteLine($"Value: {resolution.GetProperty("value").GetString()}");
                Console.WriteLine();
            }
        }
    }
}
```

Additional options can be passed to `AnalyzeConversation` like enabling more verbose output:

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithOptions
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Send an email to Carol about tomorrow's demo",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,
        verbose = true,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));
```

### Analyze a conversation in a different language

The `language` property can be set to specify the language of the conversation:

```C# Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage
string projectName = "Menu";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "Enviar un email a Carol acerca de la presentación de mañana",
            language = "es",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,
        verbose = true,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));
```

### Analyze a conversation using an orchestration project

To analyze a conversation using an orchestration project, you can call the `AnalyzeConversation()` method just like the conversation project.


```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPrediction
string projectName = "DomainOrchestrator";
string deploymentName = "production";

var data = new
{
    analysisInput = new
    {
        conversationItem = new
        {
            text = "How are you?",
            id = "1",
            participantId = "1",
        }
    },
    parameters = new
    {
        projectName,
        deploymentName,

        // Use Utf16CodeUnit for strings in .NET.
        stringIndexType = "Utf16CodeUnit",
    },
    kind = "Conversation",
};

Response response = client.AnalyzeConversation(RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(response.ContentStream);
JsonElement conversationalTaskResult = result.RootElement;
JsonElement orchestrationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");
```

#### Question Answering prediction

If your conversation was analyzed by Question Answering, it will include an intent - perhaps even the top intent - from which you can retrieve answers:

```C# Snippet:ConversationAnalysis_AnalyzeConversationOrchestrationPredictionQnA
string respondingProjectName = orchestrationPrediction.GetProperty("topIntent").GetString();
JsonElement targetIntentResult = orchestrationPrediction.GetProperty("intents").GetProperty(respondingProjectName);

if (targetIntentResult.GetProperty("targetProjectKind").GetString() == "QuestionAnswering")
{
    Console.WriteLine($"Top intent: {respondingProjectName}");

    JsonElement questionAnsweringResponse = targetIntentResult.GetProperty("result");
    Console.WriteLine($"Question Answering Response:");
    foreach (JsonElement answer in questionAnsweringResponse.GetProperty("answers").EnumerateArray())
    {
        Console.WriteLine(answer.GetProperty("answer").GetString());
    }
}
```

#### Conversational summarization

To summarize a conversation, you can use the `AnalyzeConversation` method overload that returns an `Operation<BinaryData>`:

```C# Snippet:AnalyzeConversation_ConversationSummarization
var data = new
{
    analysisInput = new
    {
        conversations = new[]
        {
            new
            {
                conversationItems = new[]
                {
                    new
                    {
                        text = "Hello, how can I help you?",
                        id = "1",
                        role = "Agent",
                        participantId = "Agent_1",
                    },
                    new
                    {
                        text = "How to upgrade Office? I am getting error messages the whole day.",
                        id = "2",
                        role = "Customer",
                        participantId = "Customer_1",
                    },
                    new
                    {
                        text = "Press the upgrade button please. Then sign in and follow the instructions.",
                        id = "3",
                        role = "Agent",
                        participantId = "Agent_1",
                    },
                },
                id = "1",
                language = "en",
                modality = "text",
            },
        }
    },
    tasks = new[]
    {
        new
        {
            taskName = "Issue task",
            kind = "ConversationalSummarizationTask",
            parameters = new
            {
                summaryAspects = new[]
                {
                    "issue",
                }
            },
        },
        new
        {
            taskName = "Resolution task",
            kind = "ConversationalSummarizationTask",
            parameters = new
            {
                summaryAspects = new[]
                {
                    "resolution",
                }
            },
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    Console.WriteLine($"Task name: {task.GetProperty("taskName").GetString()}");
    JsonElement results = task.GetProperty("results");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Summaries:");
        foreach (JsonElement summary in conversation.GetProperty("summaries").EnumerateArray())
        {
            Console.WriteLine($"Text: {summary.GetProperty("text").GetString()}");
            Console.WriteLine($"Aspect: {summary.GetProperty("aspect").GetString()}");
        }
        Console.WriteLine();
    }
}
```

#### Conversational PII

To extract and redact personally-identifiable information (PII) from text, you can use the `AnalyzeConversation` method overload that returns an `Operation<BinaryData>`:

```C# Snippet:AnalyzeConversation_ConversationPII_Text
var data = new
{
    analysisInput = new
    {
        conversations = new[]
        {
            new
            {
                conversationItems = new[]
                {
                    new
                    {
                        text = "Hi, I am John Doe.",
                        id = "1",
                        participantId = "0",
                    },
                    new
                    {
                        text = "Hi John, how are you doing today?",
                        id = "2",
                        participantId = "1",
                    },
                    new
                    {
                        text = "Pretty good.",
                        id = "3",
                        participantId = "0",
                    },
                },
                id = "1",
                language = "en",
                modality = "text",
            },
        }
    },
    tasks = new[]
    {
        new
        {
            parameters = new
            {
                piiCategories = new[]
                {
                    "All",
                },
                includeAudioRedaction = false,
                modelVersion = "2022-05-15-preview",
                loggingOptOut = false,
            },
            kind = "ConversationalPIITask",
            taskName = "analyze",
        },
    },
};

Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
JsonElement jobResults = result.RootElement;
foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
{
    JsonElement results = task.GetProperty("results");

    Console.WriteLine("Conversations:");
    foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
    {
        Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
        Console.WriteLine("Conversation Items:");
        foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
        {
            Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");

            Console.WriteLine($"Redacted Text: {conversationItem.GetProperty("redactedContent").GetProperty("text").GetString()}");

            Console.WriteLine("Entities:");
            foreach (JsonElement entity in conversationItem.GetProperty("entities").EnumerateArray())
            {
                Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                Console.WriteLine($"Confidence Score: {entity.GetProperty("confidenceScore").GetSingle()}");
                Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
```

### Additional samples

Browser our [samples][conversationanalysis_samples] for more examples of how to analyze conversations.

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a utterance to a non-existant project, a `400` error is returned indicating "Bad Request".

```C# Snippet:ConversationAnalysisClient_BadRequest
try
{
    var data = new
    {
        analysisInput = new
        {
            conversationItem = new
            {
                text = "Send an email to Carol about tomorrow's demo",
                id = "1",
                participantId = "1",
            }
        },
        parameters = new
        {
            projectName = "invalid-project",
            deploymentName = "production",

            // Use Utf16CodeUnit for strings in .NET.
            stringIndexType = "Utf16CodeUnit",
        },
        kind = "Conversation",
    };

    Response response = client.AnalyzeConversation(RequestContent.Create(data));
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```text
Azure.RequestFailedException: The input parameter is invalid.
Status: 400 (Bad Request)
ErrorCode: InvalidArgument

Content:
{
  "error": {
    "code": "InvalidArgument",
    "message": "The input parameter is invalid.",
    "innerError": {
      "code": "InvalidArgument",
      "message": "The input parameter \"payload\" cannot be null or empty."
    }
  }
}

Headers:
Transfer-Encoding: chunked
pragma: no-cache
request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
apim-request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
x-envoy-upstream-service-time: 15
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
x-content-type-options: nosniff
Cache-Control: no-store, proxy-revalidate, no-cache, max-age=0, private
Content-Type: application/json
```

### Setting up console logging

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console use the `AzureEventSourceListener.CreateConsoleLogger` method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][core_logging].

## Next steps

- View our [samples][conversationanalysis_samples].
- Read about the different [features][conversationanalysis_docs_features] of the Conversations service.
- Try our service [demos][conversationanalysis_docs_demos].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure/
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[azure_identity_install]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package
[azure_portal]: https://portal.azure.com/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[core_logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[custom_domain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[language_studio]: https://language.cognitive.azure.com/
[nuget]: https://www.nuget.org/

[conversationanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/ConversationAnalysisClient.cs
[conversationanalysis_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/
[conversationanalysis_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/
[conversationanalysis_nuget_package]: https://www.nuget.org/packages/Azure.AI.Language.Conversations/
[conversationanalysis_docs]: https://docs.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/overview
[conversationanalysis_docs_demos]: https://docs.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/quickstart
[conversationanalysis_docs_features]: https://docs.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/overview
[conversationanalysis_refdocs]: https://docs.microsoft.com/dotnet/api/azure.ai.language.conversations
[conversationanalysis_restdocs]: https://learn.microsoft.com/rest/api/language/2022-10-01-preview/conversation-analysis-runtime
[conversationanalysis_restdocs_authoring]: https://learn.microsoft.com/rest/api/language/2022-10-01-preview/conversational-analysis-authoring
