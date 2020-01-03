using MainUI.Controls;
using MainUI.Models;
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
    public class PotentialControlViewModel : INotifyPropertyChanged
    {

        private bool _isInstantiated = false;
        public bool IsInstantiated { get { return _isInstantiated; } set { _isInstantiated = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsInstantiated))); UpdatedIsInstantiated(value); } }

        private FrameworkElement _element = null;
        public FrameworkElement Element { get { return _element; } set { _element = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Element))); UpdatedElement(value); } }


        private Type _type = null;
        public Type Type { get { return _type; } set { _type = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type))); UpdatedType(value); } }


        private PotentialControlView _view;

        public event PropertyChangedEventHandler PropertyChanged;

        public PotentialControlViewModel()
        {

        }

        public void Initialize(PotentialControlView v)
        {
            _view = v;
        }



        public void UpdatedType(Type type)
        {

        }


        public void UpdatedElement(FrameworkElement element)
        {

        }

        public void UpdatedIsInstantiated(bool isInstantiated)
        {
            if (isInstantiated && Element != null)
            {
                var instance = GetNewInstance();
                _view.MainGrid.Children.Add((FrameworkElement)instance);
            }
            else
            {
                _view.MainGrid.Children.Clear();
            }
        }

        public object GetNewInstance()
        {
            var instance = Activator.CreateInstance(Type);
            foreach (var item in _view.Parameters)
            {
                var value = item.Value;
                if (value == null)
                {
                    if (item.DefaultValue != null)
                    {
                        value = item.DefaultValue;
                    }
                    else
                    {
                        object obj = item.Type.IsValueType
                            ? Activator.CreateInstance(item.Type)
                            : null;
                        value = obj;
                    }
                }
                var properties = Type.GetProperties();
                foreach (var property in properties)
                {
                    if (property.Name == item.Path)
                    {
                        property.SetValue(instance, value);
                    }
                }
            }
            return instance;
        }
    }
}
