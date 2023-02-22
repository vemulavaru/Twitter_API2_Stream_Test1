namespace Twitter_API2_Stream_Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTwtCount = new System.Windows.Forms.TextBox();
            this.btnGetTop10Hashtags = new System.Windows.Forms.Button();
            this.txtHashTags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalTweetCount = new System.Windows.Forms.TextBox();
            this.btnRecentTweets = new System.Windows.Forms.Button();
            this.btnTotalTweets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTwtCount
            // 
            this.txtTwtCount.Location = new System.Drawing.Point(31, 86);
            this.txtTwtCount.Multiline = true;
            this.txtTwtCount.Name = "txtTwtCount";
            this.txtTwtCount.Size = new System.Drawing.Size(318, 405);
            this.txtTwtCount.TabIndex = 2;
            // 
            // btnGetTop10Hashtags
            // 
            this.btnGetTop10Hashtags.Location = new System.Drawing.Point(408, 23);
            this.btnGetTop10Hashtags.Name = "btnGetTop10Hashtags";
            this.btnGetTop10Hashtags.Size = new System.Drawing.Size(186, 29);
            this.btnGetTop10Hashtags.TabIndex = 3;
            this.btnGetTop10Hashtags.Text = "Get Top 10 Hashtags";
            this.btnGetTop10Hashtags.UseVisualStyleBackColor = true;
            this.btnGetTop10Hashtags.Click += new System.EventHandler(this.btnGetTopTenHashtags_Click);
            // 
            // txtHashTags
            // 
            this.txtHashTags.Location = new System.Drawing.Point(408, 91);
            this.txtHashTags.Multiline = true;
            this.txtHashTags.Name = "txtHashTags";
            this.txtHashTags.Size = new System.Drawing.Size(334, 400);
            this.txtHashTags.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recent Tweets:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Tweets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Top10 HashTags";
            // 
            // txtTotalTweetCount
            // 
            this.txtTotalTweetCount.Location = new System.Drawing.Point(776, 91);
            this.txtTotalTweetCount.Multiline = true;
            this.txtTotalTweetCount.Name = "txtTotalTweetCount";
            this.txtTotalTweetCount.Size = new System.Drawing.Size(223, 225);
            this.txtTotalTweetCount.TabIndex = 8;
            // 
            // btnRecentTweets
            // 
            this.btnRecentTweets.Location = new System.Drawing.Point(31, 23);
            this.btnRecentTweets.Name = "btnRecentTweets";
            this.btnRecentTweets.Size = new System.Drawing.Size(186, 29);
            this.btnRecentTweets.TabIndex = 9;
            this.btnRecentTweets.Text = "Get Recent Tweets";
            this.btnRecentTweets.UseVisualStyleBackColor = true;
            this.btnRecentTweets.Click += new System.EventHandler(this.btnRecentTweets_Click);
            // 
            // btnTotalTweets
            // 
            this.btnTotalTweets.Location = new System.Drawing.Point(776, 23);
            this.btnTotalTweets.Name = "btnTotalTweets";
            this.btnTotalTweets.Size = new System.Drawing.Size(186, 29);
            this.btnTotalTweets.TabIndex = 10;
            this.btnTotalTweets.Text = "Get Total Tweets";
            this.btnTotalTweets.UseVisualStyleBackColor = true;
            this.btnTotalTweets.Click += new System.EventHandler(this.btnTotalTweets_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 726);
            this.Controls.Add(this.btnTotalTweets);
            this.Controls.Add(this.btnRecentTweets);
            this.Controls.Add(this.txtTotalTweetCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHashTags);
            this.Controls.Add(this.btnGetTop10Hashtags);
            this.Controls.Add(this.txtTwtCount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTwtCount;
        private System.Windows.Forms.Button btnGetTop10Hashtags;
        private System.Windows.Forms.TextBox txtHashTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalTweetCount;
        private System.Windows.Forms.Button btnRecentTweets;
        private System.Windows.Forms.Button btnTotalTweets;
    }
}
