using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLibrary
{
    public class IOManager
    {
        public static void WriteFile(string message, string filename)
        {
            string fname = AppDomain.CurrentDomain.BaseDirectory + filename;
            FileStream fs = File.Exists(fname) ?
                                fs = File.Open(fname, FileMode.Append) :
                                fs = File.Create(fname);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLineAsync(message);

            sw.Close();
            fs.Close();
        }
    }
}
