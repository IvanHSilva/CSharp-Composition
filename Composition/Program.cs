using Composition.Entities;
using Composition.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition {
    internal class Program {
        static void Main(string[] args) {
            // Worker data
            Console.Write("Departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Dados do trabalhador:");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Nível: (Junior/Pleno/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Instantiation and composition
            Department department = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, department);

            // Contracts
            Console.Write("Número de Contratos: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Contrato {i+1}");
                Console.Write("Data: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor/hora: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração em horas: ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, value, hours);
                worker.AddContract(contract);
            }

            // Calculation
            Console.WriteLine();
            Console.Write("Período trabalhado (mm/aaaa): ");
            string monthYear = Console.ReadLine();
            int month = int.Parse(monthYear.Substring(0,2));
            int year = int.Parse(monthYear.Substring(3));
            Console.WriteLine($"Nome: {worker.Name}");
            Console.WriteLine($"Departamento: {worker.Department.Name}");
            Console.WriteLine($"Pagamento do período {monthYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
