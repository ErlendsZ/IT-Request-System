using ITSupportSystem.Interfaces;
using ITSupportSystem.Models;
using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ITSupportSystem.Logic
{
    /// <summary>
    /// Logic for AI analysis handling.
    /// </summary>
    public class AiAnalysisLogic : IAiAnalysisLogic
    {
        /// <summary>
        ///  Creates AI response based on support request.
        /// </summary>
        /// <param name="supportRequest">IT support request data used for AI response creation.</param>
        private async Task<(string Title, string Type)> CreateAiResponseAsync(ITSupport supportRequest)
        {
            var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("llama3.2:1b", "http://localhost:11434");
            builder.Services.AddScoped<HttpClient>();

            var kernel = builder.Build();

            // TODO: put promt in seperate file.
            string prompt = $@"
                    You are an IT support assistant.

                    Your task is to generate a short title for the request and correctly determine its type based on the user's input.

                    Determine the request type using the following rules:
                    - If the description indicates an error, malfunction, or unexpected behavior in a software system or application, classify as ""Bug"".
                    - If the user suggests a feature request, a usability improvement, or system enhancement, classify as ""Improvement"".
                    - If the user is asking for help, instructions, or clarification about using an IT system, classify as ""Consultation"".
                    - If the request is primarily about **hardware (e.g., printers, monitors, cables, office equipment)**, **network wiring**, **environmental conditions**, or **anything not clearly part of an information system**, classify as:
                      ""The request does not relate to an information system.""

                    IMPORTANT:
                    - If you are **less than 70% confident** that this is a bug, improvement, or consultation *related to an information system*, then classify it as **Not Related**.
                    - Use caution when requests mention devices like **printers**, **scanners**, **cables**, or **power issues** — these are usually hardware problems, not system bugs.
                    - Uncertain or generic descriptions treat as **Not Related** unless there is a clear link to a software or digital system.

                    Input:
                    Description: {supportRequest.Description}
                    Steps: {supportRequest.ReproductionSteps}
                    ExpectedResult: {supportRequest.ExpectedResult}

                    IMPORTANT: Respond strictly in JSON format with no extra characters or explanation:
                    {{ ""title"": ""...a short title..."", ""type"": ""Bug | Improvement | Consultation | Not Related to any information system"" }}
                    ";
           
            var response = await kernel.InvokePromptAsync(prompt);

            //To be sure it is always json format and avoid random halucinations, check inputs from "{" to "}" .s
            var jsonDoc = JsonDocument.Parse(response.ToString().Substring(response.ToString().IndexOf('{'), response.ToString().LastIndexOf('}') - response.ToString().IndexOf('{') + 1));
            var root = jsonDoc.RootElement;

            string title = root.GetProperty("title").GetString() ?? "Unknown title";
            string type = root.GetProperty("type").GetString() ?? "Unknown title";

            return (title, type);
        }

        /// <summary>
        /// Get AI response using user request data.
        /// </summary>
        /// <param name="supportRequest">IT support request data used for AI response creation.</param>
        public async Task<AIResponse> GetAIResponseAsync(ITSupport supportRequest)
        {
            var (title, type) = await CreateAiResponseAsync(supportRequest);

            return new AIResponse
            {
                ItSupportId = supportRequest.ItSupportRequestId,
                UserId = supportRequest.UserId,
                GeneratedRequestTitle = title,
                GeneratedRequestType = type,
            };
        }
    }
}
