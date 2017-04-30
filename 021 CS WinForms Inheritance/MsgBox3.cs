// Classe MsgBox3
// Classe WinForm dérivée
// 2001-01-27   PV


using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



public sealed class MsgBox3 : MsgBox2
{
    private System.ComponentModel.IContainer components;

    public MsgBox3()
    {
        InitializeComponent();

    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.Color.Bisque;
    }


    public override void Info(string sMsg)
    {
        base.Info("Info MsgBox3:\r\n" + sMsg);
    }
}

