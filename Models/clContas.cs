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

        public int RegraCalculo { get; private set; }

        public double ValCorrigido { get; private set; }


        /* ---- Contrutor não funcionou
         * ----------------------------  */
        public clContas(int _DiasAtraso, int _RegraCalculo, double _ValCorrigido)
        {
            DiasAtraso = calcularAtraso(this); 
            RegraCalculo = _RegraCalculo;
            ValCorrigido = _ValCorrigido;
        }

        public clContas() {}

        /*--------------------------------------------------------------
         ---- aqui atualizando propriedades :
            DiasAtraso, RegraCalculo, ValCorrigido
        --------------------------------------------------------------
          não consegui deixar a classe com um CONSTRUTOR porque
          deu erro de execução no JSON, para não perder tempo 
          decidi deixar estas atualizações no método abaixo

         -------------------------------------------------------------*/
        public int calcularAtraso(clContas iConta)
        {
            int iDia2 = Convert.ToInt32(iConta.DtVenc.Substring(0, 2));
            int iMes2 = Convert.ToInt32(iConta.DtVenc.Substring(3, 2));
            int iAno2 = Convert.ToInt32(iConta.DtVenc.Substring(6, 4));
            int iDia1 = Convert.ToInt32(iConta.DtPagto.Substring(0, 2));
            int iMes1 = Convert.ToInt32(iConta.DtPagto.Substring(3, 2));
            int iAno1 = Convert.ToInt32(iConta.DtPagto.Substring(6, 4));
            int iResult = 0;

            DateTime dataIni = new DateTime(iAno1, iMes1, iDia1, 0, 0, 0);
            DateTime dataFim = new DateTime(iAno2, iMes2, iDia2, 0, 0, 0);

            if (dataIni > dataFim)
            {
                iResult = (dataIni - dataFim).Days;
            }

            return iResult;

        }

        private static double calcularValor()
        {
            double dResult = 0;

            return dResult;
        }
    }
}