using System;
using System.ComponentModel.DataAnnotations;

namespace deliverAPI.Models
{
    public class validaData : ValidationAttribute
    {
        //private readonly string sData;
        public validaData()
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
    
}