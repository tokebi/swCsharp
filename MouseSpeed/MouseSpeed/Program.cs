using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace MouseSpeed
{
    class MouseSensitivityChangeProgram
    {
        [DllImport("user32.dll")]
        extern static bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);
        private const uint SPI_GETMOUSESPEED = 112;
        private const uint SPI_SETMOUSESPEED = 113;
        private const uint SPIF_UPDATEINIFILE = 1;
        private const uint SPIF_SENDCHANGE = 2;

        unsafe static void Main(string[] args)
        {
            uint mouseSpeed;
            uint level1 = 3;
            uint level2 = 10;
            uint level3 = 20;

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr((void*)&mouseSpeed), 0);
            Debug.WriteLine("現在のマウス速度:" + mouseSpeed);
            Console.WriteLine("現在のマウス速度:" + mouseSpeed);
            System.Console.ReadLine();

            if (args.Length == 0)
            {
                Debug.WriteLine("コマンドライン引数はありません。");
                Console.WriteLine("コマンドライン引数はありません。");
                System.Console.ReadLine();
            }
            else
            {
                mouseSpeed = UInt32.Parse(args[0]);
            }

            Debug.WriteLine("変更後のマウス速度:" + mouseSpeed);
            Console.WriteLine("変更後のマウス速度:" + mouseSpeed);

            MessageBox.Show("速度レベルは1～20の範囲で設定をして下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(mouseSpeed), SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            /*
            if (level1 >= 1 & level2 >= 1 & level3 >= 1 & level1 <= 20 & level2 <= 20 & level3 <= 20)
            {
                SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr((void*)&mouseSpeed), 0);

                Debug.WriteLine("現在のマウス速度:" + mouseSpeed);
                if (mouseSpeed < level2) 
                {
                    Debug.WriteLine("変更後のマウス速度:" + level2);
                    //SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(level2), SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                } else if (mouseSpeed < level3) 
                {
                    Debug.WriteLine("変更後のマウス速度:" + level3);
                    //SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(level3), SPIF_UPDATEINIFILE | SPIF_SENDCHANGE); 
                } else if (mouseSpeed >= level3) 
                {
                    Debug.WriteLine("変更後のマウス速度:" + level1);
                    //SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(level1), SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                }
            }
            else
            {
                MessageBox.Show("速度レベルは1～20の範囲で設定をして下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
    }
}
