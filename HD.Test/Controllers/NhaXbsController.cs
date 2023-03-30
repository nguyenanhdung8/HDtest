//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Threading.Tasks;

//namespace HD.Test.Controllers
//{
//    public class NhaXbsController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using HD.Test.DI;
using HD.Test.Models;
using HD.Test.DI_services;

namespace HD.Test.Controllers
{
    public class NhaXbsController : Controller
    {
        private readonly QLSContext _context;
        //public IQuanlythuctap _quanlythuctap;

        public NhaXbsController(QLSContext context, ISach sach)
        {
            _context = context;
            //_quanlythuctap = quanlythuctap;
        }
        public async Task<IActionResult> Index()
        {


            var sv = (await _context.NhaXbs.ToListAsync());
            
           
            return View(sv);



        }

        //public async Task<IActionResult> Index(string svkhoa,string masv,string svname)
        //{
        //    // Use LINQ to get list of genres.
        //    IQueryable<string> nQuery = from m in _context.SinhViens
        //                               orderby m.Makhoa
        //                               select m.Makhoa;

        //    IQueryable<string> Query = from n in _context.SinhViens

        //                                select n.Hotensv;

        //    //IQueryable<int> msvQuery = from k in _context.SinhViens
        //    //                            select k.Masv;


        //    var sv = from m in _context.SinhViens
        //             select m;

        //    if (!string.IsNullOrEmpty(masv))
        //    {
        //        sv = sv.Where(x => x.Masv.ToString() == masv);

        //    }

        //    if (!string.IsNullOrEmpty(svkhoa))
        //    {
        //        sv = sv.Where(x => x.Makhoa == svkhoa);

        //    }
        //    if (!string.IsNullOrEmpty(svname))
        //    {
        //        sv = sv.Where(x => x.Hotensv == svname);

        //    }


        //    //int count = (from row in _context.SinhViens

        //    //             where row.Makhoa == svkhoa

        //    //             select row).Count();

        //    var SVKHOA = new FilterKhoaViewModel
        //    {
        //        Khoas = new SelectList(await nQuery.Distinct().ToListAsync()),
        //        Sinhvien = new SelectList(await Query.Distinct().ToListAsync()),
        //        //Masv = new SelectList(await msvQuery.Distinct().ToListAsync()),

        //        // countsv = count,

        //        SinhVien = await sv.ToListAsync()
        //    };


        //    return View(SVKHOA);
        //}

        // GET: SinhViens/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.NhaXbs == null)
        //    {
        //        return NotFound();
        //    }

        //    var nhaxb = await _context.NhaXbs
        //        .Include(s => s.MakhoaNavigation)
        //        .FirstOrDefaultAsync(m => m.Masv == id);
        //    if (sinhVien == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sinhVien);
        //}

        // GET: SinhViens/Create
        public IActionResult Create()
        {
            //ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaXb,Tenxb,Diachi,Ghichu")] NhaXb nhaxb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaxb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa", sinhVien.Makhoa);
            return View(nhaxb);
        }

        // GET: SinhViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NhaXbs == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.NhaXbs.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            //ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa", sinhVien.Makhoa);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaXb,Tenxb,Diachi,Ghichu")] NhaXb nhaXb)
        {
            if (id != nhaXb.MaXb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaXb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(nhaXb.MaXb))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa", sinhVien.Makhoa);
            return View(nhaXb);
        }

        // GET: SinhViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NhaXbs == null)
            {
                return NotFound();
            }

            var nhaXb = await _context.NhaXbs
                //.Include(s => s.MakhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaXb == id);
            if (nhaXb == null)
            {
                return NotFound();
            }

            return View(nhaXb);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NhaXbs == null)
            {
                return Problem("Entity set 'HD.Test Context'  is null.");
            }
            var sinhVien = await _context.NhaXbs.FindAsync(id);
            if (sinhVien != null)
            {
                _context.NhaXbs.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(int id)
        {
            return _context.NhaXbs.Any(e => e.MaXb == id);
        }
    }
}

