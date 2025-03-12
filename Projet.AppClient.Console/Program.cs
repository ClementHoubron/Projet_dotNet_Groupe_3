using Projet.AppClient.Controller;
using Projet.AppClient.View;
using System.Text;

internal class Program
{
    private static void loggedLoop()
    {

        var viewClient = new ClientView();
        var controllerClient = new ClientController(viewClient);

        bool reponse = true;

        while (reponse)
        {
            Console.Clear();
            Console.WriteLine(" 1 - Afficher tous les clients");
            Console.WriteLine(" 2 - Afficher un client particulier avec son nom et son prenom");
            Console.WriteLine(" 3 - Afficher un client professionnel avec son nom et son siret");
            Console.WriteLine(" 4 - Ajouter un client particulier");

            Console.WriteLine(" 0 - Quitter");

            switch (Console.ReadLine())
            {
                case "1":
                    controllerClient.ShowClients();
                    break;
                case "2":
                    Console.WriteLine("Saisir le nom du client");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Saisir le prenom du client");
                    string prenom = Console.ReadLine();
                    controllerClient.GetClientParticulier(nom, prenom);
                    break;

                case "3":
                    Console.WriteLine("Saisir le nom du client");
                    string nomPro = Console.ReadLine();
                    Console.WriteLine("Saisir le SIRET du client");
                    string siret = Console.ReadLine();
                    controllerClient.GetClientProfessionnel(nomPro, siret);
                    break;

                case "4":
                    try
                    {
                        var cliDto = viewClient.GetClientParticulierDetails();
                        if (cliDto != null)
                        {
                            Console.WriteLine("Saisie client ok");

                            controllerClient.AddClientParticulier(cliDto);

                        }
                        else
                        {
                            throw new Exception("Saisie client vide.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erreure saisie client : " + e.Message);
                    }

                
                    break;

                case "5":
                    try
                    {
                        var cliProDto = viewClient.GetClientProfessionnelDetails();
                        if (cliProDto != null)
                        {
                            Console.WriteLine("Saisie client ok");
                       
                                controllerClient.AddClientProfessionnel(cliProDto);
                 
                        }
                        else
                        {
                            throw new Exception("Saise client vide.");
                    }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erreure saisie client : " + e.Message);
                    }
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