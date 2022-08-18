using System;

namespace Ex03.GarageLogic
{
    public class Car
    {
        private readonly Vehicle r_BasicDetails;
        private readonly eCarColor r_CarColor;
        private readonly eNumOfDoors r_NumOfDoors;

        public Car(Vehicle i_BasicDetails, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        {
            r_BasicDetails = i_BasicDetails;
            r_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }

        public override string ToString()
        {
            string output = string.Format(Environment.NewLine + r_BasicDetails + "======== Car details ========" + Environment.NewLine + Environment.NewLine + "Car color: {0}" + Environment.NewLine + "Number of doors: {1}", r_CarColor, r_NumOfDoors);
            return output;
        }
    }
}