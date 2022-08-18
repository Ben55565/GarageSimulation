namespace Ex03.ConsoleUI
{
    using System;
    using Ex03.GarageLogic;
    ////    TO DO LIST:
    ////    1. use format exception for invalid input(int instead of string and such)
    ////    2. use argument exception for in-logic input(wrong fuel type for the car and such)
    ////    3. write ValueOutOfRangeException class for exception if entered to much
    ////       air pressure of fuel amount, throw from relevant classes and catch it here
    ////       this class should contain float MaxValue and float MinValue and inherits exception
    ////  AFTER ALL THE STRINGS CHECKS, TRY CONVERT ALL GARAGE LOGIC CLASSES TO INTERNAL

    internal class UserInterface
    {
        public static void RunGarage()
        {
            exitMessage();
        }

        private static void exitMessage()
        {
            Console.WriteLine(Environment.NewLine + "Press enter to continue..");
            Console.ReadLine();
        }
    }
}
