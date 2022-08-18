using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private readonly string r_ModuleName;
        private float m_CurrentAirPressure;

        public Wheel(string i_ModuleName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.r_ModuleName = i_ModuleName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public bool FillWheel(float i_AirToAdd) // add exception
        {
            bool canFillWheel = true;
            if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                canFillWheel = false;
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }

            return canFillWheel;
        }

        public override string ToString()
        {
            return string.Format("Wheel module: {0}" + Environment.NewLine + "Wheel current air pressure: {1}" + Environment.NewLine + "Wheel max air pressure: {2}", r_ModuleName, m_CurrentAirPressure, r_MaxAirPressure);
        }
    }
}
