using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace legacy_chatfilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string chatFilterLocation;

            // First step, check if the file already exists or not - if it is, it is located at C:\Users\%username%\Documents\Guild Wars\ChatFilter.ini
            chatFilterLocation = @"C:\Users\" + @Environment.UserName + @"\Documents\Guild Wars\";
            if (File.Exists(chatFilterLocation + "ChatFilter.ini"))
            {
                // File exists. Check if the file on the server matches or not.
                if (newVersionAvailable(chatFilterLocation) == true)
                    // New version is available, download it.
                    downloadFile(chatFilterLocation);
            }
            else
            {
                downloadFile(chatFilterLocation);
            }

            // File downloaded, ready to launch the game.
            launchGame();
        }


        // Checks if our existing file matches or not by checking https://www.guildwarslegacy.com/chatfilter.php
        static bool newVersionAvailable(string localFile)
        {
            // Get MD5 hash from https://www.guildwarslegacy.com/chatfilter.php
            WebClient client = new WebClient();
            string localMD5;
            string remoteMD5 = client.DownloadString("https://www.guildwarslegacy.com/chatfilter.php");
            // Generate the localMD5
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(localFile + "ChatFilter.ini"))
                {
                    localMD5 = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
            // Now we have both values, time to compare them.
            if (remoteMD5 != localMD5)
            {
                // New update available.
                return true;
            }
            else
            {
                // No update available.
                return false;
            }
        }

        // Downloads latest ChatFilter.ini from guildwarslegacy.com
        private static void downloadFile(string location)
        {
            // Create a new WebClient instance.
            using (WebClient client = new WebClient())
            {
                // Download the Web resource and save it into the current filesystem folder.
                client.DownloadFile("https://www.guildwarslegacy.com/ChatFilter.ini", location + "ChatFilter.ini");
                // Okay, it should be downloaded now.
            }
        }

        private static void launchGame()
        {
            // Check if there is a Gw.lnk - if so, launch that. Otherwise, launch Gw.exe
            if (File.Exists("Gw.lnk"))
            {
                System.Diagnostics.Process.Start("Gw.lnk");

            }
            else
            {
                try { System.Diagnostics.Process.Start("Gw.exe"); }
                catch { Console.WriteLine("ERROR: Gw.exe or Gw.lnk not found. Please place this file in your Guild Wars install folder."); Console.ReadLine(); }
            }
        }
    }
}