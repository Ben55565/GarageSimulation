using System;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        internal ElectricVehicleDetails m_ElectricVehicleDetails;

        public ElectricCar(Vehicle i_VehicleBasicDetails, Car i_CarBasicDetails, ElectricVehicleDetails i_ElectricVehicleDetails)
            : base(i_VehicleBasicDetails, i_CarBasicDetails.M_CarColor, i_CarBasicDetails.M_NumOfDoors)
        {
            m_ElectricVehicleDetails = i_ElectricVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an electric car! {0}" + Environment.NewLine + Environment.NewLine + "======== Electric Car details ========" + Environment.NewLine + "{1}" + Environment.NewLine, base.ToString(), m_ElectricVehicleDetails);
        }
    }
}
