// 309 CS MessageQueue
// 2012-02-25   PV  VS2010

using System;
using System.Messaging;
using System.Windows.Forms;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE1006 // Naming Styles

namespace FPVI.MessageQueueTest
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void btnSend_Click(object sender, EventArgs e)
        {
            var myQueue = new MessageQueue(@"c:\temp");
            myQueue.Send("Hello, world", "message1");
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            var myQueue = new MessageQueue(@"c:\temp");
            object m;
            m = myQueue.Receive();
        }
    }
}