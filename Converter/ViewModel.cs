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
        private RelayCommand _ConvertCommand;
        private string _inputValue;
        private string _outputValue;
        private double _num;

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
            _ConvertCommand = new RelayCommand(ConvertFromCtoF);
            OutputValue = _num.ToString();
        }

        public ICommand Command => _ConvertCommand;

        public void ConvertFromCtoF(object o)
        {
            double.TryParse(InputValue, out double num);
            OutputValue = model.CtoF(num).ToString();
        }
    }
}
