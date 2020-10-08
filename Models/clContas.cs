using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace deliverAPI.Models
{
    public class clContas
    {
        /*
        [Key]
        public int Id { get; set; }
        */

  

        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double ValOrig { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [validaData (ErrorMessage = "Formato esperado:  dd/mm/yyyy")]
        public string DtVenc { get; set; }
        
        [Required(ErrorMessage = "Campo é obrigatório")]
        [validaData(ErrorMessage = "Formato esperado: dd/mm/yyyy")]

        public string DtPagto { get; set; }

        public int DiasAtraso { get; set; }

        public int RegraCalculo { get; set; }


        /*
        public clContas(int diasAtraso, double valCorrigido)
        {
            DiasAtraso = diasAtraso;
            ValCorrigido = valCorrigido;
        }*/


        //private static
        public void calcularAtraso()
        {
            
            Console.WriteLine(DtVenc.Substring(0, 2));
            Console.WriteLine(DtVenc.Substring(3 , 2));
            Console.WriteLine(DtVenc.Substring(6, 4));

            int iDia2 = Convert.ToInt32(DtVenc.Substring(0, 2));
            int iMes2 = Convert.ToInt32(DtVenc.Substring(3, 2));
            int iAno2 = Convert.ToInt32(DtVenc.Substring(6, 4));
            int iDia1 = Convert.ToInt32(DtPagto.Substring(0, 2));
            int iMes1 = Convert.ToInt32(DtPagto.Substring(3, 2));
            int iAno1 = Convert.ToInt32(DtPagto.Substring(6, 4));
            int iResult = 0;

            DateTime dataIni = new DateTime(iAno1 , iMes1, iDia1, 0, 0, 0);
            DateTime dataFim = new DateTime(iAno2, iMes2, iDia2, 0, 0,  0);

            if (dataIni > dataFim)
            {
                iResult = (dataIni - dataFim).Days ;
            }

            DiasAtraso = iResult;

            
        }

        private static double calcularValor()
        {
            double dResult = 0;


            return dResult;
        }

    }


}
