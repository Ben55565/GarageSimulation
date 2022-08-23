using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private static string s_MenuChoiceInput;
        private static eVehiclesAvailable s_VehicleType;

        public static void RunGarage()
        {
            welcomeMessage();
            runUserInterface();
            exitMessage();
        }

        private static void exitMessage()
        {
            Console.WriteLine(Environment.NewLine + "Press enter to exit..");
            Console.ReadLine();
        }

        private static void welcomeMessage()
        {
            const string greetMessage = @"                ===========================================================
                =============== Welcome to our garage! ====================
                ===========================================================
                ";
            Console.WriteLine(greetMessage);
        }

        private static void showMenu()
        {
                string menuMessage = string.Format(
                    Environment.NewLine +
                    Environment.NewLine +
                    "---------------------------------------------------------------------------------" +
                    Environment.NewLine +
                    "Please choose your action:" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "   1 - Register a new vehicle into the garage" +
                    Environment.NewLine +
                    "   2 - Show list of the vehicles registration ID's" +
                    Environment.NewLine +
                    "   3 - Update existing vehicle status" +
                    Environment.NewLine +
                    "   4 - Fill existing vehicle wheels air pressure to the max" +
                    Environment.NewLine +
                    "   5 - Fuel an existing vehicle (relevant to fuel powered vehicles only)" +
                    Environment.NewLine +
                    "   6 - Charge an existing vehicle (relevant to electric powered vehicles only)" +
                    Environment.NewLine +
                    "   7 - Show existing vehicle full details (using registration ID)" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Please enter 'q' to exit the system." +
                    Environment.NewLine +
                    "---------------------------------------------------------------------------------" +
                    Environment.NewLine +
                    Environment.NewLine);
                Console.WriteLine(menuMessage);
        }

        private static void runUserInterface()
        {
            try
            {
                do
                {
                    showMenu();
                    s_MenuChoiceInput = Console.ReadLine();
                    InputValidations.checkValidMenuChoice(s_MenuChoiceInput);
                    char userMenuChoice = char.Parse(s_MenuChoiceInput ?? throw new FormatException());

                    switch (userMenuChoice)
                    {
                        case (char)eUserChoiceInMenu.RegisterNewVehicle:
                            {
                                registerNewVehicle();
                                break;
                            }

                        case (char)eUserChoiceInMenu.ShowAllExistingVehicles:
                            {
                                showAllExistingVehicles();
                                break;
                            }

                        case (char)eUserChoiceInMenu.UpdateVehicleStatus:
                            {
                                updateVehicleStatus();
                                break;
                            }

                        case (char)eUserChoiceInMenu.FillAllTires:
                            {
                                fillAllTires();
                                break;
                            }

                        case (char)eUserChoiceInMenu.FuelVehicle:
                            {
                                fuelVehicle();
                                break;
                            }

                        case (char)eUserChoiceInMenu.ChargeVehicle:
                            {
                                chargeVehicle();
                                break;
                            }

                        case (char)eUserChoiceInMenu.ShowVehicleFullDetails:
                            {
                                showVehicleFullDetails();
                                break;
                            }

                        case (char)eUserChoiceInMenu.Exit:
                            {
                                return;
                            }

                        default:
                            {
                                throw new FormatException();
                            }
                    }
                }
                while (true);
            }
            catch (FormatException i_FormatException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Menu choice entered is invalid! Please choose again." +
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_FormatException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
                runUserInterface();
            }
        }

        private static void registerNewVehicle()
        {
            try
            {
                string vehicleID = InputValidations.setVehicleId();

                if (!GarageManager.s_VehiclesInSystem.ContainsKey(vehicleID))
                {
                    string vehicleTypeMessage = string.Format(
                        Environment.NewLine +
                        Environment.NewLine +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                        Environment.NewLine +
                        "Please choose the type of the vehicle you wish to add:" +
                        Environment.NewLine +
                        Environment.NewLine +
                        "   1 - Electric car" +
                        Environment.NewLine +
                        "   2 - Fueled car" +
                        Environment.NewLine +
                        "   3 - Electric motorcycle" +
                        Environment.NewLine +
                        "   4 - Fueled motorcycle" +
                        Environment.NewLine +
                        "   5 - Truck" +
                        Environment.NewLine +
                        Environment.NewLine +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                        Environment.NewLine +
                        Environment.NewLine);
                    Console.WriteLine(vehicleTypeMessage);
                    s_MenuChoiceInput = Console.ReadLine();
                    InputValidations.setChosenVehicle(s_MenuChoiceInput, ref s_VehicleType);
                    createChosenVehicle(vehicleID);
                }
                else
                {
                    Console.WriteLine("-> This vehicle is already in the system! Moving existing vehicle to repair now...");
                    GarageManager.UpdateVehicleStatus(eVehicleStatus.InRepair, vehicleID);
                }
            }
            catch (FormatException i_FormatException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Invalid input was entered. Please try again." +
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_FormatException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
                registerNewVehicle();
            }
        }

        private static void createChosenVehicle(string i_RegistrationId)
        {
            try
            {
                string ownerName = InputValidations.setOwnerName();
                string ownerPhoneNumber = InputValidations.setPhoneNumber();
                string wheelsManufacture = InputValidations.setWheelsManufacture();
                float currentWheelsAirPressure = InputValidations.setWheelsCurrentAirPressure();
                float wheelsMaxAirPressure = InputValidations.setWheelsMaxAirPressure();

                if (currentWheelsAirPressure > wheelsMaxAirPressure)
                {
                    throw new ValueOutOfRangeException(wheelsMaxAirPressure, 0, "Current Air Pressure can't be bigger than the defined Max Air Pressure: ");
                }

                string carModel = InputValidations.setCarModel();
                float vehicleEnergyPercentage = InputValidations.setCarEnergyPercentage();

                switch (s_VehicleType)
                {
                    case eVehiclesAvailable.FueledCar:
                        {
                            float currentFuelStatus = InputValidations.setCurrentFuelStatus();
                            float maxFuelCapacity = InputValidations.setMaxFuelCapacity();

                            if (maxFuelCapacity < currentFuelStatus)
                            {
                                throw new ValueOutOfRangeException(maxFuelCapacity, 0, "Current fuel amount left must be less than the maximum: ");
                            }

                            GarageManager.CreateFueledCar(
                                carModel,
                                i_RegistrationId,
                                vehicleEnergyPercentage,
                                wheelsManufacture,
                                currentWheelsAirPressure,
                                wheelsMaxAirPressure,
                                InputValidations.setCarColor(),
                                InputValidations.setNumOfDoors(),
                                InputValidations.setFuelType(),
                                currentFuelStatus,
                                maxFuelCapacity,
                                ownerName,
                                ownerPhoneNumber);
                            break;
                        }

                    case eVehiclesAvailable.ElectricCar:
                        {
                            float batteryTimeLeft = InputValidations.setBatteryTimeLeft();
                            float batteryMaxTime = InputValidations.setBatteryMaxTime();

                            if (batteryMaxTime < batteryTimeLeft)
                            {
                                throw new ValueOutOfRangeException(batteryMaxTime, 0, "Current battery time left must be less than the maximum: ");
                            }

                            GarageManager.CreateElectricCar(
                                carModel,
                                i_RegistrationId,
                                vehicleEnergyPercentage,
                                wheelsManufacture,
                                currentWheelsAirPressure,
                                wheelsMaxAirPressure,
                                InputValidations.setCarColor(),
                                InputValidations.setNumOfDoors(),
                                batteryTimeLeft,
                                batteryMaxTime,
                                ownerName,
                                ownerPhoneNumber);
                            break;
                        }

                    case eVehiclesAvailable.ElectricMotorcycle:
                        {
                            float batteryTimeLeft = InputValidations.setBatteryTimeLeft();
                            float batteryMaxTime = InputValidations.setBatteryMaxTime();

                            if (batteryMaxTime < batteryTimeLeft)
                            {
                                throw new ValueOutOfRangeException(batteryMaxTime, 0, "Current battery time left must be less than the maximum: ");
                            }

                            GarageManager.CreateElectricMotorcycle(
                                carModel,
                                i_RegistrationId,
                                vehicleEnergyPercentage,
                                wheelsManufacture,
                                currentWheelsAirPressure,
                                wheelsMaxAirPressure,
                                InputValidations.setLicenseType(),
                                InputValidations.setEngineCapacity(),
                                batteryTimeLeft,
                                batteryMaxTime,
                                ownerName,
                                ownerPhoneNumber);
                            break;
                        }

                    case eVehiclesAvailable.FueledMotorcycle:
                        {
                            float currentFuelStatus = InputValidations.setCurrentFuelStatus();
                            float maxFuelCapacity = InputValidations.setMaxFuelCapacity();

                            if (maxFuelCapacity < currentFuelStatus)
                            {
                                throw new ValueOutOfRangeException(maxFuelCapacity, 0, "Current fuel amount left must be less than the maximum: ");
                            }

                            GarageManager.CreateFueledMotorcycle(
                                carModel,
                                i_RegistrationId,
                                vehicleEnergyPercentage,
                                wheelsManufacture,
                                currentWheelsAirPressure,
                                wheelsMaxAirPressure,
                                InputValidations.setLicenseType(),
                                InputValidations.setEngineCapacity(),
                                InputValidations.setFuelType(),
                                InputValidations.setCurrentFuelStatus(),
                                InputValidations.setMaxFuelCapacity(),
                                ownerName,
                                ownerPhoneNumber);
                            break;
                        }

                    case eVehiclesAvailable.Truck:
                        {
                            float currentFuelStatus = InputValidations.setCurrentFuelStatus();
                            float maxFuelCapacity = InputValidations.setMaxFuelCapacity();

                            if (maxFuelCapacity < currentFuelStatus)
                            {
                                throw new ValueOutOfRangeException(maxFuelCapacity, 0, "Current fuel amount left must be less than the maximum: ");
                            }

                            GarageManager.CreateTruck(
                                carModel,
                                i_RegistrationId,
                                vehicleEnergyPercentage,
                                wheelsManufacture,
                                currentWheelsAirPressure,
                                wheelsMaxAirPressure,
                                InputValidations.setIsTruckCooling(),
                                InputValidations.setTruckMaxCapacity(),
                                ownerName,
                                ownerPhoneNumber,
                                InputValidations.setFuelType(),
                                currentFuelStatus,
                                maxFuelCapacity);
                            break;
                        }

                    default:
                        {
                            throw new FormatException();
                        }
                }
            }
            catch (FormatException i_FormatException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Value entered is invalid! Please type again correctly." +
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_FormatException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
                createChosenVehicle(i_RegistrationId);
            }
            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_ValueOutOfRangeException.ExceptionMessage +
                    i_ValueOutOfRangeException.MaxValue +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
                createChosenVehicle(i_RegistrationId);
            }
        }

        private static void showAllExistingVehicles()
        {
            try
            {
                Console.WriteLine("Would you like to show the list of ID's in the system filtered by their status? (yes/no)");
                string showBySortInput = Console.ReadLine();

                switch (showBySortInput?.ToLower())
                {
                    case "yes":
                        {
                            eVehicleStatus filterByVehicleStatus = InputValidations.setVehicleStatus();

                            switch (filterByVehicleStatus)
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
                            Console.WriteLine(Environment.NewLine + "All registered Vehicles ID's:" + Environment.NewLine);
                            foreach (string vehicle in GarageManager.s_AllVehiclesIds)
                            {
                                Console.WriteLine(vehicle);
                            }

                            Console.Write(Environment.NewLine);
                            break;
                        }

                    default:
                        {
                            throw new FormatException("Value entered is not 'yes' or 'no'. Please type it correctly.");
                        }
                }
            }
            catch (FormatException i_FormatException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_FormatException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
        }

        private static void showAllVehicleInRepair()
        {
            if (GarageManager.s_AllVehiclesIdsInRepair.Count != 0)
            {
                Console.WriteLine("List of the vehicles that are in repair:" + Environment.NewLine);
                foreach (string vehicleID in GarageManager.s_AllVehiclesIdsInRepair)
                {
                    Console.WriteLine(vehicleID);
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "There are no vehicles currently in \"In Repair\" status.");
            }
        }

        private static void showAllVehicleRepaired()
        {
            if (GarageManager.s_AllVehiclesIdsRepaired.Count != 0)
            {
                Console.WriteLine("List of the vehicles that were repaired:" + Environment.NewLine);
                foreach (string vehicleID in GarageManager.s_AllVehiclesIdsRepaired)
                {
                    Console.WriteLine(vehicleID);
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "There are no vehicles in Repaired status.");
            }
        }

        private static void showAllVehiclePaid()
        {
            if (GarageManager.s_AllVehiclesIdsPaid.Count != 0)
            {
                Console.WriteLine("List of the vehicles that were paid:" + Environment.NewLine);
                foreach (string vehicleID in GarageManager.s_AllVehiclesIdsPaid)
                {
                    Console.WriteLine(vehicleID);
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "There are no vehicles in Paid status.");
            }
        }

        private static void updateVehicleStatus()
        {
            try
            {
                GarageManager.UpdateVehicleStatus(InputValidations.setVehicleStatus(), InputValidations.setVehicleId());
                Console.WriteLine("Vehicle status updated!" + Environment.NewLine);
            }
            catch (KeyNotFoundException i_KeyNotFoundException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> This ID is not registered in our garage! Please type existing ID." +
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_KeyNotFoundException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
            catch (FormatException i_FormatException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_FormatException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
        }

        private static void fillAllTires()
        {
            try
            {
                string vehicleId = InputValidations.setVehicleId();
                GarageManager.s_VehiclesInSystem[vehicleId].FillAirInTiresToTheMax();
                Console.WriteLine("All vehicle tires were filled to max capacity of air pressure!" + Environment.NewLine);
            }
            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_ValueOutOfRangeException.ExceptionMessage +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
        }

        private static void fuelVehicle()
        {
            try
            {
                GarageManager.FuelVehicle(InputValidations.setAmountToFuelOrChargeVehicle(), InputValidations.setFuelType(), InputValidations.setVehicleId());
                Console.WriteLine(Environment.NewLine + "Vehicle has been fueled!" + Environment.NewLine);
            }
            catch (ArgumentException i_ArgumentException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine + "-> Error Details: " + i_ArgumentException.Message + Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_ValueOutOfRangeException.ExceptionMessage +
                    i_ValueOutOfRangeException.MaxValue +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
            catch (Exception i_Exception)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_Exception.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
        }

        private static void chargeVehicle()
        {
            try
            {
                GarageManager.ChargeVehicle(InputValidations.setAmountToFuelOrChargeVehicle(), InputValidations.setVehicleId());
                Console.WriteLine(Environment.NewLine + "Vehicle has been charged!" + Environment.NewLine);
            }
            catch (ArgumentException i_ArgumentException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_ArgumentException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
            catch (Exception i_Exception)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_Exception.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
            }
        }

        private static void showVehicleFullDetails()
        {
            try
            {
                string vehicleIdToShow = InputValidations.setVehicleId();
                Console.WriteLine(GarageManager.s_VehiclesInSystem[vehicleIdToShow]);
            }
            catch (KeyNotFoundException i_KeyNotFoundException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> This ID is not registered in our garage! Please type existing ID." +
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_KeyNotFoundException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
                runUserInterface();
            }
            catch (FormatException i_FormatException)
            {
                string errorMessage = string.Format(
                    Environment.NewLine +
                    "-> Error Details: " +
                    i_FormatException.Message +
                    Environment.NewLine);
                Console.WriteLine(errorMessage);
                runUserInterface();
            }
        }
    }
}
