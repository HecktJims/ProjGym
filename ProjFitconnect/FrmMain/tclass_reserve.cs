//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrmMain
{
    using System;
    using System.Collections.Generic;
    
    public partial class tclass_reserve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tclass_reserve()
        {
            this.tmember_rate_class = new HashSet<tmember_rate_class>();
        }
    
        public int reserve_id { get; set; }
        public int class_schedule_id { get; set; }
        public int member_id { get; set; }
        public bool payment_status { get; set; }
        public bool reserve_status { get; set; }
    
        public virtual tclass_schedule tclass_schedule { get; set; }
        public virtual tIdentity tIdentity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmember_rate_class> tmember_rate_class { get; set; }
    }
}
