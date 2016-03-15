using lamda_practice.Data;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace lambda_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DatabaseContext())
            {
                Console.Write("//1. Listar todos los empleados cuyo departamento tenga una sede en Chihuahua\n");
                System.Threading.Thread.Sleep(2000);
                var query = ctx.Employees
                    .Where(employee => employee.City.Name == "Chihuahua");

                foreach (var worker in query)
                {
                    Console.WriteLine(worker.FirstName + ' ' + worker.LastName);
                }
                System.Threading.Thread.Sleep(3000);
                Console.Write("//2. Listar todos los departamentos y el numero de empleados que pertenezcan a cada departamento.\n");
                System.Threading.Thread.Sleep(2000);
                var query2 = ctx.Employees  
                    .GroupBy(employee => employee.Department.Name)
                    .Select(res => new { Name = res.Key, Count = res.Count() });

                foreach (var Department in query2)
                {
                    Console.WriteLine("Nombre Departamento: {0},  Numero de Empleados: {1}",
                    Department.Name, Department.Count);
                }
                System.Threading.Thread.Sleep(3000);
                Console.Write("//3. Listar todos los empleados remotos. Estos son los empleados cuya ciudad no se encuentre entre las sedes de su departamento.");
                System.Threading.Thread.Sleep(2000);
                var query3 = ctx.Employees
                    .Where(employee => employee.Department.Cities.Any(city => city.Name == employee.City.Name));

                foreach (var employee in query3)
                {
                    Console.WriteLine(employee.FirstName + ' ' + employee.LastName);
                }

                System.Threading.Thread.Sleep(3000);
                Console.Write("//4. Listar todos los empleados cuyo aniversario de contratación sea el próximo mes.\n");
                System.Threading.Thread.Sleep(2000);
                var query4 = ctx.Employees
                  .Where(e => e.HireDate.Month == System.DateTime.Now.Month + 1);

                foreach (var employee in query4)
                {
                    Console.WriteLine("Nombre: {0} {1} Contratado en:  {2}",
                    employee.FirstName, employee.LastName, employee.HireDate);
                }
                System.Threading.Thread.Sleep(3000);
                Console.Write("//5. Listar los 12 meses del año y el numero de empleados contratados por cada mes.\n");
                System.Threading.Thread.Sleep(2000);
                var query5 = ctx.Employees
                    .GroupBy(employee => employee.HireDate.Month)
                    .OrderBy(i => i.Key)
                    .Select(res => new { monthNumber = res.Key, Count = res.Count() });

                foreach (var meses in query5)
                {
                    Console.WriteLine("Numero de Mes: {0}, Empleados contratados: {1}",
                     meses.monthNumber, meses.Count);
                }
            }

            Console.Read();
        }

    }

}