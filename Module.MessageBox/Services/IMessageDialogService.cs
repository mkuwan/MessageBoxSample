using Module.MessageBox.Models;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module.MessageBox.Services
{
    public interface IMessageDialogService
    {
        ButtonResult ShowMessage(string message, string title, MessageDialogType messageDialogType);
    }
}
