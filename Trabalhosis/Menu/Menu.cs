﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Trabalhosis.Menu;
using Trabalhosis.Data;

namespace Trabalhosis
{
    public sealed class Menus
    {
        public List<MenuOption> Options { get; set; }

        public Menus()
        {
            Options = new List<MenuOption>();

            MenuOption creator = new MenuOption
            {
                Number = 1,
                DisplayText = "Cria o Banco",
                Action = new Faz()

            };

            MenuOption des = new MenuOption
            {
                Number = 2,
                DisplayText = "Destroy o Banco",
                Action = new Destroy()
            };

            MenuOption menuOption = new MenuOption
            {
                Number = 3,
                DisplayText = "Digite um Numero e a quantidade de registros requeridos em ordem",
                Action = new FindId()
            };

            MenuOption ler = new MenuOption
            {
                Number = 4,
                DisplayText = "Le o arquivo",
                Action = new Print()
            };
            MenuOption derp = new MenuOption
            {
                Number = 5,
                DisplayText = "Faz certo",
                Action = new FazCerto()

            };
            MenuOption arvre = new MenuOption
            {
                Number = 6,
                DisplayText = "Arvore",
                Action = new ArvoreMenu()
            };
            MenuOption Babon = new MenuOption
            {
                Number = 7,
                DisplayText = "Hash yeah",
                Action = new CheeseBacon()
            };
            MenuOption These = new MenuOption
            {
                Number = 8,
                DisplayText = "Mostra a resposta da tese: se usa mais Brexit ou brexit",
                Action = new Thesis()
            };
            MenuOption Exit = new MenuOption
            {
                Number = 0,
                DisplayText = "Sai do programa",
                Action = new Exit()
            };

            Options.Add(creator);
            Options.Add(des);
            Options.Add(menuOption);
            Options.Add(ler);
            Options.Add(derp);
            Options.Add(arvre);
            Options.Add(Babon);
            Options.Add(These);
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