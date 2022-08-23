using System;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        public eLicenseType r_LicenseType;
        public int r_EngineCapacity;
        private readonly string r_ElectricOrFueledDetails;

        public Motorcycle(Vehicle i_VehicleBasicDetails, eLicenseType i_LicenseType, int i_EngineCapacity)
        : base(i_VehicleBasicDetails)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
            string vehicleDetailsMessage = string.Format(Environment.NewLine + base.ToString() + "======== Motorcycle details ========" + Environment.NewLine + Environment.NewLine + "License type: {0}" + Environment.NewLine + "Engine capacity: {1}", r_LicenseType, r_EngineCapacity);
            r_ElectricOrFueledDetails = i_VehicleBasicDetails.m_electricEngine == null ? string.Format(Environment.NewLine + "You have checked in to our garage an Fuel powered motorcycle!" + Environment.NewLine + Environment.NewLine + "======== Fueled Motorcycle details ========" + Environment.NewLine + "{0}" + Environment.NewLine,  vehicleDetailsMessage) : string.Format(Environment.NewLine + "You have checked in to our garage an electric motorcycle!" + Environment.NewLine + Environment.NewLine + "======== Electric Motorcycle details ========" + Environment.NewLine + "{0}" + Environment.NewLine, vehicleDetailsMessage);
        }

        public override string ToString()
        {
            return r_ElectricOrFueledDetails;
        }
    }
}
