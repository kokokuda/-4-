using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Views
{
    public interface IBuyerSettingsView
    {
        decimal CashAmount { get; }
        decimal CardAmount { get; }
        decimal BonusAmount { get; }


        event EventHandler ApplyClicked;

        void CloseForm();
    }

}
