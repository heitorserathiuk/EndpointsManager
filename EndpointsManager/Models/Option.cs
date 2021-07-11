using EndpointsManager.Interface;
using System;

namespace EndpointsManager.Models
{
    public class Option
    {
        public int optionId { get; set; }
        public string title { get; set; }
        public MenuListener listener { get; set; }
        public bool exit { get; set; }

        public Option(String title, MenuListener listener)
        {
            this.title = title;
            this.listener = listener;
            this.exit = false;
        }

        public Option(String title, MenuListener listener, bool exit)
        {
            this.title = title;
            this.listener = listener;
            this.exit = exit;
        }

        public void activate()
        {
            if (listener != null)
            {
                listener.selectedMenuOption(optionId);
            }
        }
    }
}
