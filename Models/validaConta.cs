using System;
using System.ComponentModel.DataAnnotations;

namespace deliverAPI.Models
{
    public class validaData: ValidationAttribute
    {
        //private readonly string sData;
        public validaData()
        {
            //this.sData = sData;

        }


        public override bool IsValid(object value)
        {
            System.Console.WriteLine (value.ToString());

            DateTime time;
            if (!DateTime.TryParse(value.ToString(), out time))
            { 
                return false; 
            }


            //return base.IsValid(value);
            return true;
        }

    }

    public class validaConta : ValidationAttribute
    {
        //private readonly string sData;
        public validaConta()
        {
            //this.sData = sData;

        }


        public override bool IsValid(object value)
        {

            DateTime time;
            if (!DateTime.TryParse(value.ToString(), out time))
            {
                return false;
            }


            //return base.IsValid(value);
            return true;
        }

    }
    [AttributeUsage(AttributeTargets.Class )]
    public class calcularAtraso1 : ValidationAttribute
    {
        private readonly clContas iConta;
        public calcularAtraso1( clContas  iConta)
        {
            this.iConta = iConta;
        }


        public override bool IsValid(object value)
        {

            DateTime time;
            if ( (!DateTime.TryParse(iConta.DtVenc, out time)) ||
                 (!DateTime.TryParse(iConta.DtPagto, out time)) )
            {
                return false;
            }

           

            //return base.IsValid(value);
            return true;
        }

    }
}

