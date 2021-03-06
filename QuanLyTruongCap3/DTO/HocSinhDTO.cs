﻿using System;


namespace QuanLyTruongCap3.DTO
{
    public class HocSinhDTO
    {
        public string MaHocSinh { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public DanTocDTO DanToc { get; set; }
        public TonGiaoDTO TonGiao { get; set; }
        public string HoTenCha { get; set; }
        public NgheNghiepDTO NNghiepCha { get; set; }
        public string HoTenMe { get; set; }
        public NgheNghiepDTO NNghiepMe { get; set; }
    }
}