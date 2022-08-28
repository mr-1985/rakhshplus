using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class AgentType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgentTypeId { get; set; }

        //[Required]
        //[MaxLength(150)]
        //public string AgentTypeTitle { get; set; }

        //public virtual List<Agent> Agents { get; set; }
    }
}
