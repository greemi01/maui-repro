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

}
