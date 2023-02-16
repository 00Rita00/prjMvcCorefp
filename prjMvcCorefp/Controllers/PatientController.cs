using Microsoft.AspNetCore.Mvc;
using prjMvcCorefp.Models;
using prjMvcCorefp.ViewModel;
using System.Reflection;

namespace prjMvcCorefp.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        IWebHostEnvironment _environment;     //1.把IWebHostEnvironment此物件建成一個全域變數   
        public PatientController(IWebHostEnvironment environment)     //2.不能new所以使用注入(Dependency Injectiom)的方式寫一個建構子，把要被注入的物件變成參數 
        {
            _environment = environment;    //3.把參數記錄到全域變數上
        }

        fpdb2Context db = new fpdb2Context(); //拉到外面共用
        public ActionResult List(CKeywordViewModel vm)
        {
            IEnumerable<TPatientInfo> datas = null;

           //fpdb2Context db = new fpdb2Context();

            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from t in db.TPatientInfos
                        select t;
            else
                datas = db.TPatientInfos.Where(t => t.P姓名.Contains(vm.txtKeyword) ||
                t.P性別.Contains(vm.txtKeyword) ||
                t.P編號.Contains(vm.txtKeyword) ||
                t.P身分證字號.Contains(vm.txtKeyword) ||
                t.P出生日期.Contains(vm.txtKeyword) ||
                t.P聯絡電話.Contains(vm.txtKeyword));
           
            
            return View(datas);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TPatientInfo p, IFormFile photo)
        {
            DateTime dt = DateTime.Now;
            Random myRand = new Random();
            string strdt = dt.ToString("yyMMddHHmm");
            p.P編號 = "P" + strdt + myRand.Next(10, 100).ToString();
            p.P建立 = DateTime.Now;
            p.P更新 = DateTime.Now;

            if (photo != null)
            {
                //先取檔名photoName
                //再取路徑path
                //存到資料庫 P照片
                //CopyTo，上傳檔案。
                string photoName = Guid.NewGuid().ToString() + ".jpg";
                string path = _environment.WebRootPath + "/images/" + photoName;
                p.P照片 = photoName;
                photo.CopyTo(new FileStream(path, FileMode.Create));
                //動態取得資料夾的實體路徑。
            }
            else
            { p.P照片 = null; }
            db.TPatientInfos.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {


                TPatientInfo delPatientInfo = db.TPatientInfos.FirstOrDefault(t => t.PId == id);
                //找出要刪除的欄位

                if (delPatientInfo != null)
                {
                    db.TPatientInfos.Remove(delPatientInfo);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        //限制某個action只接受HttpPost的請求
        //存入資料庫
        public ActionResult Edit(CPatientViewModel p)
        {
            //dbDemoContext db = new dbDemoContext();
            TPatientInfo x = db.TPatientInfos.FirstOrDefault(t => t.PId == p.PId);
            if (x != null)
            {
                if (p.photo != null)
                {
                    //先取檔名photoName
                    //再取路徑path
                    //存到資料庫FimgePath
                    //CopyTo，上傳檔案。
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    string path = _environment.WebRootPath + "/images/" + photoName;
                    x.P照片 = photoName;
                    p.photo.CopyTo(new FileStream(path, FileMode.Create));
                    //動態取得資料夾的實體路徑。
                }


               
                x.P編號 = p.P編號;
                x.P姓名 = p.P姓名;
                x.P性別 = p.P性別;
                x.P身分證字號 = p.P身分證字號;
                x.P聯絡電話 = p.P聯絡電話;
                x.P聯絡人 = p.P聯絡人;
                x.P電話2 = p.P電話2;
                x.P餐點 = p.P餐點;
                x.P醫師診斷 = p.P醫師診斷;
                x.P主訴 = p.P主訴;
                x.現在病史 = p.現在病史;
                x.過去病史 = p.過去病史;
                x.家族病史 = p.家族病史;
                x.檢查 = p.檢查;
                x.指示與用藥 = p.指示與用藥;
                //x.P建立 = p.p建立;
                x.P更新 = DateTime.Now;

                //存入資料庫

            }
            return RedirectToAction("List");

        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                //dbDemoContext db = new dbDemoContext();
                TPatientInfo x = db.TPatientInfos.FirstOrDefault(t => t.PId == id);
                //FirstOrDefault 方法: 傳回序列的第一個項目；如果找不到任何項目，則傳回預設值。

                if (x != null)
                    return View(x);


            }
            return RedirectToAction("List");
        }

        public ActionResult Details(int? id)
        {

            if (id != null)
            {
                
                TPatientInfo x = db.TPatientInfos.FirstOrDefault(t => t.PId == id);
                if (x != null)
                    return View(x);
            }
            return RedirectToAction("List");
        }




    }
}
