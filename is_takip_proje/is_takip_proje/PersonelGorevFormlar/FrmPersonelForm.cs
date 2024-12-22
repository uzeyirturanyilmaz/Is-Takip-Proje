using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje.PersonelGorevFormlar
{
    public partial class FrmPersonelForm : Form
    {
        public FrmPersonelForm()
        {
            InitializeComponent();
        }

        public string mail;

        private void BtnAktifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlar.FrmAktifGorevler frm = new PersonelGorevFormlar.FrmAktifGorevler();
            frm.MdiParent = this;
            frm.mail2 = mail;
            frm.Show();
        }

        private void BtnPasifGorevler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlar.FrmPasifGorevler frm2 = new PersonelGorevFormlar.FrmPasifGorevler();
            frm2.MdiParent = this;
            frm2.mail2 = mail;
            frm2.Show();
        }

        private void BtnCagriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PersonelGorevFormlar.FrmCagriListesi frm2 = new PersonelGorevFormlar.FrmCagriListesi();
            frm2.MdiParent = this;
            frm2.mail2 = mail;
            frm2.Show();
        }
        
    }
}
