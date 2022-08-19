using System;

namespace Ex03.GarageLogic
{
    public class FueledCar
    {
        private readonly float r_MaxFuelCapacity;
        private readonly Car r_BasicDetails;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelStatus;

        public FueledCar(Car i_BasicDetails, eFuelType i_FuelType, float i_CurrentFuelStatus, float i_MaxFuelCapacity)
        {
            this.r_BasicDetails = i_BasicDetails;
            this.r_FuelType = i_FuelType;
            this.m_CurrentFuelStatus = i_CurrentFuelStatus;
            this.r_MaxFuelCapacity = i_MaxFuelCapacity;
        }

        public bool FuelVehicle(float i_LitersToFuel)
        {
            bool canFuelVehicle = true;
            if (m_CurrentFuelStatus + i_LitersToFuel > r_MaxFuelCapacity)
            {
                canFuelVehicle = false;
            }
            else
            {
                m_CurrentFuelStatus += i_LitersToFuel;
            }

            return canFuelVehicle;
        } // add exception

        public override string ToString()
        {
            string output = string.Format(Environment.NewLine + "You have checked in to our garage an Fueled car!" + r_BasicDetails + Environment.NewLine + Environment.NewLine + "======== Fueled Car details ========" + Environment.NewLine + Environment.NewLine + "Car fuel type: {0}" + Environment.NewLine + "Current fuel status: {1}" + Environment.NewLine + "Max fuel capacity: {2}" + Environment.NewLine, r_FuelType, m_CurrentFuelStatus, r_MaxFuelCapacity);

            return output;
        }
    }
}
