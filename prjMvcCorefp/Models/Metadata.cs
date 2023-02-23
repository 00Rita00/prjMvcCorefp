using System;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCorefp.Models
{
    public class TNursingRecordMetadata
    {

        public int NId { get; set; }
        public Nullable<int> EId { get; set; }
        public Nullable<int> PId { get; set; }
        public Nullable<int> OId { get; set; }
        [Display(Name = "舒張壓")]
        //[Required(ErrorMessage = "必填")]
        public string? N舒張壓 { get; set; }
        [Display(Name = "收縮壓")]
        //[Required(ErrorMessage = "必填")]
        public string? N收縮壓 { get; set; }
        [Display(Name = "體溫")]
        //[Required(ErrorMessage = "必填")]
        public string? N體溫 { get; set; }
        [Display(Name = "脈搏")]
        //[Required(ErrorMessage = "必填")]
        public string? N脈搏 { get; set; }
        [Display(Name = "呼吸速率")]
        //[Required(ErrorMessage = "必填")]
        public string? N呼吸 { get; set; }
        [Display(Name = "傷口")]
        //[Required(ErrorMessage = "必填")]
        public string? N傷口 { get; set; }
        [Display(Name = "管路液體量")]
        //[Required(ErrorMessage = "必填")]
        public string? N三管 { get; set; }
        [Display(Name = "其他")]
        //[Required(ErrorMessage = "必填")]
        public string? N其他 { get; set; }
        [Display(Name = "建立時間")]
        //[Required(ErrorMessage = "必填")]
        public string? N紀錄時間 { get; set; }
        [Display(Name = "修改時間")]
        public string? N修改時間 { get; set; }
    }
    public class TOffServiceMetadata
    {
        public int OId { get; set; }
        public int? EId { get; set; }
        public int? PId { get; set; }
        [Display(Name = "就診日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "不可空白")]
        public string? O就診日期 { get; set; }
        [Display(Name = "回診日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "不可空白")]
        public string? O回診日期 { get; set; }
        [Display(Name = "醫師診斷")]
        [Required(ErrorMessage = "不可空白")]
        public string? O醫師診斷 { get; set; }
        [Display(Name = "指示與用藥")]
        [Required(ErrorMessage = "不可空白")]
        public string? O指示與用藥 { get; set; }
        [Display(Name = "建立")]
        public DateTime? O建立 { get; set; }
        [Display(Name = "更新")]
        public DateTime? O更新 { get; set; }
    }
    public class TPatientInfoMetadata
    {
        public int PId { get; set; }
        [Display(Name = "住民編號")]
        public string? P編號 { get; set; }
        public int? EId { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "必填")]
        public string? P姓名 { get; set; }
        [Display(Name = "性別")]

        public string? P性別 { get; set; }
        [Display(Name = "身分證字號")]
        [RegularExpression("[A-Z]{1}[1-2]{1}[0-9]{8}")]
        [Required(ErrorMessage = "請輸入正確格式")]
        public string? P身分證字號 { get; set; }
        [Display(Name = "出生日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "請輸入生日")]
        public string? P出生日期 { get; set; }
        [Display(Name = "地址")]
        public string? P地址 { get; set; }
        [Display(Name = "住民電話")]
        //[Phone]
        [Required(ErrorMessage = "不可空白")]
        public string? P聯絡電話 { get; set; }
        [Display(Name = "聯絡人")]
        public string? P聯絡人 { get; set; }
        [Display(Name = "聯絡人電話")]
        //[Phone]
        public string? P電話2 { get; set; }
        [Display(Name = "餐點")]
        public string? P餐點 { get; set; }
        [Display(Name = "醫師診斷")]
        [Required(ErrorMessage = "不可空白")]
        public string? P醫師診斷 { get; set; }
        [Display(Name = "主訴")]
        [Required(ErrorMessage = "不可空白")]
        public string? P主訴 { get; set; }
        [Required(ErrorMessage = "不可空白")]
        public string? 現在病史 { get; set; }
        [Required(ErrorMessage = "不可空白")]
        public string? 過去病史 { get; set; }
        [Required(ErrorMessage = "不可空白")]
        public string? 家族病史 { get; set; }
        [Required(ErrorMessage = "不可空白")]
        public string? 檢查 { get; set; }
        [Required(ErrorMessage = "不可空白")]
        public string? 指示與用藥 { get; set; }
        [Display(Name = "建立")]
        //[DataType(DataType.DateTime)]
        // [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime? P建立 { get; set; }
        [Display(Name = "更新")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime? P更新 { get; set; }
        [Display(Name = "照片")]
        public string? P照片 { get; set; }




    }



}