//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Global.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int ScoreID { get; set; }
        public System.DateTime DateTime { get; set; }
        public int Score1 { get; set; }
        public int quizid { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
