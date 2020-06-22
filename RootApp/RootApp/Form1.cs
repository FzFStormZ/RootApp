using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RootApp
{
    public partial class Form1 : Form
    {
        private HttpClient connection;
        private HttpResponseMessage response;

        private string cookie;

        public Form1()
        {
            InitializeComponent();
            _ = Connection();
        }

        public async Task Connection()
        {
            try
            {
                connection = new HttpClient();
                response = await connection.GetAsync(ConfigurationManager.ConnectionStrings["root-me"].ConnectionString);
                string responseContent = await response.Content.ReadAsStringAsync();

                string[] delimiter = { ", " };

                cookie = responseContent.Replace('}', ' ').Replace(']', ' ').Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[2];
                Console.WriteLine(cookie);

            } catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task Challenges(int num) 
        {
            "https://api.www.root-me.org/challenges/" + num;
        }
    }
}
