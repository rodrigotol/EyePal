namespace RT.EyePal.Infra.Data.Interfaces.Context
{
    public interface IConfigurationContext
    {
        /// <summary>
        /// Determines the path toConfiguration folder
        /// </summary>
        /// <returns>File path</returns>
        string GetConfigurationFolderPath();
    }
}