using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Mogade.Examples.WindowsPhone
{
   public partial class App
   {
      public App()
      {
         UnhandledException += Application_UnhandledException;
         if (Debugger.IsAttached)
         {
            Current.Host.Settings.EnableFrameRateCounter = true;
         }         
         InitializeComponent();         
         InitializePhoneApplication();
      }
      public PhoneApplicationFrame RootFrame { get; private set; }      
      private void Application_Launching(object sender, LaunchingEventArgs e){}
      private void Application_Activated(object sender, ActivatedEventArgs e){}      
      private void Application_Deactivated(object sender, DeactivatedEventArgs e){}
      private void Application_Closing(object sender, ClosingEventArgs e){}

      
      private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
      {
         if (Debugger.IsAttached)
         {
            Debugger.Break();
         }
         else
         {
            MogadeProvider.GetInstance.LogError("nagivation failed", e.Uri.ToString());
         }
      }
      private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
      {
         if (Debugger.IsAttached)
         {
            Debugger.Break();
         }
         else
         {
            MogadeProvider.GetInstance.LogError("unhandled exception", e.ExceptionObject.Message);
         }
      }
      
      private bool phoneApplicationInitialized;
      private void InitializePhoneApplication()
      {
         if (phoneApplicationInitialized)
         {
            return;
         }
         RootFrame = new PhoneApplicationFrame();
         RootFrame.Navigated += CompleteInitializePhoneApplication;
         RootFrame.NavigationFailed += RootFrame_NavigationFailed;
         phoneApplicationInitialized = true;
      }

      // Do not add any additional code to this method
      private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
      {
         if (RootVisual != RootFrame)
         {
            RootVisual = RootFrame;
         }
         RootFrame.Navigated -= CompleteInitializePhoneApplication;
      }
   }
}