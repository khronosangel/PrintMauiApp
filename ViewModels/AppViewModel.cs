using PrintingMauiApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingMauiApp2.ViewModels
{
    public class AppViewModel
    {
        private readonly IPrintService _printService;
        public AppViewModel(IPrintService printService)
        {
            _printService = _printService;
        }
    }
}
