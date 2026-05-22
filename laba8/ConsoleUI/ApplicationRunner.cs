using laba8.Core.Application;
using laba8.Core.Domain.Models;

namespace laba8.ConsoleUI
{
    public class ApplicationRunner
    {
        private readonly ClientService _clientService;
        private readonly PropertyService _propertyService;
        private readonly OfferService _offerService;
        private readonly SearchService _searchService;

        public ApplicationRunner(ClientService cs, PropertyService ps, OfferService os, SearchService ss)
        {
            _clientService = cs;
            _propertyService = ps;
            _offerService = os;
            _searchService = ss;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== РІЕЛТОРСЬКА ФІРМА ===");
                Console.WriteLine("1. Управління клієнтами (Перегляд + Сортування)");
                Console.WriteLine("2. Управління нерухомістю (Перегляд + Сортування)");
                Console.WriteLine("3. Глобальний пошук");
                Console.WriteLine("0. Вихід з програми");
                Console.Write("\nВаш вибір: ");

                var choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1": ClientsMenu(); break;
                    case "2": PropertiesMenu(); break;
                    case "3": SearchMenu(); break;
                }
            }
        }

        private void ClientsMenu()
        {
            bool inClientsMenu = true;
            while (inClientsMenu)
            {
                Console.Clear();
                Console.WriteLine("--- КЛІЄНТИ ---");
                Console.WriteLine("1. Показати всіх");
                Console.WriteLine("2. Відсортувати за іменем");
                Console.WriteLine("3. Відсортувати за першою цифрою рахунку");
                Console.WriteLine("0. Назад до головного меню");
                Console.Write("\nВибір: ");
                
                var choice = Console.ReadLine();
                if (choice == "0") 
                {
                    inClientsMenu = false;
                    continue; // Повертає нас у головний цикл
                }

                IEnumerable<Client>? clients = choice switch
                {
                    "1" => _clientService.GetAllClients(),
                    "2" => _clientService.SortClientsByName(),
                    "3" => _clientService.SortClientsByBankAccStart(),
                    _ => null
                };

                if (clients != null)
                {
                    Console.WriteLine("\nРезультат:");
                    foreach (var c in clients)
                    {
                        Console.WriteLine($"ID: {c.Id.ToString()[..8]} | {c.LastName} {c.FirstName} | Рахунок: {c.BankAccountNumber} | Бюджет: {c.MaxBudget}$");
                    }
                }
                else
                {
                    Console.WriteLine("\nНевірний вибір.");
                }

                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }
        }

        private void PropertiesMenu()
        {
            bool inPropertiesMenu = true;
            while (inPropertiesMenu)
            {
                Console.Clear();
                Console.WriteLine("--- НЕРУХОМІСТЬ ---");
                Console.WriteLine("1. Показати всі об'єкти");
                Console.WriteLine("2. Відсортувати за ціною");
                Console.WriteLine("0. Назад до головного меню");
                Console.Write("\nВибір: ");

                var choice = Console.ReadLine();
                if (choice == "0")
                {
                    inPropertiesMenu = false;
                    continue;
                }

                IEnumerable<RealEstateProperty>? properties = choice switch
                {
                    "1" => _propertyService.GetAllProperties(),
                    "2" => _propertyService.SortPropertiesByPrice(),
                    _ => null
                };

                if (properties != null)
                {
                    Console.WriteLine("\nРезультат:");
                    foreach (var p in properties)
                    {
                        Console.WriteLine($"Тип: {p.Type} | Адреса: {p.Address} | Ціна: {p.Price}$");
                    }
                }
                else
                {
                    Console.WriteLine("\nНевірний вибір.");
                }

                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }
        }

        private void SearchMenu()
        {
            bool inSearchMenu = true;
            while (inSearchMenu)
            {
                Console.Clear();
                Console.WriteLine("--- ГЛОБАЛЬНИЙ ПОШУК ---");
                Console.WriteLine("1. Шукати");
                Console.WriteLine("0. Назад до головного меню");
                Console.Write("\nВибір: ");

                var menuChoice = Console.ReadLine();
                if (menuChoice == "0")
                {
                    inSearchMenu = false;
                    continue;
                }

                if (menuChoice == "1")
                {
                    Console.Write("Введіть ключове слово (наприклад, ім'я або частину адреси): ");
                    var keyword = Console.ReadLine();

                    var results = _searchService.GlobalSearch(keyword);

                    Console.WriteLine("\nЗнайдено:");
                    bool foundAnything = false;
                    foreach (var item in results)
                    {
                        foundAnything = true;
                        if (item is Client c)
                            Console.WriteLine($"[КЛІЄНТ] {c.FirstName} {c.LastName} (Рахунок: {c.BankAccountNumber})");
                        else if (item is RealEstateProperty p)
                            Console.WriteLine($"[НЕРУХОМІСТЬ] {p.Address} ({p.Price}$)");
                    }

                    if (!foundAnything)
                    {
                        Console.WriteLine("Нічого не знайдено.");
                    }
                }
                
                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }
        }
    }
}