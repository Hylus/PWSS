using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Masowe_wysylanie_maili
{
    public partial class Form1 : Form
    {
        int lwyslanych = 0;
        int lniewyslanych = 0;
        ConsoleKeyInfo cki;

        public Form1()
        {
            InitializeComponent();
            //wlacz SMTP na swoim mailu!
            textBoxSMTP.Text = "smtp.wp.pl";
            textBoxNadawca.Text = "napelniaczskrzynek1@wp.pl";
            textBoxTemat.Text = "No Elo";
            textBoxLogin.Text = "napelniaczskrzynek1@wp.pl";
            //maskedTextBox1.Text = "";
            textBox1.Text = "Siemano kolano";
            textBoxAdres.Text = "TobieToWysle@wp.pl";
        }

        private void WiadomoscWyslana(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled | e.Error != null)
            {
                lniewyslanych++;
                labelNieWyslano.Text = "Nie wysłano: " + lniewyslanych.ToString();
               // MessageBox.Show("Błąd: Wysyłanie anulowane bądź wystąpił błąd serwera");
            }
            
            else
            {
            //       MessageBox.Show("Wiadomość wysłana");
                lwyslanych++;
                labelWyslano.Text = "Wysłano: " + lwyslanych.ToString();
            }
            
        }

        private void Dodaj_click(object sender, EventArgs e)
        {
            if (textBoxAdres.Text != String.Empty)
            {
                if (textBoxAdres.Text.Trim().Length > 0)
                {
                    listBoxAdresy.Items.Add(textBoxAdres.Text);
                    textBoxAdres.Clear();
                }
            }
        }

        private void listBox_DoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxAdresy.SelectedIndex != -1)
            {
                listBoxAdresy.Items.RemoveAt(listBoxAdresy.SelectedIndex);
            }
        }

        private void BUTTONBROWSER_CLICK(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBoxZalaczn.Items.Add(openFileDialog1.FileName);
            }
        }






        //////

        private void WyslijAsynchronicznie(MailMessage wiadomosc)
        {
            try
            {
                SmtpClient klient = new SmtpClient(textBoxSMTP.Text);
                if (textBoxLogin.Text != String.Empty && maskedTextBox1.Text !=
                String.Empty)
                    klient.Credentials = new NetworkCredential(textBoxLogin.Text,
                    maskedTextBox1.Text);
                else
                {
                    MessageBox.Show("Proszę podać nazwę użytkownika i hasło");
                    return;
                }
                klient.SendCompleted += new
                SendCompletedEventHandler(WiadomoscWyslana);
                klient.SendAsync(wiadomosc, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void ButtonWylisj_Click(object sender, EventArgs e)
        {
              //  for (int i = 0; i < 10000; i++)
                {
                    MailAddress Od;
                    MailAddress Do;
                    MailMessage wiadomosc = new MailMessage();
                    try
                    {
                        Od = new MailAddress(textBoxNadawca.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowy adres nadawcy");
                        textBoxNadawca.Clear();
                        return;
                    }
                    wiadomosc.From = Od;
                    if (listBoxZalaczn.Items.Count > 0)
                        foreach (string plik in listBoxZalaczn.Items)
                        {
                            Attachment zalacznik = new Attachment(plik);
                            wiadomosc.Attachments.Add(zalacznik);
                        }
                    try
                    {
                        foreach (string adres in listBoxAdresy.Items)
                        {
                            Do = new MailAddress(adres);
                            wiadomosc.To.Add(Do);
                        }
                        wiadomosc.Subject = textBoxTemat.Text;
                        wiadomosc.Body = textBox1.Text;
                        WyslijAsynchronicznie(wiadomosc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd: " + ex.Message);
                    }

                } 
            

        }

    
        


    };
}
