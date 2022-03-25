using System;
using System.Collections.Generic;
using Construction;

namespace Construction
{
    public sealed class Creator
    {
        public static Dictionary<int, Building> allBuildings = new Dictionary<int, Building>();
        private Creator() { }
        private static int CalculateNumOfApartmentsPerEntrance(Building building)
        {
            return building.numOfApartments / building.numOfEntrances;
        }
        private static int CalculateHeightOfFloor(Building building)
        {
            return building.height / building.numOfFloors;
        }
        private static int CalculateNumOfApartmenstPerFloor(Building building)
        {
            return building.numOfApartments / building.numOfFloors;
        }

        public static string LookBuildingCharacteristic(Building building)
        {
            int heightOfFloor = CalculateHeightOfFloor(building);

            if (building.numOfApartments != 0 && building.numOfEntrances != 0)
            {
                int numOfApartmentsPerEntrance = CalculateNumOfApartmentsPerEntrance(building);

                int numOfApartmentsPerFloor = CalculateNumOfApartmenstPerFloor(building);

                string buildingCharacteristics = @$"Жилой дом № {building.buildingNum}.
Высота: {building.height} м.
Количество этажей: {building.numOfFloors}.
Количество подъездов: {building.numOfEntrances}.
Количество квартир: {building.numOfApartments}.
Количество квартир на подъезд: {numOfApartmentsPerEntrance}.
Высота этажа: {heightOfFloor} м.
Количество квартир на этаж: {numOfApartmentsPerFloor}.
";

                return buildingCharacteristics;
            }
            else
            {
                string buildingCharacteristics = @$"Частный дом № {building.buildingNum}.
Высота: {building.height} м.
Количество этажей: {building.numOfFloors}.
Высота этажа: {heightOfFloor} м.";

                return buildingCharacteristics;
            }


        }

        public static void AddToDictionary(Building newBuilding)
        {
            allBuildings.Add(newBuilding.buildingNum, newBuilding);
        }
        public static void RemoveFromDictionary(int buildingNum)
        {
                allBuildings.Remove(buildingNum);
        }

        public static Building CreateBuild(int height, int numOfFloors, int numOfEntrances, int numOfApartments)
        {
            Building building = new Building();

            building.buildingNum = Building.lastBuildingNum++;

            if (height <= 3)
            {
                throw new Exception("Невозможно построить здание ниже 3х метров.");
            }
            if (numOfFloors <= 0)
            {
                throw new Exception("Здание должно содержать хотя бы один этаж.");
            }
            if (height / 3 < numOfFloors)
            {
                throw new Exception("Невозможно построить здание с этажами ниже 3х метров.");
            }
            if (numOfEntrances < 1)
            {
                throw new Exception("Здание должно содержать как минимум один подъезд.");
            }
            if (numOfApartments < 2)

            {
                throw new Exception("Здание должно содержать как минимум две квартиры.");
            }

            building.height = height;

            building.numOfFloors = numOfFloors;

            building.numOfApartments = numOfApartments;

            building.numOfEntrances = numOfEntrances;

            return building;


        }
        public static Building CreateBuild(int height, int numOfFlors)
        {
            Building building = new Building();

            building.buildingNum = Building.lastBuildingNum++;

            if (height <= 3)
            {
                throw new Exception("Невозможно построить здание ниже 3х метров.");
            }
            if (numOfFlors <= 0)
            {
                throw new Exception("Здание должно содержать хотя бы один этаж.");
            }
            if (height / 3 < numOfFlors)
            {
                throw new Exception("Невозможно построить здание с этажами ниже 3х метров.");
            }

            building.height = height;

            building.numOfFloors = numOfFlors;

            return building;
        }
    }

}
