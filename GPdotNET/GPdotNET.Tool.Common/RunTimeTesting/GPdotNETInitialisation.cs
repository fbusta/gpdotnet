﻿
using System.Xml.Linq;
using GPdotNET.Core;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;
using GPdotNET.Tool.Common;
using GPdotNET.Util;
namespace GPdotNET.Tool
{
    public static class GPdotNETRunTimeTest
    {
        public static Dictionary<int,GPFunction> GenerateGPFunctionsFromXML()
        {

            var theDirectory = GPModelGlobals.GetInstalledLocation();
            string filePath = theDirectory + "\\RunTimeTesting\\FunctionSet.xml";

            try
            {
                // Loading from a file, you can also load from a stream
                var doc = XDocument.Load(filePath);
                // 
                var q = from c in doc.Descendants("FunctionSet")
                        select new GPFunction
                        {

                            Selected = bool.Parse(c.Element("Selected").Value),
                            Weight = int.Parse(c.Element("Weight").Value),
                            Name = c.Element("Name").Value,
                            Definition = c.Element("Definition").Value,
                            ExcelDefinition = c.Element("ExcelDefinition").Value,
                            Aritry = ushort.Parse(c.Element("Aritry").Value),
                            Description = c.Element("Description").Value,
                            IsReadOnly = bool.Parse(c.Element("ReadOnly").Value),
                            IsDistribution = bool.Parse(c.Element("IsDistribution").Value),
                            ID = int.Parse(c.Element("ID").Value)

                        };
                var retval = q.ToDictionary(v => v.ID, v => v);
                return retval;
            }
            catch (Exception)
            {

                throw new Exception("File not exist!");
            }
            
        }
        public static double[][] LoadTrainingData(string fileName = "sample1_traindata.csv")
        {
            var theDirectory = GPModelGlobals.GetInstalledLocation();

            return GPModelGlobals.LoadDataFromFile(theDirectory + "\\RunTimeTesting\\" + fileName);
           // return GPdotNET.Engine.GPModelGlobals.LoadGPData(theDirectory + "\\RunTimeTesting\\" + fileName);
        }

        public static string GetRunTimeTestingPath(string fileName = "sample1_traindata.csv")
        {
            var theDirectory = GPModelGlobals.GetInstalledLocation();

            return theDirectory + "\\RunTimeTesting\\" + fileName;
            // return GPdotNET.Engine.GPModelGlobals.LoadGPData(theDirectory + "\\RunTimeTesting\\" + fileName);
        }
        
        public static double[][] LoadTestData(string fileName = "sample1_testdata.csv")
        {
            var theDirectory = GPModelGlobals.GetInstalledLocation();

            return GPModelGlobals.LoadDataFromFile(theDirectory + "\\RunTimeTesting\\" + fileName);
            //return GPdotNET.Engine.GPModelGlobals.LoadGPData(theDirectory + "\\RunTimeTesting\\" + fileName);
        }
        
    }
}