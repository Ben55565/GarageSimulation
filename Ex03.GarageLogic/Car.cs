using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eCarColor r_CarColor;
        private readonly eNumOfDoors r_NumOfDoors;

        public Car(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails, object i_Engine, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        : base(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_Wheels, i_OwnerDetails, i_Engine)
        {
            r_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}" +
                Environment.NewLine +
                Environment.NewLine +
                "======== Car details ========" +
                Environment.NewLine +
                Environment.NewLine +
                "The car Color: {1}" +
                Environment.NewLine +
                "The car amount of doors: {2}",
                createVehicleDetailsMessage(),
                r_CarColor.ToString(),
                r_NumOfDoors.ToString());
        }
    }
}