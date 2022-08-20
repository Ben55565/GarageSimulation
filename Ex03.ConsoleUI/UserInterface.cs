using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    ////    TO DO LIST:
    ////    1. use format exception for invalid input(int instead of string and such)
    ////    2. use argument exception for in-logic input(wrong fuel type for the car and such)
    ////    3. write ValueOutOfRangeException class for exception if entered to much
    ////       air pressure of fuel amount, throw from relevant classes and catch it here
    ////       this class should contain float MaxValue and float MinValue and inherits exception

    internal class UserInterface
    {
        private static string s_ChoiceInput;
        private static eUserChoice s_UserChoice;
        private static eVehiclesAvailable s_VehicleType;

        public static void RunGarage()
        {
            welcomeMessage();
            runUserInterface();
            exitMessage();
        }

        private static void exitMessage()
        {
            Console.WriteLine(Environment.NewLine + "Press enter to continue..");
            Console.ReadLine();
        }

        private static void welcomeMessage()
        {
            string greetMessage = string.Format(
                @"                ===========================================================
                =============== Welcome to our garage! ====================
                ===========================================================
                ");
            Console.WriteLine(greetMessage);
        }

        private static void showMenu() // has one input read that needs to be handled with exceptions(check later if can exported to different method)
        {
            string menuMessage = string.Format(
                "Please choose your action:" +
                Environment.NewLine +
                "1 - Register a new vehicle into the garage" +
                Environment.NewLine +
                "2 - Show list of the vehicles registration ID's" +
                Environment.NewLine +
                "3 - Update existing vehicle status" +
                Environment.NewLine +
                "4 - Fill existing vehicle wheels air pressure to the max" +
                Environment.NewLine +
                "5 - Fuel an existing vehicle(relevant to fuel powered vehicles only)" +
                Environment.NewLine +
                "6 - Charge an existing vehicle(relevant to electric powered vehicles only)" +
                Environment.NewLine +
                "7 - Show existing vehicle full details(using registration ID)" +
                Environment.NewLine +
                Environment.NewLine +
                "Please enter 'q' to exit the system.");
            Console.WriteLine(menuMessage);
            s_ChoiceInput = Console.ReadLine();

            while (!InputValidations.MenuChoiceInputValidation(s_ChoiceInput))
            {
                Console.WriteLine("Entered choice is invalid! Please choose again:");
                s_ChoiceInput = Console.ReadLine();
            }

            InputValidations.setUserChoice(s_ChoiceInput, ref s_UserChoice);
        }

        private static void runUserInterface()
        {
            do
            {
                showMenu();
                switch (s_UserChoice)
                {
                    case eUserChoice.RegisterNewVehicle:
                        {
                            registerNewVehicle();
                            break;
                        }

                    case eUserChoice.ShowAllExistingVehicles:
                        {
                            showAllExistingVehicles();
                            break;
                        }

                    case eUserChoice.UpdateVehicleStatus:
                        {
                            updateVehicleStatus();
                            break;
                        }

                    case eUserChoice.FillAllTires:
                        {
                            fillAllTires();
                            break;
                        }

                    case eUserChoice.FuelVehicle:
                        {
                            fuelVehicle();
                            break;
                        }

                    case eUserChoice.ChargeVehicle:
                        {
                            chargeVehicle();
                            break;
                        }

                    case eUserChoice.ShowVehicleFullDetails:
                        {
                            showVehicleFullDetails();
                            break;
                        }

                    case eUserChoice.Exit:
                        {
                            return;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
            }
            while (true);
        }

        private static void registerNewVehicle() // has one input read that needs to be handled with exceptions(check later if can exported to different method)
        {
            string id = InputValidations.setVehicleId();

            if (!CreateAndSaveData.s_VehiclesInSystem.ContainsKey(id))
            {
                string vehicleType = string.Format(
                    "Please choose the type of the vehicle you wish to add:" +
                    Environment.NewLine +
                    "1 - Electric car" +
                    Environment.NewLine +
                    "2 - Fueled car" +
                    Environment.NewLine +
                    "3 - Electric motorcycle" +
                    Environment.NewLine +
                    "4 - Fueled motorcycle" +
                    Environment.NewLine +
                    "5 - Truck");
                Console.WriteLine(vehicleType);
                s_ChoiceInput = Console.ReadLine();

                try
                {
                    InputValidations.setChosenVehicle(s_ChoiceInput, ref s_VehicleType);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    string output = $"Entered value is invalid! {Environment.NewLine} {ex.Message}";
                    Console.WriteLine(output);
                }

                createChosenVehicle(id);
            }
            else
            {
                Console.WriteLine("This vehicle is already in the system! Moving existing vehicle to repair now..");
                CreateAndSaveData.UpdateVehicleStatusInLists(eVehicleStatus.InRepair, id);
            }
        }

        private static void createChosenVehicle(string i_RegistrationId)
        {
            switch (s_VehicleType)
            {
                case eVehiclesAvailable.FueledCar:
                    {
                        fueledCarCreation(
                            i_RegistrationId,
                            InputValidations.setOwnerName(),
                            InputValidations.setPhoneNumber(),
                            InputValidations.setWheelsManufacture(),
                            InputValidations.setWheelsCurrentAirPressure(),
                            InputValidations.setWheelsMaxAirPressure(),
                            InputValidations.setCarModel(),
                            InputValidations.setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.ElectricCar:
                    {
                        electricCarCreation(
                            i_RegistrationId,
                            InputValidations.setOwnerName(),
                            InputValidations.setPhoneNumber(),
                            InputValidations.setWheelsManufacture(),
                            InputValidations.setWheelsCurrentAirPressure(),
                            InputValidations.setWheelsMaxAirPressure(),
                            InputValidations.setCarModel(),
                            InputValidations.setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.ElectricMotorcycle:
                    {
                        electricMotorcycleCreation(
                            i_RegistrationId,
                            InputValidations.setOwnerName(),
                            InputValidations.setPhoneNumber(),
                            InputValidations.setWheelsManufacture(),
                            InputValidations.setWheelsCurrentAirPressure(),
                            InputValidations.setWheelsMaxAirPressure(),
                            InputValidations.setCarModel(),
                            InputValidations.setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.FueledMotorcycle:
                    {
                        fueledMotorcycleCreation(
                            i_RegistrationId,
                            InputValidations.setOwnerName(),
                            InputValidations.setPhoneNumber(),
                            InputValidations.setWheelsManufacture(),
                            InputValidations.setWheelsCurrentAirPressure(),
                            InputValidations.setWheelsMaxAirPressure(),
                            InputValidations.setCarModel(),
                            InputValidations.setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.Truck:
                    {
                        truckCreation(
                            i_RegistrationId,
                            InputValidations.setOwnerName(),
                            InputValidations.setPhoneNumber(),
                            InputValidations.setWheelsManufacture(),
                            InputValidations.setWheelsCurrentAirPressure(),
                            InputValidations.setWheelsMaxAirPressure(),
                            InputValidations.setCarModel(),
                            InputValidations.setCarEnergyPercentage());
                        break;
                    }

                default:
                    {
                        throw new FormatException();
                    }
            }
        }

        private static void truckCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_WheelManufacture,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModel,
            float i_EnergyPercentage)
        {
            CreateAndSaveData.CreateTruck(
                i_CarModel,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelManufacture,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                InputValidations.setIsTruckCooling(),
                InputValidations.setTruckMaxCapacity(),
                i_OwnerName,
                i_OwnerPhoneNumber,
                InputValidations.setFuelType(),
                InputValidations.setCurrentFuelStatus(),
                InputValidations.setMaxFuelCapacity());
        }

        private static void fueledMotorcycleCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelManufacture,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModel,
            float i_EnergyPercentage)
        {
            CreateAndSaveData.CreateFueledMotorcycle(
                i_CarModel,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelManufacture,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                InputValidations.setLicenseType(),
                InputValidations.setEngineCapacity(),
                InputValidations.setFuelType(),
                InputValidations.setCurrentFuelStatus(),
                InputValidations.setMaxFuelCapacity(),
                i_OwnerName,
                i_OwnerPhoneNum);
        }

        private static void electricMotorcycleCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelManufacture,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModel,
            float i_EnergyPercentage)
        {
            CreateAndSaveData.CreateElectricMotorcycle(
                i_CarModel,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelManufacture,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                InputValidations.setLicenseType(),
                InputValidations.setEngineCapacity(),
                InputValidations.setBatteryTimeLeft(),
                InputValidations.setBatteryMaxTime(),
                i_OwnerName,
                i_OwnerPhoneNum);
        }

        private static void electricCarCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelManufacture,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModel,
            float i_EnergyPercentage)
        {
            CreateAndSaveData.CreateElectricCar(
                i_CarModel,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelManufacture,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                InputValidations.setCarColor(),
                InputValidations.setNumOfDoors(),
                InputValidations.setBatteryTimeLeft(),
                InputValidations.setBatteryMaxTime(),
                i_OwnerName,
                i_OwnerPhoneNum);
        }

        private static void fueledCarCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelManufacture,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModel,
            float i_EnergyPercentage)
        {
            CreateAndSaveData.CreateFueledCar(
                i_CarModel,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelManufacture,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                InputValidations.setCarColor(),
                InputValidations.setNumOfDoors(),
                InputValidations.setFuelType(),
                InputValidations.setCurrentFuelStatus(),
                InputValidations.setMaxFuelCapacity(),
                i_OwnerName,
                i_OwnerPhoneNum);
        }

        private static void showAllExistingVehicles() // has exception, need to check its working good
        {
            Console.WriteLine("Would you like to show the list of ID's in the system filtered by their status? (yes/no)");
            string showBySortInput = Console.ReadLine();

            switch (showBySortInput?.ToLower())
            {
                case "yes":
                    {
                        eVehicleStatus filterBy = InputValidations.setVehicleStatus();

                        switch (filterBy)
                        {
                            case eVehicleStatus.InRepair:
                                {
                                    showAllVehicleInRepair();
                                    break;
                                }

                            case eVehicleStatus.Repaired:
                                {
                                    showAllVehicleRepaired();
                                    break;
                                }

                            case eVehicleStatus.Paid:
                                {
                                    showAllVehiclePaid();
                                    break;
                                }

                            default:
                                {
                                    throw new FormatException();
                                }
                        }

                        break;
                    }

                case "no":
                    {
                        Console.WriteLine(Environment.NewLine + "All registered cars id's:" + Environment.NewLine);
                        foreach (string carId in CreateAndSaveData.s_AllVehiclesIds)
                        {
                            Console.WriteLine(carId);
                        }

                        Console.Write(Environment.NewLine);
                        break;
                    }

                default:
                    {
                        throw new FormatException();
                    }
            }
        }

        private static void showAllVehicleInRepair()
        {
            if (CreateAndSaveData.s_AllVehiclesIdsInRepair.Count != 0)
            {
                Console.WriteLine("List of the vehicles that are in repair:" + Environment.NewLine);
                foreach (string carId in CreateAndSaveData.s_AllVehiclesIdsInRepair)
                {
                    Console.WriteLine(carId);
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles currently in \"In Repair\" status.");
            }
        }

        private static void showAllVehicleRepaired()
        {
            if (CreateAndSaveData.s_AllVehiclesIdsRepaired.Count != 0)
            {
                Console.WriteLine("List of the vehicles that were repaired:" + Environment.NewLine);
                foreach (string carId in CreateAndSaveData.s_AllVehiclesIdsRepaired)
                {
                    Console.WriteLine(carId);
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles in Repaired status.");
            }
        }

        private static void showAllVehiclePaid()
        {
            if (CreateAndSaveData.s_AllVehiclesIdsPaid.Count != 0)
            {
                Console.WriteLine("List of the vehicles that were paid:" + Environment.NewLine);
                foreach (string carId in CreateAndSaveData.s_AllVehiclesIdsPaid)
                {
                    Console.WriteLine(carId);
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles in paid status.");
            }
        }

        private static void updateVehicleStatus()
        {
            CreateAndSaveData.verifyVehicleTypeAndUpdateStatus(InputValidations.setVehicleStatus(), InputValidations.setVehicleId());
            Console.WriteLine("Vehicle status updated!" + Environment.NewLine);
        }

        private static void fillAllTires()
        {
            CreateAndSaveData.verifyVehicleTypeAndFillTiresToMax(InputValidations.setVehicleId());
            Console.WriteLine("All vehicle tires were filled to max capacity of air pressure!" + Environment.NewLine);
        }

        private static void fuelVehicle()
        {
            Console.WriteLine("Please enter the amount you wish to fill (Litters for fueled vehicle):");
            
            CreateAndSaveData.verifyVehicleTypeAndFuelVehicle(InputValidations.setAmountToFuelOrChargeVehicle(), InputValidations.setVehicleId(), InputValidations.setFuelType());
            Console.WriteLine("Vehicle has been fueled!" + Environment.NewLine);
        }

        private static void chargeVehicle()
        {
            Console.WriteLine("Please enter the amount you wish to fill (minutes for electric vehicle):");
            CreateAndSaveData.verifyVehicleTypeAndChargeVehicle(InputValidations.setAmountToFuelOrChargeVehicle(), InputValidations.setVehicleId());
            Console.WriteLine("Vehicle has been charged!" + Environment.NewLine);
        }

        private static void showVehicleFullDetails()
        {
            string idToShow = InputValidations.setVehicleId();

            try
            {
                Console.WriteLine(CreateAndSaveData.s_VehiclesInSystem[idToShow]);
            }
            catch (ArgumentException exception)
            {
                string output = $"This id is not registered in our garage! {Environment.NewLine} {exception.Message}";
                Console.Write(output);
            }
        }
    }
}
