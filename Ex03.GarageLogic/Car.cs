using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public eCarColor M_CarColor;
        public eNumOfDoors M_NumOfDoors;

        public Car(Vehicle i_VehicleBasicDetails, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
            : base(i_VehicleBasicDetails.m_ModelName, i_VehicleBasicDetails.RegistrationId, i_VehicleBasicDetails.m_EnergyPercentageLeft, i_VehicleBasicDetails.m_Wheels, i_VehicleBasicDetails.OwnerDetails)
        {
            M_CarColor = i_CarColor;
            M_NumOfDoors = i_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + base.ToString() + "======== Car details ========" + Environment.NewLine + Environment.NewLine + "Car color: {0}" + Environment.NewLine + "Number of doors: {1}", M_CarColor, M_NumOfDoors);
        }
    }
}