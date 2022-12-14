using System;

namespace Ex03.GarageLogic
{
    public class OwnerDetailsAndStatus
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;

        public OwnerDetailsAndStatus(string i_OwnerName, string i_OwnerPhone, eVehicleStatus i_VehicleStatus)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            VehicleStatus = i_VehicleStatus;
        }

        public eVehicleStatus VehicleStatus { get; set; }

        public override string ToString()
        {
            return string.Format(
                Environment.NewLine +
                "======== Customer details ========" +
                Environment.NewLine +
                Environment.NewLine +
                "Owner Name: {0}" +
                Environment.NewLine +
                "Owner Phone number: {1}" +
                Environment.NewLine +
                "Vehicle current status: {2}" +
                Environment.NewLine,
                r_OwnerName,
                r_OwnerPhone,
                VehicleStatus.ToString());
        }
    }
}
