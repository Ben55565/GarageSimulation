using System;

namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        private readonly Vehicle r_BasicDetails;
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(Vehicle i_BasicDetails, eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            r_BasicDetails = i_BasicDetails;
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + r_BasicDetails + "======== Motorcycle details ========" + Environment.NewLine + Environment.NewLine + "License type: {0}" + Environment.NewLine + "Engine capacity: {1}", r_LicenseType, r_EngineCapacity); ;
        }
    }
}
