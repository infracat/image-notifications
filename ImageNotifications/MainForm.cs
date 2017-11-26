using Imageboards;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using Windows.UI.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace ImageNotifications
{
    public partial class MainForm : Form
    {
        private StringCollection tags;
        private decimal timerIntervalMinutes;
        private int lastPostId;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lastPostId = Properties.Settings.Default.LastPostId;

            ((MainForm)sender).checkBoxSafe.Checked = Properties.Settings.Default.SafetyFilter;

            timerIntervalMinutes = Properties.Settings.Default.CheckInterval;
            ((MainForm)sender).numericUpDownInterval.Value = timerIntervalMinutes;

            tags = Properties.Settings.Default.Tags;
            FillListBoxTags();

            CheckForUpdates();

            timerInterval.Tick += new EventHandler(timerInterval_Tick);
            StartTimer();
        }

        private void checkBoxSafe_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SafetyFilter = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }

        private void listBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!buttonRemoveTag.Enabled)
            {
                buttonRemoveTag.Enabled = true;
            }
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            if (tags.Contains(textBoxTags.Text))
            {
                MessageBox.Show(
                    "Such tag already exists in list.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            tags.Add(textBoxTags.Text);
            textBoxTags.Text = String.Empty;

            Properties.Settings.Default.Tags = tags;
            Properties.Settings.Default.Save();

            FillListBoxTags();
            CheckForUpdates();
        }

        private void buttonRemoveTag_Click(object sender, EventArgs e)
        {
            var selectedTag = listBoxTags.SelectedItem.ToString();

            if (tags.Contains(selectedTag))
            {
                tags.Remove(selectedTag);
            }

            Properties.Settings.Default.Tags = tags;
            Properties.Settings.Default.Save();

            FillListBoxTags();
        }

        private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckInterval = ((NumericUpDown)sender).Value;
            Properties.Settings.Default.Save();

            StartTimer();
        }

        private void FillListBoxTags()
        {
            listBoxTags.Items.Clear();

            foreach (var tag in tags)
            {
                listBoxTags.Items.Add(tag);
            }
        }

        private void timerInterval_Tick(object sender, EventArgs e)
        {
            CheckForUpdates();
            StartTimer();
        }

        private void StartTimer()
        {
            if (timerInterval.Enabled)
            {
                timerInterval.Stop();
            }

            timerInterval.Interval = Convert.ToInt32(timerIntervalMinutes * 60000);
            timerInterval.Start();
        }

        private void CheckForUpdates()
        {
            DanbooruWrapper wrapper = new DanbooruWrapper();
            var currentLastPostId = lastPostId;

            foreach (var tag in tags)
            {
                var posts = wrapper.GetPosts(tag).OrderBy(p => p.Id);
                var lastPost = posts.LastOrDefault();

                if ((lastPost != null) && (!String.IsNullOrEmpty(lastPost.PreviewUrl)) && (lastPost.Id > lastPostId))
                {
                    if ((lastPost.Id > lastPostId) && (lastPost.Id > currentLastPostId))
                    {
                        currentLastPostId = lastPost.Id;
                    }

                    var previewPath = lastPost.DownloadPreview(DanbooruWrapper.Url);

                    var title = "New images at " + tag;
                    ShowToast(previewPath, title);
                }
            }

            lastPostId = currentLastPostId;
            Properties.Settings.Default.LastPostId = lastPostId;
            Properties.Settings.Default.Save();
        }

        private void ShowToast(string imagePath, string title)
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            var text = toastXml.GetElementsByTagName("text");
            text[0].AppendChild(toastXml.CreateTextNode(title));

            var imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier("test").Show(toast);
        }
    }
}