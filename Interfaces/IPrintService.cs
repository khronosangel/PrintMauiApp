using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingMauiApp2.Interfaces
{
    public interface IPrintService
    {
        void Print(Stream inputStream, string fileName);
    }
}
