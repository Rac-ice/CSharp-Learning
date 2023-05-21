﻿using CaterCommon;
using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class ManagerInfoBll
    {
        //创建数据层对象
        private ManagerInfoDal miDal;

        public ManagerInfoBll() 
        {
            miDal = new ManagerInfoDal();
        }

        public List<ManagerInfo> GetList()
        {
            return miDal.GetList();
        }

        public bool Add(ManagerInfo mi)
        {
            return miDal.Insert(mi) > 0;
        }

        public bool Edit(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        }

        public bool Remove(int id)
        {
            return miDal.Delete(id) > 0;
        }

        public LoginState Login(string name,string pwd,out int type)
        {
            //设置type默认值,如果为此值时，不会使用
            type = -1;
            //根据用户名进行对象的查询
            ManagerInfo mi = miDal.GetByName(name);
            if (mi == null)
            {
                //用户名错
                return LoginState.NameError;
            }
            else
            {
                //用户名正确
                if (mi.MPwd.Equals(Md5Helper.EncryptString(pwd)))
                {
                    //密码正确
                    //登录成功
                    type = mi.MType;
                    return LoginState.OK;
                }
                else
                {
                    //密码错误
                    return LoginState.PwdError;
                }
            }
        }
    }
}