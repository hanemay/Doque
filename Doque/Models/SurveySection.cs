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
    
    public partial class SurveySection
    {
        public SurveySection()
        {
            this.Questions = new HashSet<Questions>();
            this.UserSurveySections = new HashSet<UserSurveySections>();
        }
    
        public int ID { get; set; }
        public int SurveyHeaderID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subheading { get; set; }
        public bool Required { get; set; }
    
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual SurveyHeader SurveyHeader { get; set; }
        public virtual ICollection<UserSurveySections> UserSurveySections { get; set; }
    }
}
