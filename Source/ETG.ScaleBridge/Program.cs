using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Win32;

namespace ETG.ScaleBridge;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        if (Mutex.TryOpenExisting("ETG.ScaleBridge", out _) == false)
        {
            _ = new Mutex(true, "ETG.ScaleBridge");
        }
        else
        {
            return;
        }

        SetAutoStart();

        Task.Run(() => StartDeviceRead());
        Task.Run(() => StartWebServer());

        ApplicationConfiguration.Initialize();
        Application.Run(new Tray());
    }

    static void StartWebServer()
    {
        WebHost
            .CreateDefaultBuilder()
            .UseKestrel()
            .Configure(app =>
            {
                app.Run(async (context) => {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync($"{{ \"Status\":\"{Scale.Status}\",\"Weight\":\"{Scale.Weight}\",\"Unit\":\"{Scale.Unit}\" }}");
                });
            })
            .UseUrls("http://localhost:7777")
            .Build()
            .Run();
    }
    static void StartDeviceRead()
    {
        while (true)
        {
            Scale.ReadFromDevice();

            Thread.Sleep(100);
        }
    }

    static void SetAutoStart()
    {
        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"))
        {
            key.SetValue("Scale Bridge", Application.ExecutablePath.ToString());
        }
    }
}