using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using is_takip_proje.Entitiy;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace is_takip_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartmanlar frm = new Formlar.FrmDepartmanlar();
            frm.MdiParent = this;
            frm.Show();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void Form1_Load(object sender, EventArgs e)
        {
            void Listele()
            {

                var degerler = (from x in db.TblDepartmanlar
                                select new
                                {
                                    x.ID,
                                    x.Ad
                                }).ToList();

            }
            Listele();
        }

        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersoneller frm2 = new Formlar.FrmPersoneller();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void BtnPersonelİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonelİstatistik frm3 = new Formlar.FrmPersonelİstatistik();
            frm3.MdiParent = this;
            frm3.Show();
        }

        Formlar.FrmGorevListesi frm4;

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new Formlar.FrmGorevListesi();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }
        private void BtnGorevtTanimla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorev fr = new Formlar.FrmGorev();
            fr.Show();

        }

        private void BtnGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorevDetay fr = new Formlar.FrmGorevDetay();
            fr.Show();

        }
        Formlar.FrmAnaForm frma;
        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frma == null || frma.IsDisposed)
            {
                frma = new Formlar.FrmAnaForm();
                frma.MdiParent = this;
                frma.Show();
            }
        }
        Formlar.FrmAktifCagrilar frmak;
        private void BtnAktifCagrilar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmak == null || frmak.IsDisposed)
            {
                frmak = new Formlar.FrmAktifCagrilar();
                frmak.MdiParent = this;
                frmak.Show();
            }
        }

        Formlar.FrmYeniDepartman frmyeni;
        private void BtnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmyeni == null || frmyeni.IsDisposed)
            {
                frmyeni = new Formlar.FrmYeniDepartman();

                frmyeni.Show();
            }
        }

        Formlar.FrmYeniFirma frmyenifirma;

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmyenifirma == null || frmyenifirma.IsDisposed)
            {
                frmyenifirma = new Formlar.FrmYeniFirma();

                frmyenifirma.Show();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        Formlar.FrmPersonelEkle frm5;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new Formlar.FrmPersonelEkle();

                frm5.Show();
            }
        }


        Formlar.FrmFirmaListesi frm6;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new Formlar.FrmFirmaListesi();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        Formlar.FrmPasifCagrilar frmpasif;
        private void BtnPasifCagrilar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmpasif == null || frmpasif.IsDisposed)
            {
                frmpasif = new Formlar.FrmPasifCagrilar();
                frmpasif.MdiParent = this;
                frmpasif.Show();
            }
        }


        Formlar.FrmTamlananGorev frmgorev;
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmgorev == null || frmgorev.IsDisposed)
            {
                frmgorev = new Formlar.FrmTamlananGorev();
                frmgorev.MdiParent = this;
                frmgorev.Show();
            }
        }
    }

}
