using LuminaDiariesApp.Components;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddRazorComponents: Razor コンポーネントのサーバー側レンダリングに必要なサービスを登録する
// https://learn.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.dependencyinjection.razorcomponentsservicecollectionextensions.addrazorcomponents?view=aspnetcore-8.0
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // 例外処理ミドルウェア
    // 開発者例外ページを有効にする
    // ミドルウェアパイプラインの早い段階で実行される
    // 既定で有効
    // 運用環境では、例外情報を公開しないようにする必要がある
    // https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/error-handling?view=aspnetcore-8.0#developer-exception-page
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // すべての通信をHTTPS経由で強制する
    // https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&viewFallbackFrom=aspnetcore-2.1&tabs=visual-studio%2Clinux-ubuntu#http-strict-transport-security-protocol-hsts
    app.UseHsts();
}

// HTTP 要求を HTTPS にリダイレクトするための、HTTPS リダイレクト ミドルウェア
// https://learn.microsoft.com/ja-jp/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&tabs=visual-studio%2Clinux-ubuntu#http-redirection-to-https-causes-err_invalid_redirect-on-the-cors-preflight-request
app.UseHttpsRedirection();

// 静的ファイルを提供できるようにする
// オフにすると、cssなどがwwwrootにある静的ファイル情報が外れる
// https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/static-files?view=aspnetcore-8.0#serve-files-in-web-root
app.UseStaticFiles();

// パイプラインに偽造防止ミドルウェアを追加する
// https://learn.microsoft.com/ja-jp/aspnet/core/security/anti-request-forgery?view=aspnetcore-8.0
app.UseAntiforgery();

// Appコンポーネントをマッピングしている
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
