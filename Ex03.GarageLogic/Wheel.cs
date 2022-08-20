using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
        internal readonly float r_MaxAirPressure;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
        private readonly string r_ModuleName;

        public Wheel(string i_ModuleName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.r_ModuleName = i_ModuleName;
            this.CurrentAirPressure = i_CurrentAirPressure;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public bool FillWheel(float i_AirToAdd) // add exception
        {
            bool canFillWheel = true;

            if (CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                canFillWheel = false;
            }
            else
            {
                CurrentAirPressure += i_AirToAdd;
            }

            return canFillWheel;
        }

        public float CurrentAirPressure { get; set; }

        public override string ToString()
        {
            return string.Format("Wheel module: {0}" + Environment.NewLine + "Wheel current air pressure: {1}" + Environment.NewLine + "Wheel max air pressure: {2}", r_ModuleName, CurrentAirPressure, r_MaxAirPressure);
        }
    }
}
