using System;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine
    {
        internal readonly float r_MaxBatteryCapacityTime;
        private float m_CurrentBatteryTimeLeft;

        public ElectricEngine(float i_MaxBatteryCapacityTime, float i_CurrentBatteryTimeLeft)
        {
            r_MaxBatteryCapacityTime = i_MaxBatteryCapacityTime;
            m_CurrentBatteryTimeLeft = i_CurrentBatteryTimeLeft;
        }

        public bool ChargeVehicle(float i_HoursToAddBatteryTime)
        {
            bool canChargeVehicle = true;

            if (m_CurrentBatteryTimeLeft + i_HoursToAddBatteryTime > r_MaxBatteryCapacityTime)
            {
                canChargeVehicle = false;
            }
            else
            {
                m_CurrentBatteryTimeLeft += i_HoursToAddBatteryTime;
            }

            return canChargeVehicle;
        }

        public override string ToString()
        {
            return string.Format(
                Environment.NewLine +
                "======== Battery Details ========" +
                Environment.NewLine +
                Environment.NewLine +
                "Current battery time left (in hours): {0}" +
                Environment.NewLine +
                "Max battery capacity time (in hours): {1}",
                m_CurrentBatteryTimeLeft,
                r_MaxBatteryCapacityTime);
        }
    }
}