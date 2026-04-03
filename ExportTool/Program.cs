using System;
using System.Reflection;
using System.Windows.Forms;

namespace ExportTool
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            PreloadAssemblies();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
        static void PreloadAssemblies()
        {
            try
            {
                var names = new string[] {
                    "DocumentFormat.OpenXml, Version=2.20.0.0, Culture=neutral, PublicKeyToken=8fb06cb64d019a17",
                    "MySqlConnector, Version=2.2.5.0, Culture=neutral, PublicKeyToken=d33d5e945d2b3183",
                    "System.Buffers, Version=4.0.3.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                    "System.Memory, Version=4.0.1.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                    "System.Numerics.Vectors, Version=4.1.4.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Runtime.CompilerServices.Unsafe, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    "System.Threading.Tasks.Extensions, Version=4.2.0.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
                };
                
                foreach (var name in names)
                {
                    try
                    {
                        Assembly.Load(name);
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}
