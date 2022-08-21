using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        public string Name { get; set; }

        [Display(Name = "استان")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Ostan { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string TelePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }

        [Display(Name = "نوع مالکیت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NoeMalekiat { get; set; }

        
        public DateTime CreateDtae { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        public List<User> Users { get; set; }
        public AgentDocument AgentDocument { get; set; }
        #endregion

    }
}
