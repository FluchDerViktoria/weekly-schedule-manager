using FluchDerVika.Wpf.Essentials;
using FluchDerVika.WeeklySchedule.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluchDerVika.WeeklySchedule.Client.Model
{
  public class StickyNote : NotifyObject
  {
    #region Properties

    public int ID
    {
      get => GetProperty<int>();
      set => SetProperty(value);
    }

    public string Name
    {
      get => GetProperty<string>();
      set => SetProperty(value);
    }

    public DateTime Date
    {
      get => GetProperty<DateTime>();
      set => SetProperty(value);
    }

    #region Frontend-Only

    /// <summary>
    /// Warning: Property should only be set by <see cref="SharedData.SelectedNote"/>.
    /// </summary>
    public bool IsSelected
    {
      get => GetProperty<bool>();
      set => SetProperty(value);
    }

    #endregion Frontend-Only

    #endregion Properties
    public StickyNote() 
    { 
    }
  }
}
