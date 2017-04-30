// 309 CS MessageQueue
// 2012-02-25   PV  VS2010

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Messaging;

namespace FPVI.MessageQueueTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MessageQueue myQueue = new MessageQueue(@"c:\temp");
            myQueue.Send("Hello, world", "message1");
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            MessageQueue myQueue = new MessageQueue(@"c:\temp");
            object m;
            m = myQueue.Receive();

        }

    }
}
