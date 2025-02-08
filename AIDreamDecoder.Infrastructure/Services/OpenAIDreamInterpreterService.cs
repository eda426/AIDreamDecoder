using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.Managers;
using OpenAI.Interfaces;
using AIDreamDecoder.Domain.Enums;

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

        public async Task<string> InterpretDreamAsync(string dreamDescription, InterpretationType InterpretationType)
        {
            try
            {
                string systemMessage = InterpretationType switch
                {
                    InterpretationType.Freud => @"You are a skilled dream interpreter using Freudian psychology. 
                Analyze dreams with a focus on unconscious desires, childhood experiences, and symbolic meanings. 
                Provide interpretations that explore hidden emotions and psychological conflicts.",

                    InterpretationType.Jung => @"You are a skilled dream interpreter using Jungian psychology. 
                Analyze dreams with a focus on archetypes, collective unconscious, and personal growth. 
                Provide interpretations that explore the dreamer's journey towards self-realization.",

                    InterpretationType.Aristoteles => @"You are a skilled dream interpreter using Aristotelian philosophy. 
                Analyze dreams with a focus on logic, reason, and the nature of reality. 
                Provide interpretations that explore the dream's connection to the dreamer's waking life.",

                    InterpretationType.Descartes => @"You are a skilled dream interpreter using Cartesian philosophy. 
                Analyze dreams with a focus on the mind-body duality and the nature of existence. 
                Provide interpretations that explore the dream's connection to the dreamer's consciousness.",

                    InterpretationType.Islami => @"You are a skilled dream interpreter using Islamic teachings. 
                Analyze dreams with a focus on spiritual meanings, divine messages, and prophetic visions. 
                Provide interpretations that align with Islamic principles and provide guidance.",

                    _ => throw new ArgumentOutOfRangeException(nameof(InterpretationType), "Invalid interpretation approach.")
                };
                var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                       ChatMessage.FromSystem(systemMessage), // Yaklaşıma özel sistem mesajı
                       ChatMessage.FromUser($"Please interpret this dream: {dreamDescription}") // Kullanıcı mesajı
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