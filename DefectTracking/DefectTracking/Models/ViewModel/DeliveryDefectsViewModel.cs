
namespace DefectTracking.Models
{
    public class DeliveryDefectsViewModel
    {
        public int serialNumber { get; set; }
        public string? unitType { get; set; }
        public bool display { get; set; }
        public bool calibrationMissingCalibration { get; set; }
        public bool mechanicalAssemblyError { get; set; }
        public bool deadorDyingBatteries { get; set; }
        public bool pCBBoardDefect { get; set; }
        public bool speakerQuiet { get; set; }
        public bool noSound { get; set; }
        public bool switchNotWorking { get; set; }
        public bool buttonNotWorking { get; set; }
        public bool enclosureDefect { get; set; }
        public bool other { get; set; }
        public string? otherDesc { get; set; }
        public string? problemDesc { get; set; }
        
    }
}
