using RT.EyePal.Domain.Entities;
using RT.EyePal.Domain.Interfaces.Respositories;
using RT.EyePal.Infra.Data.Interfaces.Context;

namespace RT.EyePal.Infra.Data.Repositories
{
    /// <summary>
    /// Specific repository for FilterConfiguration
    /// </summary>
    public class FilterConfigurationRepository: XmlRepository<FilterConfiguration>, IFilterConfigurationRepository
    {
        public FilterConfigurationRepository(IConfigurationContext configurationContext) 
            : base(configurationContext)
        {
        }
    }
}