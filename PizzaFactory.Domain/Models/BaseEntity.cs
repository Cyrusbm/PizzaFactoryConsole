using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
        public string? CreateDateTime { get; set; }
        public string? ModifiedDateTime { get; set; }
        public bool? IsDeleted { get; set; }


    }
}
