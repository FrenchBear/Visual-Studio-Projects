// Classe MsgBox3
// Classe WinForm dérivée
//
// 2001-01-27   PV
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable CA1050 // Declare types in namespaces

public sealed class MsgBox3: MsgBox2
{
    private System.ComponentModel.IContainer components;

    public MsgBox3() => InitializeComponent();

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        BackColor = System.Drawing.Color.Bisque;
    }

    public override void Info(string sMsg) => base.Info("Info MsgBox3:\r\n" + sMsg);
}
