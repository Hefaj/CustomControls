using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CustomControls.Annotations;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private List<Person> _persons;

        public List<Person> Persons
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }
        
        private List<Person> _selected;

        public List<Person> Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Persons = new List<Person>
            {
                new Person{ID = 1, Name = "Rafał", Kod = "A1"},
                new Person{ID = 2, Name = "Aleksandra", Kod = "B1"},
                new Person{ID = 3, Name = "Kacper", Kod = "D1"}
            };
            
            Selected = new List<Person>
            {
                new Person{ID = 5, Name = "Artur", Kod = "Ar5"},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var a = Selected;
        }
    }
}