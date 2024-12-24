using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public class stClient
    {
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public double balance { get; set; }
    }

    public class JsonDatabase
    {
        private static string filePath = "clients.json";

        // Read all clients from the JSON file
        public static List<stClient> LoadClients()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<stClient>>(jsonData) ?? new List<stClient>();
        }

        // Save all clients back to the JSON file
        public static void SaveClients(List<stClient> clients)
        {
            string jsonData = JsonConvert.SerializeObject(clients, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }

    public class LoginForm
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }

        public static bool CheckLogin(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            var clients = JsonDatabase.LoadClients();
            return clients.Any(client => client.username == username && client.password == hashedPassword);
        }
    }

    public class SignUpForm
    {
        public static void InsertClient(stClient newClient)
        {
            var clients = JsonDatabase.LoadClients();
            if (clients.Any(client => client.username == newClient.username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }

            newClient.password = LoginForm.HashPassword(newClient.password);
            clients.Add(newClient);
            JsonDatabase.SaveClients(clients);
            Console.WriteLine("Insertion successful.");
        }

        public static bool CheckSignUp(string username)
        {
            var clients = JsonDatabase.LoadClients();
            return clients.Any(client => client.username == username);
        }
    }

    public class DashBoard
    {
        public static double GetBalance(string username)
        {
            var clients = JsonDatabase.LoadClients();
            var client = clients.FirstOrDefault(c => c.username == username);
            return client.username != null ? client.balance : 0;
        }
        public static string GetOriginalName(string username)
        {
            var clients = JsonDatabase.LoadClients();
            var client = clients.FirstOrDefault(c => c.username == username);
            return client != null ? client.username : null;
        }
        public static string GetFirstName(string username)
        {
            var clients = JsonDatabase.LoadClients();
            var client = clients.FirstOrDefault(c => c.username == username);
            return client != null ? client.firstname : null;
        }
        public static string GetLastName(string username)
        {
            var clients = JsonDatabase.LoadClients();
            var client = clients.FirstOrDefault(c => c.username == username);
            return client != null ? client.lastname : null;
        }

    }

    public class Balance
    {
        public static void UpdateBalance(string username, double balance)
        {
            var clients = JsonDatabase.LoadClients();
            var client = clients.FirstOrDefault(c => c.username == username);
            if (client.username != null)
            {
                client.balance = balance;
                JsonDatabase.SaveClients(clients);
                Console.WriteLine("Balance updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }

    public class ChangePin
    {
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2"));
                }
                return hashStringBuilder.ToString();
            }
        }

        public static bool CheckOldPin(string username, string oldPassword)
        {
            string hashedPassword = HashPassword(oldPassword);
            var clients = JsonDatabase.LoadClients();
            return clients.Any(client => client.username == username && client.password == hashedPassword);
        }

        public static void UpdatePin(string username, string newPin)
        {
            var clients = JsonDatabase.LoadClients();
            var client = clients.FirstOrDefault(c => c.username == username);
            if (client.username != null)
            {
                client.password = HashPassword(newPin);
                JsonDatabase.SaveClients(clients);
                Console.WriteLine("Pin updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}

