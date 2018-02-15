using AutoMapper;
using RT.EyePal.Application.AutoMapper;
using RT.EyePal.Application.Interfaces.Apps;
using RT.EyePal.Application.ViewModels;
using RT.EyePal.Domain.Entities;
using RT.EyePal.Domain.Interfaces.Respositories;

namespace RT.EyePal.Application.Apps
{
    /// <summary>
    /// Manage all interations between the MainWindow form and the configuration storage.
    /// Also works as a FilterConfigurationViewModel distributor
    /// </summary>
    public class MainWindowApp: IMainWindowApp
    {
        private readonly IFilterConfigurationRepository _filterConfigurationRepository;
        private readonly IMapper _mapperProfile;

        public MainWindowApp(IFilterConfigurationRepository filterConfigurationRepository)
        {
            _filterConfigurationRepository = filterConfigurationRepository;
            _mapperProfile = MapperFactory<MainWindowMapperProfile>.CreateNewMapper();
        }

        /// <summary>
        /// Creates a new FilterConfigurationViewModel
        /// </summary>
        /// <returns>New viewmodel</returns>
        public FilterConfigurationViewModel GetViewModel()
        {
            return new FilterConfigurationViewModel();
        }

        /// <summary>
        /// Serialize a FilterConfiguration into a XML file
        /// </summary>
        /// <param name="filterConfiguration">FilterConfiguration viewModel</param>
        public void SaveFilterConfiguration(FilterConfigurationViewModel filterConfiguration)
        {
            var entity = _mapperProfile.Map<FilterConfigurationViewModel, FilterConfiguration>(filterConfiguration);

            _filterConfigurationRepository.WriteXmlFile(entity);
        }

        /// <summary>
        /// Deserialize a FilterConfiguration from a XML file
        /// </summary>
        /// <return>Deserialized viewModel</return>
        public FilterConfigurationViewModel LoadFilterConfiguration()
        {
            var entity = _filterConfigurationRepository.ReadXmlFile();

            return _mapperProfile.Map<FilterConfiguration, FilterConfigurationViewModel>(entity);            
        }
    }
}
