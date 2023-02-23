using Microsoft.AspNetCore.Mvc;
using prjMvcCorefp.Models;
using prjMvcCorefp.ViewModel;

namespace prjMvcCorefp.Controllers
{
    public class testController : Controller
    {
        public ActionResult testList()
        {
            fpdb2Context db = new fpdb2Context();
            IEnumerable<TNursingRecord> datas = null;
            datas = from t in db.TNursingRecords
                    select t;
            //Include抓主鍵的資料表
            //if (string.IsNullOrEmpty(vm.txtKeyword))
            //{
            //    datas = db.TNursingRecords.Include(t => t.OIdNavigation).ThenInclude(s => s.PIdNavigation).Include(a => a.EIdNavigation);
            //}
            //else
            //{
            //    datas = db.TNursingRecords.Include(t => t.OIdNavigation).ThenInclude(s => s.PIdNavigation).Include(a => a.EIdNavigation).Where(t => t.OIdNavigation.PIdNavigation.P姓名.Contains(vm.txtKeyword) ||
            //    t.OIdNavigation.PIdNavigation.P身分證字號.Contains(vm.txtKeyword) ||
            //    t.OIdNavigation.PIdNavigation.P出生日期.Contains(vm.txtKeyword) ||
            //    t.OIdNavigation.PIdNavigation.P聯絡電話.Contains(vm.txtKeyword));
            //}

            return View(datas);
        }

    }
}
