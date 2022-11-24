using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace WebviewMinimal;

[SupportedOSPlatform("windows")]
public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainContent();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        window.HandlerChanged += Window_HandlerChanged;
        return window;
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


    private void Window_HandlerChanged(object sender, EventArgs e)
    {
        Microsoft.Maui.Controls.Window controlsWindow = (Microsoft.Maui.Controls.Window)sender;
        Microsoft.Maui.MauiWinUIWindow mainWindow = (Microsoft.Maui.MauiWinUIWindow)controlsWindow.Handler.PlatformView;

        string iconFile = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "train.png");

        System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(iconFile);

        int experiment = 1;

        if (experiment == 0)
        {
            mainWindow.ExtendsContentIntoTitleBar = true;

            // We see Japanese in the title
            controlsWindow.Title = "Hello こんにちは World Test";
            // No effect
            SendMessage(mainWindow.WindowHandle, WM.WM_SETICON, (System.IntPtr)0, bmp.GetHicon());
        }
        else if (experiment == 1)
        {
            mainWindow.ExtendsContentIntoTitleBar = false;
            // We see ??? for the Japanese in the title
            mainWindow.Title= "Hello こんにちは World Test";
            // no difference if controlsWindow.Title is set
            // sets the icon as expected
            SendMessage(mainWindow.WindowHandle, WM.WM_SETICON, (System.IntPtr)0, bmp.GetHicon());
        } else if (experiment == 2) {
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
}
