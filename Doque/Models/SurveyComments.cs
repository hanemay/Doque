//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Doque.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveyComments
    {
        public int ID { get; set; }
        public int SurveyHeaderID { get; set; }
        public int UserID { get; set; }
        public string Comments { get; set; }
    
        public virtual SurveyHeader SurveyHeader { get; set; }
        public virtual User User { get; set; }
    }
}