using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class BaseModel
    {
        [Key]
        public string Id
        {
            get;
            set;
        }

        //[Required]
        public string Name
        {
            get;
            set;
        }
    }
}