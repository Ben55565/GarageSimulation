using System;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_TransportWithCooling;
        private readonly float r_MaxCargoWeight;

        public Truck(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails, FuelEngine i_Engine, bool i_TransportWithCooling, float i_MaxCargoWeight)
            : base(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_Wheels, i_OwnerDetails, i_Engine)
        {
            r_TransportWithCooling = i_TransportWithCooling;
            r_MaxCargoWeight = i_MaxCargoWeight;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}" +
                Environment.NewLine +
                Environment.NewLine +
                "======== Truck details ========" +
                Environment.NewLine +
                Environment.NewLine +
                "Is transporting with cooling? {1}" +
                Environment.NewLine +
                "Max cargo weight capacity: {2}" +
                Environment.NewLine,
                createVehicleDetailsMessage(),
                r_TransportWithCooling,
                r_MaxCargoWeight);
        }
    }
}