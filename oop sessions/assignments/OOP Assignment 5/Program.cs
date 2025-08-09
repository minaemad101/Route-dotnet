using System.Security.AccessControl;

namespace OOP_Assignment_5
{
    #region question 1
    internal class Circle : iCircle
    {
        public double Radius {  get; set; }
        public double Area => 3.14 * Radius*Radius;
        public Circle(double radius) { Radius = radius; }
        public void DisplayShapeInfo()
        {
            Console.WriteLine($"the circle with radius {Radius} has area: {Area}");
        }
    }
    internal class Rectangel : iRectangel
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area=>Width*Height;

        public Rectangel(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"the rectangle with width {Width} and height {Height} has area: {Area}");
        }
    }
    #endregion
    #region question 2
    internal class BasicAuthenticationService : IAuthenticationService
    {
        private readonly Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"user1","pass1"},
            {"user2","pass2" }
        };
        private readonly Dictionary<string, string> roles = new Dictionary<string, string>()
        {
            {"user1","role1"},
            {"user2","role2" }
        };
        public bool AuthenticateUser(string username, string password) {
            return (Users.ContainsKey(username) && Users[username] == password);
        }
        public bool AuthorizeUser(string username, string role) {
            return (Users.ContainsKey(username) && roles[username] == role);
        }
    }
    #endregion
    #region question 3
    internal class EmailNotificationService : INotification
    {
        public void SendNotification(string resipient, string message) {
            Console.WriteLine($"sending an email notification to {resipient} with message:{message}");
        }
    }
    internal class SmsNotificationService : INotification
    {
        public void SendNotification(string resipient, string message)
        {
            Console.WriteLine($"sending an sms notification to {resipient} with message:{message}");
        }
    }
    internal class PushNotificationService : INotification
    {
        public void SendNotification(string resipient, string message)
        {
            Console.WriteLine($"sending an push notification to {resipient} with message:{message}");
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region for question 1
            iCircle circle = new Circle(6);
            circle.DisplayShapeInfo();
            iRectangel rectangel = new Rectangel(4, 5);
            rectangel.DisplayShapeInfo();
            #endregion
            #region for question 2
            IAuthenticationService authService = new BasicAuthenticationService();
            Console.WriteLine(authService.AuthenticateUser("user1", "pass1"));
            Console.WriteLine(authService.AuthorizeUser("user1", "role3"));
            #endregion
            #region for question 3
            EmailNotificationService emailNotificationService = new EmailNotificationService();
            SmsNotificationService  smsNotificationService = new SmsNotificationService();
            PushNotificationService pushNotificationService = new PushNotificationService();
            emailNotificationService.SendNotification("emailuser", "stop using email");
            smsNotificationService.SendNotification("smsuser", "stop using sms");
            pushNotificationService.SendNotification("pushuser", "stop using push");
            #endregion
        }
    }
}
