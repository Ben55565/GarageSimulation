using System;

namespace Ex03.GarageLogic
{
    public class FueledCar
    {
        internal readonly Car r_CarBasicDetails;
        internal FueledVehicleDetails m_FueledVehicleDetails;

        public FueledCar(Car i_CarBasicDetails, FueledVehicleDetails i_FueledVehicleDetails)
        {
            this.r_CarBasicDetails = i_CarBasicDetails;
            this.m_FueledVehicleDetails = i_FueledVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an Fueled car! {0}" + Environment.NewLine + Environment.NewLine + "======== Fueled Car details ========" + Environment.NewLine + "{1}" + Environment.NewLine, r_CarBasicDetails, m_FueledVehicleDetails);
        }
    }
}
