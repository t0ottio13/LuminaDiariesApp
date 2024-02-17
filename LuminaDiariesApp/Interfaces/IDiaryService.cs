using LuminaDiariesApp.Models;

namespace LuminaDiariesApp.Interfaces;

public interface IDiaryService
{
    /// <summary>
    /// Get diaries
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<IEnumerable<Diary>> GetDiariesAsync(long userId);

    /// <summary>
    /// Add a diary
    /// </summary>
    /// <param name="diary"></param>
    /// <returns></returns>
    public Task<Diary> AddDiaryAsync(Diary diary);
}
