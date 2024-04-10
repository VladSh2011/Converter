using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WpfApp2;
using System.Windows.Input;

namespace Converter
{
    class ViewModel : BaseVM
    {
        private Model model;
        private RelayCommand _convertCommand;
        private string _inputValue;
        private string _outputValue;
        private double _num;
        public IReadOnlyCollection<TemperatureUnit> Units { get; set; }
        public TemperatureUnit SelectedUnit1 { get; set; }
        public TemperatureUnit SelectedUnit2 { get; set; }

        public string InputValue
        {
            get => _inputValue;
            set
            {
                _inputValue = value;
                OnPropertyChanged(nameof(InputValue));
            }
        }
        public string OutputValue
        {
            get => _outputValue;
            set
            {
                _outputValue = value;
                OnPropertyChanged(nameof(OutputValue));
            }
        }

        public ViewModel()
        {
            model = new Model();
            _convertCommand = new RelayCommand(Convert);
            OutputValue = _num.ToString();
            Units = new List<TemperatureUnit>(Enum.GetValues(typeof(TemperatureUnit)) as TemperatureUnit[]);
        }

        public ICommand ConvertCommand => _convertCommand;

        public void Convert(object o)
        {
            if (SelectedUnit1 == SelectedUnit2)
            {
                OutputValue = InputValue;
                return;
            }
            if (SelectedUnit1 == TemperatureUnit.Celsius)
            {
                if (SelectedUnit2 == TemperatureUnit.Fahrenheit)
                {
                    double.TryParse(InputValue, out _num);
                    OutputValue = model.CtoF(_num).ToString();
                }
                else if (SelectedUnit2 == TemperatureUnit.Kelvin)
                {
                    double.TryParse(InputValue, out _num);
                    OutputValue = model.CtoK(_num).ToString();
                }
            }
            if (SelectedUnit1 == TemperatureUnit.Fahrenheit)
            {
                if(SelectedUnit2 == TemperatureUnit.Celsius)
                {
                    double.TryParse(InputValue, out _num);
                    OutputValue = model.FtoC(_num).ToString();
                }
                else if(SelectedUnit2 == TemperatureUnit.Kelvin)
                {
                    double.TryParse(InputValue, out _num);
                    OutputValue = model.FtoK(_num).ToString();
                }
            }
            if(SelectedUnit1 == TemperatureUnit.Kelvin)
            {
                if(SelectedUnit2 == TemperatureUnit.Celsius)
                {
                    double.TryParse(InputValue, out _num);
                    OutputValue = model.KtoC(_num).ToString();
                }
                else if (SelectedUnit2 == TemperatureUnit.Fahrenheit)
                {
                    double.TryParse(InputValue, out _num);
                    OutputValue = model.KtoF(_num).ToString();
                }
            }
        }
    }
}
