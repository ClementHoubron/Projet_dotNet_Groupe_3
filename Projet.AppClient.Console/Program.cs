using Microsoft.SqlServer.Server;
using Projet.AppClient.Controller;
using Projet.AppClient.View;
using System.Globalization;
using System.Text;

internal class Program
{
    private static void loggedLoop()
    {

        var viewClient = new ClientView();
        var controllerClient = new ClientController(viewClient);

        var viewTrans = new TransactionView();
        var controllerTrans = new TransactionController(viewTrans);

        bool reponse = true;

        while (reponse)
        {
            Console.Clear();
            Console.WriteLine(" 1 - Afficher tous les clients");
            Console.WriteLine(" 2 - Import des transactions du serveur");
            Console.WriteLine(" 3 - Afficher toutes les transactions");
            Console.WriteLine(" 4 - Generer le rapport xml pour un client sur une periode");

            Console.WriteLine(" 0 - Quitter");

            switch (Console.ReadLine())
            {
                case "1":
                    controllerClient.ShowClients();
                    break;
                case "2":
                    controllerTrans.ImportTransactionServeur();
                    break;
                case "3":
                    controllerTrans.ShowTransactions();
                    break;
                case "4":
                    Console.WriteLine("Veuillez entrer un numero de compte ? (format : 105003)");
                    string numCompte = Console.ReadLine();
                    Console.WriteLine("Veuillez entrer la date de debut ? (format : jj/mm/aaaa)");
                    string format = "dd/MM/yyyy";
                    string input = Console.ReadLine().Trim();
                    DateTime before;
                    while (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out before))
                    {
                        Console.WriteLine("Erreur ! Veuillez entrer la date de debut sous le format indiqué ? (format : jj/mm/aaaa)");
                        input = Console.ReadLine().Trim();
                    }
                    Console.WriteLine("Veuillez entrer la date de fin ? (format : jj/mm/aaaa)");
                    DateTime after;
                    input = Console.ReadLine().Trim();
                    while (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out after))
                    {
                        Console.WriteLine("Erreur ! Veuillez entrer la date de fin sous le format indiqué ? (format : jj/mm/aaaa)");
                        input = Console.ReadLine().Trim();
                    }
                    controllerTrans.ExportTransactionByNumCompteForPeriod(numCompte, before, after);
                    break;

                case "0":
                    reponse = false;
                    break;

            }
            Console.ReadKey();
        }
    }

    private static string GetPassword()
    {
        StringBuilder input = new StringBuilder();
        while (true)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }
            if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input.Remove(input.Length - 1, 1);
                Console.SetCursorPosition(x - 1, y);
                Console.Write(" ");
                Console.SetCursorPosition(x - 1, y);
            }
            else if (key.Key != ConsoleKey.Backspace)
            {
                input.Append(key.KeyChar);
                Console.Write("*");
            }
        }
        return input.ToString();
    }

    private static void Main(string[] args)
    {
        var controllerAdmin = new AdminController();

        bool reponse = true;

        while (reponse)
        {
            Console.Clear();
            Console.WriteLine(" 1 - Admin login");
            Console.WriteLine(" 0 - Quitter");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Saisir le login");
                    string login = Console.ReadLine();
                    Console.WriteLine("Saisir le mot de passe");
                    string mdp = GetPassword();
                    bool loginOk = controllerAdmin.Login(login, mdp).Result;
                    if (loginOk)
                    {
                        loggedLoop();
                    }
                    else
                    {
                        Console.WriteLine("Login erroné");
                    }
                    break;


                case "0":
                    reponse = false;
                    break;

            }
            Console.ReadKey();
        }
        Console.ReadKey();




    }
}