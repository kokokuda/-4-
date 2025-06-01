using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
    // Класс, управляющий списком команд оплаты и их последовательным выполнением.
    public class PaymentCommandInvoker
    {
        // Список команд оплаты
        private readonly List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command) 
        {
            commands.Add(command); // Добавляет команду оплаты в список.
        }


        public void ClearCommands()
        {
            commands.Clear();
        }

        public int CommandsCount => commands.Count;
    }
}
