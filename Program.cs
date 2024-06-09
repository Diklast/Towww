using System;
using System.Collections.Generic;
using System.Linq;
using DuoVia.FuzzyStrings;
using FuzzyStrings;

namespace TowerSearchApp
{
    public class Tower
    {
        public string Name { get; set; }
        public DateTime CurrentDate { get; set; }
        public int LevenshteinMetric { get; set; }
        public string ClassField { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int NumDials { get; set; }
        public bool HasPrincess { get; set; }
        public bool IsBeaconOn { get; set; }
        public string BuildingMaterial { get; set; }
        public DateTime BuildDate { get; set; }
        public TimeSpan TimeOnClock { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var towers = new List<Tower>
            {
                new Tower
                {
                    Name = "MagicTower",
                    CurrentDate = DateTime.Now,
                    LevenshteinMetric = 2,
                    ClassField = "A",
                    MaxHP = 100,
                    CurrentHP = 80,
                    NumDials = 4,
                    HasPrincess = true,
                    IsBeaconOn = false,
                    BuildingMaterial = "Камень",
                    BuildDate = new DateTime(2010, 5, 15),
                    TimeOnClock = new TimeSpan(12, 30, 0)
                },
                // Добавьте больше башен по необходимости
            };

            Console.WriteLine("Введите название башни для поиска:");
            string searchName = Console.ReadLine();

            Console.WriteLine("Введите максимальное расстояние Левенштейна:");
            int maxDistance = int.Parse(Console.ReadLine());

            var foundTowers = towers.Where(t => t.Name.LevenshteinDistance(searchName) <= maxDistance).ToList();

            if (foundTowers.Any())
            {
                foreach (var tower in foundTowers)
                {
                    DisplayTowerInfo(tower);
                }
            }
            else
            {
                Console.WriteLine("Башни с таким названием и расстоянием Левенштейна не найдено.");
            }
        }

        static void DisplayTowerInfo(Tower tower)
        {
            Console.WriteLine("Название башни: " + tower.Name);
            Console.WriteLine("Текущая дата: " + tower.CurrentDate.ToString("dd:MM:yyyy"));
            Console.WriteLine("Метрика Левенштейна: " + tower.LevenshteinMetric);
            Console.WriteLine("Поле класса: " + tower.ClassField);
            Console.WriteLine("Максимальное количество HP: " + tower.MaxHP);
            Console.WriteLine("Текущее количество HP: " + tower.CurrentHP);
            Console.WriteLine("Число циферблатов: " + tower.NumDials);
            Console.WriteLine("Наличие принцессы: " + (tower.HasPrincess ? "Да" : "Нет"));
            Console.WriteLine("Включен ли маяк: " + (tower.IsBeaconOn ? "Да" : "Нет"));
            Console.WriteLine("Материал постройки: " + tower.BuildingMaterial);
            Console.WriteLine("Дата постройки башни: " + tower.BuildDate.ToString("dd:MM:yyyy"));
            Console.WriteLine("Время на часах: " + tower.TimeOnClock.ToString(@"hh\:mm"));
        }
    }
}
