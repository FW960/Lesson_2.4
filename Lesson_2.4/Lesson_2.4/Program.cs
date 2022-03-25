using System;
using System.Collections.Generic;
using Construction;

namespace Lesson_2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите количество зданий. Значение по умолчанию 5");

            int numOfBuildings = 5;

            try
            {
                numOfBuildings = Convert.ToInt32(Console.ReadLine());

                if (numOfBuildings <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Введено параметр по умолчанию.");
            }
            Building[] buildings = new Building[numOfBuildings];

            Console.WriteLine(@"Введите параметры здания через пробел в формате:
'Высота' 'Количество этажей' 'Количество подъездов' 'Количество квартир'
. Либо введите лишь 2 первых параметра для того, чтобы построить частный дом.");
            Console.WriteLine();

            Console.WriteLine("Здание должно быть хотя бы 3 метра в высоту.");

            Console.WriteLine("Здание должно содержать хотя бы один этаж.");

            Console.WriteLine("Высота одного этажа не может быть ниже 3х метров.");

            for (int i = 0; i < buildings.Length; i++)
            {
                try
                {
                    string[] a = (Console.ReadLine().Split(' '));

                    if (a.Length == 2)
                    {
                        buildings[i] = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]));

                        Creator.AddToDictionary(buildings[i]);

                        Console.WriteLine("Частный дом построен.");

                        continue;
                    }

                    buildings[i] = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                    Creator.AddToDictionary(buildings[i]);

                    Console.WriteLine("Жилой дом построен.");
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

            string userChoice = string.Empty;

            do
            {
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "Посмотреть":
                        Console.WriteLine("Введите номер здания.");
                        try
                        {
                            int buildingNum = Convert.ToInt32(Console.ReadLine());

                            if (Creator.allBuildings.TryGetValue(buildingNum, out Building building))
                            {
                                string buildingCharacteristics = Creator.LookBuildingCharacteristic(building);

                                Console.WriteLine(buildingCharacteristics);

                            }else
                            {
                                Console.WriteLine("Здания с данным номером не существует.");
                            }

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
                            int buildingNum = Convert.ToInt32(Console.ReadLine());

                            Creator.allBuildings.Remove(buildingNum);

                            Console.WriteLine("Здание снесено.");
                        }
                        catch
                        {
                            Console.WriteLine("Введите номер здания в корректном формате.");
                        }
                        break;
                    case "Построить":
                        Console.WriteLine(@"Введите параметры здания через пробел в формате:
'Высота' 'Количество этажей' 'Количество подъездов' 'Количество квартир'");
                        Console.WriteLine();

                        Console.WriteLine("Здание должно быть хотя бы 3 метра в высоту.");

                        Console.WriteLine("Здание должно содержать хотя бы один этаж.");

                        Console.WriteLine("Высота одного этажа не может быть ниже 3х метров.");

                        try
                        {
                            string[] a = (Console.ReadLine().Split(' '));

                            Building building = Creator.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                            Creator.AddToDictionary(building);
                        }
                        catch
                        {
                            Console.WriteLine("Введите параметры здания в корректном формате.");
                            break;
                        }
                        Console.WriteLine("Здание построено.");
                        break;

                    case "Очистить":
                        Console.Clear();
                        break;
                    case "Помощь":
                        Console.WriteLine("Для того чтобы посмотреть характеристики здания введите 'Посмотреть'.");

                        Console.WriteLine("Для того чтобы построить здание введите 'Построить'.");

                        Console.WriteLine("Для того чтобы снести здание введите 'Снести'.");

                        Console.WriteLine("Для выхода введите 'Выход'.");
                        break;
                    case "Выход":
                        break;
                    default:
                        Console.WriteLine("Команда не распознанна.");
                        break;
                }
            } while (userChoice != "Выход");

        }
    }

    
}
