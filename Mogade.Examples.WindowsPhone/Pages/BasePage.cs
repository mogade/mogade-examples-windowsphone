using System.Windows;
using Microsoft.Phone.Controls;
using Mogade.WindowsPhone;

namespace Mogade.Examples.WindowsPhone.Pages
{
   /// <summary>
   /// Pages which inherit from BasePage will have access to the Mogade property
   /// which helps a bit to encapsulate some of this uglyness.
   /// </summary>
   // To inherit from BasePage, you change the XAML decleration, say from <phone:PhoneApplicationPage>...</phone:PhoneApplicationPage>
   // to <Pages:BasePage>...</Pages:BasePage>
   public class BasePage : PhoneApplicationPage
   {
      protected IMogadeClient Mogade
      {
         get { return ((App)Application.Current).Mogade; }
      }
   }
}