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

        public float CurrentAirPressure { get; set; }

        internal bool FillAirInWheel(float i_AirToAdd)
        {
            bool isSurpassedMaxAirPressure = false;

            if (CurrentAirPressure + i_AirToAdd > r_MaxAirPressure || i_AirToAdd == 0)
            {
                isSurpassedMaxAirPressure = true;
            }
            else
            {
                CurrentAirPressure += i_AirToAdd;
            }

            return isSurpassedMaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
                "Wheel module: {0}" +
                Environment.NewLine +
                "Wheel current air pressure: {1}" +
                Environment.NewLine +
                "Wheel max air pressure: {2}",
                r_ModuleName,
                CurrentAirPressure,
                r_MaxAirPressure);
        }
    }
}
