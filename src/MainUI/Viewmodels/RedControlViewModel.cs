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
    public class RedControlViewModel : INotifyPropertyChanged
    {

        private int _number = 0;
        public int Number { get { return _number; } set { _number = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number))); } }

        private RedControlView _view;

        public event PropertyChangedEventHandler PropertyChanged;

        public RedControlViewModel()
        {
			
        }

        public void Initialize(RedControlView v)
        {
			_view = v;
        }

    }
}
