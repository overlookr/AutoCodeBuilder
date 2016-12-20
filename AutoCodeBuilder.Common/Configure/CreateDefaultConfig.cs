﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AutoCodeBuilder.Common.Configure
{
    /// <summary>
    /// 生成默认配置文件
    /// 根节点为config，配置节点为setting
    /// </summary>
    public class CreateDefaultConfig
    {
        string filePath = "";
        Dictionary<string, string> list;

        XmlDocument doc;

        /// <summary>
        /// 生成默认配置文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="list">配置的键值列表</param>
        public CreateDefaultConfig(string filePath, Dictionary<string, string> list)
        {
            this.filePath = filePath;
            this.list = list;
        }

        /// <summary>
        /// 生成处理
        /// </summary>
        public void CreateHandle()
        {
            doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null);
            doc.AppendChild(dec);

            //一级
            XmlElement root = doc.CreateElement("config");
            doc.AppendChild(root);

            foreach (var li in list)
            {
                //二级
                XmlElement element1 = doc.CreateElement("setting");
                element1.SetAttribute("key", li.Key);
                element1.SetAttribute("value", li.Value);
                root.AppendChild(element1);
            }

            doc.Save(filePath);
        }
    }
}
