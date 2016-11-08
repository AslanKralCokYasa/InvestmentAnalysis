using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataStructure
{
    [Table("HistoricalDataBlock", Schema = "Application")]
    public class HistoricalDataBlock
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Index("IX_SYMBOL", IsUnique = true)]
        [Required]
        public string Symbol { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }

        [Required]
        public decimal LastPrice { get; set; }

        [Required]
        public decimal MinPrice { get; set; }

        [Required]
        public decimal MaxPrice { get; set; }

        [Required]
        public long Volume { get; set; }
    }
}
