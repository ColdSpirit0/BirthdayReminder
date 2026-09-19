using Avalonia.Controls;
using Avalonia.Interactivity;
using BirthdayReminder.Messages;
using BirthdayReminder.Models;
using BirthdayReminder.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;

namespace BirthdayReminder.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Design.IsDesignMode) return;

            WeakReferenceMessenger.Default.Register<MainWindow, EditRecordMessage>(this, static (w, m) =>
            {                
                var editorWindow = new EditRecordWindow();
                editorWindow.DataContext = new EditorWindowViewModel(m.record);
                var record = editorWindow.ShowDialog<BirthdayRecord?>(w);
                m.Reply(record);
            });
            
            DataTable.Loaded += OnDataTableLoaded;
        }


        private void OnDataTableLoaded(object? sender, RoutedEventArgs e)
        {
            DataTable.Loaded -= OnDataTableLoaded;

            DataTable.Columns[2].Sort(
                System.ComponentModel.ListSortDirection.Ascending);
        }
    }
}