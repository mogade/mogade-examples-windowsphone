using System;
using System.Windows;
using System.Windows.Media;

namespace Mogade.Examples.WindowsPhone
{
   public partial class GamePage
   {
      private readonly static Color[] _evilColors = new[]{Colors.Magenta,Colors.White, Colors.Blue, Colors.LightGray, Colors.Cyan, Colors.Brown, Colors.Purple, Colors.Yellow };
      private static readonly Color _timedOutColor = Colors.Red;
      private static readonly VerticalAlignment[] _verticalPositions = new[] { VerticalAlignment.Center, VerticalAlignment.Top, VerticalAlignment.Bottom };
      private static readonly HorizontalAlignment[] _horizontalPositions = new[] { HorizontalAlignment.Center, HorizontalAlignment.Left, HorizontalAlignment.Right };

      private int _level;
      private int _score;
      private Random _random;
      public GamePage()
      {
         InitializeComponent();
      }

      protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
      {
         _random = new Random();
         StartLevel(1);
         SetScore(0);
         base.OnNavigatedTo(e);
      }

      private void SetScore(int score)
      {
         _score = score;
         Score.Text = "Score " + score;
      }
      private void StartLevel(int level)
      {
         _level = level;
         Level.Text = "Level " + level;

         Board.Children.Clear();

         for (var i = 0; i < level; ++i)
         {
            var button = new Trigger(this, _random)
                         {
                            Margin = new Thickness(5), 
                            Width = 100, Height = 100, 
                            VerticalAlignment = _verticalPositions[(int) Math.Floor(i / 3)],
                            HorizontalAlignment = _horizontalPositions[i % 3],
                            Background = new SolidColorBrush(_evilColors[_random.Next(_evilColors.Length)])
                         };
            Board.Children.Add(button);
         }
      }

      public void ButtonTimedOut(Trigger trigger)
      {
         GotoEndGame();
      }

      private void GotoEndGame()
      {
         NavigationService.Navigate(new Uri(string.Format("/Pages/GameOver.xaml?score={0}&level={1}", _score, _level), UriKind.Relative));
      }

      public void Triggered(TimeSpan? timeSpan, Trigger trigger)
      {
         if (timeSpan == null)
         {
            SetScore(_score - 100);
            return;
         }

         SetScore(_score + (int)(3000 - timeSpan.Value.TotalMilliseconds));
         Board.Children.Remove(trigger);
         if (Board.Children.Count != 0)
         {
            return;
         }

         if (_level == 9)
         {
            _level = 10;
            GotoEndGame();
         }
         StartLevel(_level + 1);
      }
   }
}