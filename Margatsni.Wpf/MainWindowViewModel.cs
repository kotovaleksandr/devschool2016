using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Margatsni.Wpf
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly HttpClientWrapper _httpClient = new HttpClientWrapper("http://localhost:60263/");
		private string _userName;
		private string _userId;

		public string UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
				OnPropertyChanged();
			}
		}

		public string UserName
		{
			get { return _userName; }
			set
			{
				_userName = value;
				OnPropertyChanged();
			}
		}

		public ICommand GetUserById
		{
			get
			{
				return new CommandWrapper((o) =>
				{
					UserName = _httpClient.GetUserById(Guid.Parse(UserId)).Name;
				}, o => true);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
