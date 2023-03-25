using FluchDerVika.WeeklySchedule.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FluchDerVika.WeeklySchedule.Client.View
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    // State of Window before Fullscreen
    private WindowState _prevWindowState;


    public bool IsFullscreen
    {
      get => WindowStyle == WindowStyle.None;
    }

    public MainWindow(bool forceFullscreen = false)
    {
      DataContext = new MainViewModel();
      InitializeComponent();

      // Init current state of window
      _prevWindowState = WindowState;

      // Force full screen, if requested
      if (forceFullscreen && !IsFullscreen)
        ToggleFullScreen();
    }


    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.IsRepeat)
        return;

      switch(e.Key)
      {
        case Key.F11:
          ToggleFullScreen();
          break;
      }
    }

    private void ToggleFullScreen()
    {
      if (!IsFullscreen)
      {
        // Save current state of window
        _prevWindowState = WindowState;

        // Set Fullscreen
        WindowStyle = WindowStyle.None;
        ResizeMode = ResizeMode.NoResize;
        WindowState = WindowState.Maximized;
      }
      else
      {
        // Restore Fullscreen
        WindowStyle = WindowStyle.ThreeDBorderWindow;
        ResizeMode = ResizeMode.CanResize;
        WindowState = _prevWindowState;
      }
    }
  }
}
