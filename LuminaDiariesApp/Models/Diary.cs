namespace LuminaDiariesApp.Models;

/// <summary>
/// 日記
/// </summary>
public class Diary
{
    public Diary(string title, string content , DateTime date)
    {
        this.title = title;
        this.content = content;
        this.date = date;
        id = Guid.NewGuid();
    }

    /// <summary>
    /// Id
    /// </summary>
    public Guid id { get; private set; }

    /// <summary>
    /// タイトル
    /// </summary>
    public string title { get; set; }

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
}
