using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml;
using System.Runtime.InteropServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebviewMinimal.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();


    static internal void WindowCreated(Microsoft.UI.Xaml.Window window)
    {
        Microsoft.UI.Windowing.AppWindow appWindow = window.GetAppWindow();
        IWindow iWindow = window.GetWindow();
        Microsoft.Maui.Controls.Window controlsWindow = (Microsoft.Maui.Controls.Window) iWindow;

        Microsoft.Maui.MauiWinUIWindow mainWindow = (Microsoft.Maui.MauiWinUIWindow)window;
 

        string iconFile = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "train.png");

        System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(iconFile);

        int experiment = 1;

        if (experiment == 0)
        {
            mainWindow.ExtendsContentIntoTitleBar = true;

            // We see Japanese in the title
            controlsWindow.Title = "Hello こんにちは World Test";
            // no effect
            // mainWindow.Title = "Hello こんにちは World Test";
            // no effect
            SendMessage(mainWindow.WindowHandle, WM.WM_SETICON, (System.IntPtr)0, bmp.GetHicon());
        }
        else if (experiment == 1)
        {
            mainWindow.ExtendsContentIntoTitleBar = false;
            // We see ??? for the Japanese in the title
            mainWindow.Title = "Hello こんにちは World Test";
            // no difference from the above if controlsWindow.Title is set instead
            // controlsWindow.Title = "Hello こんにちは World Test";
            // sets the icon as expected
            SendMessage(mainWindow.WindowHandle, WM.WM_SETICON, (System.IntPtr)0, bmp.GetHicon());
        }
        else if (experiment == 2)
        {
            mainWindow.ExtendsContentIntoTitleBar = true;
            // no effect
            SetWindowText(mainWindow.WindowHandle, "Hello こんにちは World Test");
        }
        else if (experiment == 3)
        {
            mainWindow.ExtendsContentIntoTitleBar = false;
            // sets title, but, see ??? for Japanese
            SetWindowText(mainWindow.WindowHandle, "Hello こんにちは World Test");
        }
    }

    enum WM : uint
    {
        WM_SETICON = 0x0080,
        WM_SETTEXT = 0x000C
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    static extern bool SetWindowText(IntPtr hWnd, string text);
}

