using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000075 RID: 117
	public partial class frmMessages : Form
	{
		// Token: 0x06000439 RID: 1081 RVA: 0x0001E3BC File Offset: 0x0001D3BC
		public frmMessages()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0001E4D8 File Offset: 0x0001D4D8
		public void AddMessage(PlayerMessage message)
		{
			if (base.Controls.Count == frmMessages.MAX_MESSAGES)
			{
				base.Controls.RemoveAt(0);
			}
			MessageControl messageControl = new MessageControl(message);
			if (this.alternateBackground)
			{
				messageControl.BackColor = Color.Gainsboro;
			}
			this.alternateBackground = !this.alternateBackground;
			base.SuspendLayout();
			base.Controls.Add(messageControl);
			base.ResumeLayout();
			this.frmMessages_Resize(this, new EventArgs());
			base.ScrollControlIntoView(base.Controls[base.Controls.Count - 1]);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0001E586 File Offset: 0x0001D586
		private void frmMessages_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			S.MF.HideMessageWindow();
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0001E59C File Offset: 0x0001D59C
		public void Clear()
		{
			base.SuspendLayout();
			base.Controls.Clear();
			base.ResumeLayout();
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0001E5BC File Offset: 0x0001D5BC
		private void frmMessages_Resize(object sender, EventArgs e)
		{
			base.SuspendLayout();
			for (int i = 0; i < base.Controls.Count; i++)
			{
				MessageControl messageControl = (MessageControl)base.Controls[i];
				messageControl.Width = base.Width - 30;
				if (i == 0)
				{
					messageControl.Location = new Point(base.AutoScrollPosition.X, base.AutoScrollPosition.Y);
				}
				else
				{
					messageControl.Location = new Point(base.AutoScrollPosition.X, base.Controls[i - 1].Location.Y + base.Controls[i - 1].Height);
				}
			}
			base.ResumeLayout();
		}

		// Token: 0x040002C3 RID: 707
		protected const int AVAILABLE_WIDTH = 30;

		// Token: 0x040002C5 RID: 709
		protected bool alternateBackground = false;

		// Token: 0x040002C6 RID: 710
		public static int MAX_MESSAGES = 20;
	}
}
