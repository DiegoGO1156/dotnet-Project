using System.Text.Json;
using WorkerOrdersManagement.Domain.Entities;
using WorkerOrdersManagement.Domain.Enums;

namespace WorkerOrdersManagement;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                //Objeto #1
                Order orderProcessOne = new Order();
                /* Da error por el readOnly
                orderProcess.OrderId = Guid.NewGuid().ToString();
                */
                Console.WriteLine(orderProcessOne.OrderId);//Lee el dato, ya que el readOnly solo permite hacer eso 

                orderProcessOne.EntityType = EntityType.CANDIDATE;
                orderProcessOne.OperationType = OperationType.CREATE;
                orderProcessOne.Status = OrderStatus.PENDING;
                /* Parte del error por no tener instancia
                orderProcessOne.Data.Nombres = "Diego"
                orderProcessOne.Data.Apellidos = "Garcia"
                orderProcessOne.Data.Direccion = "asdasdasdas"
                orderProcessOne.Data.Email = "diego@gmail.com"
                orderProcessOne.Data.ExamenId = "56"
                orderProcessOne.Data.CarreraId = "2"
                orderProcessOne.Data.JornadaId = "1"
                */
                //Sin error por instancia por que se genera acá en el llamado del objeto 
                orderProcessOne.EntityData = new Aplicant("Diego", "Garcia", "adasdasd", "diego@gmail.com", "5985-9557", "56", "2", "1");// -> Polimorfismo, Genera un Entity Data que se puede convertir en un Aplicant //Constructores añadidos
                /*((Aplicant)orderProcessOne.EntityData).FirstName = "Diego"; //-> Fuerza el OrderProcessOne de tipo EntityData a un tipo Aplicant
                ((Aplicant)orderProcessOne.EntityData).LastName = "Garcia";
                ((Aplicant)orderProcessOne.EntityData).Address = "asdasdasdas";
                ((Aplicant)orderProcessOne.EntityData).Email = "diego@gmail.com";
                ((Aplicant)orderProcessOne.EntityData).Phone = "5985-9557";
                ((Aplicant)orderProcessOne.EntityData).ExamenId = "56";
                ((Aplicant)orderProcessOne.EntityData).CarreraId = "2";
                ((Aplicant)orderProcessOne.EntityData).ShiftId = "1";
                */
                /*Otra forma de poder instanciar datos
                orderProcessOne.Data = new Aspirantes
                {
                    Nombres = "Diego",
                    Apellidos = "Garcia",
                    Direccion = "asdasdasdas",
                    Email = "diego@gmail.com",
                    ExamenId = "56",
                    CarreraId = "2",
                    JornadaId = "1"
                };
                */
                //

                Order OrderProcessTwo = new Order(); 
                OrderProcessTwo.EntityType = EntityType.STUDENT;
                OrderProcessTwo.OperationType = OperationType.CREATE;
                OrderProcessTwo.Status = OrderStatus.PROCESS;

                OrderProcessTwo.EntityData = new Student();//Sin constructores 
                ((Student)OrderProcessTwo.EntityData).FirstName = "Esteban";
                ((Student)OrderProcessTwo.EntityData).LastName = "Cano";
                ((Student)OrderProcessTwo.EntityData).Address = "asdas";
                ((Student)OrderProcessTwo.EntityData).Email = "asdas@gmail.com";
                ((Student)OrderProcessTwo.EntityData).Phone = "1464-5636";
                ((Student)OrderProcessTwo.EntityData).StudentId = "55";


                //Lectura y escritura del Objeto #1
                _logger.LogInformation("Worker running at: {time}", JsonSerializer.Serialize(orderProcessOne));
                _logger.LogInformation("Worker running at: {time}", JsonSerializer.Serialize(OrderProcessTwo));
    
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
