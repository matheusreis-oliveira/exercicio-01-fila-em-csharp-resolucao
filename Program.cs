class Program
{
    static void Main()
    {
        QueueService queueService = new QueueService();

        for (int i = 1; i <= 10; i++)
        {
            queueService.AddCustomer(new Customer($"Cliente {i}"));
        }

        queueService.ServeCustomers();
    }
}

class Customer
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        Name = name;
        Console.WriteLine($"{DateTime.Now} : {Name} entrou na fila de espera.");
    }
}

class Employee
{
    public int Number { get; private set; }

    public Employee(int number)
    {
        Number = number;
    }

    public void ServeCustomer(Customer customer, int serviceTime)
    {
        Console.WriteLine($"{DateTime.Now} : Atendendo {customer.Name}...");
        Thread.Sleep(serviceTime * 1000);
        Console.WriteLine($"{DateTime.Now} : {customer.Name} atendido pelo Funcionário: {Number} com o tempo de {serviceTime} segundos.");
    }
}

class QueueService
{
    private Queue<Customer> customerQueue;

    public QueueService()
    {
        customerQueue = new Queue<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        customerQueue.Enqueue(customer);
    }

    public void ServeCustomers()
    {
        Random random = new Random();

        while (customerQueue.Count > 0)
        {
            Customer customer = customerQueue.Dequeue();
            Employee employee = new Employee(random.Next(1, 10));
            int serviceTime = random.Next(1, 6);
            employee.ServeCustomer(customer, serviceTime);
        }

        Console.WriteLine($"{DateTime.Now} : Todos os clientes foram atendidos.");
    }
}
