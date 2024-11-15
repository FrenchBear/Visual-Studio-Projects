﻿using System.Windows;
using System.Windows.Controls;

namespace CS500;

public partial class UC2: UserControl, INavigationContextProvider<UC2, NavigationResult>
{
    public UC2()
    {
        InitializeComponent();
        context = NavigationContext<NavigationResult>.Create(this);
    }

    private readonly INavigationContext<UC2, NavigationResult> context;

    public INavigationContext<UC2, NavigationResult> GetNavigationContext() => context;

    private void Button_Click(object sender, RoutedEventArgs e) => context.Continuer(NavigationResult.GoBackward);
}