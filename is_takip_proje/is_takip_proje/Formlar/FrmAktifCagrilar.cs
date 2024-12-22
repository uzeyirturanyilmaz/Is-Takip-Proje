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
    public partial class FrmAktifCagrilar : Form
    {
        public FrmAktifCagrilar()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void FrmAktifCagrilar_Load(object sender, EventArgs e)
        {
            

            var degerler = (from x in db.TblCagrilar
                            select new
                            {
                                x.ID,
                                FirmaAdı = x.TblFirmalar.Ad,
                                x.TblFirmalar.Telefon,
                                x.Konu,
                                Açıklama = x.Aciklama,
                                Personel= x.TblPersonel.Ad,
                                x.Durum
                            }).Where(y => y.Durum == true).ToList();
            gridControl1.DataSource = degerler;


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmCagriAtama fr = new FrmCagriAtama();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
