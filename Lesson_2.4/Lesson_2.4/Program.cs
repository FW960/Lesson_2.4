using System;
using System.Collections.Generic;

namespace Lesson_2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество зданий. Значение по умолчанию = 5");

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
'Высота' 'Количество этажей' 'Количество подъездов' 'Количество квартир'");
            Console.WriteLine();

            Console.WriteLine("Здание должно быть хотя бы 3 метра в высоту.");

            Console.WriteLine("Здание должно содержать хотя бы один этаж.");

            Console.WriteLine("Высота одного этажа не может быть ниже 3х метров.");

            for (int i = 0; i < buildings.Length; i++)
            {
                try
                {
                    string[] a = (Console.ReadLine().Split(' '));

                    buildings[i] = new Building(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                }
                catch
                {
                    --i;
                    continue;
                }

            }

            Console.Clear();

            Console.WriteLine("Для того чтобы посмотреть характеристики здания введите 'Посмотреть'.");

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

                            try
                            {
                                Building.LookBuildingCharacteristic(buildings[BuildingNum]);
                            }
                            catch
                            {
                                Console.WriteLine("Введите существующий номер здания.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Введите номер здания в корректном формате.");
                        }
                        break;
                    case "Очистить":
                        Console.Clear();
                        break;
                    case "Помощь":
                        Console.WriteLine("Для того чтобы посмотреть характеристики здания введите 'Посмотреть'.");

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
        private static int LastBuildingNum = 0;

        private int BuildingNum;

        private int Height;

        private int NumOfFloors;

        private int NumOfApartments;

        private int NumOfEntrances;

        public Building(int Height, int NumOfFloors, int NumOfEntrances, int NumOfApartments)
        {
            this.BuildingNum = LastBuildingNum++;

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

            this.Height = Height;

            this.NumOfFloors = NumOfFloors;

            this.NumOfApartments = NumOfApartments;

            this.NumOfEntrances = NumOfEntrances;

            Console.WriteLine("Дом построен.");

        }



        public float CalculateNumOfApartmentsPerEntrance()
        {
            return (float)NumOfApartments / (float)NumOfEntrances;
        }
        public float CalculateHeightOfFloor()
        {
            return (float)Height / (float)NumOfFloors;
        }
        public float CalculateNumOfApartmenstPerFloor()
        {
            return (float)NumOfApartments / (float)NumOfFloors;
        }

        public static void LookBuildingCharacteristic(Building building)
        {
            float NumOfApartmentsPerEntrance = building.CalculateNumOfApartmentsPerEntrance();

            float HeightOfFloor = building.CalculateHeightOfFloor();

            float NumOfApartmentsPerFloor = building.CalculateNumOfApartmenstPerFloor();

            Console.WriteLine(new string('-', 40));

            Console.WriteLine($"Номер здания: {building.BuildingNum}.");

            Console.WriteLine($"Высота: {building.Height} м.");

            Console.WriteLine($"Количество этажей: {building.NumOfFloors}.");

            Console.WriteLine($"Количество подъездов: {building.NumOfEntrances}.");

            Console.WriteLine($"Количество квартир: {building.NumOfApartments}.");

            Console.WriteLine($"Количество квартир на подъезд: {NumOfApartmentsPerEntrance}.");

            Console.WriteLine($"Высота этажа: {HeightOfFloor} м.");

            Console.WriteLine($"Количество квартир на этаж: {NumOfApartmentsPerFloor}.");

            Console.WriteLine(new string('-', 40));
        }
    }
}
