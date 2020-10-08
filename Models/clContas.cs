using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace deliverAPI.Models
{
    public class clContas
    {
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double ValOrig { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: AAAA-MM-DD")]
        public DateTime DtVenc { get; set; }

        [Required(ErrorMessage = "Campo é obrigatório: AAAA-MM-DD")]
        public DateTime DtPagto { get; set; }

        public int DiasAtraso { get => calcularAtraso(); }

        public double Multa { get; private set; }

        public double Juros { get; private set; }

        public double ValorCorrigido { get; private set; }

     
        public clContas() {}
        
        /*--------------------------------------------------------------
            atualizando propriedades :
            DiasAtraso, ValCorrigido, Juros e Multa
         -------------------------------------------------------------*/
        private int calcularAtraso()
        {
            int iRetorno = 0;

            DateTime dataIni = DtPagto;
            DateTime dataFim = DtVenc;


            if (dataIni > dataFim)
            {
                iRetorno = (dataIni - dataFim).Days;

                calcularJuros(iRetorno);
            }

            return iRetorno;
        }

        /*--------------------------------------------------------------
          ---- ATENÇÃO
               só chamar este método em caso de vencimento da conta  ---
               iDiasAtraso > 0                   -----------------------
          -------------------------------------------------------------*/
        private void calcularJuros(int iDiasAtraso)
        {
            double dValorNovo = 0;

            if (iDiasAtraso <= 0) { return; }

            if (iDiasAtraso <= 3)
            {
                Multa = 2;
                Juros = 0.1;
            }
            else if (iDiasAtraso <= 5)
                {
                    Multa = 3;
                    Juros = 0.2;
                }
                else
                {
                    Multa = 5;
                    Juros = 0.3;
                }
            

            dValorNovo = ValOrig + (ValOrig / 100) * Multa;
            ValorCorrigido = dValorNovo;

            for (int i = 1; i <= iDiasAtraso; i++)
            {
                dValorNovo = dValorNovo + (dValorNovo / 1000) * Juros;
            }

            ValorCorrigido = Math.Round(dValorNovo, 2);

        }

    }
}