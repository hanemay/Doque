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
    
    public partial class OptionGroups
    {
        public OptionGroups()
        {
            this.OptionChoices = new HashSet<OptionChoices>();
            this.Questions = new HashSet<Questions>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<OptionChoices> OptionChoices { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
