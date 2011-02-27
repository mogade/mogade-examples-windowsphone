using System;
using System.Windows;

namespace Mogade.Examples.WindowsPhone
{
   public partial class MainPage
   {
      // Constructor
      public MainPage()
      {
         InitializeComponent();
      }

      private void PlayButton_Click(object sender, RoutedEventArgs e)
      {
         //NavigationService.Navigate(new Uri("/Pages/GamePage.xaml", UriKind.Relative));
         NavigationService.Navigate(new Uri("/Pages/GameOver.xaml?score=1000&level=10", UriKind.Relative));
      }
   }
}