using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.Managers;
using OpenAI.Interfaces;

namespace AIDreamDecoder.Infrastructure.Services
{
    public class OpenAIDreamInterpreterService : IAIDreamInterpreterService
    {
        private readonly IOpenAIService _openAiService;
        private readonly OpenAISettings _settings;

        public OpenAIDreamInterpreterService(IOpenAIService openAiService, IOptions<OpenAISettings> settings)
        {
            _openAiService = openAiService;
            _settings = settings.Value;
        }

        public async Task<string> InterpretDreamAsync(string dreamDescription)
        {
            try
            {
                var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                        ChatMessage.FromSystem(@"You are a skilled dream interpreter. 
                            Analyze dreams with psychological insight, cultural awareness, 
                            and sensitivity. Provide interpretations that are thoughtful, 
                            supportive, and non-judgmental. Consider multiple possible 
                            meanings and their psychological significance."),
                        ChatMessage.FromUser($"Please interpret this dream: {dreamDescription}")
                    },
                    Model = Models.Gpt_4,
                    MaxTokens = _settings.MaxTokens,
                    Temperature = _settings.Temperature
                });

                if (completionResult.Successful)
                {
                    return completionResult.Choices.First().Message.Content;
                }

                throw new ApplicationException($"API Error: {completionResult.Error?.Message}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to interpret dream", ex);
            }
        }
    }
}