using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000034 RID: 52
	public class MessageControl : UserControl
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00010A58 File Offset: 0x0000FA58
		public MessageControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00010A78 File Offset: 0x0000FA78
		public MessageControl(PlayerMessage message)
		{
			this.InitializeComponent();
			this.Init();
			this.labMessageText.Text = message.Message;
			this.labFrom.Text = message.From;
			if (this.labFrom.Text.Equals(""))
			{
				this.labFromID.Visible = false;
			}
			else
			{
				this.labFromID.Visible = true;
			}
			string text;
			if (message.Date.Hour >= 12)
			{
				text = message.Date.ToString("M/d/yy - h:mm") + " PM";
			}
			else
			{
				text = message.Date.ToString("M/d/yy - h:mm") + " AM";
			}
			this.labDate.Text = text;
			this.labImage.Image = new Bitmap(base.GetType(), "Images.Warning" + message.NotificationColor.ToString() + ".gif");
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00010BA8 File Offset: 0x0000FBA8
		protected void Init()
		{
			if (MessageControl.SFTW == null)
			{
				MessageControl.SFTW = new StringFormat();
				MessageControl.SFTW.Trimming = StringTrimming.Word;
			}
			base.SuspendLayout();
			this.labMessageText.Height = 32;
			this.labImage.Height = 32;
			this.labImage.Left = 4;
			this.labMessageText.Left = this.labImage.Left + this.labImage.Width;
			this.labFrom.Left = this.labImage.Left + this.labImage.Width;
			this.labFromID.Left = 4;
			this.labFromID.Top = 4;
			this.labFrom.Top = 4;
			this.labDate.Top = 4;
			this.MessageControl_Resize(this, new EventArgs());
			base.ResumeLayout();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00010C9C File Offset: 0x0000FC9C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00010CD8 File Offset: 0x0000FCD8
		private void InitializeComponent()
		{
			this.labMessageText = new Label();
			this.labImage = new Label();
			this.labFromID = new Label();
			this.labFrom = new Label();
			this.labDate = new Label();
			base.SuspendLayout();
			this.labMessageText.Location = new Point(40, 16);
			this.labMessageText.Name = "labMessageText";
			this.labMessageText.Size = new Size(216, 32);
			this.labMessageText.TabIndex = 0;
			this.labMessageText.Text = "#message text";
			this.labMessageText.TextChanged += this.labMessageText_TextChanged;
			this.labImage.Location = new Point(0, 16);
			this.labImage.Name = "labImage";
			this.labImage.Size = new Size(40, 32);
			this.labImage.TabIndex = 1;
			this.labFromID.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labFromID.Location = new Point(0, 0);
			this.labFromID.Name = "labFromID";
			this.labFromID.Size = new Size(40, 16);
			this.labFromID.TabIndex = 2;
			this.labFromID.Text = "From:";
			this.labFromID.TextAlign = ContentAlignment.MiddleLeft;
			this.labFrom.Location = new Point(40, 0);
			this.labFrom.Name = "labFrom";
			this.labFrom.Size = new Size(104, 16);
			this.labFrom.TabIndex = 3;
			this.labFrom.Text = "#from";
			this.labFrom.TextAlign = ContentAlignment.MiddleLeft;
			this.labDate.Location = new Point(144, 0);
			this.labDate.Name = "labDate";
			this.labDate.Size = new Size(96, 16);
			this.labDate.TabIndex = 4;
			this.labDate.Text = "#date";
			this.labDate.TextAlign = ContentAlignment.MiddleRight;
			base.Controls.Add(this.labDate);
			base.Controls.Add(this.labFrom);
			base.Controls.Add(this.labFromID);
			base.Controls.Add(this.labImage);
			base.Controls.Add(this.labMessageText);
			base.Name = "MessageControl";
			base.Size = new Size(240, 48);
			base.Resize += this.MessageControl_Resize;
			base.ResumeLayout(false);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00010FC8 File Offset: 0x0000FFC8
		private void labMessageText_TextChanged(object sender, EventArgs e)
		{
			this.labMessageText.Height = (int)this.labMessageText.CreateGraphics().MeasureString(this.labMessageText.Text, this.labMessageText.Font, this.labMessageText.Width, MessageControl.SFTW).Height;
			base.Height = this.labMessageText.Height;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00011034 File Offset: 0x00010034
		protected override void OnResize(EventArgs e)
		{
			if (!this.resizing)
			{
				this.resizing = true;
				base.OnResize(e);
			}
			this.resizing = false;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00011064 File Offset: 0x00010064
		private void MessageControl_Resize(object sender, EventArgs e)
		{
			base.SuspendLayout();
			this.labMessageText.Width = base.Width - this.labImage.Width - 8;
			this.labFrom.Width = this.labMessageText.Width / 2;
			this.labDate.Left = this.labFrom.Left + this.labFrom.Width;
			this.labDate.Width = this.labFrom.Width;
			int num = (int)this.labMessageText.CreateGraphics().MeasureString(this.labMessageText.Text, this.labMessageText.Font, this.labMessageText.Width, MessageControl.SFTW).Height;
			num = Math.Max(num, 32);
			if (this.labImage.Image != null)
			{
				num = Math.Max(this.labImage.Height, num);
			}
			this.labMessageText.Height = num;
			this.labImage.Height = num;
			int val = (int)this.labFrom.CreateGraphics().MeasureString(this.labFrom.Text, this.labFrom.Font, this.labFrom.Width, MessageControl.SFTW).Height;
			int val2 = (int)this.labDate.CreateGraphics().MeasureString(this.labDate.Text, this.labDate.Font, this.labDate.Width, MessageControl.SFTW).Height;
			num = Math.Max(val, val2);
			this.labFromID.Height = num;
			this.labFrom.Height = num;
			this.labDate.Height = num;
			this.labImage.Top = num + 4;
			this.labMessageText.Top = num + 4;
			base.Height = this.labFromID.Height + this.labMessageText.Height + 8;
			base.ResumeLayout();
		}

		// Token: 0x04000149 RID: 329
		protected const int PADDING = 4;

		// Token: 0x0400014A RID: 330
		protected const int MIN_MESSAGE_TEXT_HEIGHT = 32;

		// Token: 0x0400014B RID: 331
		private Label labMessageText;

		// Token: 0x0400014C RID: 332
		private Label labImage;

		// Token: 0x0400014D RID: 333
		private Label labFromID;

		// Token: 0x0400014E RID: 334
		private Label labFrom;

		// Token: 0x0400014F RID: 335
		private Label labDate;

		// Token: 0x04000150 RID: 336
		private Container components = null;

		// Token: 0x04000151 RID: 337
		protected bool resizing = false;

		// Token: 0x04000152 RID: 338
		public static StringFormat SFTW;
	}
}
