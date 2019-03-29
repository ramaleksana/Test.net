using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Module : BaseModel
    {
        
        public static implicit operator int(Module v)
        {
            throw new NotImplementedException();
        }
    }
}