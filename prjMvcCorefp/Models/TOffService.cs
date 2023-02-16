﻿using System;
using System.Collections.Generic;

namespace prjMvcCorefp.Models
{
    public partial class TOffService
    {
        public TOffService()
        {
            TNursingRecords = new HashSet<TNursingRecord>();
        }

        public int OId { get; set; }
        public int? EId { get; set; }
        public int? PId { get; set; }
        public string? O就診日期 { get; set; }
        public string? O回診日期 { get; set; }
        public string? O醫師診斷 { get; set; }
        public string? O指示與用藥 { get; set; }
        public DateTime? O建立 { get; set; }
        public DateTime? O更新 { get; set; }

        public virtual TEmployee? EIdNavigation { get; set; }
        public virtual TPatientInfo? PIdNavigation { get; set; }
        public virtual ICollection<TNursingRecord> TNursingRecords { get; set; }
    }
}
