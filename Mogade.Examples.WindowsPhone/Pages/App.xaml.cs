using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Mogade.WindowsPhone;

namespace Mogade.Examples.WindowsPhone
{
   public partial class App
   {
      public IMogadeClient Mogade { get; private set; }

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
      private void Application_Launching(object sender, LaunchingEventArgs e)
      {
         Mogade = MogadeHelper.CreateInstance();
         Mogade.LogApplicationStart();

      }
      private void Application_Activated(object sender, ActivatedEventArgs e)
      {
         Mogade = MogadeHelper.CreateInstance();
         Mogade.LogApplicationStart();
      }
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
            //we normally don't swallow exceptions, but doing so in a global error handler isn't uncommon
            try { Mogade.LogError("nagivation failed", e.Uri.ToString()); }
            catch (Exception) { }
            
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
            //we normally don't swallow exceptions, but doing so in a global error handler isn't uncommon
            try { Mogade.LogError("nagivation failed", e.ExceptionObject.Message); }
            catch (Exception) { }
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