using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sentButton_Click(object sender, EventArgs e)
        {
            result.Text = "Отправка...";

            UdpClient _sender = new UdpClient();
            Message message = new Message(userTextBox.Text, cityTextBox.Text, stationTextBox.Text);
            result.Text = message.ToString();
            byte[] data = message.GetBytes();

            try
            {
                _sender.Send(data, data.Length, ipText.Text, Int32.Parse(destPortText.Text));
            }
            catch(Exception ex)
            {
                result.Text = ex.Message;
            }
            finally
            {
                _sender.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
