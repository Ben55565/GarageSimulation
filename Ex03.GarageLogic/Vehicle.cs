using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        internal string m_ModelName;
        internal float m_EnergyPercentageLeft;
        internal Wheel[] m_Wheels;
        internal ElectricVehicleDetails m_electricEngine;
        internal FueledVehicleDetails m_fueledEngine;
        private readonly string r_VehicleDetailsMessage;
        private readonly StringBuilder r_WheelsDetails = new StringBuilder();

        public Vehicle(Vehicle vehicle)
        {
            m_ModelName = vehicle.m_ModelName;
            m_EnergyPercentageLeft = vehicle.m_EnergyPercentageLeft;
            m_Wheels = vehicle.m_Wheels;
            m_electricEngine = vehicle.m_electricEngine;
            RegistrationId = vehicle.RegistrationId;
            OwnerDetails = vehicle.OwnerDetails;
            r_VehicleDetailsMessage = vehicle.r_VehicleDetailsMessage;
            m_fueledEngine = vehicle.m_fueledEngine;
            r_WheelsDetails = vehicle.r_WheelsDetails;
        }

        public Vehicle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails, ElectricVehicleDetails i_ElectricEngine)
        {
            m_ModelName = i_ModelName;
            RegistrationId = i_RegistrationId;
            m_EnergyPercentageLeft = i_EnergyPercentageLeft;
            m_Wheels = i_Wheels;
            OwnerDetails = i_OwnerDetails;
            m_electricEngine = i_ElectricEngine;
            setWheelsDetails();
            r_VehicleDetailsMessage = createVehicleDetailsMessage("Electric");
        }

        public Vehicle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails, FueledVehicleDetails i_FueledEngine)
        {
            m_ModelName = i_ModelName;
            RegistrationId = i_RegistrationId;
            m_EnergyPercentageLeft = i_EnergyPercentageLeft;
            m_Wheels = i_Wheels;
            OwnerDetails = i_OwnerDetails;
            m_fueledEngine = i_FueledEngine;
            setWheelsDetails();
            r_VehicleDetailsMessage = createVehicleDetailsMessage("Fueled");
        }

        public OwnerDetailsAndStatus OwnerDetails { get; set; }

        public string RegistrationId { get; set; }

        private string createVehicleDetailsMessage(string i_EngineType)
        {
            object engineType = null;

            if (i_EngineType == "Fueled")
            {
                engineType = m_fueledEngine;
            }
            else
            {
                engineType = m_electricEngine;
            }

            return string.Format(
                Environment.NewLine +
                "======== Basic vehicle details ========" +
                Environment.NewLine +
                Environment.NewLine +
                "Vehicle model: {0}" +
                Environment.NewLine +
                "Registration id: {1}" +
                Environment.NewLine +
                "Energy percentage left: {2}" +
                Environment.NewLine +
                Environment.NewLine +
                "======== Wheels details ======== " +
                Environment.NewLine +
                "{3}" +
                Environment.NewLine +
                "{4}" +
                Environment.NewLine +
                "{5}",
                m_ModelName,
                RegistrationId,
                m_EnergyPercentageLeft,
                r_WheelsDetails,
                OwnerDetails,
                engineType);
        }

        private void setWheelsDetails()
        {
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                r_WheelsDetails.AppendLine(Environment.NewLine + "Wheel #" + (i + 1).ToString());
                r_WheelsDetails.AppendLine(m_Wheels[i].ToString());
            }
        }

        public void SetVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            OwnerDetails.VehicleStatus = i_VehicleStatus;
        }

        public void FillAirInTiresToTheMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                float airToFill = wheel.r_MaxAirPressure - wheel.CurrentAirPressure;

                if (wheel.FillAirInWheel(airToFill))
                {
                    throw new ValueOutOfRangeException(wheel.r_MaxAirPressure, 0, "Surpassed Maximum Air Pressure.");
                }
            }
        }

        public override string ToString()
        {
            return r_VehicleDetailsMessage;
        }
    }
}