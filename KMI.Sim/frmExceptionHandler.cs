using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200004E RID: 78
	public partial class frmExceptionHandler : Form
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0001656A File Offset: 0x0001556A
		protected frmExceptionHandler()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000165BF File Offset: 0x000155BF
		public new static void Handle(Exception e)
		{
			frmExceptionHandler.Handle(e, null);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000165CC File Offset: 0x000155CC
		public new static void Handle(Exception e, Form errantForm)
		{
			if (!frmExceptionHandler.alreadyHandling)
			{
				frmExceptionHandler.alreadyHandling = true;
				if (e is SocketException)
				{
					frmExceptionHandler.HandleRemoteError();
				}
				else if (e is RemotingException)
				{
					frmExceptionHandler.HandleRemoteError();
				}
				else if (e is EntityNotFoundException)
				{
					string @string = S.R.GetString("{0} No Longer Exists", new object[]
					{
						S.I.EntityName
					});
					MessageBox.Show(e.Message, @string);
					S.MF.UpdateView();
					frmExceptionHandler.alreadyHandling = false;
				}
				else if (e is SimApplicationException)
				{
					MessageBox.Show(e.Message, Application.ProductName);
					frmExceptionHandler.alreadyHandling = false;
				}
				else
				{
					frmExceptionHandler frmExceptionHandler = new frmExceptionHandler();
					frmExceptionHandler.Text = S.R.GetString("An unexpected error has occurred.");
					frmExceptionHandler.MessageText = S.R.GetString("The simulation has encountered an unanticipated error from which it cannot recover.") + "\r\n\r\n";
					frmExceptionHandler frmExceptionHandler2 = frmExceptionHandler;
					frmExceptionHandler2.MessageText = frmExceptionHandler2.MessageText + S.R.GetString("If you would like to report this error please use the 'Report' button below.") + "\r\n\r\n";
					frmExceptionHandler frmExceptionHandler3 = frmExceptionHandler;
					frmExceptionHandler3.MessageText += S.R.GetString("Alternatively, you can send an e-mail to {0}.  Please include the text from the box below as part of your message.", new object[]
					{
						frmExceptionHandler.SupportEmail
					});
					frmExceptionHandler.ErrorText = frmExceptionHandler.GenerateInformation(e);
					frmExceptionHandler.reportButton.Visible = true;
					frmExceptionHandler.doneButton.Text = S.R.GetString("Close");
					frmExceptionHandler.ShowDialog();
				}
				if (errantForm != null)
				{
					errantForm.Close();
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00016798 File Offset: 0x00015798
		protected static void HandleRemoteError()
		{
			if (S.I.SimTimeRunning)
			{
				S.MF.mnuOptionsGoStop.PerformClick();
			}
			MessageBox.Show(S.R.GetString("Apparently you have been disconnected from the host session. Either the network connection has failed or the host session is no longer running.  If the host is still running, you might be able to reconnect by doing a Multiplayer Join from the File menu."), S.R.GetString("Disconnected From Host"));
			Form form = new frmStartChoices();
			form.ShowDialog(S.MF);
			frmExceptionHandler.alreadyHandling = false;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00016808 File Offset: 0x00015808
		public static bool HandleToLog(Exception e)
		{
			try
			{
				if (!EventLog.SourceExists(Application.ProductName) || !EventLog.Exists(Application.ProductName))
				{
					try
					{
						EventLog.CreateEventSource(Application.ProductName, Application.ProductName);
					}
					catch (Exception e2)
					{
						frmExceptionHandler.Handle(e2);
						return false;
					}
				}
				EventLog.WriteEntry(Application.ProductName, frmExceptionHandler.GenerateInformation(e), EventLogEntryType.Error, 0, 0);
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
				return false;
			}
			return true;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000168A0 File Offset: 0x000158A0
		private static string GenerateInformation(Exception e)
		{
			string text = "";
			StackFrame stackFrame = null;
			StackTrace stackTrace;
			if (e == null)
			{
				stackTrace = new StackTrace(true);
			}
			else
			{
				stackTrace = new StackTrace(e, true);
			}
			if (stackTrace.FrameCount > 0)
			{
				stackFrame = stackTrace.GetFrame(0);
			}
			OperatingSystem osversion = Environment.OSVersion;
			if (osversion != null)
			{
				text = text + "OSPlatform: " + osversion.Platform.ToString() + "\r\n";
				if (osversion.Version != null)
				{
					text = text + "OSVersion: " + osversion.Version.ToString() + "\r\n";
				}
			}
			if (e != null)
			{
				if (S.I != null && S.ST != null)
				{
					text = text + "Multiplayer: " + S.I.Multiplayer.ToString() + "\r\n";
					text = text + "SimStateID: " + S.ST.GUID.ToString() + "\r\n";
				}
				if (e.Source != null && e.Source.Length > 0)
				{
					text = text + "Module: " + e.Source + "\r\n";
				}
				if (stackFrame.GetFileName() != null && stackFrame.GetFileName().Length > 0)
				{
					text = text + "File: " + stackFrame.GetFileName() + "\r\n";
				}
				if (e.GetType().Name != null && e.GetType().Name.Length > 0)
				{
					text = text + "Exception: " + e.GetType().Name + "\r\n";
				}
				if (e.Message != null && e.Message.Length > 0)
				{
					text = text + "Reason: " + e.Message + "\r\n";
				}
				if (e.TargetSite != null)
				{
					text = text + "Target: " + e.TargetSite.ToString() + "\r\n";
				}
				if (stackFrame.GetFileLineNumber() > 0)
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"Line: ",
						stackFrame.GetFileLineNumber(),
						"\r\n"
					});
				}
				if (stackFrame.GetFileColumnNumber() > 0)
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"Column: ",
						stackFrame.GetFileColumnNumber(),
						"\r\n"
					});
				}
			}
			if (e != null)
			{
				text = text + "Stack Trace: " + e.StackTrace + "\r\n\r\n";
			}
			else
			{
				text = text + "Stack Trace: " + stackTrace.ToString() + "\r\n\r\n";
			}
			return text;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00016BDC File Offset: 0x00015BDC
		private void doneButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00016BE6 File Offset: 0x00015BE6
		private void ExceptionHandler_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00016BEC File Offset: 0x00015BEC
		private void reportButton_Click(object sender, EventArgs e)
		{
			if (this.txtSchool.Text.Length == 0)
			{
				MessageBox.Show(S.R.GetString("Please fill in the school name field."));
				this.txtSchool.Focus();
			}
			else
			{
				try
				{
					WebRequest webRequest = WebRequest.Create(frmExceptionHandler.ReportURL);
					webRequest.Method = "POST";
					webRequest.ContentType = "application/x-www-form-urlencoded";
					string text = "";
					text = text + "school=" + Utilities.URLEncode(this.txtSchool.Text) + "&";
					text = text + "product=" + Utilities.URLEncode(Application.ProductName) + "&";
					text = text + "version=" + Utilities.URLEncode(Application.ProductVersion) + "&";
					text = text + "error_text=" + Utilities.URLEncode(this.errorTextTextBox.Text);
					byte[] bytes = Encoding.ASCII.GetBytes(text);
					webRequest.ContentLength = (long)bytes.Length;
					Stream requestStream = webRequest.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
					WebResponse response = webRequest.GetResponse();
					StreamReader streamReader = new StreamReader(response.GetResponseStream());
					string a = streamReader.ReadToEnd();
					streamReader.Close();
					if (a == "ReportSuccess")
					{
						MessageBox.Show(S.R.GetString("ReportSuccess", new object[]
						{
							frmExceptionHandler.SupportEmail,
							frmExceptionHandler.SupportPhone
						}));
						base.Close();
					}
					else
					{
						MessageBox.Show(S.R.GetString("ReportFailure", new object[]
						{
							frmExceptionHandler.ReportURL,
							frmExceptionHandler.SupportEmail,
							frmExceptionHandler.SupportPhone
						}));
					}
				}
				catch
				{
					MessageBox.Show(S.R.GetString("ReportFailure", new object[]
					{
						frmExceptionHandler.ReportURL,
						frmExceptionHandler.SupportEmail,
						frmExceptionHandler.SupportPhone
					}));
				}
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x00016E20 File Offset: 0x00015E20
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x00016E3D File Offset: 0x00015E3D
		public string MessageText
		{
			get
			{
				return this.errorMessageTextBox.Text;
			}
			set
			{
				this.errorMessageTextBox.Text = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00016E50 File Offset: 0x00015E50
		// (set) Token: 0x060002DA RID: 730 RVA: 0x00016E6D File Offset: 0x00015E6D
		public string ErrorText
		{
			get
			{
				return this.errorTextTextBox.Text;
			}
			set
			{
				this.errorTextTextBox.Text = value;
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00016E7D File Offset: 0x00015E7D
		private void frmExceptionHandler_Closing(object sender, CancelEventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x040001BF RID: 447
		public static string ReportURL = "http://www.knowledgematters.com/reports/bugs.php";

		// Token: 0x040001C0 RID: 448
		public static string SupportEmail = "support@knowledgematters.com";

		// Token: 0x040001C1 RID: 449
		public static string SupportPhone = "1-877-965-3276";

		// Token: 0x040001C3 RID: 451
		protected static bool alreadyHandling = false;
	}
}
