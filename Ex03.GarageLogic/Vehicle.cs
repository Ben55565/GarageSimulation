using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        internal string m_ModelName;
        internal float m_EnergyPercentageLeft;
        internal Wheel[] m_Wheels;

        public Vehicle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails)
        {
            m_ModelName = i_ModelName;
            RegistrationId = i_RegistrationId;
            m_EnergyPercentageLeft = i_EnergyPercentageLeft;
            m_Wheels = i_Wheels;
            OwnerDetails = i_OwnerDetails;
        }

        public OwnerDetailsAndStatus OwnerDetails { get; set; }

        public string RegistrationId { get; set; }

        public void SetCarStatus(eVehicleStatus i_Status)
        {
            OwnerDetails.CarStatus = i_Status;
        }

        public void FillAirInTiresToTheMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                float airToFill = wheel.r_MaxAirPressure - wheel.CurrentAirPressure;
                wheel.FillAirInWheel(airToFill);
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsDetails = new StringBuilder();

            for (int i = 0; i < this.m_Wheels.Length; i++)
            {
                wheelsDetails.AppendLine(Environment.NewLine + "Wheel #" + (i + 1).ToString());
                wheelsDetails.AppendLine(m_Wheels[i].ToString());
            }

            return string.Format(Environment.NewLine + "======== Basic vehicle details ========" + Environment.NewLine + Environment.NewLine + "Vehicle model: {0}" + Environment.NewLine + "Registration id: {1}" + Environment.NewLine + "Energy percentage left: {2}" + Environment.NewLine + Environment.NewLine + "======== Wheels details ======== " + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine, m_ModelName, RegistrationId, m_EnergyPercentageLeft, wheelsDetails, OwnerDetails);
        }
    }
}
