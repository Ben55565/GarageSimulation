using System;

namespace Ex03.GarageLogic
{
    internal class FueledVehicleDetails
    {
        internal eFuelType r_FuelType;
        internal float r_MaxFuelCapacity;
        internal float m_CurrentFuelStatus;

        public FueledVehicleDetails(eFuelType i_FuelType, float i_currentFuelStatus, float i_MaxFuelCapacity)
        {
            r_FuelType = i_FuelType;
            m_CurrentFuelStatus = i_currentFuelStatus;
            r_MaxFuelCapacity = i_MaxFuelCapacity;
        }

        public bool FuelVehicle(float i_LitersToFuel) //add exception here
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
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "Fuel type: {0}" + Environment.NewLine + "Current fuel status: {1}" + Environment.NewLine + "Max fuel capacity: {2}", r_FuelType, m_CurrentFuelStatus, r_MaxFuelCapacity);
        }
    }
}
