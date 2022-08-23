using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_ExceptionMessage)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
            ExceptionMessage = i_ExceptionMessage;
        }

        public float MaxValue { get; set; }

        public float MinValue { get; set; }

        public string ExceptionMessage { get; set;  }
    }
}
