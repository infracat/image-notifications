using System.Windows.Forms;
using Windows.UI.Notifications;

namespace ImageNotifications
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ShowToast();
        }

        private void ShowToast()
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
            string imagePath = @"D:\Documents\Graphics\Userpics\flandre4.png";

            var text = toastXml.GetElementsByTagName("text");
            text[0].AppendChild(toastXml.CreateTextNode("New Image"));

            var imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier("test").Show(toast);
        }
    }
}