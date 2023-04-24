using PrintingMauiApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrintingMauiApp2.Pages
{
    public partial class Index
    {
        public async void PrintPDF()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/printsamples/Diagram_0.pdf");
            DependencyService.Get<IPrintService>().Print(stream, "Diagram_111.pdf");
        }
    }
}
