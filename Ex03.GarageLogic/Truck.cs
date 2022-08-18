using System;

namespace Ex03.GarageLogic
{
    public class Truck
    {
        private readonly Vehicle r_BasicDetails;
        private readonly bool r_TransportWithCooling;
        private readonly float r_MaxCargoWeight;

        public Truck(Vehicle i_BasicDetails, bool i_TransportWithCooling, float i_MaxCargoWeight)
        {
            r_BasicDetails = i_BasicDetails;
            r_TransportWithCooling = i_TransportWithCooling;
            r_MaxCargoWeight = i_MaxCargoWeight;
        }

        public override string ToString()
        {
            string output = string.Format(Environment.NewLine + "You have checked in to our garage an Fueled motorcycle!" + Environment.NewLine + r_BasicDetails + "======== Truck details ========" + Environment.NewLine + Environment.NewLine + "Is transporting with cooling? {0}" + Environment.NewLine + "Max cargo weight capacity: {1}", r_TransportWithCooling, r_MaxCargoWeight);
            return output;
        }
    }
}