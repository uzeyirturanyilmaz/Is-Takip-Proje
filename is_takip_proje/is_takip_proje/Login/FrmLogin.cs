using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip_proje.Entitiy;

namespace is_takip_proje.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PersonelGorevFormlar.FrmPersonelForm frm2 = new PersonelGorevFormlar.FrmPersonelForm();
            frm2.Show();
        }


        private void textBox3_Click(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.Control;
            panel2.BackColor = Color.White;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel2.BackColor = SystemColors.Control;
            panel3.BackColor = Color.White;
        }
        DbistakipEntities1 db = new DbistakipEntities1();

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            var adminvalue = db.TblAdmin.Where(x => x.Kullanici == TxtKullanici.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if (adminvalue != null)
            {
                XtraMessageBox.Show("Hoşgeldiniz");
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();

            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş");
            }
        }

        private void BtnPersonelGirisi_Click(object sender, EventArgs e)
        {
            var personel = db.TblPersonel.Where(x => x.Mail == TxtKullanici.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
            if (personel != null)
            {
                PersonelGorevFormlar.FrmPersonelForm fr = new PersonelGorevFormlar.FrmPersonelForm();
                fr.mail = TxtKullanici.Text;
                fr.Show();
                this.Hide();

            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş");
            }
        }

        private void hyperlinkLabelControl4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyperlinkLabelControl3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:60127/");
        }

        Login.FrmSifremiUnuttum frmsifre;
        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            if (frmsifre == null || frmsifre.IsDisposed)
            {
                frmsifre = new Login.FrmSifremiUnuttum();

                frmsifre.Show();
            }
        }


    }
}
