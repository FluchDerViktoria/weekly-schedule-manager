using FluchDerVika.WeeklySchedule.Client.Model;
using FluchDerVika.Wpf.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluchDerVika.WeeklySchedule.Client.ViewModel
{
  public class MainViewModel : NotifyObject
  {
    #region Properties

    public ObservableCollection<StickyNote> StickyNotes
    {
      get => GetProperty<ObservableCollection<StickyNote>>();
      set => SetProperty(value);
    }

    #endregion Properties
    public MainViewModel()
    {
      StickyNotes = new ObservableCollection<StickyNote>();
      FillTestData();
    }

    #region DEBUG

    public void FillTestData()
    {
      // TODO
    }

    #endregion DEBUG
  }
}
