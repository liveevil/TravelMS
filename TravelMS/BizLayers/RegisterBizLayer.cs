﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace TravelMS
{
    public class RegisterBizLayer
    {
        public static bool RegisterUserBiz(Models.RegisterModel userData)
        {
            MD5 hasher=MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.UTF8.GetBytes(userData.Password));
           
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            userData.Password = sBuilder.ToString();

            if (RegisterDALayer.RegisterUserDAL(userData))
                return true;
            return false;
        }
    }
}