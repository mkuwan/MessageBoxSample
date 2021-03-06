using Module.MessageBox.Models;
using Module.MessageBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Module.MessageBox.TemplateSelectors
{
    class MessageDialogTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OkOnlyTemplate { get; set; }
        public DataTemplate OkCancelTemplate { get; set; }
        public DataTemplate YesNoTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MessageDialogType messageDialogType = ((MessageDialogViewModel)item).MessageDialogValue;

            switch (messageDialogType)
            {
                case MessageDialogType.OkOnly:
                    {
                        return OkOnlyTemplate;
                    }
                case MessageDialogType.OkCancel:
                    {
                        return OkCancelTemplate;
                    }
                case MessageDialogType.YesNo:
                    {
                        return YesNoTemplate;
                    }
            }

            return base.SelectTemplate(item, container);
        }

    }
}
