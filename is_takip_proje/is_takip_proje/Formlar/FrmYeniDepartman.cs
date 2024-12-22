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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }
        DbistakipEntities1 db = new DbistakipEntities1();

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad = TxtGorevVeren.Text;

            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman Başarıyla Tanımlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Listele();
        }
        Formlar.FrmDepartmanlar frmdepartmans;
        void Listele()
        {
            if (frmdepartmans == null || frmdepartmans.IsDisposed)
            {
                frmdepartmans = new Formlar.FrmDepartmanlar();
            }

            var degerler = (from x in db.TblDepartmanlar
                            select new
                            {
                                x.ID,
                                x.Ad
                            }).ToList();
            frmdepartmans.gridControl1.DataSource = degerler;

        }

    }
}
