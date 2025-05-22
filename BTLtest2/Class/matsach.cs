using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLtest2.Class
{
    internal class matsach
    {
        public string MaLanMat { get; set; }
        public string MaSach { get; set; }
        public int SoLuongMat { get; set; }
        public DateTime NgayMat { get; set; }

        // Constructor đầy đủ tham số
        public matsach(string maLanMat, string maSach, int soLuongMat, DateTime ngayMat)
        {
            MaLanMat = maLanMat;
            MaSach = maSach;
            SoLuongMat = soLuongMat;
            NgayMat = ngayMat;
        }
    }
}
