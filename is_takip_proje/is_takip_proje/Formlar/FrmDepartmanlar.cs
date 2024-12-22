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

namespace is_takip_proje.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        DbistakipEntities1 db = new DbistakipEntities1();

        void Listele()
        {
            
            var degerler = (from x in db.TblDepartmanlar
                           select new
                           {
                               x.ID,
                               x.Ad
                           }).ToList();
            gridControl1.DataSource = degerler;
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text =="")
            {
                XtraMessageBox.Show("Departman Adı Boş Bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TblDepartmanlar t = new TblDepartmanlar();
                t.Ad = TxtAd.Text;
                db.TblDepartmanlar.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Departman Başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text =="")
            {
                XtraMessageBox.Show("Departman ID Boş Bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int x = int.Parse(TxtID.Text);

                // İlişkili personellerin Departman alanını null yap
                var personeller = db.TblPersonel.Where(p => p.Departman == x).ToList();
                foreach (var personel in personeller)
                {
                    personel.Departman = null;
                }

                // Departmanı sil
                var deger = db.TblDepartmanlar.Find(x);
                db.TblDepartmanlar.Remove(deger);

                // Değişiklikleri kaydet
                db.SaveChanges();

                XtraMessageBox.Show("Departman başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }
        private void gridView1_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblDepartmanlar.Find(x);
            deger.Ad = TxtAd.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Departman Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
        }
    }
}
