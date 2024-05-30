using ECommerceMVC.Data;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly Hshop2023Context db;

        //insert hàm làm việc với cơ sở dữ liệu 
        //db là tên biến local 
        public MenuLoaiViewComponent(Hshop2023Context Context) => db = Context; 

        public IViewComponentResult Invoke()
        {
            //Lấy tên loại và số lượng của loại đó 
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count
            }).OrderBy(p => p.TenLoai);
            //Sẽ trả về view mặc định là file Defaut, 
            return View(data); //"Defaut"
            //cú pháp đầy đủ: return View("Defaut", data);
            
        }
    }
}
