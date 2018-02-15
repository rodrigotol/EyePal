using System;
using System.IO;
using RT.EyePal.Infra.Data.Interfaces.Context;

namespace RT.EyePal.Infra.Data.Context
{
    /// <summary>
    /// Context for all app configurations
    /// </summary>
    public class ConfigurationContext: IConfigurationContext
    {
        private readonly string _basepath;
        private readonly string _configurationFolder;

        public ConfigurationContext()
        {
            _basepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _configurationFolder = "EyePal";
        }

        /// <summary>
        /// Determines the path to Configuration folder
        /// </summary>
        /// <returns>File path</returns>
        public string GetConfigurationFolderPath()
        {
            var path = Path.Combine(_basepath, _configurationFolder);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}