﻿using QuranAuthor.Helps;
using QuranAuthor.ViewModels;
using System.Windows;

namespace QuranAuthor.Views
{
    public partial class TafseerWindow : Window
    {
        public TafseerWindow()
        {
            InitializeComponent();
            this.ViewModel = new TafseerViewModel();
        }

        public TafseerViewModel ViewModel
        {
            get
            {
                return this.DataContext as TafseerViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void NewSnippet_Click(object sender, RoutedEventArgs e)
        {
            SnippetWindow snipetWindow = new SnippetWindow();
            if (snipetWindow.ShowDialog() == true && snipetWindow.Snippet != null)
            {
                this.ViewModel.SnippetTaken(snipetWindow.Snippet, snipetWindow.Page);
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            this.ViewModel.SaveExplanation();
        }

        private void NewExp_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.NewExpCommand.Execute(null);
            txtExp.SelectAll();
            txtExp.Focus();
        }
    }
}