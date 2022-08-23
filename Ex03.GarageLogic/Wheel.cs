using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        internal readonly float r_MaxAirPressure;
        private readonly string r_ModuleName;

        public Wheel(string i_ModuleName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ModuleName = i_ModuleName;
            CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void FillAirInWheel(float i_AirToAdd) //handle exception here
        {
            if (CurrentAirPressure + i_AirToAdd > r_MaxAirPressure || i_AirToAdd == 0)
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure, 0, "Surpassed Maximum Air Pressure.");
            }
            else
            {
                CurrentAirPressure += i_AirToAdd;
            }
        }

        public float CurrentAirPressure { get; set; }

        public override string ToString()
        {
            return string.Format("Wheel module: {0}" + Environment.NewLine + "Wheel current air pressure: {1}" + Environment.NewLine + "Wheel max air pressure: {2}", r_ModuleName, CurrentAirPressure, r_MaxAirPressure);
        }
    }
}
