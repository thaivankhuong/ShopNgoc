//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToanThangSite.Entities.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Introduce
    {
        public int IntroduceID { get; set; }
        public string Avatar { get; set; }
        public string Thumb { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Position { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
