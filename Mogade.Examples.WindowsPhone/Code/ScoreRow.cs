using System.Windows;
using System.Windows.Controls;

namespace Mogade.Examples.WindowsPhone
{
   public class ScoreRow : Grid
   {
      public ScoreRow(Score score)
      {
         var username = new TextBlock { Text = score.UserName, FontSize = 20};
         var points = new TextBlock { Text = score.Points.ToString(), Margin = new Thickness(200, 0, 0, 0), FontSize = 20 };
         var level = new TextBlock { Text = score.Data, Margin = new Thickness(350, 0, 0, 0), FontSize = 20 };
         Children.Add(username);
         Children.Add(points);
         Children.Add(level);
      }
   }
}