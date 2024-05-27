using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Stimulsoft.Report;
using StimulTest.Models;
using StimulTest.Utility;

namespace StimulTest
{
	public partial class Form1 : Form
	{
		private const string fileName = "data.json";

		public Form1()
		{
			InitializeComponent();
		}
		
		private void analysisOfAccountBtn_Click(object sender, EventArgs e)
		{
			
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				var file = File.ReadAllLines(fileName);

				string json = "";
				using (StreamReader r = new StreamReader(fileName))
				{
					json = r.ReadToEnd();
				}
				var data = JsonConvert.DeserializeObject<AnalysisOfAccount>(json);

				var report = Report.ShowAnalysisOfAccount(data);

				this.Close();
				
				//report.Compile();
				//report.Render();
				//report.Show(true);
				//report.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
