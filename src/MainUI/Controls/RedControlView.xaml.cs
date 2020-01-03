
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
    public partial class RedControlView : UserControl
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

		public static readonly DependencyProperty NumberProperty =
                      DependencyProperty.Register(
                          nameof(Number),
                          typeof(int),
                          typeof(RedControlView), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler))
                          {
                              BindsTwoWayByDefault = true,
                          });

		private readonly RedControlViewModel _viewModel = null;

        public RedControlView()
        {
            InitializeComponent();
			_viewModel = Resources["ViewModel"] as RedControlViewModel;
			_viewModel.Initialize(this);
        }

        private static void OnPropsValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
			RedControlView v = d as RedControlView;
			if (e.Property.Name == nameof(Number))
            {
                v.SetNumber((int)e.NewValue);
            }
        }

		private void SetNumber(int data)
        {
            _viewModel.Number = data;
        }
    }
}
