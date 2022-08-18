using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            List<Task<Post>> response = new List<Task<Post>>();

            for (int i = 4; i < 14; i++)
            {
                response.Add(Engine.GetPostById(i));
            }

            await Task.WhenAll(response);

            FileStream fStream = new FileStream("result.txt", FileMode.Create);
            StreamWriter output = new StreamWriter(fStream);

            foreach (var item in response)
            {
                string post = item.Result.ToString();
                output.WriteLine(post);
            }

            output.Close();
            Console.WriteLine("Файл заполнен!");
            Console.ReadKey();
        }

    }
}
