using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_LapTrinhWeb.Areas.Admin.Controllers
{
    public class DashBoardsController : BaseController
    {
        private readonly DbContext db = new DbContext();
        // GET: Admin/DashBoards
        public ActionResult Index()
        {
            ViewBag.Order = db.Orders.ToList();
            ViewBag.OrderDetail = db.Oder_Detail.ToList();
            ViewBag.ListOrderDetail1 = db.Oder_Detail.Where(m => m.Product.type == 1).OrderByDescending(m => m.create_at).Take(3).ToList();
            ViewBag.ListOrderDetail2 = db.Oder_Detail.Where(m => m.Product.type == 2).OrderByDescending(m => m.create_at).Take(3).ToList();
            ViewBag.ListOrder = db.Orders.OrderByDescending(m => m.oder_date).Take(7).ToList();
            return View();
        }

        //THÊM THỐNG KÊ
        //[HttpGet]
        //public ActionResult GetStatistical(string fromDate, string toDate)
        //{
        //    var query = from o in db.Orders
        //                join od in db.Oder_Detail
        //                on o.order_id equals od.order_id
        //                join p in db.Products
        //                on od.product_id equals p.product_id
        //                select new
        //                {
        //                    CreatedDate = o.create_at,
        //                    Quantity = od.quantity,
        //                    Price = od.price
        //                };
        //    if (!string.IsNullOrEmpty(fromDate))
        //    {
        //        DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
        //        query = query.Where(x => x.CreatedDate >= startDate);
        //    }
        //    if (!string.IsNullOrEmpty(toDate))
        //    {
        //        DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
        //        query = query.Where(x => x.CreatedDate < endDate);
        //    }

        //    var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
        //    {
        //        Date = x.Key.Value,                
        //        TotalSell = x.Sum(y => y.Quantity * y.Price),
        //    }).Select(x => new
        //    {
        //        Date = x.Date,
        //        DoanhThu = x.TotalSell                
        //    });
        //    return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        //}
    }
}