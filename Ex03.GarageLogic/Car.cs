using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public eCarColor M_CarColor;
        public eNumOfDoors M_NumOfDoors;
        private readonly string r_ElectricOrFueledDetails;

        public Car(Vehicle i_VehicleBasicDetails, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        : base(i_VehicleBasicDetails)
        {
            M_CarColor = i_CarColor;
            M_NumOfDoors = i_NumOfDoors;
            string vehicleDetailsMessage = string.Format(Environment.NewLine + base.ToString() + "======== Car details ========" + Environment.NewLine + Environment.NewLine + "Car color: {0}" + Environment.NewLine + "Number of doors: {1}", M_CarColor, M_NumOfDoors);
            r_ElectricOrFueledDetails = i_VehicleBasicDetails.m_electricEngine == null ? string.Format(Environment.NewLine + "You have checked in to our garage an Fueled car!" + Environment.NewLine + Environment.NewLine + "======== Fueled Car details ========" + Environment.NewLine + "{0}" + Environment.NewLine, vehicleDetailsMessage) : string.Format(Environment.NewLine + "You have checked in to our garage an electric car!" + Environment.NewLine + Environment.NewLine + "======== Electric Car details ========" + Environment.NewLine + "{0}" + Environment.NewLine, vehicleDetailsMessage);
        }

        public override string ToString()
        {
            return r_ElectricOrFueledDetails;
        }
    }
}