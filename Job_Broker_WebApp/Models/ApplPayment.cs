//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Job_Broker_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplPayment
    {
        public int ID { get; set; }
        public int APP_ID { get; set; }
        public string TYPEOFPAY { get; set; }
        public decimal AMOUNT { get; set; }
        public byte[] DOP { get; set; }
    
        public virtual Applicant Applicant { get; set; }
    }
}
