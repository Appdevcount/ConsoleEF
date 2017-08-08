using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //public class ProfileDet
    //{
    //    public int ProfileDetId { get; set; }
    //    public string ItemName { get; set; }//Textbox | Req
    //    public string ItemDescription { get; set; }//Textarea | AjaxAutoCompleteExtender
    //    public string ItemType { get; set; } //Dropdown | Req
    //    public int AvailableCount { get; set; } //NumericTextbox Range | Req
    //    public DateTime FromDate { get; set; }//Datetpicker Format Range | Req
    //    public DateTime ToDate { get; set; }//Datetpicker Range greater than FromDate | Req
    //    public DateTime PublishDate { get; set; }//Datetpicker UserControl | Req
    //    public DateTime ItemIntroDate { get; set; }//Datetpicker AjaxCalenderExtender | Req
    //    public string Email { get; set; }//Textbox Regex | Req
    //    public virtual ICollection<GeneralTopics> InterestedTopicChecks { get; set; } //CheckboxGroup
    //    public Gender Gender { get; set; } //RadioButton | Req
    //    public string Continent { get; set; } //AjaxCascDD1Extender | Req
    //    public string Country { get; set; } //AjaxCascDD2 | Req
    //    public string ConfirmText1 { get; set; } //Passwordbox | Req
    //    public string ConfirmText2 { get; set; } //Passwordbox | Req Compare
    //    public string InterestedTopicMulti { get; set; } //Listbox Multi | Req
    //    public byte[] FileDoc { get; set; } //.doc .pdf 5MBsize Filesystem AjaxFileUploadExtender | Req
    //    public byte[] ItemImage { get; set; } // .jpg DB
    //}
    //public class GeneralTopics
    //{
    //    public int GeneralTopicsId { get; set; }
    //    public string TopicName { get; set; }
    //}
    //public enum Gender
    //{
    //    Male=1, Female=2
    //}

    //========================================
    //OnetoManyRelation - looks the case of profile creation with profile details distributed
    public class ProfileDet
    {
        public ProfileDet()
        {
            InterestedTopicChecks = new HashSet<GeneralTopics>();
        }
        public ProfileDet(string ItemN,string ItemD,string ItemT,Gender G,byte[] Img,ICollection<GeneralTopics> ITopics)
        {
            this.ItemName = ItemN;
            //this.ItemDescription = ItemD;
            this.ItemType = ItemT;
            this.Gender = G;
            this.ItemImage = Img;
            this.InterestedTopicChecks = ITopics;

        }
        public int ProfileId { get; set; }
        public string ItemName { get; set; }
        //public string ItemDescription { get; set; }
        //public string ItemFull { get { return ItemName + "--" + ItemDescription; } }//Must have both getter and setter in entity model
        public string ItemType { get; set; }
        public virtual ICollection<GeneralTopics> InterestedTopicChecks { get; set; }
        public Gender Gender { get; set; }
        public byte[] ItemImage { get; set; }
    }
    public class GeneralTopics
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public ProfileDet ProfileDet { get; set; }
    }
    public enum Gender
    {
        Male = 1, Female = 2
    }
    
}
