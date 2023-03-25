using FluchDerVika.WeeklySchedule.Client.Extention;
using FluchDerVika.WeeklySchedule.Client.Model;
using FluchDerVika.WeeklySchedule.Client.Service;
using FluchDerVika.Wpf.Essentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace FluchDerVika.WeeklySchedule.Client.ViewModel
{
  public class DayViewModel : NotifyObject
  {
    #region Properties

    private CollectionViewSource _collectionViewSource;
    public SharedData SharedData
    { 
      get => GetProperty<SharedData>();
      set => SetProperty(value);
    }

    public DayOfWeek DayOfWeek
    {
      get => GetProperty<DayOfWeek>();
      set => SetProperty(value);
    }

    public ICollectionView StickyNotesView
    {
      get => _collectionViewSource.View;
    }


    #endregion Properties
    public DayViewModel(SharedData sharedData, DayOfWeek dayOfWeek)
    {
      SharedData = sharedData;
      DayOfWeek = dayOfWeek;

      _collectionViewSource = new CollectionViewSource();
      _collectionViewSource.Source = SharedData.StickyNotes;
      _collectionViewSource.Filter += CollectionViewSource_Filter;

      InitCommands();

    }

    private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
    {
      StickyNote stickyNote = e.Item as StickyNote;
      if (stickyNote == null)
      {
        e.Accepted = false;
        return;
      }

      e.Accepted = stickyNote.Date.GetStartOfWeek() == SharedData.SelectedWeek.GetStartOfWeek()
            && stickyNote.Date.DayOfWeek == DayOfWeek;
    }

    #region Commands

    private void InitCommands()
    {
      SelectStickyNoteCommand = new RelayCommand(SelectStickyNote);
    }

    public ICommand SelectStickyNoteCommand { get; set; }

    public void SelectStickyNote(object obj)
    {
      StickyNote note = obj as StickyNote;
      if (note == null)
        return;

      SharedData.SelectedNote = note;
    }

    #endregion Commands
  }
}