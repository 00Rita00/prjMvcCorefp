using System;
using System.Collections.Generic;

namespace prjMvcCorefp.Models
{
    public partial class TNursingRecord
    {
        public int NId { get; set; }
        public int? EId { get; set; }
        public int? PId { get; set; }
        public int? OId { get; set; }
        public string? N舒張壓 { get; set; }
        public string? N收縮壓 { get; set; }
        public string? N體溫 { get; set; }
        public string? N脈搏 { get; set; }
        public string? N呼吸 { get; set; }
        public string? N傷口 { get; set; }
        public string? N三管 { get; set; }
        public string? N其他 { get; set; }
        public string? N紀錄時間 { get; set; }
        public string? N修改時間 { get; set; }

        public virtual TEmployee? EIdNavigation { get; set; }
        public virtual TOffService? OIdNavigation { get; set; }
        public virtual TPatientInfo? PIdNavigation { get; set; }
    }
}
