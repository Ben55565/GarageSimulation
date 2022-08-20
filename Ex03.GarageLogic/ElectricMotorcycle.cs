using System;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle
    {
        internal readonly Motorcycle r_MotorcycleBasicDetails;
        internal ElectricVehicleDetails m_ElectricVehicleDetails;

        public ElectricMotorcycle(Motorcycle i_MotorcycleBasicDetails, ElectricVehicleDetails i_ElectricVehicleDetails)
        {
            this.r_MotorcycleBasicDetails = i_MotorcycleBasicDetails;
            this.m_ElectricVehicleDetails = i_ElectricVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an electric motorcycle! {0}" + Environment.NewLine + Environment.NewLine + "======== Electric Motorcycle details ========" + Environment.NewLine + "{1}" + Environment.NewLine, r_MotorcycleBasicDetails, m_ElectricVehicleDetails);
        }
    }
}
