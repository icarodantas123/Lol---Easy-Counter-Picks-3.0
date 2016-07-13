using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        private Button[] championButtons = new Button[300];

        private int championQtyButtons = 0;

        public Form1()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            client.DownloadStringCompleted += versao_completed;
            client.DownloadStringAsync(new Uri("http://arquivosparadownload.mygamesonline.org/versao.txt"));
            System.IO.StreamReader file = new System.IO.StreamReader("champs.txt");
            string line;
            int x = 12, y = 38;
            while ((line = file.ReadLine()) != null)
            {
                championButtons[championQtyButtons] = new Button();
                championButtons[championQtyButtons].Location = new Point(x, y);
                championButtons[championQtyButtons].Width = 60;
                championButtons[championQtyButtons].Height = 60;
                championButtons[championQtyButtons].Image = Image.FromFile(@"champs60\" + line + ".png");
                championButtons[championQtyButtons].AccessibleName = line;
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
            Button but = (Button)sender;
            WebClient cliente = new WebClient();
            cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(string_downloaded);
            cliente.DownloadStringAsync(new Uri("http://www.championcounter.com/" + but.AccessibleName));
            pictureBox1.Image = Image.FromFile(@"champs120\" + but.AccessibleName + ".png");
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
                button1.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button1.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label2.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button2.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button2.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label3.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button3.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button3.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label4.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button4.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button4.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label5.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button5.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button5.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label6.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button6.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button6.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label7.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button7.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button7.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label8.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button8.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button8.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label9.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button9.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button9.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label10.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button10.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button10.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label11.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button11.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button11.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label12.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button12.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button12.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label13.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button13.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button13.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label14.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button14.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button14.AccessibleName = temp;


                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label15.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button15.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button15.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label16.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button16.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button16.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label17.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button17.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button17.AccessibleName = temp;

                index = htmlCode.IndexOf("class=\"entity\"><h4>", index) + 19;
                label18.Text = htmlCode.Substring(index, htmlCode.IndexOf('<', index) - index);
                index = htmlCode.IndexOf("images/champions/", index) + 17;
                temp = htmlCode.Substring(index, htmlCode.IndexOf('.', index) - index);
                button18.Image = Image.FromFile(@"champs60\" + temp + ".png");
                button18.AccessibleName = temp;

                panel1.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for(int i=0;i<championQtyButtons;i++)
            {
                championButtons[i].Enabled = championButtons[i].AccessibleName.StartsWith(textBox1.Text);
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
    }
}
