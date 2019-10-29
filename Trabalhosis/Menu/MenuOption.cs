using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalhosis
{
    public sealed class MenuOption
    {
        
        public String DisplayText { get; set; }

        public int Number { get; set; }

        public IMenuAction Action { get; set; }

        
    }
}
