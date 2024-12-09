// -
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace DiagramImplementation1.App;

internal class Program
{
    /// <summary>
    /// Запрос данных пользователей с последующим отображением приветствия
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Username!");
        Console.WriteLine("---");

        List<User> users = new();

        (bool inputResult, string login, string name, bool isPremium) input;
        do
        {
            input = GetUserDataFromConsole();
            if (input.inputResult)
            {
                users.Add(new() { Login = input.login, Name = input.name, IsPremium = input.isPremium });
            }
            Console.WriteLine("---");
        } while (input.inputResult);

        foreach (User user in users)
        {
            Console.WriteLine($"Hi {user.Name} ({user.Login})");
            if (!user.IsPremium)
            {
                ShowAds();
            }
            Console.WriteLine("---");
        }

        int result = users.Count > 0 ? 0 : 1;
        Console.WriteLine($"return: [{result}]");
        Console.ReadKey();
    }


    /// <summary>
    /// Функция запроса данных пользователя через консоль
    /// </summary>
    /// <returns>данные о пользователе и результат работы функции</returns>
    private static (bool inputResult, string login, string name, bool isPremium)
        GetUserDataFromConsole()
    {
        bool res = true;
        string login = string.Empty;
        string name = string.Empty;
        bool isPremium = false;

        if (res)
        {
            Console.WriteLine("Enter the login: ");

            if (string.IsNullOrWhiteSpace(login = Console.ReadLine() ?? string.Empty))
            {
                Console.WriteLine("Empty login is not accepted.");
                res = false;
            }
        }

        if (res)
        {
            Console.WriteLine("Enter the name: ");

            if (string.IsNullOrWhiteSpace(name = Console.ReadLine() ?? string.Empty))
            {
                Console.WriteLine("Empty name is not accepted.");
                res = false;
            }
        }
        Console.WriteLine("Enter the premium status: ");

        if (res)
        {
            string boolString = Console.ReadLine() ?? string.Empty;
            boolString = boolString switch { "1" => "true", "0" => "false", _ => boolString };
            boolString = boolString switch { "+" => "true", "-" => "false", _ => boolString };

            if (!bool.TryParse(boolString, out isPremium))
            {
                Console.WriteLine("Premium status is not accepted.");
                res = false;
            }
        }

        if (res)
        {
            Console.WriteLine($"Accepted data: login: {login}, name: {name}, premium: {isPremium}");
        }
        else
        {
            Console.WriteLine("User rejected.");
        }

        return (inputResult: res, login: login, name: name, isPremium: isPremium);
    }


    /// <summary>
    /// Функция отображения рекламного сообщения
    /// </summary>
    static void ShowAds()
    {
        Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
        // Остановка на 1 с
        Thread.Sleep(1000);

        Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
        // Остановка на 2 с
        Thread.Sleep(2000);

        Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
        // Остановка на 3 с
        Thread.Sleep(3000);
    }
}
