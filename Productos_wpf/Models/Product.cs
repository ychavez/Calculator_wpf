using System.ComponentModel;

namespace Productos_wpf.Models
{
    public class Product : INotifyPropertyChanged
    {
        int _Id;
        string _Name;
        string _Category;
        string _Description;
        decimal _Price;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string Category
        {
            get { return _Category; }
            set { _Category = value; OnPropertyChanged(nameof(Category)); }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; OnPropertyChanged(nameof(Price)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
