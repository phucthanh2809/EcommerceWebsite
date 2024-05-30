using ECommerceMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly Hshop2023Context db;

        //Đầu tiên muốn làm việc với CSDL thì nhúng vô cái CSDL
        public HangHoaController(Hshop2023Context context)
        {
            db = context;
        }

        public IActionResult Index(int? loai)
        {
            //Lấy hết tất cả hàng hoá ra
            var hangHoas = db.HangHoas.AsQueryable();
            //Kiểm tra xem cột loại này có valus hay không
            if(loai.HasValue)
            {
                //Kiểm tra xem cái cột mã loại có bằng với mã loại ngta truyền vô không
                hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
            }    

            return View();
        }
    }
}
