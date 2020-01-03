
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

    public partial class BlueControlView : UserControl
    {

        public int Number
        {
            get
            {
                return (int)GetValue(NumberProperty);
            }
            set
            {
                SetValue(NumberProperty, value);
            }
        }

        public string PepeName
        {
            get
            {
                return (string)GetValue(PepeNameProperty);
            }
            set
            {
                SetValue(PepeNameProperty, value);
            }
        }


        public static readonly DependencyProperty PepeNameProperty =
                     DependencyProperty.Register(
                         nameof(PepeName),
                         typeof(string),
                         typeof(BlueControlView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));

        public static readonly DependencyProperty NumberProperty =
                      DependencyProperty.Register(
                          nameof(Number),
                          typeof(int),
                          typeof(BlueControlView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));


        private readonly BlueControlViewModel _viewModel = null;

        public BlueControlView()
        {
            InitializeComponent();
            _viewModel = Resources["ViewModel"] as BlueControlViewModel;
            _viewModel.Initialize(this);
        }


        private static void OnPropsValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BlueControlView v = d as BlueControlView;
            if (e.Property.Name == nameof(Number))
            {
                v.SetNumber((int)e.NewValue);
            }
            else if (e.Property.Name == nameof(PepeName))
            {
                v.SetPepeName((string)e.NewValue);
            }
        }


        private void SetNumber(int data)
        {
            _viewModel.Number = data;
        }



        private void SetPepeName(string data)
        {
            _viewModel.PepeName = data;
        }

    }
}
