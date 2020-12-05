using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public int Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
