﻿using Module.MessageBox.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Input;

namespace Module.MessageBox.ViewModels
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        private MessageContent messageContent;

        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        private string _message;
        public string Message { get => _message; set => SetProperty(ref _message, value); }

        private MessageDialogType _messageDialogValue;

        public MessageDialogType MessageDialogValue { get => _messageDialogValue; set => SetProperty(ref _messageDialogValue, value); }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }

        private DialogResult result = new DialogResult(ButtonResult.None);

        public event Action<IDialogResult> RequestClose;

        public MessageDialogViewModel()
        {
            OkCommand = new DelegateCommand(SelectedOk);
            CancelCommand = new DelegateCommand(SelectedCancel);
            YesCommand = new DelegateCommand(SelectedYes);
            NoCommand = new DelegateCommand(SelectedNo);
        }

        private void SelectedOk()
        {
            result = new DialogResult(ButtonResult.OK);
            RequestClose(result);
        }
        private void SelectedCancel()
        {
            result = new DialogResult(ButtonResult.Cancel);
            RequestClose(result);
        }
        private void SelectedYes()
        {
            result = new DialogResult(ButtonResult.Yes);
            RequestClose(result);
        }
        private void SelectedNo()
        {
            result = new DialogResult(ButtonResult.No);
        }



        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            messageContent = new MessageContent();
            messageContent = parameters.GetValue<MessageContent>("MessageContent");
            Title = messageContent.Title;
            Message = messageContent.Message;
            MessageDialogValue = messageContent.MessageDialogValue;

            // ビープ音を鳴らします
            SystemSounds.Asterisk.Play();
        }
    }
}
