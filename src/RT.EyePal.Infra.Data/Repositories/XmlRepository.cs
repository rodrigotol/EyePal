using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using RT.EyePal.Domain.Entities;
using RT.EyePal.Domain.Interfaces.Respositories;
using RT.EyePal.Infra.Data.Interfaces.Context;

namespace RT.EyePal.Infra.Data.Repositories
{
    /// <summary>
    /// Very simple repository to work with XMl files, base on
    /// a ConfigurationContext
    /// </summary>    
    public class XmlRepository<TEntity>: IXmlRepository<TEntity>
        where TEntity: class
    {
        private readonly IConfigurationContext _configurationContext;

        /// <summary>
        /// Injected constructor
        /// </summary>
        /// <param name="configurationContext">Injection of ConfigurationContext</param>
        public XmlRepository(IConfigurationContext configurationContext)
        {
            _configurationContext = configurationContext;
        }

        /// <summary>
        /// Serialize a TEntity into a XML file
        /// </summary>
        /// <param name="data">TEntity entity</param>
        public void WriteXmlFile(TEntity data)
        {
            WriteToFile(data, GenerateFilename(typeof(TEntity)));
        }

        /// <summary>
        /// Deserialize a TEntity from a XML file
        /// </summary>
        /// <return>Deserialized entity</return>
        public TEntity ReadXmlFile()
        {
            var filePath = GenerateFilename(typeof (TEntity));

            if (!File.Exists(filePath))
                return null;

            return ReadFromFile<TEntity>(filePath);
        }


        private string GenerateFilename(Type tEntityType)
        {
             return Path.Combine(_configurationContext.GetConfigurationFolderPath()
                , tEntityType.Name + ".xml");
        }


        private void WriteToFile<T>(T data, string filePath)
        {
            var textWriter = new XmlTextWriter(filePath, Encoding.UTF8);
            try
            {
                var serializer = new XmlSerializer(typeof (T));                

                serializer.Serialize(textWriter, data);
                textWriter.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {                
                textWriter.Close();
            }
        }

        private T ReadFromFile<T>(string filePath)
        {
            var data = default(T);
            var textReader = new XmlTextReader(filePath);

            try
            {
                var serializer = new XmlSerializer(typeof (T));                

                data = (T) serializer.Deserialize(textReader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                textReader.Close();
            }            

            return data;
        }        
    }
}
