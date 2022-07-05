using PersistanceExample;
using System;
using static PersistanceExample.Persister;
using static PersistanceExample.XMLPersister;

namespace ClientAppp
{
    [TargetPersistaneType(PersistanceType.Xml)]
    public class PatientDataModel
    {
        //[TransformToRelated(TransformTo.Attribute)]
        [XmlAttribute]
        public string MRN { get; set; }

        //[TransformToRelated(TransformTo.Element)]
        [XmlElement]
        public string Name { get; set; }

        //[TransformToRelated(TransformTo.Attribute)]
        [XmlIgnore]
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PatientDataModel model = new PatientDataModel() { MRN = "M100", Name = "Tom", Age = 33 };
            Persister _persister = new Persister();
            _persister.Persist(model);
        }
    }
}
