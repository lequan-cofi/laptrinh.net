using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLtest2.Class
{
    internal class khosach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public string MaLoai { get; set; }
        public string MaTacGia { get; set; }
        public string MaNXB { get; set; }
        public string MaLinhVuc { get; set; }
        public string MaNgonNgu { get; set; }
        public int SoTrang { get; set; }
        public string Anh { get; set; }


        // Constructor đầy đủ tham số
        public khosach(string maSach, string tenSach, int soLuong, decimal donGiaNhap, decimal donGiaBan,
                    string maLoai, string maTacGia, string maNXB, string maLinhVuc, string maNgonNgu, int soTrang, string anh)
        {
            MaSach = maSach;
            TenSach = tenSach;
            SoLuong = soLuong;
            DonGiaNhap = donGiaNhap;
            DonGiaBan = donGiaBan;
            MaLoai = maLoai;
            MaTacGia = maTacGia;
            MaNXB = maNXB;
            MaLinhVuc = maLinhVuc;
            MaNgonNgu = maNgonNgu;
            SoTrang = soTrang;
            Anh = anh;
        }

    }
}
