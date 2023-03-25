using FluchDerVika.WeeklySchedule.Client.Extention;
using FluchDerVika.WeeklySchedule.Client.Model;
using FluchDerVika.Wpf.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluchDerVika.WeeklySchedule.Client.Service
{
  public class SharedData : NotifyObject
	{
		public ObservableCollection<StickyNote> StickyNotes
		{
			get => GetProperty<ObservableCollection<StickyNote>>();
			set => SetProperty(value);
		}

		/// <summary>
		/// Day in a given week. (Start of week prefered)
		/// </summary>
		public DateTime SelectedWeek
		{
			get => GetProperty<DateTime>();
			set => SetProperty(value);
		}

		public StickyNote SelectedNote
		{
			get => GetProperty<StickyNote>();
			set
			{
				if (SelectedNote != null)
					SelectedNote.IsSelected = false;
				value.IsSelected = true;

				SetProperty(value);
			}
		}

		public SharedData()
		{
			StickyNotes = new();
			SelectedWeek = DateTime.Now.GetStartOfWeek();
		}
	}
}
