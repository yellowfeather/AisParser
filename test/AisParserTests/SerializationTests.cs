using AisParser;
using AisParser.Messages;
using Bogus;
using Shouldly;
using Xunit;

namespace AisParserTests
{
    public class SerializationTests
    {
        [Fact]
        public void Should_serialize_PositionReportClassAMessage()
        {
            var faker = new Faker();
            var aisMessage = new PositionReportClassAMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                NavigationStatus = faker.PickRandom<NavigationStatus>(),
                RateOfTurn = faker.Random.Int(),
                SpeedOverGround = faker.Random.UInt(),
                PositionAccuracy = faker.PickRandom<PositionAccuracy>(),
                Longitude = faker.Random.Double(),
                Latitude = faker.Random.Double(),
                CourseOverGround = faker.Random.Double(),
                TrueHeading = faker.Random.UInt(),
                Timestamp = faker.Random.UInt(),
                ManeuverIndicator = faker.PickRandom<ManeuverIndicator>(),
                Spare = faker.Random.UInt(),
                Raim = faker.PickRandom<Raim>(),
                RadioStatus = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.PositionReportClassA);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.NavigationStatus.ShouldBe(aisMessage.NavigationStatus);
            deserializedAisMessage.RateOfTurn.ShouldBe(aisMessage.RateOfTurn);
            deserializedAisMessage.SpeedOverGround.ShouldBe(aisMessage.SpeedOverGround);
            deserializedAisMessage.PositionAccuracy.ShouldBe(aisMessage.PositionAccuracy);
            deserializedAisMessage.Longitude.ShouldBe(aisMessage.Longitude);
            deserializedAisMessage.Latitude.ShouldBe(aisMessage.Latitude);
            deserializedAisMessage.CourseOverGround.ShouldBe(aisMessage.CourseOverGround);
            deserializedAisMessage.TrueHeading.ShouldBe(aisMessage.TrueHeading);
            deserializedAisMessage.Timestamp.ShouldBe(aisMessage.Timestamp);
            deserializedAisMessage.ManeuverIndicator.ShouldBe(aisMessage.ManeuverIndicator);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
            deserializedAisMessage.Raim.ShouldBe(aisMessage.Raim);
            deserializedAisMessage.RadioStatus.ShouldBe(aisMessage.RadioStatus);
        }

        [Fact]
        public void Should_serialize_PositionReportClassAAssignedScheduleMessage()
        {
            var faker = new Faker();
            var aisMessage = new PositionReportClassAAssignedScheduleMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                NavigationStatus = faker.PickRandom<NavigationStatus>(),
                RateOfTurn = faker.Random.Int(),
                SpeedOverGround = faker.Random.UInt(),
                PositionAccuracy = faker.PickRandom<PositionAccuracy>(),
                Longitude = faker.Random.Double(),
                Latitude = faker.Random.Double(),
                CourseOverGround = faker.Random.Double(),
                TrueHeading = faker.Random.UInt(),
                Timestamp = faker.Random.UInt(),
                ManeuverIndicator = faker.PickRandom<ManeuverIndicator>(),
                Spare = faker.Random.UInt(),
                Raim = faker.PickRandom<Raim>(),
                RadioStatus = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.PositionReportClassAAssignedSchedule);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.NavigationStatus.ShouldBe(aisMessage.NavigationStatus);
            deserializedAisMessage.RateOfTurn.ShouldBe(aisMessage.RateOfTurn);
            deserializedAisMessage.SpeedOverGround.ShouldBe(aisMessage.SpeedOverGround);
            deserializedAisMessage.PositionAccuracy.ShouldBe(aisMessage.PositionAccuracy);
            deserializedAisMessage.Longitude.ShouldBe(aisMessage.Longitude);
            deserializedAisMessage.Latitude.ShouldBe(aisMessage.Latitude);
            deserializedAisMessage.CourseOverGround.ShouldBe(aisMessage.CourseOverGround);
            deserializedAisMessage.TrueHeading.ShouldBe(aisMessage.TrueHeading);
            deserializedAisMessage.Timestamp.ShouldBe(aisMessage.Timestamp);
            deserializedAisMessage.ManeuverIndicator.ShouldBe(aisMessage.ManeuverIndicator);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
            deserializedAisMessage.Raim.ShouldBe(aisMessage.Raim);
            deserializedAisMessage.RadioStatus.ShouldBe(aisMessage.RadioStatus);
        }

        [Fact]
        public void Should_serialize_PositionReportClassAResponseToInterrogationMessage()
        {
            var faker = new Faker();
            var aisMessage = new PositionReportClassAResponseToInterrogationMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                NavigationStatus = faker.PickRandom<NavigationStatus>(),
                RateOfTurn = faker.Random.Int(),
                SpeedOverGround = faker.Random.UInt(),
                PositionAccuracy = faker.PickRandom<PositionAccuracy>(),
                Longitude = faker.Random.Double(),
                Latitude = faker.Random.Double(),
                CourseOverGround = faker.Random.Double(),
                TrueHeading = faker.Random.UInt(),
                Timestamp = faker.Random.UInt(),
                ManeuverIndicator = faker.PickRandom<ManeuverIndicator>(),
                Spare = faker.Random.UInt(),
                Raim = faker.PickRandom<Raim>(),
                RadioStatus = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.PositionReportClassAResponseToInterrogation);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.NavigationStatus.ShouldBe(aisMessage.NavigationStatus);
            deserializedAisMessage.RateOfTurn.ShouldBe(aisMessage.RateOfTurn);
            deserializedAisMessage.SpeedOverGround.ShouldBe(aisMessage.SpeedOverGround);
            deserializedAisMessage.PositionAccuracy.ShouldBe(aisMessage.PositionAccuracy);
            deserializedAisMessage.Longitude.ShouldBe(aisMessage.Longitude);
            deserializedAisMessage.Latitude.ShouldBe(aisMessage.Latitude);
            deserializedAisMessage.CourseOverGround.ShouldBe(aisMessage.CourseOverGround);
            deserializedAisMessage.TrueHeading.ShouldBe(aisMessage.TrueHeading);
            deserializedAisMessage.Timestamp.ShouldBe(aisMessage.Timestamp);
            deserializedAisMessage.ManeuverIndicator.ShouldBe(aisMessage.ManeuverIndicator);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
            deserializedAisMessage.Raim.ShouldBe(aisMessage.Raim);
            deserializedAisMessage.RadioStatus.ShouldBe(aisMessage.RadioStatus);
        }

        [Fact]
        public void Should_serialize_BaseStationReportMessage()
        {
            var faker = new Faker();
            var aisMessage = new BaseStationReportMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                Year = faker.Random.UInt(),
                Month = faker.Random.UInt(1, 12),
                Day = faker.Random.UInt(1, 31),
                Hour = faker.Random.UInt(0, 23),
                Minute = faker.Random.UInt(0, 59),
                Second = faker.Random.UInt(0, 59),
                PositionAccuracy = faker.PickRandom<PositionAccuracy>(),
                Longitude = faker.Random.Double(),
                Latitude = faker.Random.Double(),
                PositionFixType = faker.PickRandom<PositionFixType>(),
                Spare = faker.Random.UInt(),
                Raim = faker.PickRandom<Raim>(),
                RadioStatus = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.BaseStationReport);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.Year.ShouldBe(aisMessage.Year);
            deserializedAisMessage.Month.ShouldBe(aisMessage.Month);
            deserializedAisMessage.Day.ShouldBe(aisMessage.Day);
            deserializedAisMessage.Hour.ShouldBe(aisMessage.Hour);
            deserializedAisMessage.Minute.ShouldBe(aisMessage.Minute);
            deserializedAisMessage.Second.ShouldBe(aisMessage.Second);
            deserializedAisMessage.PositionAccuracy.ShouldBe(aisMessage.PositionAccuracy);
            deserializedAisMessage.Longitude.ShouldBe(aisMessage.Longitude);
            deserializedAisMessage.Latitude.ShouldBe(aisMessage.Latitude);
            deserializedAisMessage.PositionFixType.ShouldBe(aisMessage.PositionFixType);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
            deserializedAisMessage.Raim.ShouldBe(aisMessage.Raim);
            deserializedAisMessage.RadioStatus.ShouldBe(aisMessage.RadioStatus);
        }

        [Fact]
        public void Should_serialize_StaticAndVoyageRelatedDataMessage()
        {
            var faker = new Faker();
            var aisMessage = new StaticAndVoyageRelatedDataMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                AisVersion = faker.Random.UInt(),
                ImoNumber = faker.Random.UInt(),
                CallSign = faker.Lorem.Word(),
                ShipName = faker.Lorem.Word(),
                ShipType = faker.PickRandom<ShipType>(),
                DimensionToBow = faker.Random.UInt(),
                DimensionToStern = faker.Random.UInt(),
                DimensionToPort = faker.Random.UInt(),
                DimensionToStarboard = faker.Random.UInt(),
                PositionFixType = faker.PickRandom<PositionFixType>(),
                EtaMonth = faker.Random.UInt(1, 12),
                EtaDay = faker.Random.UInt(1, 31),
                EtaHour = faker.Random.UInt(0, 23),
                EtaMinute = faker.Random.UInt(0, 59),
                Draught = faker.Random.Double(),
                Destination = faker.Lorem.Word(),
                DataTerminalReady = faker.Random.Bool(),
                Spare = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.StaticAndVoyageRelatedData);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.AisVersion.ShouldBe(aisMessage.AisVersion);
            deserializedAisMessage.ImoNumber.ShouldBe(aisMessage.ImoNumber);
            deserializedAisMessage.CallSign.ShouldBe(aisMessage.CallSign);
            deserializedAisMessage.ShipName.ShouldBe(aisMessage.ShipName);
            deserializedAisMessage.ShipType.ShouldBe(aisMessage.ShipType);
            deserializedAisMessage.DimensionToBow.ShouldBe(aisMessage.DimensionToBow);
            deserializedAisMessage.DimensionToStern.ShouldBe(aisMessage.DimensionToStern);
            deserializedAisMessage.DimensionToPort.ShouldBe(aisMessage.DimensionToPort);
            deserializedAisMessage.DimensionToStarboard.ShouldBe(aisMessage.DimensionToStarboard);
            deserializedAisMessage.PositionFixType.ShouldBe(aisMessage.PositionFixType);
            deserializedAisMessage.EtaMonth.ShouldBe(aisMessage.EtaMonth);
            deserializedAisMessage.EtaDay.ShouldBe(aisMessage.EtaDay);
            deserializedAisMessage.EtaHour.ShouldBe(aisMessage.EtaHour);
            deserializedAisMessage.EtaMinute.ShouldBe(aisMessage.EtaMinute);
            deserializedAisMessage.Draught.ShouldBe(aisMessage.Draught);
            deserializedAisMessage.Destination.ShouldBe(aisMessage.Destination);
            deserializedAisMessage.DataTerminalReady.ShouldBe(aisMessage.DataTerminalReady);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
        }

        [Fact]
        public void Should_serialize_StandardClassBCsPositionReportMessage()
        {
            var faker = new Faker();
            var aisMessage = new StandardClassBCsPositionReportMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                SpeedOverGround = faker.Random.UInt(),
                PositionAccuracy = faker.PickRandom<PositionAccuracy>(),
                Longitude = faker.Random.Double(),
                Latitude = faker.Random.Double(),
                CourseOverGround = faker.Random.Double(),
                TrueHeading = faker.Random.UInt(),
                Timestamp = faker.Random.UInt(),
                IsCsUnit = faker.Random.Bool(),
                HasDisplay = faker.Random.Bool(),
                HasDscCapability = faker.Random.Bool(),
                Band = faker.Random.Bool(),
                CanAcceptMessage22 = faker.Random.Bool(),
                Assigned = faker.Random.Bool(),
                Raim = faker.PickRandom<Raim>(),
                RadioStatus = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.StandardClassBCsPositionReport);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.SpeedOverGround.ShouldBe(aisMessage.SpeedOverGround);
            deserializedAisMessage.PositionAccuracy.ShouldBe(aisMessage.PositionAccuracy);
            deserializedAisMessage.Longitude.ShouldBe(aisMessage.Longitude);
            deserializedAisMessage.Latitude.ShouldBe(aisMessage.Latitude);
            deserializedAisMessage.CourseOverGround.ShouldBe(aisMessage.CourseOverGround);
            deserializedAisMessage.TrueHeading.ShouldBe(aisMessage.TrueHeading);
            deserializedAisMessage.Timestamp.ShouldBe(aisMessage.Timestamp);
            deserializedAisMessage.IsCsUnit.ShouldBe(aisMessage.IsCsUnit);
            deserializedAisMessage.HasDisplay.ShouldBe(aisMessage.HasDisplay);
            deserializedAisMessage.HasDscCapability.ShouldBe(aisMessage.HasDscCapability);
            deserializedAisMessage.Band.ShouldBe(aisMessage.Band);
            deserializedAisMessage.CanAcceptMessage22.ShouldBe(aisMessage.CanAcceptMessage22);
            deserializedAisMessage.Assigned.ShouldBe(aisMessage.Assigned);
            deserializedAisMessage.Raim.ShouldBe(aisMessage.Raim);
            deserializedAisMessage.RadioStatus.ShouldBe(aisMessage.RadioStatus);
        }

        [Fact]
        public void Should_serialize_AidToNavigationReportMessage()
        {
            var faker = new Faker();
            var aisMessage = new AidToNavigationReportMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                NavigationalAidType = faker.PickRandom<NavigationalAidType>(),
                Name = faker.Lorem.Word(),
                PositionAccuracy = faker.PickRandom<PositionAccuracy>(),
                Longitude = faker.Random.Double(),
                Latitude = faker.Random.Double(),
                DimensionToBow = faker.Random.UInt(),
                DimensionToStern = faker.Random.UInt(),
                DimensionToPort = faker.Random.UInt(),
                DimensionToStarboard = faker.Random.UInt(),
                PositionFixType = faker.PickRandom<PositionFixType>(),
                Timestamp = faker.Random.UInt(),
                OffPosition = faker.Random.Bool(),
                Raim = faker.PickRandom<Raim>(),
                VirtualAid = faker.Random.Bool(),
                Assigned = faker.Random.Bool(),
                Spare = faker.Random.UInt(),
                NameExtension = faker.Lorem.Word()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.AidToNavigationReport);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.NavigationalAidType.ShouldBe(aisMessage.NavigationalAidType);
            deserializedAisMessage.Name.ShouldBe(aisMessage.Name);
            deserializedAisMessage.PositionAccuracy.ShouldBe(aisMessage.PositionAccuracy);
            deserializedAisMessage.Longitude.ShouldBe(aisMessage.Longitude);
            deserializedAisMessage.Latitude.ShouldBe(aisMessage.Latitude);
            deserializedAisMessage.DimensionToBow.ShouldBe(aisMessage.DimensionToBow);
            deserializedAisMessage.DimensionToStern.ShouldBe(aisMessage.DimensionToStern);
            deserializedAisMessage.DimensionToPort.ShouldBe(aisMessage.DimensionToPort);
            deserializedAisMessage.DimensionToStarboard.ShouldBe(aisMessage.DimensionToStarboard);
            deserializedAisMessage.PositionFixType.ShouldBe(aisMessage.PositionFixType);
            deserializedAisMessage.Timestamp.ShouldBe(aisMessage.Timestamp);
            deserializedAisMessage.OffPosition.ShouldBe(aisMessage.OffPosition);
            deserializedAisMessage.Raim.ShouldBe(aisMessage.Raim);
            deserializedAisMessage.VirtualAid.ShouldBe(aisMessage.VirtualAid);
            deserializedAisMessage.Assigned.ShouldBe(aisMessage.Assigned);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
            deserializedAisMessage.NameExtension.ShouldBe(aisMessage.NameExtension);
        }

        [Fact]
        public void Should_serialize_DataLinkManagementMessage()
        {
            var faker = new Faker();
            var aisMessage = new DataLinkManagementMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                Spare = faker.Random.UInt(),
                Offset1 = faker.Random.UInt(),
                ReservedSlots1 = faker.Random.UInt(),
                Timeout1 = faker.Random.UInt(),
                Increment1 = faker.Random.UInt(),
                Offset2 = faker.Random.UInt(),
                ReservedSlots2 = faker.Random.UInt(),
                Timeout2 = faker.Random.UInt(),
                Increment2 = faker.Random.UInt(),
                Offset3 = faker.Random.UInt(),
                ReservedSlots3 = faker.Random.UInt(),
                Timeout3 = faker.Random.UInt(),
                Increment3 = faker.Random.UInt(),
                Offset4 = faker.Random.UInt(),
                ReservedSlots4 = faker.Random.UInt(),
                Timeout4 = faker.Random.UInt(),
                Increment4 = faker.Random.UInt(),
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.DataLinkManagement);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
            deserializedAisMessage.Offset1.ShouldBe(aisMessage.Offset1);
            deserializedAisMessage.ReservedSlots1.ShouldBe(aisMessage.ReservedSlots1);
            deserializedAisMessage.Timeout1.ShouldBe(aisMessage.Timeout1);
            deserializedAisMessage.Increment1.ShouldBe(aisMessage.Increment1);
            deserializedAisMessage.Offset2.ShouldBe(aisMessage.Offset2);
            deserializedAisMessage.ReservedSlots2.ShouldBe(aisMessage.ReservedSlots2);
            deserializedAisMessage.Timeout2.ShouldBe(aisMessage.Timeout2);
            deserializedAisMessage.Increment2.ShouldBe(aisMessage.Increment2);
            deserializedAisMessage.Offset3.ShouldBe(aisMessage.Offset3);
            deserializedAisMessage.ReservedSlots3.ShouldBe(aisMessage.ReservedSlots3);
            deserializedAisMessage.Timeout3.ShouldBe(aisMessage.Timeout3);
            deserializedAisMessage.Increment3.ShouldBe(aisMessage.Increment3);
            deserializedAisMessage.Offset4.ShouldBe(aisMessage.Offset4);
            deserializedAisMessage.ReservedSlots4.ShouldBe(aisMessage.ReservedSlots4);
            deserializedAisMessage.Timeout4.ShouldBe(aisMessage.Timeout4);
            deserializedAisMessage.Increment4.ShouldBe(aisMessage.Increment4);
        }

        [Fact]
        public void Should_serialize_StaticDataReportPartAMessage()
        {
            var faker = new Faker();
            var aisMessage = new StaticDataReportPartAMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                ShipName = faker.Lorem.Word(),
                Spare = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.StaticDataReport);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.PartNumber.ShouldBe(aisMessage.PartNumber);
            deserializedAisMessage.ShipName.ShouldBe(aisMessage.ShipName);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
        }

        [Fact]
        public void Should_serialize_StaticDataReportPartBMessage()
        {
            var faker = new Faker();
            var aisMessage = new StaticDataReportPartBMessage
            {
                Repeat = faker.Random.UInt(),
                Mmsi = faker.Random.UInt(),
                ShipType = faker.PickRandom<ShipType>(),
                VendorId = faker.Lorem.Word(),
                UnitModelCode = faker.Random.UInt(),
                SerialNumber = faker.Random.UInt(),
                CallSign = faker.Random.Word(),
                DimensionToBow = faker.Random.UInt(),
                DimensionToStern = faker.Random.UInt(),
                DimensionToPort = faker.Random.UInt(),
                DimensionToStarboard = faker.Random.UInt(),
                Spare = faker.Random.UInt()
            };

            var deserializedAisMessage = Serialize(aisMessage);

            deserializedAisMessage.ShouldNotBeNull();
            deserializedAisMessage.MessageType.ShouldBe(AisMessageType.StaticDataReport);
            deserializedAisMessage.Repeat.ShouldBe(aisMessage.Repeat);
            deserializedAisMessage.Mmsi.ShouldBe(aisMessage.Mmsi);
            deserializedAisMessage.PartNumber.ShouldBe(aisMessage.PartNumber);
            deserializedAisMessage.ShipType.ShouldBe(aisMessage.ShipType);
            deserializedAisMessage.VendorId.ShouldBe(aisMessage.VendorId);
            deserializedAisMessage.UnitModelCode.ShouldBe(aisMessage.UnitModelCode);
            deserializedAisMessage.SerialNumber.ShouldBe(aisMessage.SerialNumber);
            deserializedAisMessage.CallSign.ShouldBe(aisMessage.CallSign);
            deserializedAisMessage.DimensionToBow.ShouldBe(aisMessage.DimensionToBow);
            deserializedAisMessage.DimensionToStern.ShouldBe(aisMessage.DimensionToStern);
            deserializedAisMessage.DimensionToPort.ShouldBe(aisMessage.DimensionToPort);
            deserializedAisMessage.DimensionToStarboard.ShouldBe(aisMessage.DimensionToStarboard);
            deserializedAisMessage.Spare.ShouldBe(aisMessage.Spare);
        }

        private static T Serialize<T>(T aisMessage) where T : AisMessage
        {
            var json = AisMessageJsonConvert.Serialize(aisMessage);
            return AisMessageJsonConvert.Deserialize(json) as T;
        }
    }
}