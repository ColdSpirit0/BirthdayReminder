using Avalonia.Controls;
using BirthdayReminder.Messages;
using BirthdayReminder.Models;
using BirthdayReminder.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using System;

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
        }
    }
}