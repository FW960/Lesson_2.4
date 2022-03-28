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

            int NumOfBuildings = 5;

            try
            {
                NumOfBuildings = Convert.ToInt32(Console.ReadLine());

                if (NumOfBuildings <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Введено параметр по умолчанию.");
            }
            Create[] buildings = new Create[NumOfBuildings];

            Console.WriteLine(@"Введите параметры здания через пробел в формате:
'Высота' 'Количество этажей' 'Количество подъездов' 'Количество квартир'");
            Console.WriteLine();

            Console.WriteLine("Здание должно быть хотя бы 3 метра в высоту.");

            Console.WriteLine("Здание должно содержать хотя бы один этаж.");

            Console.WriteLine("Высота одного этажа не может быть ниже 3х метров.");

            Dictionary<int, Create> AllBuildings = new Dictionary<int, Create>();

            for (int i = 0; i < buildings.Length; i++)
            {
                try
                {
                    string[] a = (Console.ReadLine().Split(' '));

                    buildings[i] = Create.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                    AllBuildings.Add(i, buildings[i]);

                    Console.WriteLine("Здание построено.");
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

                            if (AllBuildings.TryGetValue(BuildingNum, out Create building))
                            {
                                string BuildingCharacteristics = Create.LookBuildingCharacteristic(building);

                                Console.WriteLine(BuildingCharacteristics);

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
                            int BuildingNum = Convert.ToInt32(Console.ReadLine());

                            AllBuildings.Remove(BuildingNum);


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

                            Create building = Create.CreateBuild(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));

                            Console.WriteLine("Введите ключ, по которому вы хотели бы найти этот дом в дальнейшем.");

                            int BuildingNum = Convert.ToInt32(Console.Read());

                            AllBuildings.Add(BuildingNum, building);
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
            } while (UserChoice != "Выход");

        }
    }

    
}
