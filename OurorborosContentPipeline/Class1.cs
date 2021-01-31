using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace OurorborosContentPipeline
{
    public class ContentImporter<T>
    {
        public T Load(string filename, ContentImporterContext context)
        {
            using (var streamReader = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(T));
                return (T)deserializer.Deserialize(streamReader);
            }
        }
    }
}
