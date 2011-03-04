using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Mogade.Leaderboards;

namespace Mogade.Examples.WindowsPhone.Pages
{
   public partial class GameOver
   {
      private int _level;
      private int _score;

      public GameOver()
      {
         InitializeComponent();
      }

      protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
      {
         _level = Convert.ToInt32(NavigationContext.QueryString["level"]);
         _score = Convert.ToInt32(NavigationContext.QueryString["score"]);
         PageTitle.Text = _level == 10 ? "You Win!" : "Game Over";
         base.OnNavigatedTo(e);
      }

      private void UserName_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
      {
         if (UserName.Text == "Your Name")
         {
            UserName.Text = string.Empty;
         }
      }

      private void Submit_Click(object sender, RoutedEventArgs e)
      {
         if (string.IsNullOrEmpty(UserName.Text))
         {
            return;
         }
         Submit.IsEnabled = false;
         Submit.Content = "Sending...";

         //we can store a bit of arbitrary data in the Data field which we can then use in our leaderboard
         //you can always not set the Data if you have no extra information you want to store with the score
         var score = new Score {Data = _level.ToString(), Points = _score, UserName = UserName.Text};
         Mogade.SaveScore(MogadeHelper.LeaderboardId(Leaderboards.Main), score, ScoreResponseHandler);
      }

      private void ScoreResponseHandler(Response<Ranks> r)
      {
         if (!r.Success)
         {
            //todo handle error
         }
         else
         {
            var text = string.Format("Daily Rank: {0}\rOverall Rank: {1}", r.Data.Daily, r.Data.Overall);
            if (r.Data.TopScore)
            {
               text = "Wow, that was a personal best!\r" + text;
            }
            
            //we are in a separate thread, we can't just update controls from the main thread.
            Dispatcher.BeginInvoke(() =>
            {
               Submit.Visibility = Visibility.Collapsed;
               var block = new TextBlock {Text = text, TextAlignment = TextAlignment.Center, VerticalAlignment = VerticalAlignment.Center, FontSize = 20, Foreground = new SolidColorBrush(Colors.White)};
               ContentPanel.Children.Add(block);
            });
         }
      }

      private void Home_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
      }
   }
}