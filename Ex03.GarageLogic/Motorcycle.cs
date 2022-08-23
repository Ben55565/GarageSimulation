using System;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails, object i_Engine, eLicenseType i_LicenseType, int i_EngineCapacity)
            : base(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_Wheels, i_OwnerDetails, i_Engine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}" +
                Environment.NewLine +
                Environment.NewLine +
                "======== Motorcycle details ========" +
                Environment.NewLine +
                Environment.NewLine +
                "Motorcycle license type: {1}" +
                Environment.NewLine +
                " Motorcycle Engine capacity: {2}",
                createVehicleDetailsMessage(),
                r_LicenseType.ToString(),
                r_EngineCapacity.ToString());
        }
    }
}
