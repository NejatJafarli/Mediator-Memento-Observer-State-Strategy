using System;

namespace Memento
{
    class SettingsOrginator
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }

        public SettingsMemento Backup() => new SettingsMemento(Username, Password, Email, RememberMe);
        public void Setup(SettingsMemento settings)
        {
            this.Username = settings.Username;
            this.Password = settings.Password;
            this.Email = settings.Email;
            this.RememberMe = settings.RememberMe;
        }
        public SettingsOrginator(string userName, string password, string email, bool rememberMe)
        {
            Username = userName;
            Password = password;
            Email = email;
            RememberMe = rememberMe;
        }
    }
    public class SettingsMemento
    {
        public SettingsMemento(string username, string password, string email, bool rememberMe)
        {
            Username = username;
            Password = password;
            Email = email;
            RememberMe = rememberMe;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }
    }

    public class SettingsCaretaker
    {
        public SettingsMemento User { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            SettingsOrginator User = new SettingsOrginator("Nicat", "12345", "Mega.ceferli@gmail.com", true);

            Console.WriteLine($"Name {User.Username}\nPassword {User.Password}\nEmail {User.Email}\nRemember me {User.RememberMe}");
            Console.WriteLine();
            SettingsCaretaker settingsCaretaker=new SettingsCaretaker{
                User = User.Backup()
            };// burdada bir backup saxlayiriq

            //burda propertylerimizi deyistiririk
            User.Email = "AnyEmail@gmail.com";
            User.RememberMe = false;
            User.Username = "Some Guy";
            User.Password= "Password";

            Console.WriteLine($"Name {User.Username}\nPassword {User.Password}\nEmail {User.Email}\nRemember me {User.RememberMe}");
            Console.WriteLine();


            //sonra evvelki halina qayitsin isteyirik

            User.Setup(settingsCaretaker.User);


            Console.WriteLine($"Name {User.Username}\nPassword {User.Password}\nEmail {User.Email}\nRemember me {User.RememberMe}");
            Console.WriteLine();

        }
    }
}
