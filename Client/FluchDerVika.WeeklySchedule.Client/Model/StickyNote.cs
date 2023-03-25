using FluchDerVika.Wpf.Essentials;
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

    #endregion Properties
    public StickyNote() 
    { 
    }
  }
}
