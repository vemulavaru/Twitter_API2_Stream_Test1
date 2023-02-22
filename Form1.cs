using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitter_API2_Stream_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        
        private async void btnGetTopTenHashtags_Click(object sender, EventArgs e)
        {
            txtHashTags.Text = string.Empty;
            int i = 0;
            var hashTags = await TwitterClient.GetTop10HashTagsAsync();
            if (hashTags != null)
            {
                foreach (var hashtag in hashTags)
                {
                    txtHashTags.Text += $"{hashtag.Key}: {hashtag.Value}" + Environment.NewLine;
                    i++;
                }                
            }
            else
            {
                txtHashTags.Text = "Error. Please check the error log.";
            }
        }

        private async void btnRecentTweets_Click(object sender, EventArgs e)
        {
            int i = 1;
            txtTwtCount.Text = string.Empty;
            var recentTweets = await TwitterClient.GetRecentDevTweetsAsync();
            if (recentTweets != null)
            {
                foreach (var text in recentTweets)
                {
                    txtTwtCount.Text += "Tweet " + i.ToString() + ": " + Environment.NewLine + text + Environment.NewLine;
                    i++;
                }
            }
            else
            {
                txtTotalTweetCount.Text = "Error. Please check the error log.";
            }
        }

        private async void btnTotalTweets_Click(object sender, EventArgs e)
        {
            int totalTweets = await TwitterClient.GetTotalTweetsAsync();
            if (totalTweets < 0)
                txtTotalTweetCount.Text = "Error. Please check the error log.";
            else
                txtTotalTweetCount.Text = totalTweets == 0 ? "No Tweets" : totalTweets.ToString();
        }
    }
}
