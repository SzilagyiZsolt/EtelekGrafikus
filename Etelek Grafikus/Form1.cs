using Etel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etelek_Grafikus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await dolgozok();
        }
        private async Task dolgozok()
        {
            Leves[] lev = new Leves[1000];
            string url = $"https://retoolapi.dev/Kc6xuH/data";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                lev = Leves.FromJson(jsonString);
            }
        }

        private async void Create_button_Click(object sender, EventArgs e)
        {
            Leves[] lev = new Leves[1000];
            string url = $"http://localhost/etelek/index.php?etelek/"+textBox1.Text;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                lev = Leves.FromJson(jsonString);
            }
            lev.Append(new Leves { Megnevezes = textBox1.Text, Kaloria = Convert.ToInt32(textBox2.Text), Feherje = textBox3.Text, Zsir = textBox4.Text, Szenhidrat = textBox5.Text, Hamu = textBox6.Text, Rost = textBox7.Text });
        }
    }
}
