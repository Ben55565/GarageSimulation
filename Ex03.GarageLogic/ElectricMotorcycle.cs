using System;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        internal ElectricVehicleDetails m_ElectricVehicleDetails;

        public ElectricMotorcycle(Vehicle i_VehicleBasicDetails, Motorcycle i_MotorcycleBasicDetails, ElectricVehicleDetails i_ElectricVehicleDetails)
            : base(i_VehicleBasicDetails, i_MotorcycleBasicDetails.r_LicenseType, i_MotorcycleBasicDetails.r_EngineCapacity)
        {
            m_ElectricVehicleDetails = i_ElectricVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an electric motorcycle! {0}" + Environment.NewLine + Environment.NewLine + "======== Electric Motorcycle details ========" + Environment.NewLine + "{1}" + Environment.NewLine, base.ToString(), m_ElectricVehicleDetails);
        }
    }
}
