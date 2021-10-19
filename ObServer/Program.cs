using System;
using System.Collections.Generic;

namespace ObServer
{

     abstract class MessageSystem
    {
        abstract public void AddUserSystem(User user);
        abstract public void RemoveUserSystem(User user);
        abstract public void SendMessage(string value);
    }

    class User
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; set; }

        public void SendMessage(string value)
        {
            Console.WriteLine($"{Username} Adli Istifadeciye Gelen Mesaj {value}");
            Console.WriteLine();
        }
    }

    class Sms : MessageSystem
    {
        public List<User> Subscribers { get; set; }=new List<User>();
        public override void AddUserSystem(User user)=>Subscribers.Add(user);

        public override void RemoveUserSystem(User user)=>Subscribers.Remove(user);

        public override void SendMessage(string value)
        {
            foreach (var item in Subscribers)
            {
                item.SendMessage(value);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            Sms SmsSystem= new Sms();

            var User1 = new User("Nicat");
            var User2 = new User("Ebdul");
            var User3 = new User("Emin");
            var User4 = new User("Zahid");

            SmsSystem.AddUserSystem(User1); // butun istifadeciler sms system i istifade edirler
            SmsSystem.AddUserSystem(User2);
            SmsSystem.AddUserSystem(User3);
            SmsSystem.AddUserSystem(User4);

            SmsSystem.SendMessage("Macbook Pro Cixti sadece 2000 Dollara ala bilersiz");

            Console.WriteLine();
            Console.WriteLine();


            SmsSystem.RemoveUserSystem(User1); // Nicat Ve Ebdul Artiq Sms System in mesajlarini gormek istemir ve sistemden cixirlar
            SmsSystem.RemoveUserSystem(User3);


            SmsSystem.SendMessage("Iphone 13 cixti");

            Console.WriteLine();
            Console.WriteLine();
            //ve burda artiq mesajlar sadece smsSystem in subs larina gedir


        }
    }
}
