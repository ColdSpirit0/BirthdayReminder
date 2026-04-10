using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BirthdayReminder.Messages;
using BirthdayReminder.Views;
using CommunityToolkit.Mvvm.Messaging;
using System.Runtime.CompilerServices;

namespace BirthdayReminder;

public partial class EditRecordWindow : Window
{
    public EditRecordWindow()
    {
        InitializeComponent();

        if (Design.IsDesignMode) return;

        WeakReferenceMessenger.Default.Register<EditRecordWindow, CloseEditWindowMessage>(this, static (w, m) =>
        {
            w.Close(m.record);
        });
    }
}