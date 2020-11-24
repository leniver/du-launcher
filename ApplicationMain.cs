using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DU_Launcher
{
    class ApplicationMain
    {

        [STAThread]
        static void Main()
        {
            Application.Run(new Launcher());
        }

    }
}
