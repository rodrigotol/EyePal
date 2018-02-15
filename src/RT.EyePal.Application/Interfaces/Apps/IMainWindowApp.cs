using RT.EyePal.Application.ViewModels;

namespace RT.EyePal.Application.Interfaces.Apps
{
    public interface IMainWindowApp
    {
        /// <summary>
        /// Creates a new FilterConfigurationViewModel
        /// </summary>
        /// <returns>New viewmodel</returns>
        FilterConfigurationViewModel GetViewModel();

        /// <summary>
        /// Serialize a FilterConfiguration into a XML file
        /// </summary>
        /// <param name="filterConfiguration">FilterConfiguration viewModel</param>
        void SaveFilterConfiguration(FilterConfigurationViewModel filterConfiguration);

        /// <summary>
        /// Deserialize a FilterConfiguration from a XML file
        /// </summary>
        /// <return>Deserialized viewModel</return>
        FilterConfigurationViewModel LoadFilterConfiguration();
    }
}