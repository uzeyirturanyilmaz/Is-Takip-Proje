using DevExpress.XtraEditors;
using is_takip_proje.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje.Formlar
{
    public partial class FrmYeniFirma : Form
    {
        public FrmYeniFirma()
        {
            InitializeComponent();
        }

        DbistakipEntities1 db = new DbistakipEntities1();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblFirmalar t = new TblFirmalar();
            t.Ad = TxtAd.Text;
            t.Yetkili = TxtYetkili.Text;
            t.Telefon = TxtTelefon.Text;
            t.Mail = TxtMail.Text;
            t.Sektor = TxtSektor.Text;
            t.il = TxtIl.Text;
            t.ilce = TxtIlce.Text;
            t.Adres = TxtGorsel.Text;
            t.Sifre = TxtSifre.Text;
            t.Gorsel = TxtGorsel.Text;
            



            db.TblFirmalar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Firma Başarıyla Tanımlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
