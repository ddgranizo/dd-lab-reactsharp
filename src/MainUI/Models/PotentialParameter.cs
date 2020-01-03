using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MainUI.Models
{
    public class PotentialParameter: FrameworkElement
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


        public string Path
        {
            get
            {
                return (string)GetValue(PathProperty);
            }
            set
            {
                SetValue(PathProperty, value);
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
                         typeof(PotentialParameter),
                         new PropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));



        public static readonly DependencyProperty TypeProperty =
                     DependencyProperty.Register(
                         nameof(Type),
                         typeof(Type),
                         typeof(PotentialParameter), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));

       
        public static readonly DependencyProperty DefaultValueProperty =
                      DependencyProperty.Register(
                          nameof(DefaultValue),
                          typeof(object),
                          typeof(PotentialParameter),
                          new PropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));

        public static readonly DependencyProperty PathProperty =
                      DependencyProperty.Register(
                          nameof(Path),
                          typeof(string),
                          typeof(PotentialParameter),
                          new PropertyMetadata(new PropertyChangedCallback(OnPropsValueChangedHandler)));

        public PotentialParameter()
        {
        }

        private static void OnPropsValueChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == nameof(Value))
            {
                var asd = e.NewValue;
            }
        }

    }
}
