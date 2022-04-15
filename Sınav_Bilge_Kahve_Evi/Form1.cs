using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sınav_Bilge_Kahve_Evi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] kahveler = { "Misto", "Americano", "Bianco", "Cappucino", "Macchiato", "Con Panna", "Mocha" };
        decimal[] kahveFiyatlari = {1, 4.5m, 5.75m, 6, 7.5m, 6.75m, 8, 7.75m };

        string[] sogukIcecekler = { "Kola", "Fanta", "Sprite", "Ice Tea" };
        decimal sogukIcecekFiyat = 5.5m;

        string[] sicakIcecekler = { "Çay", "Hot Chocolate", "Chai Tea Latte" };
        decimal[] sicakIcecekFiyatlari = {1, 3, 4.5m, 6.5m };

        decimal shotfiyati = 0.75m;
        decimal sutFiyati = 0.5m;

        List<string> siparislerim = new List<string>();

        decimal toplamSiparisTutari = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            cbKahveler.Items.Add("Kahve Seçiniz...");
            cbKahveler.SelectedIndex = 0;
            foreach (string item in kahveler)
                cbKahveler.Items.Add(item);

            cbSicakIcecekler.Items.Add("Sıcak Içecek Seçiniz...");
            cbSicakIcecekler.SelectedIndex = 0;
            foreach (string item in sicakIcecekler)
                cbSicakIcecekler.Items.Add(item);

            cbSogukIcecekler.Items.Add("Soğuk Icecek Seçiniz...");
            cbSogukIcecekler.SelectedIndex = 0;
            foreach (string item in sogukIcecekler)
                cbSogukIcecekler.Items.Add(item);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            bool listBoxaEkliyimmi = true;
            decimal fiyat = 0;
            string listItem = "";

            if ((cbKahveler.SelectedIndex > 0 && nudKahveAdet.Value != 0) || (cbSicakIcecekler.SelectedIndex > 0 && nudSicakIcecekAdet.Value != 0) ||(cbSogukIcecekler.SelectedIndex > 0 && nudSogukIceceklerAdet.Value != 0))
            {
                if (cbKahveler.SelectedIndex>0)
                {
                    if (nudKahveAdet.Value != 0)
                    {
                        listItem += $"{cbKahveler.SelectedItem} {nudKahveAdet.Value} Adet, ";
                        fiyat += kahveFiyatlari[cbKahveler.SelectedIndex] * nudKahveAdet.Value;

                        if (rbTall.Checked)
                        {
                            fiyat = fiyat * 1;
                            listItem += "Tall, ";
                        }

                        if (rbGrande.Checked)
                        {
                            fiyat = fiyat * 1.25m;
                            listItem += "Grande, ";
                        }

                        if (rbVerti.Checked)
                        {
                            fiyat = fiyat * 1.75m;
                            listItem += "Venti, ";
                        }

                        if (chk1x.Checked)
                        {
                            fiyat += shotfiyati;
                            listItem += "1x Shot, ";
                        }

                        if (chk2x.Checked)
                        {
                            fiyat += shotfiyati * 2;
                            listItem += "2x Shot, ";
                        }

                        if (rbYagsiz.Checked)
                        {
                            fiyat += sutFiyati;
                            listItem += "Yağsız, ";
                        }
                        if (rbSoya.Checked)
                        {
                            fiyat += sutFiyati;
                            listItem += "Soya, ";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kahve Adedini Giriniz.");
                        listBoxaEkliyimmi = false;
                    }
                        
                }

                if (cbSogukIcecekler.SelectedIndex>0)
                    if (nudSogukIceceklerAdet.Value != 0)
                    {
                        fiyat += sogukIcecekFiyat * nudSogukIceceklerAdet.Value;
                        listItem += $"{cbSogukIcecekler.SelectedItem} {nudSogukIceceklerAdet.Value} Adet, ";
                    }
                    else
                    {
                        MessageBox.Show("Soğuk İçecek Adedini Giriniz...");
                        listBoxaEkliyimmi = false;
                    }



                if (cbSicakIcecekler.SelectedIndex > 0)
                    if (nudSicakIcecekAdet.Value != 0)
                    {
                        fiyat += sicakIcecekFiyatlari[cbSicakIcecekler.SelectedIndex] * nudSicakIcecekAdet.Value;
                        listItem += $"{cbSicakIcecekler.SelectedItem} {nudSicakIcecekAdet.Value} Adet, ";
                    }
                    else
                    {
                        MessageBox.Show("Sıcak İçecek Adedini Giriniz.");
                        listBoxaEkliyimmi = false;
                    }

                if (listBoxaEkliyimmi)
                {
                    listItem += $": {fiyat} TL";
                    lstVerilenSiparisler.Items.Add(listItem);

                    toplamSiparisTutari += fiyat;
                    lblToplamSiparis.Text = $"Toplam Sipariş Tutarı : {toplamSiparisTutari} TL";

                    siparislerim.Add(listItem);
                }                
            }
            else
                MessageBox.Show("Lütfen herhangi bir içecek ve adedini seçiniz.");
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Merhaba {txtAdSoyad.Text}.\n Toplam {siparislerim.Count} adet siparişiniz ve {toplamSiparisTutari} TL tutarındadır.");
        }
    }
}
