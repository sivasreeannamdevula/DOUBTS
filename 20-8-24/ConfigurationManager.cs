public sealed class ConfigurationManger
{
        public void LoadConfiguration(string filePath)
        {
             if(File.Exists(filePath))
             {
                string configData=File.ReadAllText(filePath);
                System.Console.WriteLine(configData);
             }
             else{
                throw new FileNotFoundException("File doen't exist");
             }
        }
        public void SaveConfiguration(string filePath,string configToSave)
        {
              if(File.Exists(filePath))
             {
                File.WriteAllText(filePath,configToSave);
             }
             else{
                throw new FileNotFoundException("File doen't exist");
             }
        }
}