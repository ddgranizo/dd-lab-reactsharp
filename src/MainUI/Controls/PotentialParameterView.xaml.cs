
using MainUI.Viewmodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainUI.Controls
{

    public partial class PotentialParameterView : UserControl
    {

        public Type Type
        {
            get
            {
                return (Type)GetValue(TypeProperty);
            }
            set
            {
                SetValue(TypeProperty, value);
            }
        }

        public string PropertyName
        {
            get
            {
                return (string)GetValue(PropertyNameProperty);
            }
            set
            {
                SetValue(PropertyNameProperty, value);
            }
        }

        public object Value
        {
            get
            {
                return (object)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public object DefaultValue
        {
            get
            {
                return (object)GetValue(DefaultValueProperty);
            }
            set
            {
                SetValue(DefaultValueProperty, value);
            }
        }

		public static readonly DependencyProperty TypeProperty =
                      DependencyProperty.Register(
                          nameof(Type),
                          typeof(Type),
                          typeof(PotentialParameterView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = true,
                          });


		public static readonly DependencyProperty PropertyNameProperty =
                      DependencyProperty.Register(
                          nameof(PropertyName),
                          typeof(string),
                          typeof(PotentialParameterView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = true,
                          });


		public static readonly DependencyProperty ValueProperty =
                      DependencyProperty.Register(
                          nameof(Value),
                          typeof(object),
                          typeof(PotentialParameterView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = true,
                          });


		public static readonly DependencyProperty DefaultValueProperty =
                      DependencyProperty.Register(
                          nameof(DefaultValue),
                          typeof(object),
                          typeof(PotentialParameterView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = true,
                          });

		private readonly PotentialParameterViewModel _viewModel = null;

        public PotentialParameterView()
        {
            InitializeComponent();
			_viewModel = Resources["ViewModel"] as PotentialParameterViewModel;
			_viewModel.Initialize(this);
        }

        private static void OnPropsValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
			PotentialParameterView v = d as PotentialParameterView;
			if (e.Property.Name == nameof(Type))
            {
                v.SetType((Type)e.NewValue);
            }
			else if (e.Property.Name == nameof(PropertyName))
            {
                v.SetPropertyName((string)e.NewValue);
            }
			else if (e.Property.Name == nameof(Value))
            {
                v.SetValue((object)e.NewValue);
            }
			else if (e.Property.Name == nameof(DefaultValue))
            {
                v.SetDefaultValue((object)e.NewValue);
            }
        }


		private void SetType(Type data)
        {
            _viewModel.Type = data;
        }


		private void SetPropertyName(string data)
        {
            _viewModel.PropertyName = data;
        }


		private void SetValue(object data)
        {
            _viewModel.Value = data;
        }


		private void SetDefaultValue(object data)
        {
            _viewModel.DefaultValue = data;
        }


		
    }
}
