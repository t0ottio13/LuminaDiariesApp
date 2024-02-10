using LuminaDiariesApp.Components;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddRazorComponents: Razor �R���|�[�l���g�̃T�[�o�[�������_�����O�ɕK�v�ȃT�[�r�X��o�^����
// https://learn.microsoft.com/ja-jp/dotnet/api/microsoft.extensions.dependencyinjection.razorcomponentsservicecollectionextensions.addrazorcomponents?view=aspnetcore-8.0
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // ��O�����~�h���E�F�A
    // �J���җ�O�y�[�W��L���ɂ���
    // �~�h���E�F�A�p�C�v���C���̑����i�K�Ŏ��s�����
    // ����ŗL��
    // �^�p���ł́A��O�������J���Ȃ��悤�ɂ���K�v������
    // https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/error-handling?view=aspnetcore-8.0#developer-exception-page
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // ���ׂĂ̒ʐM��HTTPS�o�R�ŋ�������
    // https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&viewFallbackFrom=aspnetcore-2.1&tabs=visual-studio%2Clinux-ubuntu#http-strict-transport-security-protocol-hsts
    app.UseHsts();
}

// HTTP �v���� HTTPS �Ƀ��_�C���N�g���邽�߂́AHTTPS ���_�C���N�g �~�h���E�F�A
// https://learn.microsoft.com/ja-jp/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&tabs=visual-studio%2Clinux-ubuntu#http-redirection-to-https-causes-err_invalid_redirect-on-the-cors-preflight-request
app.UseHttpsRedirection();

// �ÓI�t�@�C����񋟂ł���悤�ɂ���
// �I�t�ɂ���ƁAcss�Ȃǂ�wwwroot�ɂ���ÓI�t�@�C����񂪊O���
// https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/static-files?view=aspnetcore-8.0#serve-files-in-web-root
app.UseStaticFiles();

// �p�C�v���C���ɋU���h�~�~�h���E�F�A��ǉ�����
// https://learn.microsoft.com/ja-jp/aspnet/core/security/anti-request-forgery?view=aspnetcore-8.0
app.UseAntiforgery();

// App�R���|�[�l���g���}�b�s���O���Ă���
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
