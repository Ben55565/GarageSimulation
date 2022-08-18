using System;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle
    {
        private readonly float r_MaxBatteryCapacityTime;
        private readonly Motorcycle r_BasicDetails;
        private float m_CurrentBatteryTimeLeft;

        public ElectricMotorcycle(Motorcycle i_BasicDetails, float i_CurrentBatteryTimeLeft, float i_MaxBatteryCapacityTime)
        {
            this.r_BasicDetails = i_BasicDetails;
            this.m_CurrentBatteryTimeLeft = i_CurrentBatteryTimeLeft;
            this.r_MaxBatteryCapacityTime = i_MaxBatteryCapacityTime;
        }

        public bool ChargeVehicle(float i_HoursToAddBatteryTime) // add exception
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
            string output = string.Format(Environment.NewLine + "You have checked in to our garage an electric motorcycle!" + r_BasicDetails + Environment.NewLine + Environment.NewLine + "======== Electric Motorcycle details ========" + Environment.NewLine + Environment.NewLine + "Current battery time left(in hours): {0}" + Environment.NewLine + "Max battery capacity time(in hours): {1}", m_CurrentBatteryTimeLeft, r_MaxBatteryCapacityTime);

            return output;
        }
    }
}
