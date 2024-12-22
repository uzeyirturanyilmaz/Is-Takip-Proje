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
    public partial class FrmFirmaListesi : Form
    {
        public FrmFirmaListesi()
        {
            InitializeComponent();
        }

        DbistakipEntities1 db = new DbistakipEntities1();

        private void FrmFirmaListesi_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblFirmalar
                            select new
                            {
                                x.ID,
                                x.Ad,
                                x.Yetkili,
                                x.Telefon,
                                x.Mail,
                                x.Sifre,
                                x.Sektor,
                                x.il,
                                x.ilce,
                                x.Adres,
                                x.Gorsel
                            }).ToList();
            gridControl1.DataSource = degerler;
        }

        public void Listele()
        {
            var degerler = (from x in db.TblFirmalar
                                select new
                                {
                                    x.ID,
                                    x.Ad,
                                    x.Yetkili,
                                    x.Telefon,
                                    x.Mail,
                                    x.Sifre,
                                    x.Sektor,
                                    x.il,
                                    x.ilce,
                                    x.Adres,
                                    x.Gorsel
            }).ToList();
        gridControl1.DataSource = degerler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "")
            {
                XtraMessageBox.Show("Departman Adı Boş Bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TblFirmalar x = new TblFirmalar();
                
                x.ID = int.Parse(TxtID.Text);
                x.Ad = TxtAd.Text;
                x.Yetkili = TxtYetkili.Text;
                x.Telefon = TxtTelefon.Text;
                x.Mail = TxtMail.Text;
                x.Sifre = TxtSifre.Text;
                x.Sektor = TxtSektor.Text;
                x.il = TxtIl.Text;
                x.ilce = TxtIlce.Text;
                x.Adres = TxtAdres.Text;
                x.Gorsel = TxtGorsel.Text;

                db.TblFirmalar.Add(x);
                db.SaveChanges();
                XtraMessageBox.Show("Firma Başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();
                
            }
            
        }

        

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Null değerleri kontrol ederek boş değer döndürmek için kodunuza null kontrolü ekleyebilirsiniz. 
            //Bunu yapmak için ?.ToString() ifadesi ile birlikte bir null kontrolü kullanabilirsiniz. 
            //Ayrıca ?? "" operatörüyle, null değer yerine boş string döndürebilirsiniz.

            TxtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad")?.ToString() ?? "";
            TxtYetkili.Text = gridView1.GetFocusedRowCellValue("Yetkili")?.ToString() ?? "";
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon")?.ToString() ?? "";
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail")?.ToString() ?? "";
            TxtSifre.Text = gridView1.GetFocusedRowCellValue("Sifre")?.ToString() ?? "";
            TxtSektor.Text = gridView1.GetFocusedRowCellValue("Sektor")?.ToString() ?? "";
            TxtIl.Text = gridView1.GetFocusedRowCellValue("il")?.ToString() ?? "";
            TxtIlce.Text = gridView1.GetFocusedRowCellValue("ilce")?.ToString() ?? "";
            TxtAdres.Text = gridView1.GetFocusedRowCellValue("Adres")?.ToString() ?? "";
            TxtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel")?.ToString() ?? "";

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                XtraMessageBox.Show("Firma ID Boş Bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int x = int.Parse(TxtID.Text);
                var deger = db.TblFirmalar.Find(x);
                db.TblFirmalar.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Firma Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblFirmalar.Find(x);
            deger.Ad = TxtAd.Text;
            deger.Yetkili = TxtYetkili.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Mail = TxtMail.Text;
            deger.Sifre = TxtSifre.Text;
            deger.Sektor = TxtSektor.Text;
            deger.il = TxtIl.Text;
            deger.ilce = TxtIlce.Text;
            deger.Adres = TxtAdres.Text;
            deger.Gorsel = TxtGorsel.Text;

            db.SaveChanges();
            XtraMessageBox.Show("Firma Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
        }
    }
}
