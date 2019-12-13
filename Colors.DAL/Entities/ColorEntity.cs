using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colors.DAL.Entities
{
    [Table("Colors")]
    public class ColorEntity
    {
        [Key]
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
