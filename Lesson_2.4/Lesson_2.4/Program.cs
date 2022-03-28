using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson_2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество зданий. Значение по умолчанию 5");

            int NumOfBuildings = 5;

            try
            {
                NumOfBuildings = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введено параметр по умолчанию.");
            }
            Building[] buildings = new Building[NumOfBuildings];

            Console.WriteLine(@"Введите параметры здания через пробел в формате:
'Высота' 'Количество этажей' 'Количество подъездов' 'Количество квартир'.
Либо введите лишь первые 2 параметра для того, чтобы построить частный дом.'");
            Console.WriteLine();

            Console.WriteLine("Здание должно быть хотя бы 3 метра в высоту.");

            Console.WriteLine("Здание должно содержать хотя бы один этаж.");

            Console.WriteLine("Высота одного этажа не может быть ниже 3х метров.");

            Dictionary<int, Building> AllBuildings = new Dictionary<int, Building>();

            for (int i = 0; i < buildings.Length; i++)
            {
                try
                {
                    string[] a = (Console.ReadLine().Split(' '));

                    if (a.Length == 2)
                    {
                        buildings[i] = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]));

                        Creator.AddToDictionary(buildings[i], AllBuildings);

                        continue;
                    }

                    buildings[i] = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                    Creator.AddToDictionary(buildings[i], AllBuildings);
                }
                catch
                {
                    --i;
                    continue;
                }

            }



            Console.Clear();

            Console.WriteLine("Для того чтобы посмотреть характеристики здания введите 'Посмотреть'.");

            Console.WriteLine("Для того чтобы снести здание введите 'Снести'.");

            Console.WriteLine("Для того чтобы построить здание введите 'Построить'.");

            Console.WriteLine("Для выхода введите 'Выход'.");

            string UserChoice = string.Empty;

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "Посмотреть":
                        Console.WriteLine("Введите номер здания.");
                        try
                        {
                            int BuildingNum = Convert.ToInt32(Console.ReadLine());

                            Creator.LookBuildingCharacteristic(AllBuildings, BuildingNum);

                        }
                        catch
                        {
                            Console.WriteLine("Введите номер здания в корректном формате.");
                        }
                        break;
                    case "Снести":
                        Console.WriteLine("Введите номер здания для сноса.");
                        try
                        {
                            int BuildingNum = Convert.ToInt32(Console.ReadLine());

                            Creator.RemoveFromDictionary(BuildingNum, AllBuildings);

                        }
                        catch
                        {
                            Console.WriteLine("Введите номер здания в корректном формате.");
                        }
                        break;
                    case "Построить":
                        Console.WriteLine(@"Введите параметры здания через пробел в формате:
'Высота' 'Количество этажей' 'Количество подъездов' 'Количество квартир'.
Либо введите лишь первые 2 параметра для того, чтобы построить частный дом.");
                        Console.WriteLine();

                        Console.WriteLine("Здание должно быть хотя бы 3 метра в высоту.");

                        Console.WriteLine("Здание должно содержать хотя бы один этаж.");

                        Console.WriteLine("Высота одного этажа не может быть ниже 3х метров.");

                        try
                        {
                            string[] a = (Console.ReadLine().Split(' '));

                            if (a.Length == 2)
                            {
                                Building NewBuilding = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]));

                                Creator.AddToDictionary(NewBuilding, AllBuildings);

                                break;
                            }

                            Building building = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                            Creator.AddToDictionary(building, AllBuildings);
                        }
                        catch
                        {
                            Console.WriteLine("Введите параметры здания в корректном формате.");
                        }
                        break;

                    case "Очистить":
                        Console.Clear();
                        break;
                    case "Помощь":
                        Console.WriteLine("Для того чтобы посмотреть характеристики здания введите 'Посмотреть'.");


                        Console.WriteLine("Для того чтобы снести здание введите 'Снести'.");

                        Console.WriteLine("Для выхода введите 'Выход'.");
                        break;
                    case "Выход":
                        break;
                    default:
                        Console.WriteLine("Команда не распознанна.");
                        break;
                }
            } while (UserChoice != "Выход");

        }
    }

     public class Building
    {


        internal protected static int LastBuildingNum = 0;

        internal protected int BuildingNum;

        internal protected int Height;

        internal protected int NumOfFloors;

        internal protected int NumOfApartments;

        internal protected int NumOfEntrances;

        internal protected Building() { }

    }
    public class Creator : Building
    {
        private Creator() { }
        private static float CalculateNumOfApartmentsPerEntrance(Building building)
        {
            return (float)building.NumOfApartments / (float)building.NumOfEntrances;
        }
        private static float CalculateHeightOfFloor(Building building)
        {
            return (float)building.Height / (float)building.NumOfFloors;
        }
        private static float CalculateNumOfApartmenstPerFloor(Building building)
        {
            return (float)building.NumOfApartments / (float)building.NumOfFloors;
        }

        public static void LookBuildingCharacteristic(Dictionary<int, Building> dictionary, int BuildingNum)
        {
            if (!dictionary.TryGetValue(BuildingNum, out Building building))
            {
                Console.WriteLine("Здания с данным номером не существует.");

                return;
            }
            float HeightOfFloor = CalculateHeightOfFloor(building);

            if (building.NumOfApartments != 0 && building.NumOfEntrances != 0)
            {
                float NumOfApartmentsPerEntrance = CalculateNumOfApartmentsPerEntrance(building);

                float NumOfApartmentsPerFloor = CalculateNumOfApartmenstPerFloor(building);

                Console.WriteLine(new string('-', 40));

                Console.WriteLine($"Жилой дом №{building.BuildingNum}.");

                Console.WriteLine($"Высота: {building.Height} м.");

                Console.WriteLine($"Количество этажей: {building.NumOfFloors}.");

                Console.WriteLine($"Количество подъездов: {building.NumOfEntrances}.");

                Console.WriteLine($"Количество квартир: {building.NumOfApartments}.");

                Console.WriteLine($"Количество квартир на подъезд: {NumOfApartmentsPerEntrance}.");

                Console.WriteLine($"Высота этажа: {HeightOfFloor} м.");

                Console.WriteLine($"Количество квартир на этаж: {NumOfApartmentsPerFloor}.");

                Console.WriteLine(new string('-', 40));

            }else
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine($"Частный дом №{building.BuildingNum}.");

                Console.WriteLine($"Высота: {building.Height} м.");

                Console.WriteLine($"Количество этажей: {building.NumOfFloors}.");

                Console.WriteLine($"Высота этажа: {HeightOfFloor} м.");

                Console.WriteLine(new string('-', 40));
            }
        }


        public static void AddToDictionary(Building NewBuilding, Dictionary<int, Building> AllBuildings)
        {
            AllBuildings.Add(NewBuilding.BuildingNum, NewBuilding);

        }
        public static void RemoveFromDictionary(int BuildingNum, Dictionary<int, Building> AllBuildings)
        {
            try
            {
                AllBuildings.Remove(BuildingNum);
            }
            catch
            {
                Console.WriteLine("Здания с данным номером не существует.");
            }

            Console.WriteLine("Здание снесено.");
        }

        public static Building CreateBuild(int Height, int NumOfFloors, int NumOfEntrances, int NumOfApartments)
        {
            Building building = new Building();

            building.BuildingNum = LastBuildingNum++;

            if (Height <= 3)
            {
                Console.WriteLine("Невозможно построить здание ниже 3 метров.");

                Console.WriteLine("Введите корректную высоту.");

                do
                {
                    try
                    {
                        Height = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }
                } while (Height <= 3);
            }
            if (NumOfFloors <= 0)
            {
                Console.WriteLine("Здание должно содержать хотя бы один этаж.");

                Console.WriteLine("Введите корректное количество этажей.");

                do
                {
                    try
                    {
                        NumOfFloors = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }

                } while (NumOfFloors <= 0);
            }
            if (Height / 3 < NumOfFloors)
            {
                Console.WriteLine("Невозможно построить здание с этажами ниже 3х метров.");

                Console.WriteLine("Введите корректное количество этажей.");

                do
                {
                    try
                    {
                        NumOfFloors = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }

                } while (Height / 3 < NumOfFloors);

            }
            if (NumOfEntrances < 1)
            {
                Console.WriteLine("Здание должно содержать как минимум один подъезд.");

                Console.WriteLine("Введите корректное количество подъездов.");

                do
                {
                    try
                    {
                        NumOfEntrances = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }

                } while (NumOfEntrances < 1);
            }
            if (NumOfApartments < 2)
            {
                Console.WriteLine("Здание должно содержать как минимум две квартиры.");

                Console.WriteLine("Введите корректное количество квартир.");
                do
                {
                    try
                    {
                        NumOfApartments = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }

                } while (NumOfApartments < 2);
            }

            building.Height = Height;

            building.NumOfFloors = NumOfFloors;

            building.NumOfApartments = NumOfApartments;

            building.NumOfEntrances = NumOfEntrances;

            Console.WriteLine($"Дом c номером {building.BuildingNum} построен.");

            return building;


        }

        public static Building CreateBuild(int Height, int NumOfFloors)
        {
            Building building = new Building();

            building.BuildingNum = LastBuildingNum++;

            if (Height <= 3)
            {
                Console.WriteLine("Невозможно построить здание ниже 3 метров.");

                Console.WriteLine("Введите корректную высоту.");

                do
                {
                    try
                    {
                        Height = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }
                } while (Height <= 3);
            }
            if (NumOfFloors <= 0)
            {
                Console.WriteLine("Здание должно содержать хотя бы один этаж.");

                Console.WriteLine("Введите корректное количество этажей.");

                do
                {
                    try
                    {
                        NumOfFloors = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }

                } while (NumOfFloors <= 0);
            }
            if (Height / 3 < NumOfFloors)
            {
                Console.WriteLine("Невозможно построить здание с этажами ниже 3х метров.");

                Console.WriteLine("Введите корректное количество этажей.");

                do
                {
                    try
                    {
                        NumOfFloors = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                    }

                } while (Height / 3 < NumOfFloors);

            }
            building.Height = Height;

            building.NumOfFloors = NumOfFloors;

            Console.WriteLine($"Дом c номером {building.BuildingNum} построен.");

            return building;
        }
    }
}
