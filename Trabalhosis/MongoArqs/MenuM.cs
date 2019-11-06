using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Trabalhosis.Menu;
using Trabalhosis.Data;

namespace Trabalhosis.MongoArqs
{
    public sealed class MenuM
    {
        public List<MenuOption> Options { get; set; }

        public MenuM()
        {
            Options = new List<MenuOption>();

            MenuOption creator = new MenuOption
            {
                Number = 1,
                DisplayText = "Cria o Banco",
                Action = new Faz()

            };

            
            MenuOption Exit = new MenuOption
            {
                Number = 0,
                DisplayText = "Sai do programa",
                Action = new Exit()
            };

            Options.Add(creator);
            
            Options.Add(Exit);
        }

        public void ParseAndDestroy(string input)
        {
            if (int.TryParse(input, out int option))
            {
                var list = Options.Where(x => x.Number == option);
                if (list.Count() > 0)
                {
                    MenuOption op = list.First();
                    op.Action.Run();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------MENU-------------");
            sb.AppendLine();
            foreach (MenuOption item in Options)
            {
                sb.AppendLine(string.Format("Menu {0}  -  {1}  ", item.Number, item.DisplayText));

            }
            sb.AppendLine();
            sb.AppendLine("DIGITE OPCAO DESEJADA");

            return sb.ToString();
        }


    }


}