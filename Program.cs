using BannerChurch.CheckInApp.Modules.Basic;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

internal static class Program
{
	public static Login LoginForm;

	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		ThemeResolutionService.LoadPackageResource("BannerChurch.CheckInApp.App_Themes.Office2010Silver_Compass.tssp");
		ThemeResolutionService.ApplicationThemeName = "Office2010Silver_Compass";
		LoginForm = new Login();
		Application.Run(LoginForm);
	}
}
