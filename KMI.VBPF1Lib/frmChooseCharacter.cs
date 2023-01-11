using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBPF1Lib
{
	/// <summary>
	/// Summary description for frmChooseCharacter.
	/// </summary>
	// Token: 0x0200000F RID: 15
	public partial class frmChooseCharacter : Form
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00005924 File Offset: 0x00004924
		public frmChooseCharacter(string name)
		{
			this.InitializeComponent();
			this.labName.Text = name;
			if (name != "")
			{
				this.labName.Enabled = false;
			}
			for (int i = 0; i < 12; i++)
			{
				Label j = new Label();
				j.Location = new Point(i % 6 * 77 + 20, i / 6 * 110);
				j.Image = A.R.GetImage("Palette" + (i + 6));
				j.Size = j.Image.Size;
				j.Click += this.Palette_Click;
				j.Tag = i + 6;
				this.panPalettes.Controls.Add(j);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005CF4 File Offset: 0x00004CF4
		private void Palette_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panPalettes.Controls)
			{
				Label i = (Label)obj;
				i.BorderStyle = BorderStyle.None;
			}
			Label l2 = (Label)sender;
			l2.BorderStyle = BorderStyle.FixedSingle;
			this.index = (int)l2.Tag;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005D84 File Offset: 0x00004D84
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.labName.Text == "")
			{
				MessageBox.Show(A.R.GetString("You must enter a name for yourself. Please try again."), A.R.GetString("Input Required"));
			}
			else if (this.index == -1)
			{
				MessageBox.Show(A.R.GetString("You must select an image for yourself. Please click a person."), A.R.GetString("Input Required"));
			}
			else
			{
				try
				{
					Person.GenderType gender = Person.GenderType.Male;
					if (this.index < 12)
					{
						gender = Person.GenderType.Female;
					}
					long entityID = A.SA.AddEntity(A.I.ThisPlayerName, this.labName.Text, gender, this.index);
					A.MF.OnCurrentEntityChange(entityID);
					this.okToClose = true;
					base.Close();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex, this);
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005E88 File Offset: 0x00004E88
		private void frmChooseCharacter_Closing(object sender, CancelEventArgs e)
		{
			if (!this.okToClose)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005EA8 File Offset: 0x00004EA8
		private void frmChooseCharacter_Load(object sender, EventArgs e)
		{
			this.labName.Focus();
		}

		// Token: 0x040000AF RID: 175
		private int index = -1;

		// Token: 0x040000B0 RID: 176
		private bool okToClose = false;
	}
}
