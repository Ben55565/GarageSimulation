using System;
using System.Diagnostics.CodeAnalysis;

namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class CreateAndSaveData
    {
        private static int s_VehicleNumOfWheels;
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
        public static Dictionary<string, object> s_VehiclesInSystem = new Dictionary<string, object>();
        public static List<string> s_AllVehiclesIds = new List<string>();
        public static List<string> s_AllVehiclesIdsInRepair = new List<string>();
        public static List<string> s_AllVehiclesIdsRepaired = new List<string>();
        public static List<string> s_AllVehiclesIdsPaid = new List<string>();
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter

        public static void UpdateVehicleStatusInLists(eVehicleStatus i_VehicleStatus, string i_CarId)
        {
            switch (i_VehicleStatus)
            {
                case eVehicleStatus.InRepair:
                    {
                        updateVehicleStatusToInRepair(i_CarId);
                        break;
                    }

                case eVehicleStatus.Paid:
                    {
                        updateVehicleStatusToPaid(i_CarId);
                        break;
                    }

                case eVehicleStatus.Repaired:
                default:
                    {
                        updateVehicleStatusToRepaired(i_CarId);
                        break;
                    }
            }
        }

        private static void updateVehicleStatusToRepaired(string i_CarId)
        {
            if (s_AllVehiclesIdsPaid.Contains(i_CarId))
            {
                s_AllVehiclesIdsPaid.Remove(i_CarId);
                s_AllVehiclesIdsRepaired.Add(i_CarId);
            }
            else if (s_AllVehiclesIdsInRepair.Contains(i_CarId))
            {
                s_AllVehiclesIdsInRepair.Remove(i_CarId);
                s_AllVehiclesIdsRepaired.Add(i_CarId);
            }
        }

        private static void updateVehicleStatusToPaid(string i_CarId)
        {
            if (s_AllVehiclesIdsRepaired.Contains(i_CarId))
            {
                s_AllVehiclesIdsRepaired.Remove(i_CarId);
                s_AllVehiclesIdsPaid.Add(i_CarId);
            }
            else if (s_AllVehiclesIdsInRepair.Contains(i_CarId))
            {
                s_AllVehiclesIdsInRepair.Remove(i_CarId);
                s_AllVehiclesIdsPaid.Add(i_CarId);
            }
        }

        private static void updateVehicleStatusToInRepair(string i_CarId)
        {
            if (s_AllVehiclesIdsRepaired.Contains(i_CarId))
            {
                s_AllVehiclesIdsRepaired.Remove(i_CarId);
                s_AllVehiclesIdsInRepair.Add(i_CarId);
            }
            else if (s_AllVehiclesIdsPaid.Contains(i_CarId))
            {
                s_AllVehiclesIdsPaid.Remove(i_CarId);
                s_AllVehiclesIdsInRepair.Add(i_CarId);
            }
        }

        public static void verifyVehicleTypeAndUpdateStatus(eVehicleStatus i_VehicleStatus, string i_CarId)
        {
            string vehicleType = s_VehiclesInSystem[i_CarId].GetType().Name;

            switch (vehicleType)
            {
                case "Truck":
                    {
                        Truck truck = (Truck)s_VehiclesInSystem[i_CarId];
                        UpdateVehicleStatusInLists(i_VehicleStatus, i_CarId);
                        truck.r_VehicleBasicDetails.SetCarStatus(i_VehicleStatus);
                        break;
                    }

                case "ElectricCar":
                    {
                        ElectricCar electricCar = (ElectricCar)s_VehiclesInSystem[i_CarId];
                        UpdateVehicleStatusInLists(i_VehicleStatus, i_CarId);
                        electricCar.r_CarBasicDetails.r_VehicleBasicDetails.SetCarStatus(i_VehicleStatus);
                        break;
                    }

                case "FueledCar":
                    {
                        FueledCar fueledCar = (FueledCar)s_VehiclesInSystem[i_CarId];
                        UpdateVehicleStatusInLists(i_VehicleStatus, i_CarId);
                        fueledCar.r_CarBasicDetails.r_VehicleBasicDetails.SetCarStatus(i_VehicleStatus);
                        break;
                    }

                case "ElectricMotorcycle":
                    {
                        ElectricMotorcycle electricMotorcycle = (ElectricMotorcycle)s_VehiclesInSystem[i_CarId];
                        UpdateVehicleStatusInLists(i_VehicleStatus, i_CarId);
                        electricMotorcycle.r_MotorcycleBasicDetails.r_VehicleBasicDetails.SetCarStatus(i_VehicleStatus);
                        break;
                    }

                case "FueledMotorcycle":
                    {
                        FueledMotorcycle fueledMotorcycle = (FueledMotorcycle)s_VehiclesInSystem[i_CarId];
                        UpdateVehicleStatusInLists(i_VehicleStatus, i_CarId);
                        fueledMotorcycle.r_MotorcycleBasicDetails.r_VehicleBasicDetails.SetCarStatus(i_VehicleStatus);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        public static void verifyVehicleTypeAndFillTiresToMax(string i_CarId)
        {
            string vehicleType = s_VehiclesInSystem[i_CarId].GetType().Name;

            switch (vehicleType)
            {
                case "Truck":
                    {
                        Truck truck = (Truck)s_VehiclesInSystem[i_CarId];
                        truck.r_VehicleBasicDetails.FillAirInTiresToTheMax();
                        break;
                    }

                case "ElectricCar":
                    {
                        ElectricCar electricCar = (ElectricCar)s_VehiclesInSystem[i_CarId];
                        electricCar.r_CarBasicDetails.r_VehicleBasicDetails.FillAirInTiresToTheMax();
                        break;
                    }

                case "FueledCar":
                    {
                        FueledCar fueledCar = (FueledCar)s_VehiclesInSystem[i_CarId];
                        fueledCar.r_CarBasicDetails.r_VehicleBasicDetails.FillAirInTiresToTheMax();
                        break;
                    }

                case "ElectricMotorcycle":
                    {
                        ElectricMotorcycle electricMotorcycle = (ElectricMotorcycle)s_VehiclesInSystem[i_CarId];
                        electricMotorcycle.r_MotorcycleBasicDetails.r_VehicleBasicDetails.FillAirInTiresToTheMax();
                        break;
                    }

                case "FueledMotorcycle":
                    {
                        FueledMotorcycle fueledMotorcycle = (FueledMotorcycle)s_VehiclesInSystem[i_CarId];
                        fueledMotorcycle.r_MotorcycleBasicDetails.r_VehicleBasicDetails.FillAirInTiresToTheMax();
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        public static void verifyVehicleTypeAndFuelVehicle(float i_LittersToFuel, eFuelType i_FuelType, string i_CarId)
        {
            string vehicleType = s_VehiclesInSystem[i_CarId].GetType().Name;

            switch (vehicleType)
            {
                case "Truck":
                    {
                        Truck truck = (Truck)s_VehiclesInSystem[i_CarId];

                        if (truck.m_FueledVehicleDetails.r_FuelType != i_FuelType)
                        {
                            throw new ArgumentException();
                        }

                        truck.m_FueledVehicleDetails.FuelVehicle(i_LittersToFuel);
                        break;
                    }

                case "FueledCar":
                    {
                        FueledCar fueledCar = (FueledCar)s_VehiclesInSystem[i_CarId];

                        if (fueledCar.m_FueledVehicleDetails.r_FuelType != i_FuelType)
                        {
                            throw new ArgumentException();
                        }

                        fueledCar.m_FueledVehicleDetails.FuelVehicle(i_LittersToFuel);
                        break;
                    }

                case "FueledMotorcycle":
                    {
                        FueledMotorcycle fueledMotorcycle = (FueledMotorcycle)s_VehiclesInSystem[i_CarId];

                        if (fueledMotorcycle.m_FueledVehicleDetails.r_FuelType != i_FuelType)
                        {
                            throw new ArgumentException();
                        }

                        fueledMotorcycle.m_FueledVehicleDetails.FuelVehicle(i_LittersToFuel);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        public static void verifyVehicleTypeAndChargeVehicle(float i_MinutesToCharge, string i_CarId)
        {
            string vehicleType = s_VehiclesInSystem[i_CarId].GetType().Name;

            switch (vehicleType)
            {
                case "ElectricCar":
                    {
                        ElectricCar electricCar = (ElectricCar)s_VehiclesInSystem[i_CarId];
                        electricCar.m_ElectricVehicleDetails.ChargeVehicle(i_MinutesToCharge);
                        break;
                    }

                case "ElectricMotorcycle":
                    {
                        ElectricMotorcycle electricMotorcycle = (ElectricMotorcycle)s_VehiclesInSystem[i_CarId];
                        electricMotorcycle.m_ElectricVehicleDetails.ChargeVehicle(i_MinutesToCharge);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
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
            string i_OwnerPhone)
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

            Wheel[] carWheels = new Wheel[s_VehicleNumOfWheels];

            for (int i = 0; i < carWheels.Length; i++)
            {
                carWheels[i] = new Wheel(i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure);
            }

            s_AllVehiclesIds.Add(i_RegistrationId);
            s_AllVehiclesIdsInRepair.Add(i_RegistrationId);
            OwnerDetailsAndStatus ownerDetails = new OwnerDetailsAndStatus(i_OwnerName, i_OwnerPhone, eVehicleStatus.InRepair);

            return new Vehicle(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, carWheels, ownerDetails);
        }

        private static Car createCar(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            const eVehicleType k_Type = eVehicleType.Car;
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone);

            return new Car(vehicle, i_CarColor, i_NumOfDoors);
        }

        private static Motorcycle createMotorcycle(
            string i_ModelName,
            string i_RegistrationId,
            float i_EnergyPercentageLeft,
            string i_WheelModuleName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure,
            eLicenseType i_LicenseType,
            int i_EngineCapacity,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            const eVehicleType k_Type = eVehicleType.Motorcycle;
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone);

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
            Car car = createCar(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_CarColor, i_NumOfDoors, i_OwnerName, i_OwnerPhone);
            ElectricVehicleDetails electricVehicleDetails = new ElectricVehicleDetails(i_MaxBatteryCapacityTime, i_CurrentBatteryTimeLeft);
            s_VehiclesInSystem.Add(i_RegistrationId, new ElectricCar(car, electricVehicleDetails));
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
            Car car = createCar(i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_CarColor, i_NumOfDoors, i_OwnerName, i_OwnerPhone);
            FueledVehicleDetails fueledVehicleDetails = new FueledVehicleDetails(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            s_VehiclesInSystem.Add(i_RegistrationId, new FueledCar(car, fueledVehicleDetails));
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
            Motorcycle motorcycle = createMotorcycle(
                i_ModelName,
                i_RegistrationId,
                i_EnergyPercentageLeft,
                i_WheelModuleName,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                i_LicenseType,
                i_EngineCapacity,
                i_OwnerName,
                i_OwnerPhone);
            ElectricVehicleDetails electricVehicleDetails = new ElectricVehicleDetails(i_MaxBatteryCapacityTime, i_CurrentBatteryTimeLeft);
            s_VehiclesInSystem.Add(i_RegistrationId, new ElectricMotorcycle(motorcycle, electricVehicleDetails));
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
            Motorcycle motorcycle = createMotorcycle(
                i_ModelName,
                i_RegistrationId,
                i_EnergyPercentageLeft,
                i_WheelModuleName,
                i_CurrentAirPressure,
                i_MaxAirPressure,
                i_LicenseType,
                i_EngineCapacity,
                i_OwnerName,
                i_OwnerPhone);
            FueledVehicleDetails fueledVehicleDetails = new FueledVehicleDetails(
                i_FuelType,
                i_CurrentFuelStatus,
                i_MaxFuelCapacity);
            s_VehiclesInSystem.Add(i_RegistrationId, new FueledMotorcycle(motorcycle, fueledVehicleDetails));
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
            const eVehicleType k_Type = eVehicleType.Truck;
            Vehicle vehicle = createVehicle(k_Type, i_ModelName, i_RegistrationId, i_EnergyPercentageLeft, i_WheelModuleName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone);
            FueledVehicleDetails fueledVehicleDetails = new FueledVehicleDetails(i_FuelType, i_CurrentFuelStatus, i_MaxFuelCapacity);
            s_VehiclesInSystem.Add(i_RegistrationId, new Truck(vehicle, i_TransportWithCooling, i_MaxCargoWeight, fueledVehicleDetails));
        }
    }
}
