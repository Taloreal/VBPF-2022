using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200003C RID: 60
	public partial class frmLessonsSimple : Form
	{
		// Token: 0x06000251 RID: 593 RVA: 0x00012C64 File Offset: 0x00011C64
		public frmLessonsSimple()
		{
			this.InitializeComponent();
			if (!Directory.Exists(Application.StartupPath + "\\Lessons\\"))
			{
				this.NoLessonsFound = true;
			}
			else
			{
				string[] files = Directory.GetFiles(Application.StartupPath + "\\Lessons\\", "*." + S.I.DataFileTypeExtension);
				if (files.Length == 0)
				{
					this.NoLessonsFound = true;
				}
				else
				{
					for (int i = 0; i < files.Length; i++)
					{
						files[i] = Path.GetFileNameWithoutExtension(files[i]);
					}
					Array.Sort(files, new frmLessonsSimple.LessonNameComparer());
					foreach (string text in files)
					{
						if (text.IndexOf(", Sim 1") > -1)
						{
							string text2 = text.Substring(0, text.IndexOf(", Sim "));
							this.lboLesson.Items.Add(text2);
							this.multiSimLessons.Add(text2, 1);
						}
						else if (text.IndexOf(", Sim ") == -1)
						{
							this.lboLesson.Items.Add(text);
						}
						else
						{
							string text2 = text.Substring(0, text.IndexOf(", Sim "));
							this.multiSimLessons[text2] = (int)this.multiSimLessons[text2] + 1;
						}
					}
				}
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000133BC File Offset: 0x000123BC
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.lboLesson.SelectedIndex > -1)
			{
				if (this.lboSim.Visible)
				{
					if (this.lboSim.SelectedIndex <= -1)
					{
						MessageBox.Show(S.R.GetString("The lesson you selected has multiple sims associated with it. Please choose one below as directed in your assignment."), S.R.GetString("Choose a Sim"));
						return;
					}
					this.lessonFileName = string.Concat(new object[]
					{
						Application.StartupPath,
						"\\Lessons\\",
						(string)this.lboLesson.SelectedItem,
						", Sim ",
						this.lboSim.SelectedIndex + 1,
						".",
						S.I.DataFileTypeExtension
					});
				}
				else
				{
					this.lessonFileName = string.Concat(new string[]
					{
						Application.StartupPath,
						"\\Lessons\\",
						(string)this.lboLesson.SelectedItem,
						".",
						S.I.DataFileTypeExtension
					});
				}
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("Please choose a lesson or hit cancel.", "No Lesson Selected");
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0001350A File Offset: 0x0001250A
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00013514 File Offset: 0x00012514
		private void lboLesson_DoubleClick(object sender, EventArgs e)
		{
			this.btnOK.PerformClick();
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00013524 File Offset: 0x00012524
		public string LessonFileName
		{
			get
			{
				return this.lessonFileName;
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0001353C File Offset: 0x0001253C
		private void frmLessonsSimple_Load(object sender, EventArgs e)
		{
			if (this.NoLessonsFound)
			{
				MessageBox.Show(S.R.GetString("No lessons found."), S.R.GetString("No Lessons Found"));
				base.Close();
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00013584 File Offset: 0x00012584
		private void lboLesson_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lboSim.Visible = this.multiSimLessons.ContainsKey(this.lboLesson.SelectedItem);
			this.labMultiSimLesson.Visible = this.lboSim.Visible;
			if (this.lboSim.Visible)
			{
				this.lboSim.Items.Clear();
				for (int i = 1; i <= (int)this.multiSimLessons[this.lboLesson.SelectedItem]; i++)
				{
					this.lboSim.Items.Add("Sim " + i);
				}
			}
		}

		// Token: 0x04000172 RID: 370
		private Hashtable multiSimLessons = new Hashtable();

		// Token: 0x0400017A RID: 378
		protected string lessonFileName;

		// Token: 0x0400017B RID: 379
		private bool NoLessonsFound = false;

		// Token: 0x0200003D RID: 61
		public class LessonNameComparer : IComparer
		{
			// Token: 0x0600025A RID: 602 RVA: 0x00013640 File Offset: 0x00012640
			public int Compare(object x1, object x2)
			{
				string text = (string)x1;
				string text2 = (string)x2;
				int result;
				if (text == text2)
				{
					result = 0;
				}
				else
				{
					string[] array = text.Split(new char[]
					{
						' '
					});
					string[] array2 = text2.Split(new char[]
					{
						' '
					});
					int num = int.Parse(array[1]);
					int num2 = int.Parse(array2[1]);
					if (num != num2)
					{
						result = num - num2;
					}
					else
					{
						int num3 = int.Parse(array[array.Length - 1]);
						int num4 = int.Parse(array2[array2.Length - 1]);
						result = num3 - num4;
					}
				}
				return result;
			}
		}
	}
}
