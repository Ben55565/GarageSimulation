namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class GarageManager
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

        public static void FuelVehicle(float i_LittersToFuel, eFuelType i_FuelType, string i_VehicleID)
        {
            if (s_VehiclesInSystem[i_VehicleID].m_fueledEngine == null)
            {
                throw new Exception("Cannot fuel an electric vehicle!");
            }

            if (!s_VehiclesInSystem[i_VehicleID].m_fueledEngine.FuelVehicle(i_LittersToFuel))
            {
                throw new ValueOutOfRangeException(
                    s_VehiclesInSystem[i_VehicleID].m_fueledEngine.r_MaxFuelCapacity,
                    0,
                    "Surpassed Maximum Fuel Capacity for this Vehicle: ");
            }
            else if (s_VehiclesInSystem[i_VehicleID].m_fueledEngine.r_FuelType != i_FuelType)
            {
                throw new ArgumentException("Fuel Type is not matching the Vehicle's fuel type.");
            }
        }

        public static void ChargeVehicle(float i_MinutesToCharge, string i_VehicleID)
        {
            if (s_VehiclesInSystem[i_VehicleID].m_electricEngine == null)
            {
                throw new Exception("Cannot Charge an fueled vehicle!");
            }

            if (!s_VehiclesInSystem[i_VehicleID].m_electricEngine.ChargeVehicle(i_MinutesToCharge))
            {
                throw new ValueOutOfRangeException(s_VehiclesInSystem[i_VehicleID].m_electricEngine.r_MaxBatteryCapacityTime, 0, "Surpassed Maximum Battery Capacity for this Electric Vehicle.");
            }
        }

        private static Wheel[] setWheels(string i_WheelModuleName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            Wheel[] vehicleWheels = new Wheel[s_VehicleNumOfWheels];

            for (int i = 0; i < vehicleWheels.Length; i++)
            {
                vehicleWheels[i] = new Wheel(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            }

            return vehicleWheels;
        }

        private static void setVehicleWheelsNumber(eVehicleType i_VehicleType)
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

        private static Car createCar(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            Wheel[] i_VehicleWheels,
            OwnerDetailsAndStatus i_OwnerDetails,
            object i_Engine,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors)
        {
            s_AllVehiclesIds.Add(i_RegistrationId);
            s_AllVehiclesIdsInRepair.Add(i_RegistrationId);

            return new Car(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_VehicleWheels, i_OwnerDetails, i_Engine, i_CarColor, i_NumOfDoors);
        }

        private static Motorcycle createMotorcycle(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            Wheel[] i_VehicleWheels,
            OwnerDetailsAndStatus i_OwnerDetails,
            object i_Engine,
            eLicenseType i_LicenseType,
            int i_EngineCapacity)
        {
            s_AllVehiclesIds.Add(i_RegistrationId);
            s_AllVehiclesIdsInRepair.Add(i_RegistrationId);

            return new Motorcycle(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_VehicleWheels, i_OwnerDetails, i_Engine, i_LicenseType, i_EngineCapacity);
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
            ElectricEngine electricVehicleDetails = new ElectricEngine(i_MaxBatteryCapacityTime, i_CurrentBatteryTimeLeft);
            setVehicleWheelsNumber(eVehicleType.Car);
            OwnerDetailsAndStatus ownerDetailsAndStatus = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);
            Wheel[] vehicleWheels = setWheels(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            Car electricCar = createCar(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetailsAndStatus, electricVehicleDetails, i_CarColor, i_NumOfDoors);
            s_VehiclesInSystem.Add(i_RegistrationId, electricCar);
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
            FuelEngine fueledVehicleDetails = new FuelEngine(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            setVehicleWheelsNumber(eVehicleType.Car);
            OwnerDetailsAndStatus ownerDetailsAndStatus = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);
            Wheel[] vehicleWheels = setWheels(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            Car fueledCar = createCar(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetailsAndStatus, fueledVehicleDetails, i_CarColor, i_NumOfDoors);
            s_VehiclesInSystem.Add(i_RegistrationId, fueledCar);
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
            ElectricEngine electricVehicleDetails = new ElectricEngine(i_MaxBatteryCapacityTime, i_CurrentBatteryTimeLeft);
            setVehicleWheelsNumber(eVehicleType.Car);
            OwnerDetailsAndStatus ownerDetailsAndStatus = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);
            Wheel[] vehicleWheels = setWheels(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            Motorcycle motorcycle = createMotorcycle(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetailsAndStatus, electricVehicleDetails, i_LicenseType, i_EngineCapacity);
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
            FuelEngine fueledVehicleDetails = new FuelEngine(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            setVehicleWheelsNumber(eVehicleType.Motorcycle);
            OwnerDetailsAndStatus ownerDetailsAndStatus = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);
            Wheel[] vehicleWheels = setWheels(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            Motorcycle motorcycle = createMotorcycle(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetailsAndStatus, fueledVehicleDetails, i_LicenseType, i_EngineCapacity);
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
            FuelEngine fueledVehicleDetails = new FuelEngine(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            setVehicleWheelsNumber(eVehicleType.Truck);
            OwnerDetailsAndStatus ownerDetailsAndStatus = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);
            Wheel[] vehicleWheels = setWheels(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            s_AllVehiclesIds.Add(i_RegistrationId);
            s_AllVehiclesIdsInRepair.Add(i_RegistrationId);
            s_VehiclesInSystem.Add(i_RegistrationId, new Truck(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, vehicleWheels, ownerDetailsAndStatus, fueledVehicleDetails, i_TransportWithCooling, i_MaxCargoWeight));
        }
    }
}