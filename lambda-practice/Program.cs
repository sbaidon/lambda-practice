using lamda_practice.Data;
using System;
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
                /1. Listar todos los empleados cuyo departamento tenga una sede en Chihuahua
                City chihuahua = (City)ctx.Cities.Where(c => c.Name == "Chihuahua");
            
                var chihuahuaDepartments = ctx.Departments.Where(d => d.Cities.Contains(chihuahua));
                Console.WriteLine("Listar todos los empleados cuyo departamento tenga una sede en Chih" + chihuahuaDepartments.ToList());
                //2. Listar todos los departamentos y el numero de empleados que pertenezcan a cada departamento.
                var employeesPerDepartment = ctx.Employees.Where(c => c.Department.Name != null).Count();

                //3. Listar todos los empleados remotos. Estos son los empleados cuya ciudad no se encuentre entre las sedes de su departamento.
                var remoteEmployees = ctx.Employees.Where(e => e.City  != e.Department.Cities);

                //4. Listar todos los empleados cuyo aniversario de contratación sea el próximo mes.
                DateTime NextMonth = DateTime.Now.AddMonths(1);
                var nextMonthAniversary = ctx.Employees.Where(c => c.HireDate != NextMonth);

                //Listar los 12 meses del año y el numero de empleados contratados por cada mes.
              

            }


            Console.Read();
        }
    }
}
