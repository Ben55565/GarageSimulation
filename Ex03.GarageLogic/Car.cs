using System;

namespace Ex03.GarageLogic
{
    public class Car
    {
        internal readonly Vehicle r_VehicleBasicDetails;
        private readonly eCarColor r_CarColor;
        private readonly eNumOfDoors r_NumOfDoors;

        public Car(Vehicle i_VehicleBasicDetails, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        {
            r_VehicleBasicDetails = i_VehicleBasicDetails;
            r_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + r_VehicleBasicDetails + "======== Car details ========" + Environment.NewLine + Environment.NewLine + "Car color: {0}" + Environment.NewLine + "Number of doors: {1}", r_CarColor, r_NumOfDoors);
        }
    }
}