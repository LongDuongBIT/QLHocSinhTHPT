﻿using DevComponents.DotNetBar;
using Microsoft.Reporting.WinForms;
using QuanLyTruongCap3.BLL;
using QuanLyTruongCap3.Components;
using QuanLyTruongCap3.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTruongCap3.Reports
{
    public partial class frptDanhSachLopHoc : Office2007Form
    {
        private NamHocBLL namHocBLL = new NamHocBLL();

        public frptDanhSachLopHoc()
        {
            InitializeComponent();
            DataService.OpenConnection();
        }

        private void frptDanhSachLopHoc_Load(object sender, EventArgs e)
        {
            namHocBLL.HienThiComboBox(cmbNamHoc);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            IList<LopDTO> lop = LopBLL.LayDsLop(cmbNamHoc.SelectedValue.ToString());

            IList<ReportParameter> param = new List<ReportParameter>();
            QuyDinhDTO truong = QuyDinh.LayThongTinTruong();
            param.Add(new ReportParameter("TenTruong", truong.TenTruong));
            param.Add(new ReportParameter("DiaChiTruong", truong.DiaChiTruong));
            param.Add(new ReportParameter("NgayLap", string.Format("{0}/{1}/{2}", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year)));
            param.Add(new ReportParameter("NamHoc", cmbNamHoc.Text));
            this.reportViewerDSLop.LocalReport.SetParameters(param);

            this.bSDSLop.DataSource = lop;
            this.reportViewerDSLop.RefreshReport();
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            IList<LopDTO> lop = LopBLL.LayDsLop();

            IList<ReportParameter> param = new List<ReportParameter>();
            QuyDinhDTO truong = QuyDinh.LayThongTinTruong();
            param.Add(new ReportParameter("TenTruong", truong.TenTruong));
            param.Add(new ReportParameter("DiaChiTruong", truong.DiaChiTruong));
            param.Add(new ReportParameter("NgayLap", string.Format("{0}/{1}/{2}", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year)));
            param.Add(new ReportParameter("NamHoc", "Tất cả"));
            this.reportViewerDSLop.LocalReport.SetParameters(param);

            this.bSDSLop.DataSource = lop;
            this.reportViewerDSLop.RefreshReport();
        }
    }
}