using PrintingMauiApp2.Interfaces;

namespace PrintingMauiApp2.Platforms
{
    public class PrintService : IPrintService
    {
        public void Print(Stream inputStream, string fileName)
        {
            throw new NotImplementedException();
        }

        public void PrintHTML(string HTML)
        {
            throw new NotImplementedException();
        }

        public void PrintURL(string TargetURL)
        {
            throw new NotImplementedException();
        }
    }
}
