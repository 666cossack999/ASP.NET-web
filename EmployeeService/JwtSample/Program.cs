namespace JwtSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();

            UserService userService = new UserService();
            Console.WriteLine(userService.Authentication(login, password)); 



        }
    }
}