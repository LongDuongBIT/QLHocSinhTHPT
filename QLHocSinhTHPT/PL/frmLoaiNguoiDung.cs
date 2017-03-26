﻿using DevComponents.DotNetBar;
using QLHocSinhTHPT.BLL;
using QLHocSinhTHPT.Components;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLHocSinhTHPT
{
    public partial class frmLoaiNguoiDung : Office2007Form
    {
        private LoaiNguoiDungBLL loaiNguoiDungBLL = new LoaiNguoiDungBLL();
        private QuyDinh quyDinh = new QuyDinh();

        public frmLoaiNguoiDung()
        {
            InitializeComponent();
            DataService.OpenConnection();
        }

        private void frmLoaiNguoiDung_Load(object sender, EventArgs e)
        {
            loaiNguoiDungBLL.HienThi(dGVLoaiNguoiDung, bindingNavigatorLoaiNguoiDung);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVLoaiNguoiDung.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = false;
            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorLoaiNguoiDung.BindingSource.RemoveCurrent();
            }
        }

        private void bindingNavigatorExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled |= dGVLoaiNguoiDung.RowCount == 0;

            DataRow row = loaiNguoiDungBLL.ThemDongMoi();
            row["MaLoai"] = string.Format("LND{0}", quyDinh.LaySTT(dGVLoaiNguoiDung.Rows.Count + 1));
            row["TenLoaiND"] = string.Empty;
            loaiNguoiDungBLL.ThemLoaiNguoiDung(row);
            bindingNavigatorLoaiNguoiDung.BindingSource.MoveLast();
        }

        public bool KiemTraTruocKhiLuu(string cellString)
        {
            foreach (DataGridViewRow row in dGVLoaiNguoiDung.Rows)
            {
                if (row.Cells[cellString].Value != null)
                {
                    string str = row.Cells[cellString].Value.ToString();
                    if (str == string.Empty)
                    {
                        MessageBoxEx.Show("Giá trị của ô không được rỗng!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiLuu("colMaLoai") == true && KiemTraTruocKhiLuu("colTenLoaiND") == true)
            {
                bindingNavigatorPositionItem.Focus();
                loaiNguoiDungBLL.LuuLoaiNguoiDung();
            }
        }

        private void dGVLoaiNguoiDung_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}