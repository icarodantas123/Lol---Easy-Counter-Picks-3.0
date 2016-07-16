using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        private PictureBox[] championButtons = new PictureBox[300];

        private int championQtyButtons = 0;

        public Form1()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            WebClient client2 = new WebClient();
            client2.DownloadStringCompleted += new DownloadStringCompletedEventHandler(patrocinador);
            client2.DownloadStringAsync(new Uri("http://arquivosparadownload.mygamesonline.org/patrocinador"));
            client.DownloadStringCompleted += versao_completed;
            client.DownloadStringAsync(new Uri("http://arquivosparadownload.mygamesonline.org/versao.txt"));
            System.IO.StreamReader file = new System.IO.StreamReader("champs.txt");
            string line;
            int x = 12, y = 38;
            while ((line = file.ReadLine()) != null)
            {
                championButtons[championQtyButtons] = new PictureBox();
                championButtons[championQtyButtons].Location = new Point(x, y);
                championButtons[championQtyButtons].TabStop = false;
                championButtons[championQtyButtons].Width = 60;
                championButtons[championQtyButtons].Height = 60;
                championButtons[championQtyButtons].Image = Image.FromFile(@"champs60\" + line + ".png");
                championButtons[championQtyButtons].AccessibleName = line;
                championButtons[championQtyButtons].Cursor = Cursors.Hand;
                championButtons[championQtyButtons].Click += champion_button_click;
                this.Controls.Add(championButtons[championQtyButtons]);
                if(x != 1200)
                {
                    x += 66;
                }
                else
                {
                    x = 12;
                    y += 66;
                }
                championQtyButtons++;
            }
        }

        private void patrocinador(object sender, DownloadStringCompletedEventArgs e)
        {
            pictureBox21.LoadAsync(e.Result);
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(patrocinador_link);
            client.DownloadStringAsync(new Uri("http://arquivosparadownload.mygamesonline.org/patrocinador_link"));
        }

        string patrocinadorUrl;

        private void patrocinador_link(object sender, DownloadStringCompletedEventArgs e)
        {
            patrocinadorUrl = e.Result;
        }

        private void versao_completed(object sender, DownloadStringCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                if (e.Result != "3.0.1")
                {
                    linkLabel1.Text = ">>>> Atualização disponível! " + e.Result;
                }
            }
        }

        private void champion_button_click(object sender, EventArgs e)
        {
            PictureBox but = (PictureBox)sender;
            WebClient cliente = new WebClient();
            cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(string_downloaded);
            cliente.DownloadStringAsync(new Uri("http://www.championcounter.com/" + but.AccessibleName));
            pictureBox1.Image = Image.FromFile(@"champs120\" + but.AccessibleName + ".png");
            button1.AccessibleName = but.AccessibleName;
        }


        private void string_downloaded(object sender, DownloadStringCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                MessageBox.Show("Erro de conexão.", "Erro");
            }
            else
            {
                string htmlCode = e.Result, temp;
                int index = 0;
                index = htmlCode.IndexOf("<head><title>", index) + 13;
                label30.Text = (htmlCode.Substring(index, htmlCode.IndexOf(" Counter", index) - index));

                index = 3000;
                index = htmlCode.IndexOf("text-anchor=\"end\">", index) + 18;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('/', index) - index);
                label31.Width = Convert.ToInt32(temp)*20;
                label31.Text = temp + "/10";

                index += 100;
                index = htmlCode.IndexOf("text-anchor=\"end\">", index) + 18;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('/', index) - index);
                label32.Width = Convert.ToInt32(temp) * 20;
                label32.Text = temp + "/10";
                index += 100;

                index = htmlCode.IndexOf("text-anchor=\"end\">", index) + 18;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('/', index) - index);
                label33.Width = Convert.ToInt32(temp) * 20;
                label33.Text = temp + "/10";
                index += 100;

                index = htmlCode.IndexOf("text-anchor=\"end\">", index) + 18;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('/', index) - index);
                label34.Width = Convert.ToInt32(temp) * 20;
                label34.Text = temp + "/10";
                index += 1200;

                index = htmlCode.IndexOf("text-anchor=\"end\">#", index) + 19;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                label26.Text =  '#' + temp;
                label26.Width = Convert.ToInt32(((championButtons.Length - Convert.ToDouble(temp)) / championButtons.Length) * 200);
                index += 100;

                index = htmlCode.IndexOf("text-anchor=\"end\">", index) + 18;
                label24.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                label24.Width = Convert.ToInt32(htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index))*2;
                index += 5000;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label1.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox3.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox3.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label2.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox4.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox4.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label3.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox5.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox5.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label4.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox6.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox6.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label5.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox7.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox7.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label6.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox8.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox8.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label7.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox9.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox9.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label8.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox10.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox10.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label9.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox11.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox11.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label10.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox12.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox12.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label11.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox13.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox13.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label12.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox14.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox14.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label13.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox15.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox15.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label14.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox16.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox16.AccessibleName = temp;


                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label15.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox17.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox17.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label16.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox18.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox18.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label17.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox19.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox19.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label18.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                pictureBox20.Image = Image.FromFile(@"champs60\" + temp + ".png");
                pictureBox20.AccessibleName = temp;

                panel1.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for(int i=0;i<championQtyButtons;i++)
            {
                championButtons[i].Visible = championButtons[i].AccessibleName.StartsWith(textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void doação(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://pag.ae/bmcgCZ1");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://loleasycounterpicks.blogspot.com.br/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            System.Diagnostics.Process.Start("http://br.op.gg/champion/" + but.AccessibleName + "/statistics/mid");
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(patrocinadorUrl);
        }
    }
}
