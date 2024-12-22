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
    public partial class FrmPersonelEkle : Form
    {
        public FrmPersonelEkle()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void FrmPersonelEkle_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblDepartmanlar
                            select new
                            {
                                x.ID,
                                x.Ad
                            }).ToList();

            
            lookUpEdit1.Properties.DisplayMember = "Ad";
            
            lookUpEdit1.Properties.ValueMember = "ID";
            
            lookUpEdit1.Properties.DataSource = degerler;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked==true)
            {
                TblPersonel t = new TblPersonel();
                t.Ad = TxtAd.Text;
                t.Soyad = TxtSoyad.Text;
                t.Mail = TxtMail.Text;
                t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
                t.Durum = true;
                t.Sifre = TxtSifre.Text;
                db.TblPersonel.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Personel Başarıyla Tanımlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (checkEdit1.Checked==false)
            {
                TblPersonel t = new TblPersonel();
                t.Ad = TxtAd.Text;
                t.Soyad = TxtSoyad.Text;
                t.Mail = TxtMail.Text;
                t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
                t.Durum = false;
                t.Sifre = TxtSifre.Text;
                db.TblPersonel.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Personel Başarıyla Tanımlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
   
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
