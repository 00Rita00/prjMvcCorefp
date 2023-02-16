using System;
using System.Collections.Generic;

namespace prjMvcCorefp.Models
{
    public partial class TBed
    {
        public int BId { get; set; }
        public int PId { get; set; }
        public int? RbId { get; set; }
        public string? B入住時間 { get; set; }
        public string? B預計退房時間 { get; set; }

        public virtual TPatientInfo PIdNavigation { get; set; } = null!;
        public virtual TRoombed? Rb { get; set; }
    }
}
