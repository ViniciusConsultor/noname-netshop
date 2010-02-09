using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NoName.NetShop.CMS.Config;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace NoName.NetShop.CMS.FileManage
{
    public class FileManager
    {
        private static FileManagementSection Config = (FileManagementSection)ConfigurationManager.GetSection("fileManagement");

        public static List<FileSystemObject> Upload(HttpPostedFile UploadFile)
        {
            string FileExtension = Path.GetExtension(UploadFile.FileName).ToLower().Substring(1);

            if ("rar|zip".Contains(FileExtension))
            {
                return UploadDecompress(UploadFile);
            }
            else
            {
                List<FileSystemObject> List = new List<FileSystemObject>();
                List.Add(UploadDirect(UploadFile));
                return List;
            }
        }

        public static List<FileSystemObject> GetList(FileManagementElement Element, string RequestPath)
        {
            List<FileSystemObject> list = new List<FileSystemObject>();

            if (RequestPath != Element.PathRoot)
            {
                DirectoryInfo pd = new DirectoryInfo(RequestPath).Parent;

                list.Add(new FileSystemObject()
                {
                    FileName = "上级目录",
                    FullName = pd.FullName,
                    LastWriteTime = pd.LastWriteTime,
                    Size = -1,
                    Suffix = "none",
                    Type = FileSystemObjectType.None,
                    Url = "--"
                });
            }


            foreach (string d in Directory.GetDirectories(RequestPath))
            {
                DirectoryInfo di = new DirectoryInfo(d);

                FileSystemObject fso = new FileSystemObject();

                fso.FileName = di.Name;
                fso.FullName = di.FullName;
                fso.Suffix = "folder";
                fso.Url = "--";
                fso.Size = -1;
                fso.LastWriteTime = di.LastWriteTime;
                fso.Type = FileSystemObjectType.Folder;

                list.Add(fso);
            }

            foreach (string f in Directory.GetFiles(RequestPath))
            {
                FileInfo fi = new FileInfo(f);

                FileSystemObject fso = new FileSystemObject();

                fso.FileName = fi.Name;
                fso.FullName = fi.FullName;
                fso.Suffix = Path.GetExtension(fi.FullName).Substring(1);
                fso.Url = Element.UrlRoot + fi.FullName.Replace(Element.PathRoot, String.Empty).Replace("\\", "/");
                fso.Size = Convert.ToDecimal((fi.Length / 1024.00).ToString("0.00"));
                fso.LastWriteTime = fi.LastWriteTime;
                fso.Type = FileSystemObjectType.File;

                list.Add(fso);
            }

            return list;
        }

        public static bool Delete(FileSystemObject fso, out string Message)
        {
            Message = String.Empty;
            bool Result = true;
            try
            {
                    File.Delete(fso.FullName);
                    Directory.Delete(fso.FullName);
            }
            catch (Exception ex)
            {
                Result = false;
                Message = ex.Message;
            }

            return Result;
        }


        #region 私有方法区
        private static List<FileSystemObject> UploadDecompress(HttpPostedFile UploadFile)
        {
            FileManagementElement Element = Config.FileCategories[0];
            List<FileSystemObject> List = new List<FileSystemObject>();

            FileSystemObject RarFile = UploadDirect(UploadFile);

            string FatherFolder = String.Format("{0}{1}\\{2}\\", (Element.PathRoot.EndsWith("\\") ? Element.PathRoot : Element.PathRoot + "\\"), DateTime.Today.ToString("yyyy-MM"), DateTime.Today.ToString("dd"));

            //创建临时文件夹，将rar文件释放在临时文件夹中
            string TempFolderName = String.Format("_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));
            ExtractFile(RarFile.FullName, FatherFolder + TempFolderName);


            //扫描该临时文件夹，删除不合规则文件，将符合要求的文件按照规则命名，拷贝到上级目录，同时加入List中
            foreach (string ExtractedFileName in Directory.GetFiles(TempFolderName))
            {
                string Suffix = Path.GetExtension(ExtractedFileName).ToLower().Substring(1);
                if (!Element.AllowedFormats.Contains(Suffix))
                {
                    File.Delete(ExtractedFileName);
                }
                else
                {
                    string NewFileName = String.Format("{0}{1}.{2}", FatherFolder, Guid.NewGuid(), Suffix);

                    File.Copy(ExtractedFileName, NewFileName);

                    FileInfo TheFile = new FileInfo(NewFileName);

                    FileSystemObject fso = new FileSystemObject();

                    fso.FileName = TheFile.Name;
                    fso.FullName = TheFile.FullName;
                    fso.Suffix = Path.GetExtension(TheFile.FullName).Substring(1);
                    fso.Url = Element.UrlRoot + TheFile.FullName.Replace(Element.PathRoot, String.Empty).Replace("\\", "/");
                    fso.Size = Convert.ToDecimal((TheFile.Length / 1024.00).ToString("0.00"));
                    fso.LastWriteTime = TheFile.LastWriteTime;
                    fso.Type = FileSystemObjectType.File;

                    List.Add(fso);
                }
            }

            //删除临时文件夹
            try
            {
                Directory.Delete(TempFolderName);
            }
            catch (Exception ex) { }

            return List;
        }

        private static FileSystemObject UploadDirect(HttpPostedFile UploadFile)
        {
            FileManagementElement Element = Config.FileCategories[0];

            string FileExtension = Path.GetExtension(UploadFile.FileName).ToLower().Substring(1);

            string FileRelativeName = String.Format(Element.FileNameFormat, DateTime.Today.ToString("yyyy-MM"), DateTime.Today.ToString("dd"), Guid.NewGuid(), FileExtension);
            string FileFullName = (Element.PathRoot.EndsWith("\\") ? Element.PathRoot : Element.PathRoot + "\\") + FileRelativeName;
            string ParentDirectoryName = FileFullName.Substring(0, FileFullName.LastIndexOf("\\"));

            if (UploadFile.ContentLength <= Element.MaxSize && Element.AllowedFormats.Contains(FileExtension))
            {
                if (!ParentDirectoryName.EndsWith("\\")) ParentDirectoryName += "\\";
                if (!Directory.Exists(ParentDirectoryName)) { Directory.CreateDirectory(ParentDirectoryName); }

                UploadFile.SaveAs(FileFullName);
                return new FileSystemObject()
                {
                    FileName = FileFullName.Substring(FileFullName.LastIndexOf("\\") + 1),
                    FullName = FileFullName,
                    Url = Element.UrlRoot + FileRelativeName.Replace("\\", "/"),
                    Size = UploadFile.ContentLength / 1024,
                    Suffix = FileExtension,
                    Type = FileSystemObjectType.File,
                };
            }
            else
            {
                throw new Exception("上传文件不符合要求");
            }
        }

        private static void ExtractFile(string FileName, string FolderName)
        {
            Process rar = new Process();

            string exePath = Config.DecompressionProgram;
            rar.StartInfo.FileName = exePath;
            rar.StartInfo.CreateNoWindow = true;

            if (FileName.ToLower().IndexOf(@".rar") > 0 || FileName.ToLower().IndexOf(@".zip") > 0)
            {
                if (!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);

                rar.StartInfo.Arguments = "e x -inul -y " + FileName + " " + FolderName;
                rar.Start();
                rar.WaitForExit();
            }
        }
        #endregion
    }
}
