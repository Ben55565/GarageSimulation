using System;

namespace Ex03.GarageLogic
{
    public class Truck
    {
        private readonly float r_MaxFuelCapacity;
        internal readonly Vehicle r_BasicDetails;
        private readonly bool r_TransportWithCooling;
        private readonly float r_MaxCargoWeight;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelStatus;

        public Truck(Vehicle i_BasicDetails, bool i_TransportWithCooling, float i_MaxCargoWeight, eFuelType i_FuelType, float i_CurrentFuelStatus, float i_MaxFuelCapacity)
        {
            r_BasicDetails = i_BasicDetails;
            r_TransportWithCooling = i_TransportWithCooling;
            r_MaxCargoWeight = i_MaxCargoWeight;
            this.r_FuelType = i_FuelType;
            this.m_CurrentFuelStatus = i_CurrentFuelStatus;
            this.r_MaxFuelCapacity = i_MaxFuelCapacity;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage a Truck!" + Environment.NewLine + r_BasicDetails + "======== Truck details ========" + Environment.NewLine + Environment.NewLine + "Is transporting with cooling? {0}" + Environment.NewLine + "Max cargo weight capacity: {1}", r_TransportWithCooling, r_MaxCargoWeight);
        }
    }
}