using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private readonly string r_ModelName;
        private readonly float r_EnergyPercentageLeft;
        private readonly Wheel[] r_Wheels;

        public Vehicle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels, OwnerDetailsAndStatus i_OwnerDetails)
        {
            this.r_ModelName = i_ModelName;
            this.RegistrationId = i_RegistrationId;
            this.r_EnergyPercentageLeft = i_EnergyPercentageLeft;
            this.r_Wheels = i_Wheels;
            this.OwnerDetails = i_OwnerDetails;
        }

        public OwnerDetailsAndStatus OwnerDetails { get; set; }

        public string RegistrationId { get; }

        public void SetCarStatus(eVehicleStatus i_Status)
        {
            OwnerDetails.CarStatus = i_Status;
        }

        public void FillAirInTiresToTheMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.CurrentAirPressure = wheel.r_MaxAirPressure;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsDetails = new StringBuilder();

            for (int i = 0; i < this.r_Wheels.Length; i++)
            {
                wheelsDetails.AppendLine(Environment.NewLine + "Wheel #" + (i + 1).ToString());
                wheelsDetails.AppendLine(r_Wheels[i].ToString());
            }

            return string.Format(Environment.NewLine + "======== Basic vehicle details ========" + Environment.NewLine + Environment.NewLine + "Vehicle model: {0}" + Environment.NewLine + "Registration id: {1}" + Environment.NewLine + "Energy percentage left: {2}" + Environment.NewLine + Environment.NewLine + "======== Wheels details ======== " + Environment.NewLine + "{3}" + Environment.NewLine + Environment.NewLine + "{4}" + Environment.NewLine, r_ModelName, RegistrationId, r_EnergyPercentageLeft, wheelsDetails, OwnerDetails);
        }
    }
}
