using System.ComponentModel;
using System.Data.SqlClient;

namespace DefectTracking.Models
{
    public class DeliveryDefects
    {
        public int Id { get; set; }
		[DisplayName("Serial Number")]
		public int SerialNumber { get; set; }
		[DisplayName("Unit Type")]
		public string? UnitType { get; set; }
		public int Display { get; set; }
		[DisplayName("Calibration/Missing Calibration")]
		public int CalibrationMissingCalibration { get; set; }
		[DisplayName("Mechanical Assembly Error")]
		public int MechanicalAssemblyError { get; set; }
		[DisplayName("Dead or Dying Batteries")]
		public int DeadorDyingBatteries { get; set; }
		[DisplayName("PCB Board Defect")]
		public int PCBBoardDefect { get; set; }
		[DisplayName("Speaker Quiet")]
		public int SpeakerQuiet { get; set; }
		[DisplayName("No Sound")]
		public int NoSound { get; set; }
		[DisplayName("Switch Not Working")]
		public int SwitchNotWorking { get; set; }
		[DisplayName("Button Not Working")]
		public int ButtonNotWorking { get; set; }
		[DisplayName("Enclosure Defect")]
		public int EnclosureDefect { get; set; }
		public int Other { get; set; }
		[DisplayName("Other Description")]
		public string? OtherDesc { get; set; }
		[DisplayName("Units Problem Description")]
		public string? ProblemDesc { get; set; }
		public DateTime Date { get; set; }

		public int SaveDetails()
        {
            SqlConnection con = new SqlConnection("Server=P3NWPLSK12SQL-v13.shr.prod.phx3.secureserver.net;Database=9CI_DATABASE;User Id=ADMINIVD;Password=LatinSinner8372!;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=False;Encrypt=True;");
            string query = "INSERT INTO DeliveryDefects(SerialNumber, UnitType, Display, CalibrationMissingCalibration, MechanicalAssemblyError, DeadorDyingBatteries, " +
                "PCBBoardDefect, SpeakerQuiet, NoSound, SwitchNotWorking, ButtonNotWorking, EnclosureDefect, Other, OtherDesc, ProblemDesc, Date) " +
                "values ('" + SerialNumber + "', '" + UnitType + "', '" + Display + "', '" +
                CalibrationMissingCalibration + "', '" + MechanicalAssemblyError + "', '" + DeadorDyingBatteries + "', '" +
                PCBBoardDefect + "', '" + SpeakerQuiet + "', '" + NoSound + "', '" + SwitchNotWorking + "', '" + ButtonNotWorking +
				"', '" + EnclosureDefect + "', '" + Other + "', '" + OtherDesc + "', '" + ProblemDesc + "', '" + Date + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
