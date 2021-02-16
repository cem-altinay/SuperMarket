using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logic)
        {
            foreach (var result in logic)
            {
                if (!result.Success)
                    return result;
            }
            return null;
        }  
    }
}
