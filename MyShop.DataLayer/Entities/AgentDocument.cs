using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class AgentDocument
    {
        public int AgentDocumentId { get; set; }

        public int AgentId { get; set; }


        [Display(Name = "تصویر مچوز کسب")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MojavezeKasbImage { get; set; }

        [Display(Name = "تصویر شرکت نامه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string SherkatnameImage { get; set; }

        [Display(Name = "تصویر روزنامه رسمی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NewsPaperImage { get; set; }

        [Display(Name = "تصویر آگهی تاسیس")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string AgahiTaasisImage { get; set; }

        [Display(Name = "تصویر آخرین آگهی تغییرات")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string AkharinAgahiTaaghiratImage { get; set; }

        [Display(Name = "تصویر سر در فروشگاه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string SarDarForoushgahImage { get; set; }

        [Display(Name = "فیش آب")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FishAbImage { get; set; }

        [Display(Name = "فیش گاز")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FishGazImage { get; set; }

        [Display(Name = "فیش برق")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FishBarghImage { get; set; }

        [Display(Name = "فیش تلفن ثابت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FishTelePhoneImage { get; set; }

        [Display(Name = "تصویر سند نوع مالکیت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string SanadNoeeMalekiatImage { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }



        public Agent Agent { get; set; }
    }
}
