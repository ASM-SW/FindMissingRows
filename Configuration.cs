using System;

namespace FindMissingRows
{
    public class Class1
    {
        public string MemberListFileName { get; set; }
        public string CompareListFileName { get; set; }
        public string MemberListColumnName { get; set; }
        public string CompareListColumnName { get; set; }
        public string ConfigFilePath { get; private set; }

        public Class1()
        {
            string appData = Environment.GetEnvironmentVariable("APPDATA");
            string dataDir = Path.Combine(appData, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);
            ConfigFileName = Path.Combine(dataDir, "Configuration.xml");
        }
    }
}
