using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.WINFORMS
{
    [Table("NOTES")]
    public partial class NOTES
    {      
        public string CUSTOMER { get; set; }
        [Key]
        public string ID { get; set; }
        public int STT { get; set; }
        public string TIME { get; set; }
        public string STAFF { get; set; }
        public string NOTE { get; set; }
        public string STATUS { get; set; }
    }
}