namespace Ex03.ConsoleUI
{
    using System;
    using Ex03.GarageLogic;
    //      TO DO LIST:
    //    3. use format exception for invalid input(int instead of string and such)
    //    4. use argument exception for in-logic input(wrong fuel type for the car and such)
    //    5. write ValueOutOfRangeException class for exception if entered to much
    //       air pressure of fuel amount, throw from relevant classes and catch it here
    //       this class should contain float MaxValue and float MinValue and inherits exception

    internal class UserInterface
    {
        public static void RunGarage()
        {
            // test to see that creation of objects is ok

            Console.WriteLine("Please enter details for electric car: ");
            CreateAndSaveData.CreateFueledCar("kia picanto", "345689", 11.34f, "kia", 33f, 35f, eCarColor.Black, eNumOfDoors.Four, eFuelType.Octan95, 350f, 400f);
            CreateAndSaveData.m_VehiclesInSystem.TryGetValue("345689", out object test);
            test = (FueledCar)test;
            Console.WriteLine(test.ToString());
            exitMessage();
        }

        private static void exitMessage()
        {
            Console.WriteLine("Press enter to continue..");
            Console.ReadLine();
        }

    }
}
