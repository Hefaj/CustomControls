using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls.custom
{
    public partial class MagicBox
    {
        public IList ItemSoruce
        {
            get => (IList)GetValue(ItemSoruceProperty);
            set => SetValue(ItemSoruceProperty, value);
        }
        
        public static readonly DependencyProperty ItemSoruceProperty =
            DependencyProperty.Register(nameof(ItemSoruce), typeof(IList), typeof(MagicBox));

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }
        
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(nameof(DisplayMemberPath), typeof(string),
                typeof(MagicBox), new UIPropertyMetadata("Name"));
        
        public string SelectedValuePath
        {
            get => (string)GetValue(SelectedValuePathProperty);
            set => SetValue(SelectedValuePathProperty, value);
        }
        
        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register(nameof(SelectedValuePath), typeof(string),
                typeof(MagicBox), new UIPropertyMetadata("ID"));
        
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


        // public static readonly DependencyProperty SelectedItemsProperty =
        //     DependencyProperty.RegisterAttached("SelectedItems",
        //         typeof(INotifyCollectionChanged), typeof(MagicBox),
        //         new PropertyMetadata(default(IList)));
        //
        // public static void SetSelectedItems(DependencyObject d, INotifyCollectionChanged value)
        // {
        //     d.SetValue(SelectedItemsProperty, value);
        // }
        //
        // public static IList GetSelectedItems(DependencyObject element)
        // {
        //     return (IList)element.GetValue(SelectedItemsProperty);
        // }
        
        public IList SelectedItemsList
        {
            get => (IList)GetValue(SelectedItemsListProperty);
            set => SetValue(SelectedItemsListProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
            DependencyProperty.Register(nameof(SelectedItemsList), typeof(IList), 
                typeof(MagicBox), new FrameworkPropertyMetadata( null,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        
        
        public IList ItemSoruce2
        {
            get => (IList)GetValue(ItemSoruceProperty2);
            set => SetValue(ItemSoruceProperty2, value);
        }
        
        public static readonly DependencyProperty ItemSoruceProperty2 =
            DependencyProperty.Register(nameof(ItemSoruce2), typeof(IList), typeof(MagicBox));
        
        private void _listBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItemsList = _listBox.SelectedItems; // nie dziala tak jak chce, dziala cast<Person>().ToList(). Ale wiaze z Person 
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