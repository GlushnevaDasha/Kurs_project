//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kr_avt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordering
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Client { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ActionId { get; set; }
        public string Number { get; set; }
        public bool Status { get; set; }
    
        public virtual Sale Sale { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
