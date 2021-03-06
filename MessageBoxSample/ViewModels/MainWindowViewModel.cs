using Module.MessageBox.Models;
using Module.MessageBox.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace MessageBoxSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IMessageDialogService _messageDialogService;

        public ICommand ShowOKMessageBox { get; }
        public ICommand ShowYesNoMessageBox { get; }
        public ICommand ShowOKCancelMessageBox { get; }

        public MainWindowViewModel(IMessageDialogService messageDialogService)
        {
            _messageDialogService = messageDialogService;

            ShowOKMessageBox = new DelegateCommand(ShowOkMessage);
            ShowYesNoMessageBox = new DelegateCommand(ShowYesNoMessage);
            ShowOKCancelMessageBox = new DelegateCommand(ShowOkCancalMesssage);
        }

        private void ShowOkCancalMesssage()
        {
            _messageDialogService.ShowMessage("OK・キャンセルになっていますよ", "OK・キャンセルタイトル", MessageDialogType.OkCancel);
        }

        private void ShowYesNoMessage()
        {
            _messageDialogService.ShowMessage("はい・いいえになっていますよ", "はい・いいえタイトル", MessageDialogType.YesNo);
        }

        private void ShowOkMessage()
        {
            _messageDialogService.ShowMessage("OKになっていますよ", "OKタイトル", MessageDialogType.OkOnly);
        }
    }
}
