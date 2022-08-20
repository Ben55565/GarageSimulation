using System;

namespace Ex03.GarageLogic
{
    public class FueledMotorcycle
    {
        private readonly float r_MaxFuelCapacity;
        internal readonly Motorcycle r_MotorcycleBasicDetails;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelStatus;

        public FueledMotorcycle(Motorcycle i_MotorcycleBasicDetails, eFuelType i_FuelType, float i_CurrentFuelStatus, float i_MaxFuelCapacity)
        {
            this.r_MotorcycleBasicDetails = i_MotorcycleBasicDetails;
            this.r_FuelType = i_FuelType;
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

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "You have checked in to our garage an Fueled motorcycle!" + r_MotorcycleBasicDetails + Environment.NewLine + Environment.NewLine + "======== Fueled Motorcycle details ========" + Environment.NewLine + Environment.NewLine + "Motorcycle fuel type: {0}" + Environment.NewLine + "Current fuel status: {1}" + Environment.NewLine + "Max fuel capacity: {2}", r_FuelType, m_CurrentFuelStatus, r_MaxFuelCapacity);
        }
    }
}
