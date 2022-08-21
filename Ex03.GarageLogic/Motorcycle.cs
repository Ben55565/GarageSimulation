using System;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        public eLicenseType r_LicenseType;
        public int r_EngineCapacity;

        public Motorcycle(Vehicle i_VehicleBasicDetails, eLicenseType i_LicenseType, int i_EngineCapacity)
        : base(i_VehicleBasicDetails.m_ModelName, i_VehicleBasicDetails.RegistrationId, i_VehicleBasicDetails.m_EnergyPercentageLeft, i_VehicleBasicDetails.m_Wheels, i_VehicleBasicDetails.OwnerDetails)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + base.ToString() + "======== Motorcycle details ========" + Environment.NewLine + Environment.NewLine + "License type: {0}" + Environment.NewLine + "Engine capacity: {1}", r_LicenseType, r_EngineCapacity);
        }
    }
}
