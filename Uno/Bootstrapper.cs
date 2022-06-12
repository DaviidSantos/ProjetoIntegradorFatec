using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Uno.ViewModels;

namespace Uno
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<LoginViewModel>();
        }
    }
}
