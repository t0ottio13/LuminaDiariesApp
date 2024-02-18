using Azure.AI.OpenAI;
using Azure;
using LuminaDiariesApp.Interfaces;

namespace LuminaDiariesApp.Services;

public class OpenAIService : IOpenAIService
{
    private readonly OpenAIClient _openAIClient;

    public OpenAIService(OpenAIClient openAIClient)
    {
        _openAIClient = openAIClient ?? throw new ArgumentNullException(nameof(openAIClient));
    }

    public async Task<string> GetCommentAsync(string diaryContent)
    {
        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            DeploymentName = "gpt35turbo",
            Messages =
            {
                new ChatRequestSystemMessage("あなたは、ほめ上手なアシスタントです。ユーザーが書いた日記に対してほめてください。言葉遣いは友人に接するようにお願いします。"),
                new ChatRequestUserMessage(diaryContent)
            }
        };

        var response = await _openAIClient.GetChatCompletionsAsync(chatCompletionsOptions);
        var responseMessage = response.Value.Choices[0].Message.Content;

        return responseMessage.ToString() ?? string.Empty;
    }
}
