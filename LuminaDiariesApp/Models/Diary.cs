using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;

namespace LuminaDiariesApp.Models;

/// <summary>
/// 日記
/// </summary>
[PartitionKeyPath("/userId")]
public class Diary : Item
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="userId">ユーザーID</param>
    /// <param name="content">内容</param>
    /// <param name="date">登録日</param>
    public Diary(long userId, string content, DateTime date, string? eulogy)
    {
        this.userId = userId.ToString();
        this.content = content;
        this.date = date;
        this.eulogy = eulogy ?? string.Empty;
    }

    /// <summary>
    /// ユーザーID
    /// </summary>
    public string userId { get; private set; }

    /// <summary>
    /// 日記の内容
    /// </summary>
    public string content { get; set; }

    /// <summary>
    /// AIの褒め言葉
    /// </summary>
    public string? eulogy { get; set; }

    /// <summary>
    /// 日記を書いた日付
    /// </summary>
    public DateTime date { get; set; }

    protected override string GetPartitionKeyValue() => userId;
}
