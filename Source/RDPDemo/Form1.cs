using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxMSTSCLib;
using MSTSCLib;

namespace RDPDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectRDP(axMsTscAxNotSafeForScripting1, tbxIP.Text, tbxDomain.Text, tbxUser.Text, tbxPassword.Text);
        }

        private void ConnectRDP(AxMsTscAxNotSafeForScripting rdp, string ip, string domain, string user, string password)
        {
            if (rdp.Connected == 1)
                rdp.Disconnect();

            rdp.Server = ip;
            rdp.Domain = domain;            
            rdp.UserName = user;
            IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
            secured.ClearTextPassword = password;

            rdp.Connect();
        }
    }
}
