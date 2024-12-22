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
    public partial class FrmTamlananGorev : Form
    {
        public FrmTamlananGorev()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();
        private void FrmTamlananGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblGorevler
                            select new
                            {
                                x.ID,
                                PersonelAdı = x.TblPersonel.Ad,
                                GorevAlan = x.TblPersonel.Ad,
                                
                                Açıklama = x.Aciklama,
                                x.Tarih,
                                x.Durum
                            }).Where(y => y.Durum == false).ToList();
            gridControl1.DataSource = degerler;
        }
    }
}
