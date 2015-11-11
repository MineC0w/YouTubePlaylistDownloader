using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const string API_KEY = "AIzaSyAWNH7Ny4GFvJ_485ObBWE7RrJ-K9cuTqQ";

        private string examplePlaylist = "https://www.youtube.com/playlist?list=PL1oVHjBfBpwCuKJ0dynZyslyApZPwz9jr";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var playlistId = "PL1oVHjBfBpwCuKJ0dynZyslyApZPwz9jr";

            HttpClient httpClient = new HttpClient();
            string getRequestURL = string.Format("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId={0}&key={1}", playlistId, API_KEY);
            string response = httpClient.GetStringAsync(getRequestURL).ToString();

            System.Diagnostics.Debug.Print(response.ToString());

        }

        private string getPlaylistId(string playlistUrl)
        {
            if (playlistUrl.Contains("?list="))
                return playlistUrl.Split(new string[] { "?list=" }, StringSplitOptions.None)[1];
            else return "Error: Invalid playlist URL.";
        }
    }
}
