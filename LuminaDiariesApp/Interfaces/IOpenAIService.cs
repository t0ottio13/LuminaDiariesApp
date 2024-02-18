namespace LuminaDiariesApp.Interfaces;

public interface IOpenAIService
{
    public Task<string> GetCommentAsync(string diaryContent);
}
