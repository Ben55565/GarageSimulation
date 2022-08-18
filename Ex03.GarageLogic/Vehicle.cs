using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_RegistrationId;
        private readonly float r_EnergyPercentageLeft;
        private readonly Wheel[] r_Wheels;

        public Vehicle(string i_ModelName, string i_RegistrationId, float i_EnergyPercentageLeft, Wheel[] i_Wheels)
        {
            this.r_ModelName = i_ModelName;
            this.r_RegistrationId = i_RegistrationId;
            this.r_EnergyPercentageLeft = i_EnergyPercentageLeft;
            this.r_Wheels = i_Wheels;
        }

        public override string ToString()
        {
            StringBuilder wheelsDetails = new StringBuilder();
            for (int i = 0; i < this.r_Wheels.Length; i++)
            {
                wheelsDetails.AppendLine(Environment.NewLine + "Wheel #" + (i + 1).ToString());
                wheelsDetails.AppendLine(r_Wheels[i].ToString());
            }

            string output = string.Format(Environment.NewLine + "======== Basic vehicle details ========" + Environment.NewLine + Environment.NewLine + "Vehicle model: {0}" + Environment.NewLine + "Registration id: {1}" + Environment.NewLine + "Energy percentage left: {2}" + Environment.NewLine + Environment.NewLine + "======== Wheels details ======== " + Environment.NewLine + "{3}" + Environment.NewLine, r_ModelName, r_RegistrationId, r_EnergyPercentageLeft, wheelsDetails);
            return output;
        }
    }
}
