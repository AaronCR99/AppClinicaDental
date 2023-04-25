using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppClinicaDental.Models
{
    public class Cita
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPorAdelantado { get; set; }
        public string Email { get; set; }
        public int Procedimiento { get; set; }

        public decimal MontoIva { get; set; }


        public int precioProcedimiento (int procedimiento)
        {
           if(procedimiento == 1)
            {
               return  25000;
            }
            else if (procedimiento == 2)
            {
                return 10000;
            }
            else if (procedimiento == 3)

            {
                return 355000;
            }

             else if (procedimiento == 4)

            {
                return  15000;
            }

             else if (procedimiento == 5)

            {
                return 35000;
            }
            
            return 0;
        }

        public decimal totalIva(decimal total)
        {
            decimal totalIva = 0.0m;

            totalIva = (total * 0.13m);

            return totalIva;
        }

        public decimal montoPorAdelantado(decimal totalIva, decimal total)
        {
            decimal totalconiva;

            decimal totalAdelanto = 0.0m;
            totalconiva = totalIva + total;
            totalAdelanto = (totalconiva * 0.42m);

            return totalAdelanto;
        }






    }
}
