using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;
using System.Data;

namespace NoName.Security
{
    public abstract class MenuProvider:ProviderBase
    {
        public abstract string ApplicationName { get; set; }

        public abstract bool IsAppRootPath { get;}
        /// <summary>
        /// ����²˵�������Ȩ��Ϣ
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="isForced">�Ƿ�ǿ�Ƹ��Ǿ�����ͬ����URL�˵�����Ȩ</param>
        /// <returns></returns>
        public abstract int AddMenuItem(AspnetMenuItem menu, bool isForced);
        /// <summary>
        /// ���²˵���Ȩ��Ϣ
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="isForced">�Ƿ�ǿ�Ƹ��Ǿ�����ͬ����URL�˵�����Ȩ</param>
        /// <returns></returns>
        public abstract int UpdateMenuItem(AspnetMenuItem menu, bool isForced);
        /// <summary>
        /// ɾ���˵�
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="isForced">�Ƿ�ͬʱǿ��ɾ����Ŀ¼</param>
        /// <returns></returns>
        public abstract bool DeleteMenuItem(int menuId, bool isForced);

        /// <summary>
        /// �жϲ˵��Ƿ����
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public abstract bool IsExistsMenudItem(int menuId);

        /// <summary>
        /// ��ò˵���
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public abstract AspnetMenuItem GetMenuItem(int menuId);

        /// <summary>
        /// ���ý�ɫ����Ȩ
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ����Ȩ���в˵�������Ϊ3������ɫ
        ///  Ϊ�գ�ȡ����ɫ������Ȩ
        /// '1,2,3'�� ��Ȩ���ṩ�Ĳ˵�����ɫ���˵�������Ȩ����Ϊ3
        /// </param>
        /// <returns></returns>
        public abstract int ChangeMenusOfRole(string rolename, string menus);

       /// <summary>
        /// ����ĳ������Ա����Ȩ
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ����Ȩ���в˵�������Ϊ3������ɫ
        ///  Ϊ�գ�ȡ����ɫ������Ȩ
        /// '1,2,3'�� ��Ȩ���ṩ�Ĳ˵�����ɫ���˵�������Ȩ����Ϊ3
        /// </param>
        /// <returns></returns>
        public abstract int ChangeMenusOfAdmin(string username, string menus);


        /// <summary>
        /// ������еĲ˵���:���ڹ����ά��
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetMenusForManager();


        /// <summary>
        /// �ƶ�ĳ���˵���Ŀ��˵���
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public abstract int MoveMenu(int sourceId, int destinationId);


        /// <summary>
        /// ��ò˵���Ȩ��֤����
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<string, string> GetAllMenuRoleMaps();
         
        /// <summary>
        /// ���ò˵��ṩ�����������Ļ�������
        /// </summary>
        public abstract void ResetCache();

        /// <summary>
        /// ��ý�ɫ��ӵ�еĲ˵�Ȩ�ޣ���������Ȩ����Ϊ3�Ĳ˵�
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public abstract string[] GetMenusOfRole(string rolename);

        /// <summary>
        /// ��ò˵�����
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetMenusForSitemap();

        /// <summary>
        /// ���ĳ������Ա���Է���Ĳ˵�
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public abstract string[] GetMenusOfAdmin(string adminID);

        /// <summary>
        /// ����û�����Ľ�ɫ
        /// </summary>
        /// <param name="amindID"></param>
        /// <returns></returns>
        public abstract string[] GetRolesOfAdmin(string amindID);

        /// <summary>
        /// �����û�����Ľ�ɫ
        /// </summary>
        /// <param name="username"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public abstract int ChangeRolesOfAdmin(string username, string roles);

    }
}
