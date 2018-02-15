namespace RT.EyePal.Domain.Interfaces.Respositories
{
    public interface IXmlRepository<TEntity> where TEntity: class 
    {
        /// <summary>
        /// Serialize a TEntity into a XML file
        /// </summary>
        /// <param name="data">TEntity entity</param>
        void WriteXmlFile(TEntity data);

        /// <summary>
        /// Deserialize a TEntity from a XML file
        /// </summary>
        /// <return>Deserialized entity</return>
        TEntity ReadXmlFile();
    }
}