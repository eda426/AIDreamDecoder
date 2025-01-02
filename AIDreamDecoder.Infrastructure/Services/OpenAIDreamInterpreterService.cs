using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*using OpenAI_API;
using OpenAI_API.Chat;

namespace AIDreamDecoder.Infrastructure.Services
{
    public class OpenAIDreamInterpreterService : IAIDreamInterpreterService
    {
        private readonly OpenAIAPI _openAiApi;
        private readonly OpenAISettings _settings;

        public OpenAIDreamInterpreterService(IOptions<OpenAISettings> settings)
        {
            _settings = settings.Value;
            _openAiApi = new OpenAIAPI(_settings.ApiKey);
        }

        public async Task<string> InterpretDreamAsync(string dreamDescription)
        {
            try
            {
                var chat = _openAiApi.Chat.CreateConversation();

                // Set the system message to define AI's role
                chat.AppendSystemMessage(@"You are a skilled dream interpreter. 
                    Analyze dreams with psychological insight, cultural awareness, 
                    and sensitivity. Provide interpretations that are thoughtful, 
                    supportive, and non-judgmental. Consider multiple possible 
                    meanings and their psychological significance.");

                // Add the user's dream
                chat.AppendUserInput($"Please interpret this dream: {dreamDescription}");

                // Get the interpretation
                var response = await chat.GetResponseFromChatbotAsync();

                return response;
            }
            catch (Exception ex)
            {
                // Log the error
                throw new ApplicationException("Failed to interpret dream", ex);
            }
        }
    }
}*/