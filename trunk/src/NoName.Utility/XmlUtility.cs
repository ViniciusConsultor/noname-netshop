using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace NoName.Utility
{
    public class XmlUtility
    {

        /// <summary>
        /// 根据提供的xpath创建节点,并返回最终的页节点,
        /// 支持xpath的属性，支持是否创建属性节点
        /// </summary>
        /// <param name="xPath">相对于当前节点的xpath表达式，只支持简单的xpath，
        ///	如：a[@a='c']/b/c[@b='a' or @b='f']/d，
        ///		a[@a='c']/b/c[@b='a' and @a='f']/d,
        ///		a/b/c/d
        /// </param>
        /// <param name="rootNode">需要创建节点的根节点</param>
        /// <param name="IsCreateAttribute">是否创建属性节点</param>
        /// <returns>最后创建的页节点</returns>
        public static XmlNode GetOrCreateXmlTree(string xPath, XmlNode node)
        {
            return GetOrCreateXmlTree(xPath, node, true);
        }

        /// <summary>
        /// 根据提供的xpath创建节点,并返回最终的页节点,
        /// 支持xpath的属性，支持是否创建属性节点
        /// </summary>
        /// <param name="xPath">相对于当前节点的xpath表达式，只支持简单的xpath，
        ///	如：a[@a='c']/b/c[@b='a' or @b='f']/d，
        ///		a[@a='c']/b/c[@b='a' and @a='f']/d,
        ///		a/b/c/d
        /// </param>
        /// <param name="rootNode">需要创建节点的根节点</param>
        /// <param name="IsCreateAttribute">是否创建属性节点</param>
        /// <returns>最后创建的页节点</returns>
        public static XmlNode GetOrCreateXmlTree(string xPath, XmlNode node, bool IsCreateAttribute)
        {
            if (node.NodeType != XmlNodeType.Element)
            {
                throw new ArgumentException("传入的节点不是一个XmlNodeType.Element节点");
            }

            XmlDocument tempXdoc = node.OwnerDocument;
            XmlNode fatherNode = node;
            XmlNode sonNode = null;
            xPath = xPath.Trim('/');

            string regstr = @"(?<path>(?<name>\w+)[^/]*)";

            MatchCollection mc = Regex.Matches(xPath, regstr);

            foreach (Match match in mc)
            {
                string name = match.Groups["name"].Value;
                string path = match.Groups["path"].Value;
                sonNode = fatherNode.SelectSingleNode(path);
                if (sonNode == null)
                {
                    sonNode = tempXdoc.CreateElement(name);
                    fatherNode.AppendChild(sonNode);
                    if (IsCreateAttribute)
                    {
                        string attrRegx = "@(?<aName>\\w+)=['|\"]?(?<aValue>\\w+)['|\"]?";
                        MatchCollection amc = Regex.Matches(path, attrRegx);
                        foreach (Match amatch in amc)
                        {
                            string aName = amatch.Groups["aName"].Value;
                            string aValue = amatch.Groups["aValue"].Value;
                            sonNode.Attributes.Append(tempXdoc.CreateAttribute(aName));
                            sonNode.Attributes[aName].Value = aValue;
                        }
                    }
                }
                fatherNode = sonNode;
            }
            return sonNode;
        }

        /// <summary>
        /// 为xml节点的属性赋值，如果属性不存在则创建属性并赋值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <param name="attrValue"></param>
        public static void SetAtrributeValue(XmlNode node, string attrName, string attrValue)
        {
            if (node.NodeType != XmlNodeType.Element)
            {
                throw new ArgumentException("传入的节点不是一个XmlNodeType.Element节点");
            }

            XmlDocument tempXdoc = node.OwnerDocument;

            if (node.Attributes[attrName] == null)
            {
                node.Attributes.Append(tempXdoc.CreateAttribute(attrName));
            }
            node.Attributes[attrName].Value = attrValue;
        }

        /// <summary>
        /// 添加一个新节点，如果有内容，同时为节点赋值，如果没有，则只创建
        /// </summary>
        /// <param name="fathernode"></param>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static XmlNode AddNewNode(XmlNode fathernode, string name, string content)
        {
            XmlDocument xdoc = fathernode.OwnerDocument;
            XmlNode snode = xdoc.CreateElement(name);
            if (!String.IsNullOrEmpty(content))
            {
                snode.InnerXml = ReplaceInvalidChar(content);
            }
            fathernode.AppendChild(snode);
            return snode;
        }


        public static XmlNode AddCDataNode(XmlNode fathernode, string name, string content)
        {
            XmlDocument xdoc = fathernode.OwnerDocument;
            XmlNode snode = xdoc.CreateElement(name);

            XmlCDataSection CData = xdoc.CreateCDataSection(content);

            snode.AppendChild((XmlNode)CData);

            fathernode.AppendChild(snode);

            return snode;
        }

        public static string ReplaceInvalidChar(string instr)
        {
            string result = instr.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;");
            return result;
        }
    }
}
