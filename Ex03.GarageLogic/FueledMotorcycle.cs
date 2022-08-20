using System;

namespace Ex03.GarageLogic
{
    public class FueledMotorcycle
    {
        internal readonly Motorcycle r_MotorcycleBasicDetails;
        internal FueledVehicleDetails m_FueledVehicleDetails;

        public FueledMotorcycle(Motorcycle i_MotorcycleBasicDetails, FueledVehicleDetails i_FueledVehicleDetails)
        {
            this.r_MotorcycleBasicDetails = i_MotorcycleBasicDetails;
            this.m_FueledVehicleDetails = i_FueledVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an Fuel powered motorcycle! {0}" + Environment.NewLine + Environment.NewLine + "======== Fueled Motorcycle details ========" + Environment.NewLine + "{1}" + Environment.NewLine, r_MotorcycleBasicDetails, m_FueledVehicleDetails);
        }
    }
}
