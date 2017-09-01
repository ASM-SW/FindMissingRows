using System;
using System.IO;

namespace FindMissingRows
{
    /// <summary>
    /// This class is used to hold all of the configuration information.
    /// It will be serialized and deserialized to a configuration file in the directory %APPDATA%
    /// </summary>
    public class Configuration
    {
        public string MemberListFileName { get; set; }
        public string CompareListFileName { get; set; }
        public string MemberListColumnName { get; set; }
        public string CompareListColumnName { get; set; }

        private static string m_FileName;

        public static string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }


        static Configuration()
        {
            string appData = Environment.GetEnvironmentVariable("APPDATA");
            string dataDir = Path.Combine(appData, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);
            m_FileName = Path.Combine(dataDir, "Configuration.xml");
        }

        public Configuration()
        {
        }
    }
}
