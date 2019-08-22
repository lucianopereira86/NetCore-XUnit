using System;
using System.Collections.Generic;

namespace APITest.Presentation.WebAPI.Models
{
    public class BusinessException: Exception
    {
        public IList<dynamic> ErrorList { get; set; }

    }
}
