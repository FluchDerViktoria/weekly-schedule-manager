using FluchDerVika.WeeklySchedule.Client.Extention;
using FluchDerVika.WeeklySchedule.Client.Model;
using FluchDerVika.WeeklySchedule.Client.Service;
using FluchDerVika.Wpf.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluchDerVika.WeeklySchedule.Client.ViewModel
{
  public class MainViewModel : NotifyObject
  {
    #region Properties

    public SharedData SharedData
    {
      get => GetProperty<SharedData>();
      set => SetProperty(value);
    }

    #region Sub ViewModels

    public ObservableCollection<DayViewModel> DayViewModels
    {
      get => GetProperty<ObservableCollection<DayViewModel>>();
      set => SetProperty(value);
    }

    #endregion Sub ViewModels

    
    #endregion Properties
    public MainViewModel()
    {
      SharedData = new SharedData();
      InitDays();
      FillTestData();

      InitCommands();
    }

    #region Init

    private void InitDays()
    {
      DayViewModels = new ObservableCollection<DayViewModel>()
      {
        new DayViewModel(SharedData, DayOfWeek.Monday),
        new DayViewModel(SharedData, DayOfWeek.Tuesday),
        new DayViewModel(SharedData, DayOfWeek.Wednesday),
        new DayViewModel(SharedData, DayOfWeek.Thursday),
        new DayViewModel(SharedData, DayOfWeek.Friday),
        new DayViewModel(SharedData, DayOfWeek.Saturday),
        new DayViewModel(SharedData, DayOfWeek.Sunday)
      };
    }

    #endregion Init

    #region DEBUG

    public void FillTestData()
    {
      // TestData

      DateTime dateTime = DateTime.Now.GetStartOfWeek();

      for(int i = 0; i < 7; i++)
      {
        var amountStickyNotes = Random.Shared.Next(5);

        for(int j = 0; j < amountStickyNotes; j++)
        {
          SharedData.StickyNotes.Add(new StickyNote()
          {
            ID = i * 100 + j,
            Name = $"Note #{Random.Shared.Next()}",
            Date = dateTime
          });
        }

        dateTime = dateTime.AddDays(1);
      }
    }

    #endregion DEBUG

    #region Commands

    public void InitCommands()
    {
      HomeCommand = new RelayCommand(Home);
    }

    #region Home Command

    public ICommand HomeCommand
    {
      get; set;
    }

    // TODO: Currently Debug Function
    public void Home()
    {
      SharedData.StickyNotes.Add(new StickyNote()
      {
        ID = -1,
        Name = "Hi!",
        Date = DateTime.Now
      });
    }


    #endregion Home Command

    #endregion Commands
  }
}
