using System.Collections.Generic;

//{
//    public class Quanlysach
//    {
//    }
//}
using HD.Test.DI_services;
using HD.Test.Models;

namespace HD.Test.DI_services.Services
{
    public class Quanlysach : ISach
    {
        private readonly QLSContext _context;

        public Quanlysach(QLSContext context)
        {
            _context = context;
        }

        //public List<SinhVien> GetDiem(string masv)
        //{

        //}

        //public List<SinhVien> Getdssv(string svkhoa, string magv)
        //{


        //    var list = new List<SinhVien>();
        //    var lists = (from m in _context.SinhViens
        //                 join c in _context.HuongDans on m.Masv equals c.Masv
        //                 where m.Makhoa == svkhoa
        //                 where c.Magv.ToString() == magv
        //                 select m).ToList();

        //    foreach (var listItem in lists)
        //    {
        //        list.Add(listItem);
        //    }

        //    return list;
        //}

    }
}

