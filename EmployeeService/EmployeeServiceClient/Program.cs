using Grpc.Net.Client;
using static EmployeeServiceProto.DictionariesService;

namespace EmployeeServiceClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            DictionariesServiceClient client = new DictionariesServiceClient(channel);

            Console.WriteLine("1. Добавить тип сотрудника.");
            Console.WriteLine("2. Найти тип сотрудника по ID");
            Console.Write("Выберите действие:");
            string userAction =  Console.ReadLine();

            while (true)
            {
                switch (userAction)
                {
                    case "1":

                        Console.Write("Укажите тип сотрудника: ");

                        var createResponse = client.CreateEmployeeType(new EmployeeServiceProto.CreateEmployeeTypeRequest
                        {
                            Description = Console.ReadLine()
                        });

                        if (createResponse != null)
                        {
                            Console.WriteLine($"Тип сотрудника успешно добавлен: #{createResponse.Id}");
                        }

                        var getAllEmployeeTypesResponse = client.GetAllEmployeeTypes(new EmployeeServiceProto.GetAllEmployeeTypesRequest());
                        foreach (var employeeType in getAllEmployeeTypesResponse.EmployeeTypes)
                        {
                            Console.WriteLine($"#{employeeType.Id} / {employeeType.Description}");
                        }
                        break;

                    case "2":
                        Console.Write("Укажите ID: ");
                        var getByIdResponse = client.GetById(new EmployeeServiceProto.GetByIdRequest
                        {
                            Id = int.Parse(Console.ReadLine())
                        });

                        if (getByIdResponse != null)
                        {
                            Console.WriteLine($"Тип сотрудника: {getByIdResponse.EmployeeType.Description}");
                        }
                        break;

                    default:
                        break;
                }
            }

            

            Console.ReadKey(true);
        }
    }
}