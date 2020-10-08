using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace deliverAPI.Models
{
    public class clContas
    {
        
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double ValOrig { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [validaData(ErrorMessage = "Formato esperado:  dd/mm/yyyy")]
        public string DtVenc { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório")]
        [validaData(ErrorMessage = "Formato esperado: dd/mm/yyyy")]
        public string DtPagto { get; set; }

        public int DiasAtraso { get; private set; }

        public double Multa { get; private set; }

        public double Juros { get; private set; }

        public double ValorCorrigido { get; private set; }

     
        public clContas() {}
        
        /*--------------------------------------------------------------
         ---- aqui atualizando propriedades :
            DiasAtraso, RegraCalculo, ValCorrigido
         --------------------------------------------------------------
         -------------------------------------------------------------*/
        public void calcularAtraso()
        {
            double dValorNovo = 0;

            int iDia2 = Convert.ToInt32(DtVenc.Substring(0, 2));
            int iMes2 = Convert.ToInt32(DtVenc.Substring(3, 2));
            int iAno2 = Convert.ToInt32(DtVenc.Substring(6, 4));
            int iDia1 = Convert.ToInt32(DtPagto.Substring(0, 2));
            int iMes1 = Convert.ToInt32(DtPagto.Substring(3, 2));
            int iAno1 = Convert.ToInt32(DtPagto.Substring(6, 4));

            DateTime dataIni = new DateTime(iAno1, iMes1, iDia1, 0, 0, 0);
            DateTime dataFim = new DateTime(iAno2, iMes2, iDia2, 0, 0, 0);

            if (dataIni > dataFim)
            {
                DiasAtraso = (dataIni - dataFim).Days;

                if (DiasAtraso <= 3)
                {
                    Multa = 2;
                    Juros = 0.1;
                }
                else
                {
                    if (DiasAtraso <= 5)
                    {
                        Multa = 3;
                        Juros = 0.2;
                    }
                    else
                    {
                        Multa = 5;
                        Juros = 0.3;
                    }
                }

                dValorNovo = ValOrig + (ValOrig / 100) * Multa;
                ValorCorrigido = dValorNovo;

                for (int i = 1; i <= DiasAtraso; i++)
                {
                    dValorNovo = dValorNovo + (dValorNovo / 1000) * Juros;
                }
                ValorCorrigido = Math.Round(dValorNovo,2);

            }

        }

        private static double calcularValor()
        {
            double dResult = 0;

            return dResult;
        }
    }
}