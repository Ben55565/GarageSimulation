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

            setUserChoice();
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
            string id = setVehicleId();

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
                    setChosenVehicle();
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
                            setOwnerName(),
                            setPhoneNumber(),
                            setWheelsManufacture(),
                            setWheelsCurrentAirPressure(),
                            setWheelsMaxAirPressure(),
                            setCarModel(),
                            setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.ElectricCar:
                    {
                        electricCarCreation(
                            i_RegistrationId,
                            setOwnerName(),
                            setPhoneNumber(),
                            setWheelsManufacture(),
                            setWheelsCurrentAirPressure(),
                            setWheelsMaxAirPressure(),
                            setCarModel(),
                            setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.ElectricMotorcycle:
                    {
                        electricMotorcycleCreation(
                            i_RegistrationId,
                            setOwnerName(),
                            setPhoneNumber(),
                            setWheelsManufacture(),
                            setWheelsCurrentAirPressure(),
                            setWheelsMaxAirPressure(),
                            setCarModel(),
                            setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.FueledMotorcycle:
                    {
                        fueledMotorcycleCreation(
                            i_RegistrationId,
                            setOwnerName(),
                            setPhoneNumber(),
                            setWheelsManufacture(),
                            setWheelsCurrentAirPressure(),
                            setWheelsMaxAirPressure(),
                            setCarModel(),
                            setCarEnergyPercentage());
                        break;
                    }

                case eVehiclesAvailable.Truck:
                    {
                        truckCreation(
                            i_RegistrationId,
                            setOwnerName(),
                            setPhoneNumber(),
                            setWheelsManufacture(),
                            setWheelsCurrentAirPressure(),
                            setWheelsMaxAirPressure(),
                            setCarModel(),
                            setCarEnergyPercentage());
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
                setIsTruckCooling(),
                setTruckMaxCapacity(),
                i_OwnerName,
                i_OwnerPhoneNumber,
                setFuelType(),
                setCurrentFuelStatus(),
                setMaxFuelCapacity());
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
                setLicenseType(),
                setEngineCapacity(),
                setFuelType(),
                setCurrentFuelStatus(),
                setMaxFuelCapacity(),
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
                setLicenseType(),
                setEngineCapacity(),
                setBatteryTimeLeft(),
                setBatteryMaxTime(),
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
                setCarColor(),
                setNumOfDoors(),
                setBatteryTimeLeft(),
                setBatteryMaxTime(),
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
                setCarColor(),
                setNumOfDoors(),
                setFuelType(),
                setCurrentFuelStatus(),
                setMaxFuelCapacity(),
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
                        eVehicleStatus filterBy = setVehicleStatus();

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
            CreateAndSaveData.verifyVehicleTypeAndPerformAction(setVehicleStatus(), setVehicleId(), eCarActions.UpdateStatus);
        }

        private static void fillAllTires()
        {
            string id = setVehicleId();
        }

        private static void fuelVehicle()
        {
            return;
        }

        private static void chargeVehicle()
        {
            return;
        }

        private static void showVehicleFullDetails()
        {
            string idToShow = setVehicleId();

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

        private static int setEngineCapacity()
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

        private static eLicenseType setLicenseType()
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

        private static eCarColor setCarColor()
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

        private static eNumOfDoors setNumOfDoors()
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

        private static eFuelType setFuelType()
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

        private static void setChosenVehicle()
        {
            char.TryParse(s_ChoiceInput, out char userVehicleSelectionChoice);
            switch (userVehicleSelectionChoice)
            {
                case '1':
                    s_VehicleType = eVehiclesAvailable.ElectricCar;
                    break;
                case '2':
                    s_VehicleType = eVehiclesAvailable.FueledCar;
                    break;
                case '3':
                    s_VehicleType = eVehiclesAvailable.ElectricMotorcycle;
                    break;
                case '4':
                    s_VehicleType = eVehiclesAvailable.FueledMotorcycle;
                    break;
                case '5':
                    s_VehicleType = eVehiclesAvailable.Truck;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string setOwnerName()
        {
            Console.WriteLine("Please enter your name: ");
            string ownerName = Console.ReadLine();
            return ownerName;
        }

        private static string setPhoneNumber()
        {
            Console.WriteLine("Please enter your Phone number: ");
            string ownerPhoneNum = Console.ReadLine();
            return ownerPhoneNum;
        }

        private static string setWheelsManufacture()
        {
            Console.WriteLine("Please enter Wheel manufacture name (will apply for all tires): ");
            string wheelManufacture = Console.ReadLine();
            return wheelManufacture;
        }

        private static float setWheelsCurrentAirPressure()
        {
            Console.WriteLine("Please enter Car wheels current air pressure (will apply for all tires): ");
            string currentAirPressureString = Console.ReadLine();
            bool legalInput = float.TryParse(currentAirPressureString, out float currentAirPressure); // use to validate later
            return currentAirPressure;
        }

        private static float setWheelsMaxAirPressure()
        {
            Console.WriteLine("Please enter Car wheels max air pressure (will apply for all tires): ");
            string maxAirPressureString = Console.ReadLine();
            bool legalInput = float.TryParse(maxAirPressureString, out float maxAirPressure); // use to validate later
            return maxAirPressure;
        }

        private static float setCarEnergyPercentage()
        {
            Console.WriteLine("Please enter car energy percentage left: ");
            string energyPercentageString = Console.ReadLine();
            bool legalInput = float.TryParse(energyPercentageString, out float energyPercentage);
            return energyPercentage;
        }

        private static string setCarModel()
        {
            Console.WriteLine("Please enter Car model: ");
            string carModel = Console.ReadLine();
            return carModel;
        }

        private static void setUserChoice()
        {
            char.TryParse(s_ChoiceInput, out char userMenuSelectionChoice);
            switch (userMenuSelectionChoice)
            {
                case '1':
                    s_UserChoice = eUserChoice.RegisterNewVehicle;
                    break;
                case '2':
                    s_UserChoice = eUserChoice.ShowAllExistingVehicles;
                    break;
                case '3':
                    s_UserChoice = eUserChoice.UpdateVehicleStatus;
                    break;
                case '4':
                    s_UserChoice = eUserChoice.FillAllTires;
                    break;
                case '5':
                    s_UserChoice = eUserChoice.FuelVehicle;
                    break;
                case '6':
                    s_UserChoice = eUserChoice.ChargeVehicle;
                    break;
                case '7':
                    s_UserChoice = eUserChoice.ShowVehicleFullDetails;
                    break;
                default:
                    s_UserChoice = eUserChoice.Exit;
                    break;
            }
        }

        private static float setCurrentFuelStatus()
        {
            Console.WriteLine("Please enter the vehicle current fuel status:");
            string fuelCurrentStatusString = Console.ReadLine();
            float.TryParse(fuelCurrentStatusString, out float fuelCurrentStatus);
            return fuelCurrentStatus;
        }

        private static float setMaxFuelCapacity()
        {
            Console.WriteLine("Please enter the vehicle fuel max capacity:");
            string fuelMaxCapacityStr = Console.ReadLine();
            float.TryParse(fuelMaxCapacityStr, out float fuelMaxCapacity);
            return fuelMaxCapacity;
        }

        private static float setTruckMaxCapacity()
        {
            Console.WriteLine("Please enter truck max cargo capacity: ");
            string cargoCapacityString = Console.ReadLine();
            float.TryParse(cargoCapacityString, out float cargoCapacity);
            return cargoCapacity;
        }

        private static bool setIsTruckCooling()
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

        private static float setBatteryTimeLeft()
        {
            Console.WriteLine("Please enter the battery time left: ");
            string batteryTimeLeftString = Console.ReadLine();
            float.TryParse(batteryTimeLeftString, out float batteryTimeLeft);
            return batteryTimeLeft;
        }

        public static float setBatteryMaxTime()
        {
            Console.WriteLine("Please enter the max battery capacity:");
            string batterTimeCapacityString = Console.ReadLine();
            float.TryParse(batterTimeCapacityString, out float batteryTimeCapacity);
            return batteryTimeCapacity;
        }

        private static string setVehicleId()
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

        private static eVehicleStatus setVehicleStatus()
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
