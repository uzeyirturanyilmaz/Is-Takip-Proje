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
    public partial class FrmPasifCagrilar : Form
    {
        public FrmPasifCagrilar()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void FrmPasifCagrilar_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblCagrilar
                            select new
                            {
                                x.ID,
                                FirmaAdı = x.TblFirmalar.Ad,
                                x.TblFirmalar.Telefon,
                                x.Konu,
                                Açıklama = x.Aciklama,
                                Personel = x.TblPersonel.Ad,
                                x.Durum
                            }).Where(y => y.Durum == false).ToList();
            gridControl1.DataSource = degerler;
        }
    }
}
