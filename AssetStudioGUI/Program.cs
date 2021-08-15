using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssetStudio;

namespace AssetStudioGUI
{
    static class Program
    {
        public static void Main() {
            var path = @"C:\Users\edo\AppData\LocalLow\DefaultCompany\DerePlayer\Assets\3d_tx_body7043154.unity3d";
            var exportPath = Environment.CurrentDirectory;
            Export(path, exportPath);
        }

        public static void Export(string path, string exportPath) {
            var assetManager = new AssetsManager();
            assetManager.LoadFiles(path);
            foreach (var serializedFile in assetManager.assetsFileList) {
                foreach (var fileObject in serializedFile.Objects)
                    Exporter.ExportTexture2DToPng(new AssetItem(fileObject), exportPath);
            }
            
            assetManager.Clear(); //Dispose
        }
        
//         [STAThread]
//         static void Main()
//         {
// #if !NETFRAMEWORK
//             Application.SetHighDpiMode(HighDpiMode.SystemAware);
// #endif
//             Application.EnableVisualStyles();
//             Application.SetCompatibleTextRenderingDefault(false);
//             Application.Run(new AssetStudioGUIForm());
//         }
    }
}
