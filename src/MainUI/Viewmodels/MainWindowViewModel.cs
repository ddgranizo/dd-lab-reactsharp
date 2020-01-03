using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MainUI.Viewmodels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<string> _comboOptions = new ObservableCollection<string>();
        public ObservableCollection<string> ComboOptions { get { return _comboOptions; } }

        private string _currentOption = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        private int _counter = 0;
        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBlueVisible)));
                PepeName = PepeName + ".";
            }
        }

        private bool _isRedVisible = false;
        public bool IsRedVisible
        {
            get { return _isRedVisible; }
            set
            {
                _isRedVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRedVisible)));
            }
        }


        private string _pepeName = "test";
        public string PepeName
        {
            get { return _pepeName; }
            set
            {
                _pepeName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PepeName)));
            }
        }

        //private bool _isBlueVisible = false;
        public bool IsBlueVisible
        {
            get { return Counter % 2 == 0; }
            //set
            //{
            //    _isBlueVisible = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBlueVisible)));
            //}
        }

        public string CurrentOption
        {
            get { return _currentOption; }
            set
            {
                _currentOption = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentOption)));

                IsRedVisible = false;
                //IsBlueVisible = false;
                //if (value == "Red")
                //{
                //    IsRedVisible = true;
                //}
                //else if (value == "Blue")
                //{
                //    IsBlueVisible = true;
                //}
                //else if (value == "Both")
                //{
                //    IsRedVisible = true;
                //    IsBlueVisible = true;
                //}
            }
        }

        public MainWindowViewModel()
        {
            ComboOptions.Add("Red");
            ComboOptions.Add("Blue");
            ComboOptions.Add("Both");


            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }


        private MainWindow _view;
        public void Initialize(MainWindow view)
        {
            _view = view;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Counter++;
        }

        
    }
}
