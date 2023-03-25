using FluchDerVika.WeeklySchedule.Client.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FluchDerVika.WeeklySchedule.Client
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      // Get Settings from command parameters
      bool forceFullscreen = false;

      for(int i = 0; i < e.Args.Length; i++)
      {
        if (e.Args[i] == null)
          continue;
        if (e.Args[i].ToLowerInvariant() == "/forcefullscreen")
          forceFullscreen = true;
      }

      MainWindow = new MainWindow(forceFullscreen);
      MainWindow.Show();
    }
  }
}
