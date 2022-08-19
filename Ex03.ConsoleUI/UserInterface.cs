using System;
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

        private static void showMenu()
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

        private static void runUserInterface()
        {
            do
            {
                showMenu();
                switch (s_UserChoice)
                {
                    case eUserChoice.RegisterNewVehicle:
                        registerNewVehicle();
                        break;
                    case eUserChoice.ShowAllExistingVehicles:
                        showAllExistingVehicles();
                        break;
                    case eUserChoice.UpdateVehicleStatus:
                        updateVehicleStatus();
                        break;
                    case eUserChoice.FillAllTires:
                        fillAllTires();
                        break;
                    case eUserChoice.FuelVehicle:
                        fuelVehicle();
                        break;
                    case eUserChoice.ChargeVehicle:
                        chargeVehicle();
                        break;
                    case eUserChoice.ShowVehicleFullDetails:
                        showVehicleFullDetails();
                        break;
                    case eUserChoice.Exit:
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            while (true);
        }

        private static void registerNewVehicle()
        {
            Console.WriteLine("Please enter the vehicle ID you wish to enlist to the garage:");
            string id = Console.ReadLine();

            while (!InputValidations.CarIdValidation(id))
            {
                Console.WriteLine("Car id entered is invalid! please enter a valid id:");
                id = Console.ReadLine();
            }

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
                    Console.WriteLine("Entered value is invalid!");
                }

                createChosenVehicle(id);
            }
            else
            {
                Console.WriteLine("This vehicle is already in the system! Moving existing vehicle to repair now..");
                if (CreateAndSaveData.s_VehiclesInSystem[id] is Vehicle vehicle)
                {
                    vehicle.OwnerDetails.CarStatus = eCarStatus.InRepair;
                }
            }
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

        private static void createChosenVehicle(string i_RegistrationId) // a lot of input validation here
        { /// Collect all of the props in different methods ?
            Console.WriteLine("Please enter your name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please enter your Phone number: ");
            string ownerPhoneNum = Console.ReadLine();
            Console.WriteLine("Please enter Car wheels module (will apply for all tires): ");
            string wheelModule = Console.ReadLine();
            Console.WriteLine("Please enter Car wheels current air pressure (will apply for all tires): ");
            string currentAirPressureString = Console.ReadLine();
            float.TryParse(currentAirPressureString, out float currentAirPressure);
            Console.WriteLine("Please enter Car wheels max air pressure (will apply for all tires): ");
            string maxAirPressureString = Console.ReadLine();
            float.TryParse(maxAirPressureString, out float maxAirPressure);
            Console.WriteLine("Please enter car energy percentage left: ");
            string energyPercentageString = Console.ReadLine();
            float.TryParse(energyPercentageString, out float energyPercentage);
            Console.WriteLine("Please enter Car module: ");
            string carModule = Console.ReadLine();

            switch (s_VehicleType)
            {
                case eVehiclesAvailable.FueledCar:
                    fueledCarCreation(
                        i_RegistrationId,
                        ownerName,
                        ownerPhoneNum,
                        wheelModule,
                        currentAirPressure,
                        maxAirPressure,
                        carModule,
                        energyPercentage);
                    break;
                case eVehiclesAvailable.ElectricCar:
                    electricCarCreation(
                        i_RegistrationId,
                        ownerName,
                        ownerPhoneNum,
                        wheelModule,
                        currentAirPressure,
                        maxAirPressure,
                        carModule,
                        energyPercentage);
                    break;
                case eVehiclesAvailable.ElectricMotorcycle:
                    electricMotorcycleCreation(
                        i_RegistrationId,
                        ownerName,
                        ownerPhoneNum,
                        wheelModule,
                        currentAirPressure,
                        maxAirPressure,
                        carModule,
                        energyPercentage);
                    break;
                case eVehiclesAvailable.FueledMotorcycle:
                    fueledMotorcycleCreation(
                        i_RegistrationId,
                        ownerName,
                        ownerPhoneNum,
                        wheelModule,
                        currentAirPressure,
                        maxAirPressure,
                        carModule,
                        energyPercentage);
                    break;
                case eVehiclesAvailable.Truck:
                    truckCreation(
                        i_RegistrationId,
                        ownerName,
                        ownerPhoneNum,
                        wheelModule,
                        currentAirPressure,
                        maxAirPressure,
                        carModule,
                        energyPercentage);
                    break;
                default:
                    throw new FormatException();
            }
        }

        private static void truckCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_WheelModule,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModule,
            float i_EnergyPercentage)
        {
            bool isCooling;
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
                        isCooling = true;
                        break;
                    case "no":
                        isCooling = false;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            Console.WriteLine("Please enter truck max cargo capacity: ");
            string cargoCapacityString = Console.ReadLine();
            float.TryParse(cargoCapacityString, out float cargoCapacity);
            CreateAndSaveData.CreateTruck(
                i_CarModule,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelModule,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                isCooling,
                cargoCapacity,
                i_OwnerName,
                i_OwnerPhoneNumber);
        }

        private static void fueledMotorcycleCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelModule,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModule,
            float i_EnergyPercentage)
        {
            Console.WriteLine("Please enter motorcycle current fuel status:");
            string fuelCurrentStatusString = Console.ReadLine();
            float.TryParse(fuelCurrentStatusString, out float fuelCurrentStatus);
            Console.WriteLine("Please enter the fuel max capacity:");
            string fuelMaxCapacityStr = Console.ReadLine();
            float.TryParse(fuelMaxCapacityStr, out float fuelMaxCapacity);
            CreateAndSaveData.CreateFueledMotorcycle(
                i_CarModule,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelModule,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                setLicenseType(),
                setEngineCapacity(),
                setFuelType(),
                fuelCurrentStatus,
                fuelMaxCapacity,
                i_OwnerName,
                i_OwnerPhoneNum);
        }

        private static void electricMotorcycleCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelModule,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModule,
            float i_EnergyPercentage)
        {
            Console.WriteLine("Please enter the battery time left: ");
            string batteryTimeLeftString = Console.ReadLine();
            Console.WriteLine("Please enter the max battery capacity:");
            string batterTimeCapacityString = Console.ReadLine();
            float.TryParse(batteryTimeLeftString, out float batteryTimeLeft);
            float.TryParse(batterTimeCapacityString, out float batteryTimeCapacity);
            CreateAndSaveData.CreateElectricMotorcycle(
                i_CarModule,
                i_RegistrationId,
                i_EnergyPercentage,
                i_WheelModule,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                setLicenseType(),
                setEngineCapacity(),
                batteryTimeLeft,
                batteryTimeCapacity,
                i_OwnerName,
                i_OwnerPhoneNum);
        }

        private static void electricCarCreation(
            string i_RegistrationId,
            string i_OwnerName,
            string i_OwnerPhoneNum,
            string i_WheelModule,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_CarModule,
            float i_EnergyPercentage)
        {
            Console.WriteLine("Please enter the battery time left: ");
            string batteryTimeLeftString = Console.ReadLine();
            Console.WriteLine("Please enter the max battery capacity:");
            string batterTimeCapacityString = Console.ReadLine();
            float.TryParse(batteryTimeLeftString, out float batteryTimeLeft);
            float.TryParse(batterTimeCapacityString, out float batteryTimeCapacity);
            CreateAndSaveData.CreateElectricCar(i_CarModule, i_RegistrationId, i_EnergyPercentage, i_WheelModule, i_CurrentAirPressure, i_MaxAirPressure, setCarColor(), setNumOfDoors(), batteryTimeLeft, batteryTimeCapacity, i_OwnerName, i_OwnerPhoneNum);
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

        private static void fueledCarCreation(string i_RegistrationId, string i_OwnerName, string i_OwnerPhoneNum, string i_WheelModule, float i_CurrentAirPressure, float i_MaxAirPressure, string i_CarModule, float i_EnergyPercentage)
        {
            eCarColor carColor = setCarColor();
            eNumOfDoors numOfDoors = setNumOfDoors();
            eFuelType fuelType = setFuelType();

            Console.WriteLine("Please enter car current fuel status:");
            string fuelCurrentStatusStr = Console.ReadLine();
            float.TryParse(fuelCurrentStatusStr, out float fuelCurrentStatus);
            Console.WriteLine("Please enter the fuel max capacity:");
            string fuelMaxCapacityStr = Console.ReadLine();
            float.TryParse(fuelMaxCapacityStr, out float fuelMaxCapacity);
            CreateAndSaveData.CreateFueledCar(i_CarModule, i_RegistrationId, i_EnergyPercentage, i_WheelModule, i_CurrentAirPressure, i_MaxAirPressure, carColor, numOfDoors, fuelType, fuelCurrentStatus, fuelMaxCapacity, i_OwnerName, i_OwnerPhoneNum);
        }

        private static void showAllExistingVehicles()
        {

        }

        private static void updateVehicleStatus()
        {

        }

        private static void fillAllTires()
        {

        }

        private static void fuelVehicle()
        {

        }

        private static void chargeVehicle()
        {

        }

        private static void showVehicleFullDetails()
        {
            Console.WriteLine("Please Enter an id to show the car status:");
            string idToShow = Console.ReadLine();

            try
            {
                Console.WriteLine(CreateAndSaveData.s_VehiclesInSystem[idToShow]);
            }
            catch (ArgumentException exception)
            {
                Console.Write("This id is not registered in our garage!");
            }
        }
    }
}
