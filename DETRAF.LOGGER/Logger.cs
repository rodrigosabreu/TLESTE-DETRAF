using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DETRAF.LOGGER
{
    public class Logger
    {
        
            public void Gravar(string caminho, string msg)
            {
                StreamWriter sw = new StreamWriter(@caminho, true);
                string log = String.Format("Data: {0} Erro: {1}", DateTime.Now.ToString(), msg);
                sw.WriteLine(log);
                sw.Close();
            }

            public void GravarCSV(string caminho, string msg)
            {
                StreamWriter sw = new StreamWriter(@caminho, true);
                string log = String.Format(msg);
                sw.WriteLine(log);
                sw.Close();
            }
        
    }
}
