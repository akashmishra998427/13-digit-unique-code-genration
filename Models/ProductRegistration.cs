using System;
using System.ComponentModel.DataAnnotations;

namespace VCQRU.Models
{
    public class ProductRegistration
    {
        [Key]
        public int Id { get; set; } // Optional primary key if needed

        [Required]
        public decimal BatchSize { get; set; }

        public string Comments { get; set; }

        [Required]
        public string Comp_ID { get; set; }

        public string Dispatch_Location { get; set; }

        public string Display_Product { get; set; }

        public string Display_Series { get; set; }

        public int Doc_Flag { get; set; }

        public string Doc_Remark { get; set; }

        public string Label_Code { get; set; }

        public string Pro_Desc { get; set; }

        public string Pro_Doc { get; set; }

        public DateTime Pro_Entry_Date { get; set; }

        [Required]
        public string Pro_ID { get; set; }

        public string Pro_Name { get; set; }

        public string Remark { get; set; }

        public decimal Row_ID { get; set; }

        public int Sound_Flag { get; set; }

        public string Sound_Remark { get; set; }

        public decimal Update_Flag { get; set; }

        public decimal Update_Flag_E { get; set; }

        public decimal Update_Flag_H { get; set; }
    }
}
