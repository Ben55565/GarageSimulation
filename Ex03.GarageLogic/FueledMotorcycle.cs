namespace Ex03.GarageLogic
{
    internal class FueledMotorcycle
    {
        private readonly float r_MaxFuelCapacity;
        private Motorcycle m_BasicDetails;
        private eFuelType m_FuelType;
        private float m_CurrentFuelStatus;

        public FueledMotorcycle(Motorcycle i_BasicDetails, eFuelType i_FuelType, float i_CurrentFuelStatus, float i_MaxFuelCapacity)
        {
            this.m_BasicDetails = i_BasicDetails;
            this.m_FuelType = i_FuelType;
            this.m_CurrentFuelStatus = i_CurrentFuelStatus;
            this.r_MaxFuelCapacity = i_MaxFuelCapacity;
        }

        public bool FuelVehicle(float i_LitersToFuel)
        {
            bool canFuelVehicle = true;
            if(m_CurrentFuelStatus + i_LitersToFuel > r_MaxFuelCapacity)
            {
                canFuelVehicle = false;
            }
            else
            {
                m_CurrentFuelStatus += i_LitersToFuel;
            }

            return canFuelVehicle;
        } // add exception
    }
}
