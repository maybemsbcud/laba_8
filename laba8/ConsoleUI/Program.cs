using System;
using laba8.Core.Infrastructure;
using laba8.Core.Application;

namespace laba8.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Щоб українська мова в консолі відображалася нормально
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Створюємо сховища з даними
            var clientRepo = new InMemoryClientRepository();
            var propertyRepo = new InMemoryPropertyRepository();

            // 2. Створюємо сервіси
            var clientService = new ClientService(clientRepo);
            var propertyService = new PropertyService(propertyRepo);
            var offerService = new OfferService(propertyRepo);
            var searchService = new SearchService(clientRepo, propertyRepo);

            // 3. Запускаємо меню
            var app = new ApplicationRunner(clientService, propertyService, offerService, searchService);
            app.Run();
        }
    }
}