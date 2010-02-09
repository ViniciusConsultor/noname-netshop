using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.CMS.FileManage
{
    public class FileSystemObject
    {
        /// <summary>
        /// Object name only
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Object name, including path part
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// object suffix, if exist
        /// </summary>
        public string Suffix
        {
            get;
            set;
        }

        /// <summary>
        /// Visit url via http
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Object disk cost, to folder, value of this properity is -1;
        /// </summary>
        public decimal Size
        {
            get;
            set;
        }

        /// <summary>
        /// Last write time
        /// </summary>
        public DateTime LastWriteTime
        {
            get;
            set;
        }

        /// <summary>
        /// Object type, file or folder
        /// </summary>
        public FileSystemObjectType Type
        {
            get;
            set;
        }
    }

    public enum FileSystemObjectType
    {
        File = 1,
        Folder = 2,
        None=3,
    }
}
