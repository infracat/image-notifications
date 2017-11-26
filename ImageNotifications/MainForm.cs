using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Windows.UI.Notifications;

namespace ImageNotifications
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DanbooruWrapper wrapper = new DanbooruWrapper();
            var posts = wrapper.GetPosts("flandre_scarlet");
            var previewPath = String.Empty;


            foreach (var post in posts)
            {
                if (!String.IsNullOrEmpty(post.PreviewUrl))
                {
                    previewPath = DownloadPreview(post);
                    break;
                }
            }

            ShowToast(previewPath);
        }

        private void ShowToast(string imagePath)
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            var text = toastXml.GetElementsByTagName("text");
            text[0].AppendChild(toastXml.CreateTextNode("New Image"));

            var imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier("test").Show(toast);
        }

        private string DownloadPreview(Post post)
        {
            var url = "http://danbooru.donmai.us" + post.PreviewUrl;
            var tempDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Temp\\";
            var tempFilePath = tempDirectory + post.Id + Path.GetExtension(post.PreviewUrl);

            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            var client = new WebClient();
            client.DownloadFile(url, tempFilePath);

            return tempFilePath;
        }
    }
}