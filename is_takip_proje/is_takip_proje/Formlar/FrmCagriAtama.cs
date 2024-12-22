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
    public partial class FrmCagriAtama : Form
    {
        public FrmCagriAtama()
        {
            InitializeComponent();
        }
        public int id;

        DbistakipEntities1 db = new DbistakipEntities1();

        private void FrmCagriAtama_Load(object sender, EventArgs e)
        {
            //lookup icin gelen verilerin listelenmesi
            var degerler = (from x in db.TblPersonel
                            select new
                            {
                                x.ID,
                                AdSoyad = x.Ad + " " + x.Soyad
                            }).ToList();


            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
            lookUpEdit1.Properties.DataSource = degerler;


            TxtCagriID.Text = id.ToString();
            var gelenVeri = db.TblCagrilar.Find(id);
            TxtAciklama.Text = gelenVeri.Aciklama;
            TxtTarih.Text = gelenVeri.Tarih.ToString();
            TxtKonu.Text = gelenVeri.Konu;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            var gelenVeri = db.TblCagrilar.Find(id);
            gelenVeri.Konu = TxtKonu.Text;
            gelenVeri.Tarih = Convert.ToDateTime(TxtTarih.Text);
            gelenVeri.Aciklama = TxtAciklama.Text;
            gelenVeri.CagriPersonel = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
        }
    }
}
