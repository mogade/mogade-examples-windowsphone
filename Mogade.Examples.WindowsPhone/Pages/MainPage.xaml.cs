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
         NavigationService.Navigate(new Uri("/Pages/GamePage.xaml", UriKind.Relative));
      }
   }
}