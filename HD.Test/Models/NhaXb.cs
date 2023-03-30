using System;
using System.Collections.Generic;

#nullable disable

namespace HD.Test.Models
{
    public partial class NhaXb
    {
        public NhaXb()
        {
            Saches = new HashSet<Sach>();
        }

        public int MaXb { get; set; }
        public string Tenxb { get; set; }
        public string Diachi { get; set; }
        public string Ghichu { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
