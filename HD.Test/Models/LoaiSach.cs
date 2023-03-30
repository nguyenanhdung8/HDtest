using System;
using System.Collections.Generic;

#nullable disable

namespace HD.Test.Models
{
    public partial class LoaiSach
    {
        public LoaiSach()
        {
            Saches = new HashSet<Sach>();
        }

        public int Maloai { get; set; }
        public string Tenloai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
