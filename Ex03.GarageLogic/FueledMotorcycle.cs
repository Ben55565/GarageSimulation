using System;

namespace Ex03.GarageLogic
{
    internal class FueledMotorcycle : Motorcycle
    {
        internal FueledVehicleDetails m_FueledVehicleDetails;

        public FueledMotorcycle(Vehicle i_VehicleBasicDetails, Motorcycle i_MotorcycleBasicDetails, FueledVehicleDetails i_FueledVehicleDetails)
        : base(i_VehicleBasicDetails, i_MotorcycleBasicDetails.r_LicenseType, i_MotorcycleBasicDetails.r_EngineCapacity)
        {
            m_FueledVehicleDetails = i_FueledVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an Fuel powered motorcycle! {0}" + Environment.NewLine + Environment.NewLine + "======== Fueled Motorcycle details ========" + Environment.NewLine + "{1}" + Environment.NewLine, base.ToString(), m_FueledVehicleDetails);
        }
    }
}
