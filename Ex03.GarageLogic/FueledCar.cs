using System;

namespace Ex03.GarageLogic
{
    internal class FueledCar : Car
    {
        internal FueledVehicleDetails m_FueledVehicleDetails;

        public FueledCar(Vehicle i_VehicleBasicDetails, Car i_CarBasicDetails, FueledVehicleDetails i_FueledVehicleDetails)
        : base(i_VehicleBasicDetails, i_CarBasicDetails.M_CarColor, i_CarBasicDetails.M_NumOfDoors)
        {
            m_FueledVehicleDetails = i_FueledVehicleDetails;
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an Fueled car!" + Environment.NewLine + Environment.NewLine + "======== Fueled Car details ========" + Environment.NewLine + "{0}" + Environment.NewLine, base.ToString());
        }
    }
}
