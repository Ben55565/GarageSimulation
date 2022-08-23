using System;

namespace Ex03.GarageLogic
{
    internal class FuelEngine
    {
        internal readonly eFuelType r_FuelType;
        internal readonly float r_MaxFuelCapacity;
        private float m_CurrentFuelStatus;

        public FuelEngine(eFuelType i_FuelType, float i_currentFuelStatus, float i_MaxFuelCapacity)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelCapacity = i_MaxFuelCapacity;
            m_CurrentFuelStatus = i_currentFuelStatus;
        }

        internal bool FuelVehicle(float i_LitersToFuel)
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
            return string.Format(Environment.NewLine + "======== Fuel Details ========" + Environment.NewLine + Environment.NewLine + "Fuel type: {0}" + Environment.NewLine + "Current fuel status: {1}" + Environment.NewLine + "Max fuel capacity: {2}", r_FuelType, m_CurrentFuelStatus, r_MaxFuelCapacity);
        }
    }
}