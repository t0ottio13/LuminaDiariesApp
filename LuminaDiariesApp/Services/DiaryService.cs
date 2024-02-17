using LuminaDiariesApp.Interfaces;
using LuminaDiariesApp.Models;
using Microsoft.Azure.CosmosRepository;

namespace LuminaDiariesApp.Services;
public class DiaryService : IDiaryService
{
    readonly IRepository<Diary> _repository;

    public DiaryService(IRepository<Diary> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Get diaries in ascending order
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>diaries</returns>
    public async Task<IEnumerable<Diary>> GetDiariesAsync(long userId)
    {
        var items = await _repository.GetAsync(d => d.userId == userId.ToString());
        // itemsを昇順にする
        items.OrderByDescending(d => d.date).ToList();
        return items;
    }

    /// <summary>
    /// Add a diary
    /// </summary>
    /// <param name="diary">diary information</param>
    /// <returns></returns>
    public async Task<Diary> AddDiaryAsync(Diary diary)
    {
        return await _repository.CreateAsync(diary);
    }
}
