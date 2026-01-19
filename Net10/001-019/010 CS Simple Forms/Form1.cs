// 010 CS Simple Forms
// Essais élémentaires du designer en C#
// PV janvier 2001
//
// 2006-10-01	PV		V2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Windows.Forms;

#pragma warning disable IDE0052 // Remove unread private members

namespace CS010;

public class Form1: Form
{
    private System.ComponentModel.Container components;

    public Form1() => InitializeComponent();

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        Text = "010 CS Simple Forms";
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    }

    public static void Main(string[] args) => Application.Run(new Form1());
}
