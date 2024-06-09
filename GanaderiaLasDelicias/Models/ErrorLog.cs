using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class ErrorLog
    {
        public int ErrorId { get; set; }
        public string ErrorDescription { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
    }
}
