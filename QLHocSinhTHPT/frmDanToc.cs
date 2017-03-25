﻿using DevComponents.DotNetBar;
using QLHocSinhTHPT.BLL;
using QLHocSinhTHPT.Component;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLHocSinhTHPT
{
    public partial class frmDanToc : Office2007Form
    {
        private DanTocBLL danTocBLL = new DanTocBLL();
        private QuyDinh quyDinh = new QuyDinh();

        public frmDanToc()
        {
            InitializeComponent();
            DataService.OpenConnection();
        }

        private void frmDanToc_Load(object sender, EventArgs e)
        {
            danTocBLL.HienThi(dGVDanToc, bindingNavigatorDanToc);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVDanToc.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = false;
            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorDanToc.BindingSource.RemoveCurrent();
            }
        }

        private void bindingNavigatorExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled |= dGVDanToc.RowCount == 0;

            DataRow row = danTocBLL.ThemDongMoi();
            row["MaDanToc"] = string.Format("DT{0}", quyDinh.LaySTT(dGVDanToc.Rows.Count + 1));
            row["TenDanToc"] = string.Empty;
            danTocBLL.ThemDanToc(row);
            bindingNavigatorDanToc.BindingSource.MoveLast();
        }

        public bool KiemTraTruocKhiLuu(string cellString)
        {
            foreach (DataGridViewRow row in dGVDanToc.Rows)
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
            if (KiemTraTruocKhiLuu("colMaDanToc") == true &&
                KiemTraTruocKhiLuu("colTenDanToc") == true)
            {
                bindingNavigatorPositionItem.Focus();
                danTocBLL.LuuDanToc();
            }
        }

        private void dGVDanToc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}