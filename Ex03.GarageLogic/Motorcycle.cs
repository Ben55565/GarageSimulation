using System;

namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        internal readonly Vehicle r_VehicleBasicDetails;
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(Vehicle i_VehicleBasicDetails, eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            r_VehicleBasicDetails = i_VehicleBasicDetails;
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + r_VehicleBasicDetails + "======== Motorcycle details ========" + Environment.NewLine + Environment.NewLine + "License type: {0}" + Environment.NewLine + "Engine capacity: {1}", r_LicenseType, r_EngineCapacity);
        }
    }
}
