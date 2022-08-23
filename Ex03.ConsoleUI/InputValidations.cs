using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class InputValidations
    {
        private static int s_IntegerValue; // check names
        private static float s_FloatValue;

        internal static void checkValidMenuChoice(string i_MenuChoice)
        {
            if (i_MenuChoice == null || i_MenuChoice.Length != 1)
            {
                throw new FormatException();
            }

            if (int.TryParse(i_MenuChoice, out int o_MenuChoiceInteger))
            {
                if (o_MenuChoiceInteger < 1 || o_MenuChoiceInteger > 7)
                {
                    throw new FormatException();
                }
            }
            else if (char.TryParse(i_MenuChoice, out char o_MenuChoiceCharacter))
            {
                if (o_MenuChoiceCharacter != 'q' && o_MenuChoiceCharacter != 'Q')
                {
                    throw new FormatException();
                }
            }
        }

        internal static eLicenseType setLicenseType()
        {
            eLicenseType licenseType;
            Console.WriteLine("Please enter the license type (A / AA / B1 / BB):");
            string licenseTypeString = Console.ReadLine();

            if (licenseTypeString == null)
            {
                throw new FormatException();
            }
            else
            {
                switch (licenseTypeString.ToLower())
                {
                    case "a":
                        {
                            licenseType = eLicenseType.A;
                            break;
                        }

                    case "aa":
                        {
                            licenseType = eLicenseType.AA;
                            break;
                        }

                    case "b1":
                        {
                            licenseType = eLicenseType.B1;
                            break;
                        }

                    case "bb":
                        {
                            licenseType = eLicenseType.BB;
                            break;
                        }

                    default:
                        {
                            throw new FormatException();
                        }
                }
            }

            return licenseType;
        }

        internal static eCarColor setCarColor()
        {
            eCarColor carColor;
            Console.WriteLine("Please enter car color (Grey / White / Black / Blue):");
            string carColorString = Console.ReadLine();

            if (carColorString == null)
            {
                throw new FormatException();
            }
            else
            {
                switch (carColorString.ToLower())
                {
                    case "black":
                        {
                            carColor = eCarColor.Black;
                            break;
                        }

                    case "grey":
                        {
                            carColor = eCarColor.Grey;
                            break;
                        }

                    case "white":
                        {
                            carColor = eCarColor.White;
                            break;
                        }

                    case "blue":
                        {
                            carColor = eCarColor.Blue;
                            break;
                        }

                    default:
                        {
                            throw new FormatException("No such color available for a Car.");
                        }
                }
            }

            return carColor;
        }

        internal static eNumOfDoors setNumOfDoors()
        {
            eNumOfDoors carNumOfDoors;
            Console.WriteLine("Please enter car Number of doors (2 / 3 / 4 / 5):");
            string carNumOfDoorsString = Console.ReadLine();

            if (carNumOfDoorsString == null)
            {
                throw new FormatException();
            }
            else
            {
                switch (carNumOfDoorsString)
                {
                    case "2":
                        {
                            carNumOfDoors = eNumOfDoors.Two;
                            break;
                        }

                    case "3":
                        {
                            carNumOfDoors = eNumOfDoors.Three;
                            break;
                        }

                    case "4":
                        {
                            carNumOfDoors = eNumOfDoors.Four;
                            break;
                        }

                    case "5":
                        {
                            carNumOfDoors = eNumOfDoors.Five;
                            break;
                        }

                    default:
                        {
                            throw new FormatException("No such amount of doors available for a Car.");
                        }
                }
            }

            return carNumOfDoors;
        }

        internal static eFuelType setFuelType()
        {
            eFuelType fuelType;
            Console.WriteLine("Please enter fuel type (95 / 96 / 98 / Soler):");
            string fuelTypeString = Console.ReadLine();

            if (fuelTypeString == null)
            {
                throw new FormatException();
            }
            else
            {
                switch (fuelTypeString)
                {
                    case "95":
                        {
                            fuelType = eFuelType.Octan95;
                            break;
                        }

                    case "96":
                        {
                            fuelType = eFuelType.Octan96;
                            break;
                        }

                    case "98":
                        {
                            fuelType = eFuelType.Octan98;
                            break;
                        }

                    default:
                        {
                            if (fuelTypeString.ToLower() == "soler")
                            {
                                fuelType = eFuelType.Soler;
                            }
                            else
                            {
                                throw new FormatException("No option of this fuel available.");
                            }

                            break;
                        }
                }
            }

            return fuelType;
        }

        internal static eVehicleStatus setVehicleStatus()
        {
            Console.WriteLine("Please enter desired vehicle status (In repair = 1 / Repaired = 2 / Paid = 3):");
            string vehicleStatusToUpdate = Console.ReadLine();

            switch (vehicleStatusToUpdate)
            {
                case "1":
                    {
                        return eVehicleStatus.InRepair;
                    }

                case "2":
                    {
                        return eVehicleStatus.Repaired;
                    }

                case "3":
                    {
                        return eVehicleStatus.Paid;
                    }

                default:
                    {
                        throw new FormatException("Wrong vehicle status value entered. Please try again.");
                    }
            }
        }

        internal static void setChosenVehicle(string i_UserChosenVehicle, ref eVehiclesAvailable io_VehicleType)
        {
            char.TryParse(i_UserChosenVehicle, out char o_UserVehicleSelectionChoice);
            switch (o_UserVehicleSelectionChoice)
            {
                case '1':
                    {
                        io_VehicleType = eVehiclesAvailable.ElectricCar;
                        break;
                    }

                case '2':
                    {
                        io_VehicleType = eVehiclesAvailable.FueledCar;
                        break;
                    }

                case '3':
                    {
                        io_VehicleType = eVehiclesAvailable.ElectricMotorcycle;
                        break;
                    }

                case '4':
                    {
                        io_VehicleType = eVehiclesAvailable.FueledMotorcycle;
                        break;
                    }

                case '5':
                    {
                        io_VehicleType = eVehiclesAvailable.Truck;
                        break;
                    }

                default:
                    {
                        throw new FormatException("Invalid choice of a vehicle. Please type a number from the list only.");
                    }
            }
        }

        internal static string setVehicleId()
        {
            Console.WriteLine("Please enter the vehicle ID (Number only):");
            string vehicleID = Console.ReadLine();

            if (!checkIfInputStingIncludesOnlyDigits(vehicleID))
            {
                throw new FormatException("Vehicle ID entered is invalid! Please make sure to type only number digits.");
            }

            return vehicleID;
        }

        internal static string setOwnerName()
        {
            Console.WriteLine("Please enter your name (Letters only): ");
            string ownerName = Console.ReadLine();

            if (!checkIfInputStingIncludesOnlyLetters(ownerName))
            {
                throw new FormatException("Invalid Owner Name.");
            }

            return ownerName;
        }

        internal static string setPhoneNumber()
        {
            Console.WriteLine("Please enter your Phone number (Digits only): ");
            string ownerPhoneNumber = Console.ReadLine();

            if (!checkIfInputStingIncludesOnlyDigits(ownerPhoneNumber))
            {
                throw new FormatException("Invalid Owner Phone Number.");
            }

            return ownerPhoneNumber;
        }

        internal static string setWheelsManufacture()
        {
            Console.WriteLine("Please enter Wheel manufacture name (Letters only, will apply for all tires): ");
            string wheelManufactureName = Console.ReadLine();

            if (!checkIfInputStingIncludesOnlyLetters(wheelManufactureName))
            {
                throw new FormatException("Invalid Wheel Manufacture Name.");
            }

            return wheelManufactureName;
        }

        internal static string setCarModel()
        {
            Console.WriteLine("Please enter Car model (Letters only): ");
            string carModel = Console.ReadLine();

            if (!checkIfInputStingIncludesOnlyLetters(carModel))
            {
                throw new FormatException("Invalid Car Model Entered.");
            }

            return carModel;
        }

        internal static int setEngineCapacity()
        {
            Console.WriteLine("Please enter the engine capacity (Number only):");
            string engineCapacityString = Console.ReadLine();

            if (!checkIfUserInputIsIntegerType(engineCapacityString))
            {
                throw new FormatException("Invalid Engine Capacity Entered.");
            }

            return s_IntegerValue;
        }

        internal static float setWheelsCurrentAirPressure()
        {
            Console.WriteLine("Please enter Car wheels current air pressure (Number only, will apply for all tires): ");
            string currentAirPressureString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(currentAirPressureString))
            {
                throw new FormatException("Invalid Air Pressure Entered.");
            }

            return s_FloatValue;
        }

        internal static float setWheelsMaxAirPressure()
        {
            Console.WriteLine("Please enter Car wheels max air pressure (Number only, will apply for all tires): ");
            string maxAirPressureString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(maxAirPressureString))
            {
                throw new FormatException("Invalid Max Air Pressure Entered.");
            }

            return s_FloatValue;
        }

        internal static float setCarEnergyPercentage()
        {
            Console.WriteLine("Please enter car energy percentage left (Number only): ");
            string energyPercentageString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(energyPercentageString))
            {
                throw new FormatException("Invalid Car Energy Percentage Entered.");
            }

            return s_FloatValue;
        }

        internal static float setCurrentFuelStatus()
        {
            Console.WriteLine("Please enter the vehicle current fuel status (Number only):");
            string fuelCurrentStatusString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(fuelCurrentStatusString))
            {
                throw new FormatException("Invalid Vehicle Current Fuel Status Entered.");
            }

            return s_FloatValue;
        }

        internal static float setMaxFuelCapacity()
        {
            Console.WriteLine("Please enter the vehicle fuel max capacity (Number only):");
            string fuelMaxCapacityString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(fuelMaxCapacityString))
            {
                throw new FormatException("Invalid Vehicle Fuel Max Capacity Entered.");
            }

            return s_FloatValue;
        }

        internal static float setTruckMaxCapacity()
        {
            Console.WriteLine("Please enter truck max cargo capacity (Number only): ");
            string cargoCapacityString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(cargoCapacityString))
            {
                throw new FormatException("Invalid Truck Max Cargo Capacity Entered.");
            }

            return s_FloatValue;
        }

        internal static float setBatteryTimeLeft()
        {
            Console.WriteLine("Please enter the battery time left (Number only): ");
            string batteryTimeLeftString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(batteryTimeLeftString))
            {
                throw new FormatException("Invalid Battery Time Left Entered.");
            }

            return s_FloatValue;
        }

        internal static float setBatteryMaxTime()
        {
            Console.WriteLine("Please enter the max battery capacity (Number only):");
            string batteryMaxTimeCapacityString = Console.ReadLine();

            if (!checkIfUserInputIsFloatType(batteryMaxTimeCapacityString))
            {
                throw new FormatException("Invalid Max Battery Capacity Entered.");
            }

            return s_FloatValue;
        }

        internal static float setAmountToFuelOrChargeVehicle()
        {
            Console.WriteLine("Please enter desired amount to fuel/charge the vehicle (Number only):");
            string amountToFuelOrChargeVehicleString = Console.ReadLine();
            if (!checkIfUserInputIsFloatType(amountToFuelOrChargeVehicleString))
            {
                throw new FormatException("Invalid Fuel/Charge Amount Entered.");
            }

            return s_FloatValue;
        }

        internal static bool setIsTruckCooling()
        {
            Console.WriteLine("Is the truck transporting with cooling? (yes/no)");
            string isCoolingString = Console.ReadLine();

            if (isCoolingString == null)
            {
                throw new FormatException("You should type only 'yes' or 'no'.");
            }
            else
            {
                switch (isCoolingString.ToLower())
                {
                    case "yes":
                        {
                            return true;
                        }

                    case "no":
                        {
                            return false;
                        }

                    default:
                        {
                            throw new FormatException("You should type only 'yes' or 'no'.");
                        }
                }
            }
        }

        internal static bool checkIfUserInputIsFloatType(string i_UserInput)
        {
            return !(i_UserInput == null || !float.TryParse(i_UserInput, out s_FloatValue));
        }

        internal static bool checkIfUserInputIsIntegerType(string i_UserInput)
        {
            return !(i_UserInput == null || !int.TryParse(i_UserInput, out s_IntegerValue));
        }

        internal static bool checkIfInputStingIncludesOnlyLetters(string i_UserInput)
        {
            bool isLettersOnlyString = true;

            if (i_UserInput == null)
            {
                isLettersOnlyString = false;
            }
            else
            {
                foreach (char character in i_UserInput)
                {
                    if(char.IsLetter(character))
                    {
                        continue;
                    }

                    isLettersOnlyString = false;
                    break;
                }
            }

            return isLettersOnlyString;
        }

        internal static bool checkIfInputStingIncludesOnlyDigits(string i_UserInput)
        {
            bool isDigitsOnlyString = true;

            if (i_UserInput == null)
            {
                isDigitsOnlyString = false;
            }
            else
            {
                foreach (char digit in i_UserInput)
                {
                    if(char.IsDigit(digit))
                    {
                        continue;
                    }

                    isDigitsOnlyString = false;
                    break;
                }
            }

            return isDigitsOnlyString;
        }
    }
}
