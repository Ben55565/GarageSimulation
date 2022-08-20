using System;

namespace Ex03.GarageLogic
{
    public class Truck
    {
        internal readonly Vehicle r_VehicleBasicDetails;
        private readonly bool r_TransportWithCooling;
        private readonly float r_MaxCargoWeight;
        internal FueledVehicleDetails m_FueledVehicleDetails;

        public Truck(Vehicle i_VehicleBasicDetails, bool i_TransportWithCooling, float i_MaxCargoWeight, FueledVehicleDetails i_FueledVehicleDetails)
        {
            r_VehicleBasicDetails = i_VehicleBasicDetails;
            r_TransportWithCooling = i_TransportWithCooling;
            r_MaxCargoWeight = i_MaxCargoWeight;
            m_FueledVehicleDetails = i_FueledVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage a Truck!" + Environment.NewLine + r_VehicleBasicDetails + "======== Truck details ========" + Environment.NewLine + Environment.NewLine + "Is transporting with cooling? {0}" + Environment.NewLine + "Max cargo weight capacity: {1}" + Environment.NewLine + "{2}" + Environment.NewLine, r_TransportWithCooling, r_MaxCargoWeight, m_FueledVehicleDetails);
        }
    }
}