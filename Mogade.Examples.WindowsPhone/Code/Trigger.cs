using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Mogade.Examples.WindowsPhone
{
   public class Trigger : Button
   {
      private readonly static Color _goodColor = Colors.Green;
      private readonly DispatcherTimer _timer;
      private readonly GamePage _board;
      private DateTime? _goodAsOf;

      public Trigger(GamePage board, Random random)
      {
         _board = board;
         _timer = new DispatcherTimer
                  {
                     Interval = TimeSpan.FromMilliseconds(random.Next(2000, 4000))
                  };
         _timer.Tick += Tick;
         _timer.Start();
      }

      protected override void OnClick()
      {
        if (_goodAsOf != null)
        {
           _timer.Stop();
        }
         _board.Triggered(_goodAsOf == null ? (TimeSpan?)null : DateTime.Now - _goodAsOf.Value, this);
         base.OnClick();
      }
      private void Tick(object sender, EventArgs e)
      {
         //2 second timer has elasped, the user loses!
         if (_goodAsOf != null)
         {
            _board.ButtonTimedOut(this);
            _timer.Stop();
         }
         _goodAsOf = DateTime.Now;
         Background = new SolidColorBrush(_goodColor);
         _timer.Interval = TimeSpan.FromSeconds(2);
      }
   }
}