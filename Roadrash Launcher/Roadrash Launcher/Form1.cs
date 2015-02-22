using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Roadrash_Launcher
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(File.Exists("Roadrash.exe"))
            {
            Process process = new Process();
            
            process.StartInfo.FileName = "Roadrash.exe";
            bool ok = false;
            while (ok == false)
            {
                Thread.Sleep(100);
                if (!FindAndKillProcess("explorer"))
                {
                    try
                    {
                        process.Start();
                    }
                    catch {
                        MessageBox.Show("Error: Cannot open the roadrash.", "Roadrash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ok = true;
                }
            }

            Thread.Sleep(100);
            string path = Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe");
            process.WaitForExit(); 
            Process.Start(path);

            this.Close();
            }
            else
                MessageBox.Show("Error: Cannot find \"Roadrash.exe\".\nCopy this launcher to the roadrash directory.", "Roadrash", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool FindAndKillProcess(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.StartsWith(name))
                {
                    for (int x = 0; x < 200; x++)
                    {
                        try
                        {
                            clsProcess.Kill();
                        }
                        catch { }
                    }
                    return true;
                }
            }
            return false;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey masterKey = Registry.LocalMachine.CreateSubKey
            ("SOFTWARE\\Electronic Arts\\RoadRash 95");

                    masterKey.SetValue("Path", "C:\\Cracked\\By\\Berber");
                    masterKey.SetValue("OpponentList", "01");
                    masterKey.SetValue("CheckDialup", "00");
                    masterKey.SetValue("ChatState", "00");
                    masterKey.SetValue("MiniDash", "02");

                    masterKey.Close();

        }
    }
}
