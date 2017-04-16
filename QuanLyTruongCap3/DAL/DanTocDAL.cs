﻿using QuanLyTruongCap3.Components;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTruongCap3.DAL
{
    public class DanTocDAL
    {
        private readonly DataService danTocDS = new DataService();

        public DataTable LayDsDanToc()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * " + "FROM DANTOC"))
            {
                danTocDS.Load(cmd);
            }

            return danTocDS;
        }

        public DataRow ThemDongMoi()
        {
            return danTocDS.NewRow();
        }

        public void ThemDanToc(DataRow row)
        {
            danTocDS.Rows.Add(row);
        }

        public bool LuuDanToc()
        {
            return danTocDS.ExecuteNonQuery() > 0;
        }
    }
}