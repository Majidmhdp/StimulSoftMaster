using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Export;
using StimulTest.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace StimulTest.Utility
{
	class Report
	{
		public static void ReportShow(string reportName, DataTable dtReport, Dictionary<string, string> parameters,
			bool direct)
		{
			try
			{
				StiReport report = new StiReport();
				report.Load("Reports\\" + reportName + ".mrt");

				dtReport.TableName = "df";
				//dtReport.DefaultView.Sort = FrmGridSorter._Sort;
				DataSet ds_Sort = new DataSet();

				ds_Sort.Tables.Add(dtReport.DefaultView.ToTable());
				ds_Sort.Tables[0].TableName = "df";
				report.RegData(ds_Sort.Tables[0].TableName, ds_Sort);
				report.Dictionary.Synchronize();

				dtReport.TableName = "df";
				report.RegData(dtReport);
				report.Dictionary.Synchronize();


				StiPage p = report.Pages[0];

				StiDataBand dataBand = report.GetComponents()["DataBand1"] as StiDataBand;
				dataBand.DataSourceName = dtReport.TableName;

				//StiImage image = report.GetComponents()["LogoImage"] as StiImage;
				//image.Image = global::Mesghal.Properties.Resources.logo;

				if (parameters.Count > 0)
					foreach (KeyValuePair<string, string> item in parameters)
					{
						string paramName = item.Key;
						string paramValue = item.Value;
						if (paramValue != null)
						{
							StiText txt = report.GetComponents()[paramName] as StiText;
							if (txt != null)
							{
								txt.Text = paramValue;
								txt.TextOptions.RightToLeft = true;
							}
						}

					}

				report.Compile();

				if (direct)
					report.Print();
				else
				{
					report.Show(true);
				}

				report.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public static StiReport ShowHeader()
		{
			StiReport report = new StiReport();
			try
			{
				
				report.Load("Reports\\Header.mrt");

				Dictionary<string, string> parameters = new Dictionary<string, string>
				{
					{ "COMPANY_NAME", "PERFECT IMAGE + SDN BHD" },
					{ "TAX_FILE_NO", "C2018512710" },
					{ "YEAR_OF_ASSESSMENT", "2021" },
					{ "BASIS_PERIOD", "18/01/2021 To 31/12/2021" },
				};

				if (parameters.Count > 0)
					foreach (KeyValuePair<string, string> item in parameters)
					{
						report.Dictionary.Variables[item.Key].Value = item.Value;

						//                    string paramName = item.Key;
						//                    string paramValue = item.Value;
						//                    if (paramValue != null)
						//                    {
						//                        StiText txt = report.GetComponents()[paramName] as StiText;
						//                        if (txt != null)
						//                        {
						//                            txt.Text = paramValue;
						//                            txt.TextOptions.RightToLeft = true;
						//                        }
						//                    }
					}

				

				// report.Compile();

				//if (direct)
				//    report.Print();
				//else
				//{
				// report.Show(true);
				//}
				//report.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return report;
		}

		public static StiReport ShowMain()
		{
			StiReport report = new StiReport();
			try
			{

				report.Load("Reports\\Report.mrt");

				var header = Report.ShowHeader();
				//header.Compile();

				// report.SubReports.Add(report1);
				//report.SubReports.Add(header);
				//header.Compile();
				//header.Render();
				//report["SubReportHeader"] = header;

				StiSubReport subHeader = report.GetComponents()["SubReport1"] as StiSubReport;
				//subHeader.UseExternalReport = true;
				subHeader.CanGrow = true;
				header.Render();
				subHeader.Report = header;

				//header.Render();

				//subHeader.Report = header;
				//subHeader.Render();


				//report.Compile();
				//report.Show(true);
				//report.Dispose();

				//var loanToDirector = Report.ShowLoanToDirector();
				//report.SubReports.Add(loanToDirector);

				//var temp = ShowLoanToDirector();

				//report.GetSubReport += new StiGetSubReportEventHandler((object sender, StiGetSubReportEventArgs e) =>
				//{
				//	e.Report = ShowLoanToDirector();
				//});

				//StiSubReport subHeader = report.GetComponents()["SubNstSummary"] as StiSubReport;
				//subHeader.Enabled = true;
				//subHeader.Report = temp;

				//subHeader.UseExternalReport = true;



				//Stimulsoft.Report.Components.StiSubReport SubReport1 = new Stimulsoft.Report.Components.StiSubReport();
				////SubReport1.ClientRectangle = new Stimulsoft.Base.Drawing.RectangleD(0, 0, 7.7, 0.5);
				//SubReport1.Name = "SubNstSummary";
				//SubReport1.UseExternalReport = true;

				//report.Render();
				//report.Design();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return report;
		}

		public static StiReport ShowAnalysisOfAccount(AnalysisOfAccount data)
		{
			StiReport report = new StiReport();
			try
			{

				report.Load("Reports\\AnalysisOfAccount.mrt");

				
				report.Dictionary.Variables["COMPANY_NAME"].Value = data.CompanyName;
				report.Dictionary.Variables["TAX_FILE_NO"].Value = data.TaxFileNo;
				report.Dictionary.Variables["YEAR_OF_ASSESSMENT"].Value = data.YearOfAssessment;
				report.Dictionary.Variables["BASIS_PERIOD"].Value = data.BasisPeriod;
				report.Dictionary.Variables["SCHEDULE"].Value = data.Schedule;
				report.Dictionary.Variables["REPORT_TITLE"].Value = data.ReportTitle;


				DataTable dtReport = new DataTable("LoanToDirectorDataset");

				dtReport.Columns.Add("Id", typeof(Int32));
				dtReport.Columns.Add("CategoryId", typeof(Int32));
				dtReport.Columns.Add("Month", typeof(String));
				dtReport.Columns.Add("LoanBalance", typeof(String));
				dtReport.Columns.Add("LendingRate", typeof(String));
				dtReport.Columns.Add("DirectorRate", typeof(String));
				dtReport.Columns.Add("Deemed", typeof(String));
				dtReport.Columns.Add("RM", typeof(Double));
				dtReport.Columns.Add("Title", typeof(String));
				dtReport.Columns.Add("Extra", typeof(String));

				DataTable dtReportCat = new DataTable("LoanToDirectorDataset");

				dtReportCat.Columns.Add("Id", typeof(Int32));
				dtReportCat.Columns.Add("Title", typeof(String));

				int Id = 1;
				int Cat = 1;
				foreach (var item in data.Data.Where(s=>s.Id == "2"))
				{
					try
					{
						//"Id": "2",
						//"Title": "Loan to Directors",
						//"SubTitle": "Loan to director\nName: Tan Ah Kau\nI/C: 09127802840480",
						//"RM": 287,
						//"Percent": "",
						//"Remarks": "",
						//"Comment": "* - Computation based on Interest Rates published by Bank Negara in Jul 2021;",
						//"Data": [

						//{
						//	"Title": "1/2021 %^% 100,000 %^% 3.44 ^%^ 0.00 ^%^ 100,000 x 3.44 % x 1/12",
						//	"RM": 287,
						//	"Percent": "",
						//	"Remarks": ""

						//}
						DataRow temp = dtReportCat.NewRow();
						temp["Id"] = Cat;
						temp["Title"] = item.SubTitle;

						dtReportCat.Rows.Add(temp);

						foreach (var subItem in item.Data)
						{
							string[] words = subItem.Title.Split('^');

							DataRow row = dtReport.NewRow();
							row["Id"] = Id++;
							row["CategoryId"] = Cat;
							
							row["Month"] = words[0];
							row["LoanBalance"] = words[1];
							row["LendingRate"] = words[2];
							row["DirectorRate"] = words[3];
							row["Deemed"] = words[4];
							row["RM"] = subItem.RM;
							row["Title"] = item.SubTitle;
							row["Extra"] = item.Comment;

							dtReport.Rows.Add(row);
						}

						Cat++;
					}
					catch { }
				}

				dtReport.TableName = "LoanToDirectorDataset";
				report.RegData("LoanToDirectorDataset", dtReport);
				report.Dictionary.Synchronize();

				StiDataBand dataBand2 = report.GetComponents()["DataBand2"] as StiDataBand;
				dataBand2.DataSourceName = "LoanToDirectorDataset";

				dtReportCat.TableName = "LoanToDirectorCatDataSet";
				report.RegData("LoanToDirectorCatDataSet", dtReportCat);
				report.Dictionary.Synchronize();
				StiDataBand dataBand1 = report.GetComponents()["DataBand1"] as StiDataBand;
				dataBand1.DataSourceName = "LoanToDirectorCatDataSet";

				
				
				//report.Render();
				//StiPdfExportSettings pdfSettings = new StiPdfExportSettings();
				//report.ExportDocument(StiExportFormat.Pdf, "MyReport.Pdf", pdfSettings);

				report.Compile();
				report.Show(true);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return report;
		}

		

		public static StiReport ShowLoanToDirector()
		{
			StiReport report = new StiReport();
			try
			{

				report.Load("Reports\\LoanToDirector.mrt");

				//Dictionary<string, string> parameters = new Dictionary<string, string>
				//{
				//	{ "COMPANY_NAME", "PERFECT IMAGE + SDN BHD" },
				//	{ "TAX_FILE_NO", "C2018512710" },
				//	{ "YEAR_OF_ASSESSMENT", "2021" },
				//	{ "BASIS_PERIOD", "18/01/2021 To 31/12/2021" },
				//};

				//if (parameters.Count > 0)
				//	foreach (KeyValuePair<string, string> item in parameters)
				//	{
				//		report.Dictionary.Variables[item.Key].Value = item.Value;

				//		//                    string paramName = item.Key;
				//		//                    string paramValue = item.Value;
				//		//                    if (paramValue != null)
				//		//                    {
				//		//                        StiText txt = report.GetComponents()[paramName] as StiText;
				//		//                        if (txt != null)
				//		//                        {
				//		//                            txt.Text = paramValue;
				//		//                            txt.TextOptions.RightToLeft = true;
				//		//                        }
				//		//                    }
				//	}



				// report.Compile();

				//if (direct)
				//    report.Print();
				//else
				//{
				// report.Show(true);
				//}
				//report.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return report;
		}
	}
}
