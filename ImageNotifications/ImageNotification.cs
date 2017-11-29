using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace ImageNotifications
{
    public class ImageNotification
    {
        private string imagePath;

        public ImageNotification(string imagePath)
        {
            this.imagePath = imagePath;
        }

        public void Show()
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            var text = toastXml.GetElementsByTagName("text");
            text[0].AppendChild(toastXml.CreateTextNode("New image"));

            var imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier("test").Show(toast);
        }
    }
}