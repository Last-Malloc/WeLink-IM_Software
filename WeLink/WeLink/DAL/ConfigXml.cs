using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeLink.DAL
{
    class ConfigXml
    {
        static string xmlPath = Environment.CurrentDirectory + @"\cookie\general\clientConfig.xml";
        /// <summary>
        /// 在cookie\general建立后即执行projectInit后调用
        /// </summary>
        public static void initConfigXML()
        {
            XDocument xDocument = new XDocument();
            //定义根节点
            XElement xRoot = new XElement("configs");
            //保存根节点
            xDocument.Add(xRoot);
            //保存为clientConfig.xml
            xDocument.Save(Environment.CurrentDirectory +  @"\cookie\general\clientConfig.xml");
        }

        /// <summary>
        /// 增加节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void addConfigXML(string key, string value)
        {
            XElement xe = XElement.Load(xmlPath);
            XElement element = new XElement(new XElement("config", new XElement("key", key), new XElement("value", value)));
            xe.Add(element);
            xe.Save(xmlPath);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void updateConfigXML(string key, string value)
        {
            XElement xe = XElement.Load(xmlPath);
            IEnumerable<XElement> xElements = from ele in xe.Elements("config") where (string)ele.Element("key") == key select ele;
            if (xElements.Count() > 0)
            {
                xElements.First().ReplaceNodes(new XElement("key", key), new XElement("value", value));
            }
            xe.Save(xmlPath);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="key"></param>
        public static void removeConfigXML(string key)
        {
            XElement xe = XElement.Load(xmlPath);
            IEnumerable<XElement> xElements = from ele in xe.Elements("config") where (string)ele.Element("key") == key select ele;
            if (xElements.Count() > 0)
            {
                xElements.First().Remove();
            }
            xe.Save(xmlPath);
        }

        public static string selectConfigXML(string key)
        {
            XElement xe = XElement.Load(xmlPath);
            IEnumerable<XElement> xElements = from ele in xe.Elements("config") where (string)ele.Element("key") == key select ele;
            if (xElements.Count() > 0)
            {
                return xElements.First().Element("value").Value;
            }
            return "";
        }
    }
}
