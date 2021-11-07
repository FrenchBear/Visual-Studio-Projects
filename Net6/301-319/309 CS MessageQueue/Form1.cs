// 309 CS MessageQueue
//
// 2012-02-25   PV  VS2010
// 2021-09-20   PV  VS2022; Net6

using Experimental.System.Messaging;
using System;
using System.Windows.Forms;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE1006 // Naming Styles

namespace FPVI.MessageQueueTest;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        MessageQueue myQueue = new(@"c:\temp");
        myQueue.Send("Hello, world", "message1");
    }

    private void btnReceive_Click(object sender, EventArgs e)
    {
        MessageQueue myQueue = new(@"c:\temp");
        object m;
        m = myQueue.Receive();
    }
}