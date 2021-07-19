using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls.custom
{
    public partial class MagicBox : UserControl
    {
        public static readonly DependencyProperty ItemSoruceProperty =
            DependencyProperty.Register(nameof(ItemSoruce), typeof(IList), typeof(MagicBox));
        
        public IList ItemSoruce
        {
            get => (IList)GetValue(ItemSoruceProperty);
            set => SetValue(ItemSoruceProperty, value);
        }
        
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(nameof(DisplayMemberPath), typeof(string),
                typeof(MagicBox), new UIPropertyMetadata("Name"));
        
        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }
        
        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register(nameof(SelectedValuePath), typeof(string),
                typeof(MagicBox), new UIPropertyMetadata("ID"));
        
        public string SelectedValuePath
        {
            get => (string)GetValue(SelectedValuePathProperty);
            set => SetValue(SelectedValuePathProperty, value);
        }
        
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), 
                typeof(MagicBox), new UIPropertyMetadata(string.Empty));
        
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly DependencyProperty ButtonAllProperty =
            DependencyProperty.Register(nameof(ButtonAll), typeof(bool), 
                typeof(MagicBox), new UIPropertyMetadata(false));
        
        public bool ButtonAll
        {
            get => (bool)GetValue(ButtonAllProperty);
            set => SetValue(ButtonAllProperty, value);
        }
        
        public MagicBox()
        {
            InitializeComponent();
        }
        
        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _listBox.UnselectAll();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            _listBox.SelectAll();
        }
    }
}