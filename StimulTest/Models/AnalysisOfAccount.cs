using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StimulTest.Models
{
	public class AnalysisOfAccount
	{
		public string CompanyName { get; set; }
		public string TaxFileNo { get; set; }
		public string YearOfAssessment { get; set; }
		public string BasisPeriod { get; set; }
		public string Schedule { get; set; }
		public string ReportTitle { get; set; }
		public List<Datum> Data { get; set; }
	}

	public class Datum
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public int RM { get; set; }
		public string Percent { get; set; }
		public string Remarks { get; set; }
		public string Comment { get; set; }
		public List<Datum> Data { get; set; }
	}

}
