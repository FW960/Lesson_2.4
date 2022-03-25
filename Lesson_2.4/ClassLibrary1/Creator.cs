using System;
using Construction;

namespace Construction
{
    public sealed class Create : Building
    {
        private Create() { }
        private static float CalculateNumOfApartmentsPerEntrance(Create building)
        {
            return (float)building.NumOfApartments / (float)building.NumOfEntrances;
        }
        private static float CalculateHeightOfFloor(Create building)
        {
            return (float)building.Height / (float)building.NumOfFloors;
        }
        private static float CalculateNumOfApartmenstPerFloor(Create building)
        {
            return (float)building.NumOfApartments / (float)building.NumOfFloors;
        }

        public static string LookBuildingCharacteristic(Create building)
        {

            float NumOfApartmentsPerEntrance = CalculateNumOfApartmentsPerEntrance(building);

            float HeightOfFloor = CalculateHeightOfFloor(building);

            float NumOfApartmentsPerFloor = CalculateNumOfApartmenstPerFloor(building);

            string BuildingCharacteristics = @$"Номер здания: {building.BuildingNum}.
Высота: {building.Height} м.
Количество этажей: {building.NumOfFloors}.
Количество подъездов: {building.NumOfEntrances}.
Количество квартир: {building.NumOfApartments}.
Количество квартир на подъезд: {NumOfApartmentsPerEntrance}.
Высота этажа: {HeightOfFloor} м.
Количество квартир на этаж: {NumOfApartmentsPerFloor}.
";

            return BuildingCharacteristics;
        }

        public static Create CreateBuild(int Height, int NumOfFloors, int NumOfEntrances, int NumOfApartments)
        {
            Create building = new Create();

            building.BuildingNum = LastBuildingNum++;

            if (Height <= 3)
            {
                throw new Exception("Невозможно построить здание ниже 3х метров.");
            }
            if (NumOfFloors <= 0)
            {
                throw new Exception("Здание должно содержать хотя бы один этаж.");
            }
            if (Height / 3 < NumOfFloors)
            {
                throw new Exception("Невозможно построить здание с этажами ниже 3х метров.");
            }
            if (NumOfEntrances < 1)
            {
                throw new Exception("Здание должно содержать как минимум один подъезд.");
            }
            if (NumOfApartments < 2)

            {
                throw new Exception("Здание должно содержать как минимум две квартиры.");
            }

            building.Height = Height;

            building.NumOfFloors = NumOfFloors;

            building.NumOfApartments = NumOfApartments;

            building.NumOfEntrances = NumOfEntrances;

            return building;


        }
    }
}
