using Module.MessageBox.Models;
using Module.MessageBox.Views;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.MessageBox.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        private readonly IDialogService _dialogService;

        public MessageDialogService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public ButtonResult ShowMessage(string message, string title, MessageDialogType messageDialogType)
        {
            MessageContent messageContent = new MessageContent()
            {
                Message = message,
                Title = title,
                MessageDialogValue = messageDialogType
            };

            IDialogResult dialogResult = null;
            _dialogService.ShowDialog(nameof(MessageDialog), new DialogParameters { { "MessageContent", messageContent } }, result => dialogResult = result);

            return dialogResult.Result;
        }
    }
}
