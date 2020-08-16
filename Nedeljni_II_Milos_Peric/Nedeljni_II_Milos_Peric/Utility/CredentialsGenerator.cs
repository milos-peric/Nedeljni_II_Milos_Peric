using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Milos_Peric.Utility
{
    class CredentialsGenerator
    {
        private const string pathCredentialAccess = @"..\..\ClinicAccess.txt";
        private static List<string> passwordData = new List<string>();
 
        public static List<string> ReadCredentialsFromFile()
        {
            string line;
            try
            {
                using (StreamReader streamReader = new StreamReader(pathCredentialAccess))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] lines = line.Split(':');
                        line = lines.ElementAt(1).ToString();
                        passwordData.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Not possible to read from file {0} or file doesn't exist.", pathCredentialAccess);
                Debug.WriteLine(e.Message);
            }
            return passwordData;
        }
 
        public static void WriteCredentialsToFile(string userName, string password)
        {
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(pathCredentialAccess))
                    {
                        streamWriter.WriteLine($"Username:{userName}");
                        streamWriter.WriteLine($"Password:{password}");
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Not possible to write to file. Path: ", pathCredentialAccess);
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
