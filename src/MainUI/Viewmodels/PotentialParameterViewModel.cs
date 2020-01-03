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
    public class PotentialParameterViewModel : INotifyPropertyChanged
    {

        private Type _type;
        public Type Type
        {
            get { return _type; }
            set
            {
                _type = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
            }
        }

        private string _propertyName;
        public string PropertyName
        {
            get { return _propertyName; }
            set
            {
                _propertyName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PropertyName)));
            }
        }

        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }


        private object _defaultValue;
        public object DefaultValue
        {
            get { return _defaultValue; }
            set
            {
                _defaultValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DefaultValue)));
            }
        }

		private PotentialParameterView _view;

        public event PropertyChangedEventHandler PropertyChanged;

        public PotentialParameterViewModel()
        {
			
        }

        public void Initialize(PotentialParameterView v)
        {
			_view = v;
        }

		

    }
}
