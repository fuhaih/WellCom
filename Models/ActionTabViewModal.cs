using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellCom.Models
{
    public class ActionTabViewModal
    {
        // These Are the tabs that will be bound to the TabControl 
        public ObservableCollection<ActionTabItem> Tabs { get; set; }
    }
}
