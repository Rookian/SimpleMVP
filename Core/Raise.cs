using System;

namespace Core
{
    public class Raise
    {
        public static void Event(EventHandler eventHandler, object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }
    }
}