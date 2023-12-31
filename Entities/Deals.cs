//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deals
    {
        public System.Guid DealID { get; set; }
        public Nullable<System.Guid> PropertyID { get; set; }
        public Nullable<System.Guid> ClientID { get; set; }
        public Nullable<System.Guid> AgentID { get; set; }
        public Nullable<System.DateTime> DealDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string DealStatus { get; set; }
        public string DealName { get; set; }
    
        public virtual Agents Agents { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Properties Properties { get; set; }
    }
}
