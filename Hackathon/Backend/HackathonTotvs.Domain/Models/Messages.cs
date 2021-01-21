using System;
using System.Collections.Generic;
using System.Text;

namespace HackathonTotvs.Domain.Models
{
    public class Messages
    {
        public Messages(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
