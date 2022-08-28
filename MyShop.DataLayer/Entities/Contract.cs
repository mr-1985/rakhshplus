using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }


        [Display(Name = "شماره قرارداد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string ContractNumber { get; set; }


        public int  UserId { get; set; }
        public int? AgentId { get; set; }
        public int? OperativeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Agent> Agents { get; set; }
        public List<Operative> Operatives { get; set; }
    }
}
