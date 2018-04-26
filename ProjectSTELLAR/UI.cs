using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ProjectStellar
{
    class UI
    {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

        public UI()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
        }

        public void Draw(RenderWindow window, Font font, DateTime time)
        {
            DrawTime(window, font, time);
        }

        static void DrawTime(RenderWindow window, Font font, DateTime time)
        {
            Text Time = new Text(time.ToString(), font);
            Time.Draw(window, RenderStates.Default);
        }
    }
}
