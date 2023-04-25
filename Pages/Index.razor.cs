using PrintingMauiApp2.Interfaces;
using PrintingMauiApp2.Services;
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
        //public IPrintService printer;
        //public Index(IPrintService _printer)
        //{
        //    printer = _printer;
        //}

        public async void PrintPDF()
        {
#if ANDROID
            IPrintService printer = new PrintService();
            using var stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/printsamples/Diagram_0.pdf");
            printer.Print(stream, "Diagram_111.pdf");
#endif
        }

        public async void PrintPDF2()
        {
#if ANDROID
            //IPrintService printer = DependencyService.Get<IPrintService>();
            IPrintService printer = new PrintService();
            using var spFileContent = await FileSystem.OpenAppPackageFileAsync("wwwroot/printsamples/Diagram_0.pdf");
            MemoryStream stream = new MemoryStream();
            spFileContent.CopyTo(stream);
            printer.PrintHTML("<iframe width='100%' height='100%' src='data:application/pdf;base64," + Convert.ToBase64String(stream.ToArray())+ "></iframe>");
            //printer.PrintURL("https://www.introprogramming.info/wp-content/uploads/2013/07/Books/CSharpEn/Fundamentals-of-Computer-Programming-with-CSharp-Nakov-eBook-v2013.pdf");
#endif
        }

        public async void PrintPDF3()
        {
#if ANDROID
            IPrintService printer = new PrintService();
            using var spFileContent = await FileSystem.OpenAppPackageFileAsync("wwwroot/printsamples/10367338.jpg");
            MemoryStream stream = new MemoryStream();
            spFileContent.CopyTo(stream);
            printer.PrintHTML("<img src='data:image/jpg;base64," + Convert.ToBase64String(stream.ToArray())+"'/>");
#endif
        }
    }
}
