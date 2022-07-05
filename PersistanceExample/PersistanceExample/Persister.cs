using System;
using System.Linq;
using static PersistanceExample.Persister;

namespace PersistanceExample
{
    public class Persister
    {
        public enum PersistanceType
        {
            Xml,Json,Binary,Csv
        }

        [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
        public class TargetPersistaneTypeAttribute : Attribute
        {
            public PersistanceType format;
            public TargetPersistaneTypeAttribute(PersistanceType format)
            {
                this.format = format;
            }
        }

        public bool Persist(object source)
        {
            var targetTypeAttribute = source.GetType().GetCustomAttributes(typeof(TargetPersistaneTypeAttribute), true).FirstOrDefault() as TargetPersistaneTypeAttribute;
            PersistanceType _targetFormat = targetTypeAttribute.format;
            Console.WriteLine($"Target format is : {_targetFormat} ");
            switch (_targetFormat)
            {
                case PersistanceType.Xml:
                    XMLPersister _persister = new XMLPersister();
                    _persister.WriteObject(source);
                    break;
            }
            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public class XmlPersisterAttribute:Attribute
    {

    }

    public class XmlAttributeAttribute : XmlPersisterAttribute
    {

    }
    public class XmlElementAttribute : XmlPersisterAttribute
    {

    }
    public class XmlIgnoreAttribute : XmlPersisterAttribute
    {

    }

    public class XMLPersister
    {
        //public enum TransformTo
        //{
        //    Attribute, Element
        //}

        //[AttributeUsage(AttributeTargets.Property)]
        //public class TransformToRelatedAttribute : Attribute
        //{
        //    public TransformTo transformTo;
        //    public TransformToRelatedAttribute(TransformTo format)
        //    {
        //        this.transformTo = format;
        //    }
        //}
        public void WriteObject(object source)
        {
            var allProperties = source.GetType().GetProperties();
            //for(int i=0;i<allProperties.Length;i++)
            //{
            //    var changeTo = allProperties[i].GetCustomAttributes(typeof(TransformToRelatedAttribute), true).FirstOrDefault() as TransformToRelatedAttribute;
            //    TransformTo _transformTo = changeTo.transformTo;
            //    Console.WriteLine($"Property  : {(allProperties[i]).Name} and change to {_transformTo}");
            //}

            for (int i = 0; i < allProperties.Length; i++)
            {
                var customAttributes = allProperties[i].GetCustomAttributes(typeof(XmlPersisterAttribute), true) as XmlPersisterAttribute[];
                
                foreach(var xmlAttribute in customAttributes)
                {
                    if(xmlAttribute is XmlAttributeAttribute)
                    {
                        Console.WriteLine($"Property  : {(allProperties[i]).Name} and change to {xmlAttribute}");
                    }
                    if(xmlAttribute is XmlElementAttribute)
                    {
                        Console.WriteLine($"Property  : {(allProperties[i]).Name} and change to {xmlAttribute}");
                    }
                    if(xmlAttribute is XmlIgnoreAttribute)
                    {
                        Console.WriteLine($"Property  : {(allProperties[i]).Name} and change to {xmlAttribute}");
                    }

                }
            }


        }
    }
}
