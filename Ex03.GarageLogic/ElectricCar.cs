using System;

namespace Ex03.GarageLogic
{
    public class ElectricCar
    {
        internal readonly Car r_CarBasicDetails;
        internal ElectricVehicleDetails m_ElectricVehicleDetails;

        public ElectricCar(Car i_CarBasicDetails, ElectricVehicleDetails i_ElectricVehicleDetails)
        {
            this.r_CarBasicDetails = i_CarBasicDetails;
            this.m_ElectricVehicleDetails = i_ElectricVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an electric car! {0}" + Environment.NewLine + Environment.NewLine + "======== Electric Car details ========" + Environment.NewLine + "{1}" + Environment.NewLine, r_CarBasicDetails, m_ElectricVehicleDetails);
        }
    }
}
