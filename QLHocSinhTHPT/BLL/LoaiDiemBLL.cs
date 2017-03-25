﻿using DevComponents.DotNetBar.Controls;
using QLHocSinhTHPT.DAL;
using System.Data;
using System.Windows.Forms;

namespace QLHocSinhTHPT.BLL
{
    public class LoaiDiemBLL
    {
        private readonly LoaiDiemDAL loaiDiemDAL = new LoaiDiemDAL();

        public void HienThiComboBox(ComboBoxEx comboBox)
        {
            comboBox.DataSource = loaiDiemDAL.LayDsLoaiDiem();
            comboBox.DisplayMember = "TenLoai";
            comboBox.ValueMember = "MaLoai";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmbColumn)
        {
            cmbColumn.DataSource = loaiDiemDAL.LayDsLoaiDiem();
            cmbColumn.DisplayMember = "TenLoai";
            cmbColumn.ValueMember = "MaLoai";
            cmbColumn.DataPropertyName = "MaLoai";
            cmbColumn.HeaderText = "Loại điểm";
        }

        public void HienThi(DataGridViewX dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();

            bS.DataSource = loaiDiemDAL.LayDsLoaiDiem();
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public DataRow ThemDongMoi()
        {
            return loaiDiemDAL.ThemDongMoi();
        }

        public void ThemLoaiDiem(DataRow row)
        {
            loaiDiemDAL.ThemLoaiDiem(row);
        }

        public bool LuuLoaiDiem()
        {
            return loaiDiemDAL.LuuLoaiDiem();
        }
    }
}