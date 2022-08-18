namespace Ex03.GarageLogic
{
    internal class Motorcycle
    {
        private Vehicle m_BasicDetails;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(Vehicle i_BasicDetails, eLicenseType i_LicenseType, int i_EngineCapacity)
        {
            m_BasicDetails = i_BasicDetails;
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
