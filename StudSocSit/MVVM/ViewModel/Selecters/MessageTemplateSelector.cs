using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace Selecters;

public class MessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate MyMessageTemplate { get; set; }
    public DataTemplate OtherMessageTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var message = item as MainPageVM.MessageCollection; // Замените YourMessageType на реальный тип вашего сообщения

        if (message != null)
        {
            if (message.Messages.AuthorId == message.StudentId)
            {
                return MyMessageTemplate;
            }
            else
            {
                return OtherMessageTemplate;
            }
        }

        return base.SelectTemplate(item, container);
    }
}
