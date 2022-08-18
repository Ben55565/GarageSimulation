namespace Ex03.GarageLogic
{
    internal class Truck
    {
        private Vehicle m_BasicDetails;
        private bool m_TransportWithCooling;
        private float m_MaxCargoWeight;

        public Truck(Vehicle i_BasicDetails, bool i_TransportWithCooling, float i_MaxCargoWeight)
        {
            m_BasicDetails = i_BasicDetails;
            m_TransportWithCooling = i_TransportWithCooling;
            m_MaxCargoWeight = i_MaxCargoWeight;
        }
    }
}