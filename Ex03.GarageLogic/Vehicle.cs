using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private readonly string r_ModelName;
        private readonly float r_EnergyPercentageLeft;
        private readonly Wheel[] r_Wheels;
        private readonly StringBuilder r_WheelsDetails = new StringBuilder();
        internal ElectricEngine m_electricEngine;
        internal FuelEngine m_fueledEngine;

        public Vehicle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails, object i_EngineType)
        {
            r_ModelName = i_ModelName;
            RegistrationId = i_RegistrationId;
            r_EnergyPercentageLeft = i_EnergyPercentageLeft;
            r_Wheels = i_Wheels;
            OwnerDetails = i_OwnerDetails;

            if (i_EngineType.GetType() == typeof(ElectricEngine))
            {
                m_electricEngine = (ElectricEngine)i_EngineType;
            }
            else
            {
                m_fueledEngine = (FuelEngine)i_EngineType;
            }
        }

        public OwnerDetailsAndStatus OwnerDetails { get; set; }

        public string RegistrationId { get; set; }

        protected string createVehicleDetailsMessage()
        {
            setWheelsDetails();
            object vehicleEngineType;

            if (m_electricEngine == null)
            {
                vehicleEngineType = m_fueledEngine;
            }
            else
            {
                vehicleEngineType = m_electricEngine;
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
                r_ModelName,
                RegistrationId,
                r_EnergyPercentageLeft,
                r_WheelsDetails,
                OwnerDetails,
                vehicleEngineType);
        }

        protected void setWheelsDetails()
        {
            r_WheelsDetails.Clear();
            for (int i = 0; i < r_Wheels.Length; i++)
            {
                r_WheelsDetails.AppendLine(Environment.NewLine + "Wheel #" + (i + 1));
                r_WheelsDetails.AppendLine(r_Wheels[i].ToString());
            }
        }

        internal void SetVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            OwnerDetails.VehicleStatus = i_VehicleStatus;
        }

        public void FillAirInTiresToTheMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                float airToFill = wheel.r_MaxAirPressure - wheel.CurrentAirPressure;

                if (wheel.FillAirInWheel(airToFill))
                {
                    throw new ValueOutOfRangeException(wheel.r_MaxAirPressure, 0, "Surpassed Maximum Air Pressure.");
                }
            }
        }
    }
}