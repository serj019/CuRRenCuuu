using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp14
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        double _firstValue;
        double _secondValue;
        string _firstAbb;
        string _secondAbb;
        JsonToValuteAdapter adapter;

        ObservableCollection<string> _abbreviation; 


        public ViewModel()
        {
            adapter = new JsonToValuteAdapter();
            adapter.Convert(Connector.JsonText);
            _abbreviation = new ObservableCollection<string>();
            foreach (string val in adapter.Valutes.Keys)
            {


                Abbreviation.Add(val);
            }
            
            _firstAbb = _abbreviation[0];
            _secondAbb = _abbreviation[0];

            FirstValue = 0;
            SecondValue = 0;
        }

        public double FirstValue
        {

            get { return _firstValue; }
            set
            {
                _firstValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstValue"));
                _secondValue = ConverterValute.Convert(adapter.Valutes[_firstAbb], adapter.Valutes[_secondAbb]);
                _secondValue *= _firstValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondValue"));
            }
        }
        public double SecondValue
        {

            get { return _secondValue; }
            set
            {
                _secondValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondValue"));
                _firstValue = ConverterValute.Convert(adapter.Valutes[_secondAbb],adapter.Valutes[_firstAbb]);
                _firstValue *= _secondValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstValue"));
            }

        }

    

        public string FirstAbb
        {

            get { return _firstAbb; }
            set
            {
                _firstAbb = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstAbb"));
                FirstValue = _firstValue;
            }

        }
        public string SecondAbb
        {

            get { return _secondAbb; }
            set
            {
                _secondAbb = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondAbb"));
                SecondValue = _secondValue;
            }

        }

        public ObservableCollection<string> Abbreviation
        {

            get { return _abbreviation; }
            set
            {
                _abbreviation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Abbreviation"));
            }

        }

    }
}
