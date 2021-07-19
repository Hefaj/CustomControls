using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
        
        public static readonly DependencyProperty FillterProperty =
            DependencyProperty.Register(nameof(Fillter), typeof(bool), 
                typeof(MagicBox), new UIPropertyMetadata(false));
        
        public bool Fillter
        {
            get => (bool)GetValue(FillterProperty);
            set => SetValue(FillterProperty, value);
        }

        public IList SelectedValues { get; } = new List<object>();
        private CollectionView Widok { get; set; }
        public MagicBox()
        {
            InitializeComponent();
        }

        private bool UserFillter(object obj)
        {
            if (string.IsNullOrEmpty(_searchBox.Text)) return true;
            return ((Person)obj).Name.IndexOf(_searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _listBox.UnselectAll();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            _listBox.SelectAll();
        }

        private void _listBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                SelectedValues.Add(item);
            }
            
            foreach (var item in e.RemovedItems)
            {
                SelectedValues.Remove(item);
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Widok = (CollectionView) CollectionViewSource.GetDefaultView(_listBox.ItemsSource);
            Widok.Filter = UserFillter;
            CollectionViewSource.GetDefaultView(_listBox.ItemsSource).Refresh();
        }
    }
}