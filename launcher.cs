using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace MTALauncher
{
    public partial class launcher : Form
    {
        public String html;
        public Uri url;
        public launcher()
        {
            InitializeComponent();
        }

        private DiscordRPC.EventHandlers handlers;
        private DiscordRPC.RichPresence presence;
        public void RPC(string players="0/0")
        {
            this.handlers = default(DiscordRPC.EventHandlers);
            DiscordRPC.Initialize("1073614047188111410", ref this.handlers, true, null);
            this.presence.details = "Players";
            this.presence.state = players;
            this.presence.largeImageKey = "dcinfinity";
            this.presence.largeImageText = "image text";
            this.presence.startTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            DiscordRPC.UpdatePresence(ref this.presence);
        }
        private void launcher_Load(object sender, EventArgs e)
        {
            RPC();
            label1.Text = "";
            webBrowser1.Navigate("https://www.game-state.com/193.223.107.134:22003/");
            webBrowser2.Navigate("http://codeinfinity.tech/api/get.php?server_id=1");
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            veri_elements();
            veri_web();
            this.ActiveControl = null;
        }                                                               
        /*public void veriAl_agility(string Url,String XPath,ListBox sonuc)
        {
            try
            {
                url = new Uri(Url);

            }
            catch(UriFormatException)
            {
                label2.Text = "Hata";
            }
            WebClient client = new WebClient();
            client.Encoding= Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);

            }
            catch(WebException)
            {
                label2.Text = "Hata";
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                sonuc.Items.Add(doc.DocumentNode.SelectSingleNode(XPath).InnerText);
            }
            catch(NullReferenceException)
            {
                label2.Text = "Hata Xpath";
            }
        }*/
        public void veri_elements()
        {
            HtmlElementCollection htmlElementCollection = webBrowser1.Document.All;
            foreach(HtmlElement name in htmlElementCollection) {
                if (name.GetAttribute("classname") == "value" && name.GetAttribute("Id") == "players")
                {
                    label1.Text = name.InnerText;
                    this.presence.state = "Oyuncu: " + name.InnerText;
                    DiscordRPC.UpdatePresence(ref this.presence);
                }
                if (name.GetAttribute("classname") == "value" && name.GetAttribute("Id") == "state")
                {
                    if (name.InnerText == "Online")
                    {
                        pictureBox4.Visible = false;
                        pictureBox3.Visible = true;
                    }
                    else if (name.InnerText == "Offline")
                    {
                        pictureBox3.Visible = false;
                        pictureBox4.Visible = true;
                    }
                }
            }
        }

        public void veri_web()
        {
            HtmlElementCollection htmlElementCollection = webBrowser2.Document.All;
            foreach (HtmlElement name in htmlElementCollection)
            {
                if (name.GetAttribute("classname") == "server_announcments")
                {
                    label4.Text= "1-"+name.InnerText;
                    var satirlar = Enter(label4.Text, 39);
                    label4.Text = satirlar;
                }
                if (name.GetAttribute("classname") == "server_discord")
                {
                    string server_discord = name.InnerText;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.presence.details= textBox1.Text;
            DiscordRPC.UpdatePresence(ref this.presence);
        }

        string Enter(string value, int lineLimit)
        {
            var result = "";
            for (var i = 0; i < value.Length; i++)
            {
                result += value[i];
                if (i % lineLimit == 0 && i != 0)
                    result += Environment.NewLine;
            }
            return result;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HtmlElementCollection htmlElementCollection = webBrowser2.Document.All;
            foreach (HtmlElement name in htmlElementCollection)
            {
                if (name.GetAttribute("classname") == "server_discord")
                {
                    System.Diagnostics.Process.Start(name.InnerText);
                }
            }
        }

        int i = 426;
        bool izin = false;
        bool variable = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox6.Visible == true && i < 745 && izin==false)
            { //745
                pictureBox6.Location = new Point(i,-99);
                i++;
                if (i == 744)
                {
                    i = 745;
                    pictureBox6.Visible = false;
                    pictureBox7.Location = new Point(i,-78);
                    pictureBox7.Visible = true;
                    System.Threading.Thread.Sleep(200);
                }
            }
            if(pictureBox7.Visible == true && i > 426) {
                if (izin == false)
                {
                    pictureBox7.Location = new Point(i,-78);
                    i--;
                    if (i == 427)
                    {
                        i = 427;
                        izin = true;
                        System.Threading.Thread.Sleep(4000);
                    }
                }
                if (izin == true && i<745)
                {
                    pictureBox7.Location = new Point(i,-78);
                    i++;
                    if (i == 744)
                    {
                        i = 745;
                        pictureBox7.Visible = false;
                        pictureBox8.Location = new Point(i,-9);
                        pictureBox8.Visible = true;
                        izin = false;
                        System.Threading.Thread.Sleep(200);
                    }
                }

            }

            if (pictureBox8.Visible == true && i > 426)
            {
                if (izin == false)
                {
                    pictureBox8.Location = new Point(i, -9);
                    i--;
                    if (i == 427)
                    {
                        i = 427;
                        izin = true;
                        System.Threading.Thread.Sleep(4000);
                    }
                }
                if (izin == true && i < 745)
                {
                    pictureBox8.Location = new Point(i, -9);
                    i++;
                    if (i == 744)
                    {
                        i = 745;
                        pictureBox8.Visible = false;
                        pictureBox9.Location = new Point(i,-24);
                        pictureBox9.Visible = true;
                        izin = false;
                        System.Threading.Thread.Sleep(200);
                    }
                }

            }

            if (pictureBox9.Visible == true && i > 426)
            {
                if (izin == false)
                {
                    pictureBox9.Location = new Point(i, -24);
                    i--;
                    if (i == 427)
                    {
                        i = 427;
                        izin = true;
                        System.Threading.Thread.Sleep(4000);
                    }
                }
                if (izin == true && i < 745)
                {
                    pictureBox9.Location = new Point(i, -24);
                    i++;
                    if (i == 744)
                    {
                        i = 745;
                        pictureBox9.Visible = false;
                        pictureBox6.Location = new Point(i, -99);
                        pictureBox6.Visible = true;
                        izin = true;
                        System.Threading.Thread.Sleep(200);
                    }
                }

            }

            if (pictureBox6.Visible == true && i > 426 && izin == true)
            {
                    pictureBox6.Location = new Point(i, -99);
                    i--;
                    if (i == 427)
                    {
                        i = 426;
                        izin = false;
                        System.Threading.Thread.Sleep(4000);
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElementCollection htmlElementCollection = webBrowser2.Document.All;
            foreach (HtmlElement name in htmlElementCollection)
            {
                if (name.GetAttribute("classname") == "server_ip")
                {
                    System.Diagnostics.Process.Start("mtasa://"+name.InnerText);
                }
            }
        }
    }
}
