﻿using System.Windows;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsSelection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectionButtonClick(object sender, RoutedEventArgs e)
        {
            IsSelection = true;
        }

        private void PanButtonClick(object sender, RoutedEventArgs e)
        {
            IsSelection = false;
        }
    }
}
