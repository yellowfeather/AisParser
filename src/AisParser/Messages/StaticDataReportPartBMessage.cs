namespace AisParser.Messages
{
    public class StaticDataReportPartBMessage : StaticDataReportMessage
    {
        public ShipType ShipType { get; set; }
        public string VendorId { get; set; }
        public uint UnitModelCode { get; set; }
        public uint SerialNumber { get; set; }
        public string CallSign { get; set; }
        public uint DimensionToBow { get; set; }
        public uint DimensionToStern { get; set; }
        public uint DimensionToPort { get; set; }
        public uint DimensionToStarboard { get; set; }
        public uint MothershipMmsi { get; set; }
        public uint Spare { get; set; }
    }
}