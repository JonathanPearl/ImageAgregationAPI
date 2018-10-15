using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DL.Generic
{
    class DatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static DatabaseSettings GetSettings ()
        {
            var path = Environment.CurrentDirectory + "DatabaseSettings.xml";

            if (!new FileInfo(path).Exists)
            {
                DefaultSettingsData();
            }

            var xmlSerializer = new DataContractSerializer(typeof(DatabaseSettings));
            var settingsFile = XmlReader.Create(path);

            var settings = (DatabaseSettings)xmlSerializer.ReadObject(settingsFile);
            settingsFile.Close();
            return settings;
        }

        private static void DefaultSettingsData()
        {
            var DefaultSettings = new DatabaseSettings();
            DefaultSettings.DatabaseName = "imagesearch";
            DefaultSettings.Server = "localhost";
            DefaultSettings.Port = "3306";
            DefaultSettings.UserName = "root";
            DefaultSettings.Password = "admin";
            DatabaseSettings.SetSettings(DefaultSettings);
        }

        // Writes Default Settings if not existing
        private static void SetSettings(DatabaseSettings defaultSettings)
        {
            var path = Environment.CurrentDirectory + "DatabaseSettings.xml";
            var xmlSerializer = new DataContractSerializer(typeof(DatabaseSettings));
            var settings = new System.Xml.XmlWriterSettings { Indent = true, NewLineOnAttributes = true };
            var SettingsFile = XmlWriter.Create(path, settings);
            xmlSerializer.WriteObject(SettingsFile, settings);
            SettingsFile.Close();
        }
    }
}
