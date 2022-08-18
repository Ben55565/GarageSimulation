namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle
    {
        private readonly float r_MaxBatteryCapacityTime;
        private Motorcycle m_BasicDetails;
        private float m_CurrentBatteryTimeLeft;

        public ElectricMotorcycle(Motorcycle i_BasicDetails, float i_CurrentBatteryTimeLeft, float i_MaxBatteryCapacityTime)
        {
            this.m_BasicDetails = i_BasicDetails;
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
    }
}
