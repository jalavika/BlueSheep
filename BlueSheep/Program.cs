﻿using System;
using System.Windows.Forms;
using BlueSheep.Interface;
using Microsoft.Win32;
using System.IO;

namespace BlueSheep
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.Exit();
            if (args[0] == "ok")
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    RegistryKey reg;
                    Registry.CurrentUser.DeleteSubKeyTree("Software\\BlueSheep", false);
                    reg = Registry.CurrentUser.CreateSubKey("Software\\BlueSheep");
                    reg = Registry.CurrentUser.OpenSubKey("Software\\BlueSheep", true);
                    if (reg.ValueCount > 1)
                    {
                        reg.DeleteValue("Version");
                        reg.DeleteValue("Minor");
                        System.Threading.Thread.Sleep(1000);
                    }
                    reg.SetValue("Version", 0.8);
                    reg.SetValue("Minor", 6);
                    Application.Run(new MainForm(0, "0.8.6"));
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message + ex.StackTrace); }
                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Veuillez lancer BlueSheep via l'updater !");
                Application.Exit();
            }


        }

    }
}