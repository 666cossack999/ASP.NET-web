using AccoutHelper;

namespace AccountHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PasswordUtils.CreatePasswordHash("qwer1234"));
            //brV8tzkNiaIYVavrpAWPTA==, MGZLR1IJ3MCdr+6Z3ymPlUZ32eyuh8kbJZK5x4hs+1AeF/Iql95BNjcxgWXYO+MYll3d1O05aXSwDhdzPhmwgg==
        }
    }
}