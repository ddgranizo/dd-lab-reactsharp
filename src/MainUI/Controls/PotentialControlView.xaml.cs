
using MainUI.Models;
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



    public partial class PotentialControlView : UserControl
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


        public bool IsInstantiated
        {
            get
            {
                return (bool)GetValue(IsInstantiatedProperty);
            }
            set
            {
                SetValue(IsInstantiatedProperty, value);
            }
        }

        public FrameworkElement Element
        {
            get
            {
                return (FrameworkElement)GetValue(ElementProperty);
            }
            set
            {
                SetValue(ElementProperty, value);
            }
        }

        public ObservableCollection<PotentialParameter> Parameters
        {
            get
            {
                return (ObservableCollection<PotentialParameter>)GetValue(ParametersProperty);
            }
            set
            {
                SetValue(ParametersProperty, value);
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

        public static readonly DependencyProperty ValueProperty =
                     DependencyProperty.Register(
                         nameof(Value),
                         typeof(object),
                         typeof(PotentialControlView),
                         new PropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));

        public static readonly DependencyProperty TypeProperty =
                      DependencyProperty.Register(
                          nameof(Type),
                          typeof(Type),
                          typeof(PotentialControlView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));

        public static readonly DependencyProperty IsInstantiatedProperty =
                      DependencyProperty.Register(
                          nameof(IsInstantiated),
                          typeof(bool),
                          typeof(PotentialControlView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = false,
                          });

		public static readonly DependencyProperty ElementProperty =
                      DependencyProperty.Register(
                          nameof(Element),
                          typeof(FrameworkElement),
                          typeof(PotentialControlView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = false,
                          });

		public static readonly DependencyProperty ParametersProperty =
                      DependencyProperty.Register(
                          nameof(Parameters),
                          typeof(ObservableCollection<PotentialParameter>),
                          typeof(PotentialControlView), 
                          new PropertyMetadata(new ObservableCollection<PotentialParameter>(), new PropertyChangedCallback(OnPropsValueChangedHandler)));

		private readonly PotentialControlViewModel _viewModel = null;

        public PotentialControlView()
        {
            InitializeComponent();
			_viewModel = Resources["ViewModel"] as PotentialControlViewModel;
			_viewModel.Initialize(this);
        }

        private static void OnPropsValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
			PotentialControlView v = d as PotentialControlView;
			if (e.Property.Name == nameof(IsInstantiated))
            {
                v.SetIsInstantiated((bool)e.NewValue);
            }
			else if (e.Property.Name == nameof(Element))
            {
                v.SetElement((FrameworkElement)e.NewValue);
            }
            else if (e.Property.Name == nameof(Type))
            {
                v.SetType((Type)e.NewValue);
            }
        }

		private void SetIsInstantiated(bool data)
        {
            _viewModel.IsInstantiated = data;
        }

		private void SetElement(FrameworkElement data)
        {
            _viewModel.Element = data;
        }

        private void SetType(Type data)
        {
            _viewModel.Type = data;
        }

        //private void SetParameters(List<PotentialParameter> data)
        //      {
        //          _viewModel.Parameters = data;
        //      }

    }
}
