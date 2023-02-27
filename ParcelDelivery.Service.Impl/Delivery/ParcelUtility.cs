﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ParcelDelivery.Service.Impl
{
    public class ParcelUtility : IParcelUtility
    {

        public T ParseXml<T>(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            var t = default(T);

            using (var streamReader = File.OpenText(xmlFilePath))
            {
                t = (T)serializer.Deserialize(streamReader);
            }

            return t;
        }

        public static Organization CreateOrganization()
        {
            return new Organization
            {
                Departments = new List<Department>
                {
                    new InsuranceDepartment(),
                    new MailDepartment(),
                    new RegularDepartment(),
                    new HeavyDepartment(),
                    new AddDepartment()
                }
            };
        }

    }
}
