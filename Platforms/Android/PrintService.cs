using Android.Content;
using Android.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintingMauiApp2.Platforms.Droid;
using Android.Webkit;
using WebView = Android.Webkit.WebView;
using PrintingMauiApp2.Interfaces;

//[assembly: Dependency(typeof(PrintService))]
//namespace PrintingMauiApp2.Platforms.Droid
namespace PrintingMauiApp2.Services
{
    public class PrintService : IPrintService
    {
        public void Print(Stream inputStream, string fileName)
        {
            if (inputStream.CanSeek)
                //Reset the position of PDF document stream to be printed
                inputStream.Position = 0;
            //Create a new file in the Personal folder with the given name
            string createdFilePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            //Save the stream to the created file
            using (var dest = System.IO.File.OpenWrite(createdFilePath))
                inputStream.CopyTo(dest);
            string filePath = createdFilePath;
            var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
            PrintManager printManager = (PrintManager)activity.GetSystemService(Context.PrintService);
            PrintDocumentAdapter pda = new CustomPrintDocumentAdapter(filePath);
            //Print with null PrintAttributes
            printManager.Print(fileName, pda, null);
        }

        public void PrintHTML(string HTML)
        {
            AndroidPrintClient client = new AndroidPrintClient();
            WebView web = new WebView(Platform.CurrentActivity.ApplicationContext);
            web.Settings.UserAgentString = "Mozilla/5.0 (Android 4.4; Mobile; rv:41.0) Gecko/41.0 Firefox/41.0";
            web.Settings.JavaScriptEnabled = true;
            web.SetWebChromeClient(new WebChromeClient());
            web.SetWebViewClient(client);

            web.LoadDataWithBaseURL("", HTML, "text/html", "utf-8", "");
        }

        public void PrintURL(string TargetURL)
        {
            AndroidPrintClient client = new AndroidPrintClient();
            WebView web = new WebView(Platform.CurrentActivity.ApplicationContext);
            web.Settings.UserAgentString = "Mozilla/5.0 (Android 4.4; Mobile; rv:41.0) Gecko/41.0 Firefox/41.0";
            web.Settings.JavaScriptEnabled = true;
            web.SetWebChromeClient(new WebChromeClient());
            web.SetWebViewClient(client);
            web.LoadUrl(TargetURL);
        }

        private class AndroidPrintClient : WebViewClient
        {
            PrintManager printMgr = (PrintManager)Platform.CurrentActivity.GetSystemService(Context.PrintService);

            public override async void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);

                printMgr.Print("Print", view.CreatePrintDocumentAdapter(), null);
            }
        }
    }
}
