using System;
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
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           x.Aciklama
                                       }).ToList();

            var a= db.TblGorevler.Where(x => x.Durum == true).Count();
            var b= db.TblGorevler.Where(x => x.Durum == false).Count();

            LblAktifisSayisi.Text = a.ToString();
            LblPasifisSayisi.Text = b.ToString();
            LblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();


            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler", a);
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", b);

          }
    }
}
