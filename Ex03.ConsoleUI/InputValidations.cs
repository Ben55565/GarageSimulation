using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class InputValidations
    {
        internal static bool MenuChoiceInputValidation(string i_Input)
        {
            bool isValid = true;

            if (i_Input == null || i_Input.Length != 1)
            {
                throw new FormatException();
            }
            else
            {
                char.TryParse(i_Input, out char inputChar);
                if (inputChar == 'q' || inputChar == 'Q')
                {
                    isValid = true;
                }
                else if (char.IsDigit(inputChar))
                {
                    int.TryParse(i_Input, out int inputInt);
                    if (inputInt < 1 || inputInt > 7)
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        internal static bool CarIdValidation(string i_Input)
        {
            bool isValid = true;
            if (i_Input == null)
            {
                isValid = false;
            }
            else
            {
                foreach (char digit in i_Input)
                {
                    if (char.IsDigit(digit))
                    {
                        continue;
                    }

                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        internal static int setEngineCapacity()
        {
            Console.WriteLine("Please enter the engine capacity:");
            string engineCapacityStr = Console.ReadLine();

            if (int.TryParse(engineCapacityStr, out int engineCapacity))
            {
                return engineCapacity;
            }
            else
            {
                throw new FormatException();
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
                        licenseType = eLicenseType.A;
                        break;
                    case "aa":
                        licenseType = eLicenseType.AA;
                        break;
                    case "b1":
                        licenseType = eLicenseType.B1;
                        break;
                    case "bb":
                        licenseType = eLicenseType.BB;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return licenseType;
        }

        internal static float setAmountToFuelOrChargeVehicle()
        {
            string amountToFuelOrChargeVehicleStr = Console.ReadLine();
            bool legalInput = float.TryParse(amountToFuelOrChargeVehicleStr, out float amountToFuelOrChargeVehicle);
            return amountToFuelOrChargeVehicle;
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
                        carColor = eCarColor.Black;
                        break;
                    case "grey":
                        carColor = eCarColor.Grey;
                        break;
                    case "white":
                        carColor = eCarColor.White;
                        break;
                    case "blue":
                        carColor = eCarColor.Blue;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return carColor;
        }

        internal static eNumOfDoors setNumOfDoors()
        {
            eNumOfDoors carNumOfDoors;
            Console.WriteLine("Please enter car Number of doors(2 / 3 / 4 / 5):");
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
                        carNumOfDoors = eNumOfDoors.Two;
                        break;
                    case "3":
                        carNumOfDoors = eNumOfDoors.Three;
                        break;
                    case "4":
                        carNumOfDoors = eNumOfDoors.Four;
                        break;
                    case "5":
                        carNumOfDoors = eNumOfDoors.Five;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return carNumOfDoors;
        }

        internal static eFuelType setFuelType()
        {
            eFuelType fuelType;
            Console.WriteLine("Please enter fuel type(95 / 96 / 98 / Soler):");
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
                        fuelType = eFuelType.Octan95;
                        break;
                    case "96":
                        fuelType = eFuelType.Octan96;
                        break;
                    case "98":
                        fuelType = eFuelType.Octan98;
                        break;
                    default:
                        {
                            if (fuelTypeString.ToLower() == "soler")
                            {
                                fuelType = eFuelType.Soler;
                            }
                            else
                            {
                                throw new FormatException();
                            }

                            break;
                        }
                }
            }

            return fuelType;
        }

        internal static void setChosenVehicle(string i_UserChoiceInput, ref eVehiclesAvailable i_VehicleType)
        {
            char.TryParse(i_UserChoiceInput, out char userVehicleSelectionChoice);
            switch (userVehicleSelectionChoice)
            {
                case '1':
                    i_VehicleType = eVehiclesAvailable.ElectricCar;
                    break;
                case '2':
                    i_VehicleType = eVehiclesAvailable.FueledCar;
                    break;
                case '3':
                    i_VehicleType = eVehiclesAvailable.ElectricMotorcycle;
                    break;
                case '4':
                    i_VehicleType = eVehiclesAvailable.FueledMotorcycle;
                    break;
                case '5':
                    i_VehicleType = eVehiclesAvailable.Truck;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static string setOwnerName()
        {
            Console.WriteLine("Please enter your name: ");
            string ownerName = Console.ReadLine();
            return ownerName;
        }

        internal static string setPhoneNumber()
        {
            Console.WriteLine("Please enter your Phone number: ");
            string ownerPhoneNum = Console.ReadLine();
            return ownerPhoneNum;
        }

        internal static string setWheelsManufacture()
        {
            Console.WriteLine("Please enter Wheel manufacture name (will apply for all tires): ");
            string wheelManufacture = Console.ReadLine();
            return wheelManufacture;
        }

        internal static float setWheelsCurrentAirPressure()
        {
            Console.WriteLine("Please enter Car wheels current air pressure (will apply for all tires): ");
            string currentAirPressureString = Console.ReadLine();
            bool legalInput = float.TryParse(currentAirPressureString, out float currentAirPressure); // use to validate later
            return currentAirPressure;
        }

        internal static float setWheelsMaxAirPressure()
        {
            Console.WriteLine("Please enter Car wheels max air pressure (will apply for all tires): ");
            string maxAirPressureString = Console.ReadLine();
            bool legalInput = float.TryParse(maxAirPressureString, out float maxAirPressure); // use to validate later
            return maxAirPressure;
        }

        internal static float setCarEnergyPercentage()
        {
            Console.WriteLine("Please enter car energy percentage left: ");
            string energyPercentageString = Console.ReadLine();
            bool legalInput = float.TryParse(energyPercentageString, out float energyPercentage);
            return energyPercentage;
        }

        internal static string setCarModel()
        {
            Console.WriteLine("Please enter Car model: ");
            string carModel = Console.ReadLine();
            return carModel;
        }

        internal static void setUserChoice(string i_UserChoiceInput, ref eUserChoice io_UserChoice)
        {
            char.TryParse(i_UserChoiceInput, out char userMenuSelectionChoice);
            switch (userMenuSelectionChoice)
            {
                case '1':
                    io_UserChoice = eUserChoice.RegisterNewVehicle;
                    break;
                case '2':
                    io_UserChoice = eUserChoice.ShowAllExistingVehicles;
                    break;
                case '3':
                    io_UserChoice = eUserChoice.UpdateVehicleStatus;
                    break;
                case '4':
                    io_UserChoice = eUserChoice.FillAllTires;
                    break;
                case '5':
                    io_UserChoice = eUserChoice.FuelVehicle;
                    break;
                case '6':
                    io_UserChoice = eUserChoice.ChargeVehicle;
                    break;
                case '7':
                    io_UserChoice = eUserChoice.ShowVehicleFullDetails;
                    break;
                default:
                    io_UserChoice = eUserChoice.Exit;
                    break;
            }
        }

        internal static float setCurrentFuelStatus()
        {
            Console.WriteLine("Please enter the vehicle current fuel status:");
            string fuelCurrentStatusString = Console.ReadLine();
            float.TryParse(fuelCurrentStatusString, out float fuelCurrentStatus);
            return fuelCurrentStatus;
        }

        internal static float setMaxFuelCapacity()
        {
            Console.WriteLine("Please enter the vehicle fuel max capacity:");
            string fuelMaxCapacityStr = Console.ReadLine();
            float.TryParse(fuelMaxCapacityStr, out float fuelMaxCapacity);
            return fuelMaxCapacity;
        }

        internal static float setTruckMaxCapacity()
        {
            Console.WriteLine("Please enter truck max cargo capacity: ");
            string cargoCapacityString = Console.ReadLine();
            float.TryParse(cargoCapacityString, out float cargoCapacity);
            return cargoCapacity;
        }

        internal static bool setIsTruckCooling()
        {
            Console.WriteLine("Is the truck transporting with cooling? (yes/no)");
            string isCoolingString = Console.ReadLine();

            if (isCoolingString == null)
            {
                throw new FormatException();
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
                            throw new ArgumentException();
                        }
                }
            }
        }

        internal static float setBatteryTimeLeft()
        {
            Console.WriteLine("Please enter the battery time left: ");
            string batteryTimeLeftString = Console.ReadLine();
            float.TryParse(batteryTimeLeftString, out float batteryTimeLeft);
            return batteryTimeLeft;
        }

        internal static float setBatteryMaxTime()
        {
            Console.WriteLine("Please enter the max battery capacity:");
            string batterTimeCapacityString = Console.ReadLine();
            float.TryParse(batterTimeCapacityString, out float batteryTimeCapacity);
            return batteryTimeCapacity;
        }

        internal static string setVehicleId()
        {
            Console.WriteLine("Please enter the vehicle ID:");
            string id = Console.ReadLine();

            while (!InputValidations.CarIdValidation(id))
            {
                Console.WriteLine("Car id entered is invalid! please enter a valid id:");
                id = Console.ReadLine();
            }

            return id;
        }

        internal static eVehicleStatus setVehicleStatus()
        {
            Console.WriteLine("Please enter desired vehicle status (In repair = 1 / Repaired = 2 / Paid = 3):");
            string vehicleStatusToUpdate = Console.ReadLine();

            switch (vehicleStatusToUpdate?.ToLower())
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
                        throw new FormatException();
                    }
            }
        }
    }
}
