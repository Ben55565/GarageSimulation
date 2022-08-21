using System;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_TransportWithCooling;
        private readonly float r_MaxCargoWeight;
        internal FueledVehicleDetails m_FueledVehicleDetails;

        public Truck(Vehicle i_VehicleBasicDetails, bool i_TransportWithCooling, float i_MaxCargoWeight, FueledVehicleDetails i_FueledVehicleDetails)
            : base(i_VehicleBasicDetails.m_ModelName, i_VehicleBasicDetails.RegistrationId, i_VehicleBasicDetails.m_EnergyPercentageLeft, i_VehicleBasicDetails.m_Wheels, i_VehicleBasicDetails.OwnerDetails)
        {
            r_TransportWithCooling = i_TransportWithCooling;
            r_MaxCargoWeight = i_MaxCargoWeight;
            m_FueledVehicleDetails = i_FueledVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage a Truck!" + Environment.NewLine + base.ToString() + "======== Truck details ========" + Environment.NewLine + Environment.NewLine + "Is transporting with cooling? {0}" + Environment.NewLine + "Max cargo weight capacity: {1}" + Environment.NewLine + "{2}" + Environment.NewLine, r_TransportWithCooling, r_MaxCargoWeight, m_FueledVehicleDetails);
        }
    }
}