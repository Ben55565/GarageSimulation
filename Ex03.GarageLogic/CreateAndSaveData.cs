namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class CreateAndSaveData
    {
        private static int s_VehicleNumOfWheels;
        public static Dictionary<string, Vehicle> s_VehiclesInSystem = new Dictionary<string, Vehicle>();
        public static List<string> s_AllVehiclesIds = new List<string>();
        public static List<string> s_AllVehiclesIdsInRepair = new List<string>();
        public static List<string> s_AllVehiclesIdsRepaired = new List<string>();
        public static List<string> s_AllVehiclesIdsPaid = new List<string>();

        public static void UpdateVehicleStatus(eVehicleStatus i_VehicleStatus, string i_VehicleID)
        {
            s_VehiclesInSystem[i_VehicleID].SetVehicleStatus(i_VehicleStatus);
            switch (i_VehicleStatus)
            {
                case eVehicleStatus.InRepair:
                    {
                        updateVehicleStatusToInRepair(i_VehicleID);
                        break;
                    }

                case eVehicleStatus.Paid:
                    {
                        updateVehicleStatusToPaid(i_VehicleID);
                        break;
                    }

                case eVehicleStatus.Repaired:
                default:
                    {
                        updateVehicleStatusToRepaired(i_VehicleID);
                        break;
                    }
            }
        }

        private static void updateVehicleStatusToRepaired(string i_VehicleID)
        {
            if (s_AllVehiclesIdsPaid.Contains(i_VehicleID))
            {
                s_AllVehiclesIdsPaid.Remove(i_VehicleID);
                s_AllVehiclesIdsRepaired.Add(i_VehicleID);
            }
            else if (s_AllVehiclesIdsInRepair.Contains(i_VehicleID))
            {
                s_AllVehiclesIdsInRepair.Remove(i_VehicleID);
                s_AllVehiclesIdsRepaired.Add(i_VehicleID);
            }
        }

        private static void updateVehicleStatusToPaid(string i_VehicleID)
        {
            if (s_AllVehiclesIdsRepaired.Contains(i_VehicleID))
            {
                s_AllVehiclesIdsRepaired.Remove(i_VehicleID);
                s_AllVehiclesIdsPaid.Add(i_VehicleID);
            }
            else if (s_AllVehiclesIdsInRepair.Contains(i_VehicleID))
            {
                s_AllVehiclesIdsInRepair.Remove(i_VehicleID);
                s_AllVehiclesIdsPaid.Add(i_VehicleID);
            }
        }

        private static void updateVehicleStatusToInRepair(string i_VehicleID)
        {
            if (s_AllVehiclesIdsRepaired.Contains(i_VehicleID))
            {
                s_AllVehiclesIdsRepaired.Remove(i_VehicleID);
                s_AllVehiclesIdsInRepair.Add(i_VehicleID);
            }
            else if (s_AllVehiclesIdsPaid.Contains(i_VehicleID))
            {
                s_AllVehiclesIdsPaid.Remove(i_VehicleID);
                s_AllVehiclesIdsInRepair.Add(i_VehicleID);
            }
        }

        public static void FuelVehicle(float i_LittersToFuel, eFuelType i_FuelType, string i_VehicleID)// need to throw exception when fueling wrong fuel, or fueling above the max
        {
            if (!s_VehiclesInSystem[i_VehicleID].m_fueledEngine.FuelVehicle(i_LittersToFuel))
            {
                throw new ValueOutOfRangeException(s_VehiclesInSystem[i_VehicleID].m_fueledEngine.r_MaxFuelCapacity, 0, "Surpassed Maximum Fuel Capacity for this Vehicle.");
            }
            else if (s_VehiclesInSystem[i_VehicleID].m_fueledEngine.r_FuelType != i_FuelType)
            {
                throw new ArgumentException("Fuel Type is not matching the Vehicle's fuel type.");
            }
        }

        public static void ChargeVehicle(float i_MinutesToCharge, string i_VehicleID) // need to throw exception when charging above max
        {
            if (!s_VehiclesInSystem[i_VehicleID].m_electricEngine.ChargeVehicle(i_MinutesToCharge))
            {
                throw new ValueOutOfRangeException(s_VehiclesInSystem[i_VehicleID].m_electricEngine.r_MaxBatteryCapacityTime, 0, "Surpassed Maximum Battery Capacity for this Electric Vehicle.");
            }
        }

        public static Wheel[] setWheels(string i_WheelModuleName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            Wheel[] vehicleWheels = new Wheel[s_VehicleNumOfWheels];

            for (int i = 0; i < vehicleWheels.Length; i++)
            {
                vehicleWheels[i] = new Wheel(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            }

            return vehicleWheels;
        }

        public static void setVehicleWheelsNumber(eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.Motorcycle:
                    {
                        s_VehicleNumOfWheels = 2;
                        break;
                    }

                case eVehicleType.Car:
                    {
                        s_VehicleNumOfWheels = 4;
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        s_VehicleNumOfWheels = 16;
                        break;
                    }

                default:
                    {
                        s_VehicleNumOfWheels = 4;
                        break;
                    }
            }
        }

        private static Vehicle createVehicle(
            eVehicleType i_VehicleType,
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            string i_OwnerName,
            string i_OwnerPhone,
            object i_CarEngine)
        {
            setVehicleWheelsNumber(i_VehicleType);
            Wheel[] vehicleWheels = setWheels(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            s_AllVehiclesIds.Add(i_RegistrationId);
            s_AllVehiclesIdsInRepair.Add(i_RegistrationId);
            OwnerDetailsAndStatus ownerDetails = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);
            Vehicle vehicle = i_CarEngine.GetType() == typeof(ElectricVehicleDetails) ? new Vehicle(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetails, (ElectricVehicleDetails)i_CarEngine) : new Vehicle(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetails, (FueledVehicleDetails)i_CarEngine);

            return vehicle;
        }

        private static Car createCar(
            Vehicle vehicle,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors)
        {
            return new Car(vehicle, i_CarColor, i_NumOfDoors);
        }

        private static Motorcycle createMotorcycle(
            Vehicle vehicle,
            eLicenseType i_LicenseType,
            int i_EngineCapacity)
        {
            return new Motorcycle(vehicle, i_LicenseType, i_EngineCapacity);
        }

        public static void CreateElectricCar(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            float i_CurrentBatteryTimeLeft,
            float i_MaxBatteryCapacityTime,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            ElectricVehicleDetails electricVehicleDetails = new ElectricVehicleDetails(i_MaxBatteryCapacityTime, i_CurrentBatteryTimeLeft);
            const eVehicleType k_Type = eVehicleType.Car;
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone, electricVehicleDetails);
            Car car = createCar(vehicle, i_CarColor, i_NumOfDoors);
            s_VehiclesInSystem.Add(i_RegistrationId, car);
        }

        public static void CreateFueledCar(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            eFuelType i_FuelType,
            float i_CurrentFuelStatus,
            float i_MaxFuelCapacity,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            const eVehicleType k_Type = eVehicleType.Car;
            FueledVehicleDetails fueledVehicleDetails = new FueledVehicleDetails( i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone, fueledVehicleDetails);
            Car car = createCar(vehicle, i_CarColor, i_NumOfDoors);
            s_VehiclesInSystem.Add(i_RegistrationId, car);
        }

        public static void CreateElectricMotorcycle(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            eLicenseType i_LicenseType,
            int i_EngineCapacity,
            float i_CurrentBatteryTimeLeft,
            float i_MaxBatteryCapacityTime,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            const eVehicleType k_Type = eVehicleType.Motorcycle;
            ElectricVehicleDetails electricVehicleDetails = new ElectricVehicleDetails(i_MaxBatteryCapacityTime, i_CurrentBatteryTimeLeft);
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone, electricVehicleDetails);
            Motorcycle motorcycle = createMotorcycle(vehicle, i_LicenseType, i_EngineCapacity);
            s_VehiclesInSystem.Add(i_RegistrationId, motorcycle);
        }

        public static void CreateFueledMotorcycle(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            eLicenseType i_LicenseType,
            int i_EngineCapacity,
            eFuelType i_FuelType,
            float i_CurrentFuelStatus,
            float i_MaxFuelCapacity,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            const eVehicleType k_Type = eVehicleType.Motorcycle;
            FueledVehicleDetails fueledVehicleDetails = new FueledVehicleDetails(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone, fueledVehicleDetails);
            Motorcycle motorcycle = createMotorcycle(vehicle, i_LicenseType, i_EngineCapacity);
            s_VehiclesInSystem.Add(i_RegistrationId, motorcycle);
        }

        public static void CreateTruck(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            bool i_TransportWithCooling,
            float i_MaxCargoWeight,
            string i_OwnerName,
            string i_OwnerPhone,
            eFuelType i_FuelType,
            float i_CurrentFuelStatus,
            float i_MaxFuelCapacity)
        {
            FueledVehicleDetails fueledVehicleDetails = new FueledVehicleDetails(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            const eVehicleType k_Type = eVehicleType.Truck;
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone, fueledVehicleDetails);
            s_VehiclesInSystem.Add(i_RegistrationId, new Truck(vehicle, i_TransportWithCooling, i_MaxCargoWeight, fueledVehicleDetails));
        }
    }
}
