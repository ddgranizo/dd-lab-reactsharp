using MainUI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;


namespace MainUI.Viewmodels
{
    public class BlueControlViewModel : INotifyPropertyChanged
    {

        private int _number = 0;
		public int Number { get { return _number; } set { _number = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number))); } }


        private string _pepeName = "";
        public string PepeName { get { return _pepeName; } set { _pepeName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PepeName))); } }



        private BlueControlView _view;

        public event PropertyChangedEventHandler PropertyChanged;

        public BlueControlViewModel()
        {
			
        }

        public void Initialize(BlueControlView v)
        {
			_view = v;
        }

		
        
    }
}
