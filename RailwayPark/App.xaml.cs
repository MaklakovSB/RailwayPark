using RailwayPark.ViewModels;
using RailwayPark.Views;
using System.Windows;

namespace RailwayPark
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Точкка входа.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mv = new MainView(new MainViewModel());
            mv.Show();
        }
    }
}
