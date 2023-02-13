using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TimerStringConverter
    {
        public static string GetStringFromSeconds(int seconds)
        {
            int viewMinutes = (int)(Math.Floor(seconds / 60f));
            int viewSeconds = seconds - (viewMinutes * 60);

            return viewMinutes.ToString() + " : " + viewSeconds.ToString();
        }
    }
}
