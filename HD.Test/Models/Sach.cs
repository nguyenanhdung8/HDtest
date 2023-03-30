using System;
using System.Collections.Generic;

#nullable disable

namespace HD.Test.Models
{
    public partial class Sach
    {
        public int? Maxb { get; set; }
        public int? Maloai { get; set; }
        public int Masach { get; set; }
        public string Tensach { get; set; }
        public string Tacgia { get; set; }

        public virtual LoaiSach MaloaiNavigation { get; set; }
        public virtual NhaXb MaxbNavigation { get; set; }
    }
}
