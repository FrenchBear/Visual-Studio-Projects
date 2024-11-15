﻿// 2001 PV
//
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Windows.Forms;

#pragma warning disable CA1822 // Mark members as static

namespace Hello1;

public class Hello1: Form
{
    internal void InitializeComponent()
    {
    }

    /// Point d'entrée du programme
    public static int Main(string[] args)
    {
        Application.Run(new Hello1());
        return 0;
    }

    /// Constructeur de la fenêtre
    public Hello1() =>
        //    InitializeComponent();
        Text = "Hello 1";
}
