using System;
using System.Collections.Generic;

namespace prjMvcCorefp.Models
{
    public partial class TRoombed
    {
        public TRoombed()
        {
            TBeds = new HashSet<TBed>();
        }

        public int RbId { get; set; }
        public string? Rb房型 { get; set; }
        public string? Rb床號 { get; set; }
        public string? Rb空床 { get; set; }

        public virtual ICollection<TBed> TBeds { get; set; }
    }
}
