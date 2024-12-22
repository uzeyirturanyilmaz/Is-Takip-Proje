﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entitiy;
namespace is_takip_proje.Formlar
{
    public partial class FrmPersonelİstatistik : Form
    {
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            LblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            LblToplamFirma.Text = db.TblFirmalar.Count().ToString();
            LblToplamPersonel.Text = db.TblPersonel.Count().ToString();
            LblAktifis.Text = db.TblGorevler.Count(x => x.Durum == true).ToString();
            LblPasifis.Text = db.TblGorevler.Count(x => x.Durum == false).ToString();
            LblSonGorev.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Aciklama).FirstOrDefault();
            LblSonGorevDetay.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Tarih).FirstOrDefault().ToString();
            LblSehirSayisi.Text = db.TblFirmalar.Select(x => x.il).Distinct().Count().ToString();
            LblSektor.Text = db.TblFirmalar.Select(x => x.Sektor).Distinct().Count().ToString();
            LblBugunAcilanGorevler.Text = db.TblGorevler.Count(x => x.Tarih == bugun).ToString();
            var d1 = db.TblGorevler.GroupBy(x => x.GorevAlan).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            LblAyinPersoneli.Text = db.TblPersonel.Where(x => x.ID == d1).Select(y => y.Ad+" "+y.Soyad).FirstOrDefault().ToString();
            LblAyinDepartmani.Text = db.TblDepartmanlar.Where(x => x.ID == db.TblPersonel.Where(t=>t.ID==d1).Select(z=>z.Departman).FirstOrDefault()).Select(y => y.Ad).FirstOrDefault().ToString();

        }

    }
}
