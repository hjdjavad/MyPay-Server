using System;
using System.ComponentModel.DataAnnotations;

namespace MyPay.Data.Models
{
    public class BaseEntity<T>
    {
        [Key] 
        public T Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
    }
}
