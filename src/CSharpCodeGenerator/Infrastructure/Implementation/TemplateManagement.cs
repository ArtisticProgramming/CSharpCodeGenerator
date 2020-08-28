using CSharpCodeGenerator.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCodeGenerator.Core;
using System.IO;
using Newtonsoft.Json;

namespace CSharpCodeGenerator.Infrastructure.Implementation
{
    public class TemplateManagement : ITemplateManagement
    {

        public Dictionary<string, string> ConvertToArgumentDictionary(IEnumerable<string> argumentText)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            var args = argumentText.Where(x=>x.Contains(":"));
            foreach (var item in args)
            {
                var KeyValueModel = item.Split(new char[] { ':' },StringSplitOptions.RemoveEmptyEntries);
                if (KeyValueModel.Length==2)
                {
                    values.Add(KeyValueModel[0].Trim(), KeyValueModel[1].Trim());
                }
            }
            return values;
        }

        public Template CreateTemplate(string fileName, string templateFilePath, IEnumerable<string> argumentText, string argumentStartSign, string argumentEndSign)
        {
            CheckTempateValidation(fileName, templateFilePath, argumentText, argumentStartSign, argumentEndSign);
            CheckArgumentsValidation(templateFilePath, argumentText, argumentStartSign, argumentEndSign);
            Template template = new Template();
            template.Name = fileName;
            template.StoragePath = templateFilePath;
            template.Argument = ConvertToArgumentDictionary(argumentText);
            template.ArgumentStartSign = argumentStartSign;
            template.ArgumentEndSign = argumentEndSign;
            template.Content = GetContent(templateFilePath);

            return template;
        }

        public string[] GetTemplateArgumentsList(string templateFilePath, string templateStartSign, string templateEndSign)
        {
            var content = GetContent(templateFilePath);
            var prameterList = getBetween(content, templateStartSign, templateEndSign);
            return prameterList.ToArray();
        }

        public void CheckArgumentsValidation(string templateFilePath, IEnumerable<string> argumentText, string templateStartSign, string templateEndSign)
        {
            if (argumentText.Count()==0)
            {
                throw new ArgumentNullException();
            }

            var Argumentdic = ConvertToArgumentDictionary(argumentText);

            var templateParameterList =
                GetTemplateArgumentsList(templateFilePath, templateStartSign, templateEndSign);

            List<string> MissedParameterLi = GetMissedParameterList(Argumentdic, templateParameterList);
            List<string> ExtraParameterLi = GetExtraParameter(Argumentdic, templateParameterList);
            string missedParameterErrorMessgeText = "The following Arguments are missed : ";
            string extraParameterErrorMessgeText = "The following Arguments are Extra : ";

            if (MissedParameterLi !=null && MissedParameterLi.Count > 0)
            {
                foreach (var item in MissedParameterLi)
                {
                    missedParameterErrorMessgeText = item + ", ";
                }
            }
            if (ExtraParameterLi != null && ExtraParameterLi.Count > 0)
            {
                foreach (var item in ExtraParameterLi)
                {
                    extraParameterErrorMessgeText = item + ", ";
                }
            }
            if (MissedParameterLi != null && ExtraParameterLi != null)
            {
                throw new Exception(
                    missedParameterErrorMessgeText + 
                    Environment.NewLine + 
                    extraParameterErrorMessgeText);
            }

        }

        public bool IsTemplateExist(string templateFilePath)
        {
            return File.Exists(templateFilePath);
        }

        public void CheckTempateValidation(string fileName, string templateFilePath, IEnumerable<string> argumentText, string argumentStartSign, string argumentEndSign)
        {
            if (IsTemplateExist(templateFilePath) == false)
            {
                throw new Exception("Template File is not exist.");
            }
            if (string.IsNullOrEmpty(fileName))
            {
                if (fileName.Contains(".") == false)
                {
                    throw new Exception("File name needs extions");
                }
                throw new Exception("Arguments is not valid");
            }
            if (string.IsNullOrEmpty(argumentStartSign))
            {
                throw new Exception("Arguments sign is not valid");
            }
            if (string.IsNullOrEmpty(argumentEndSign))
            {
                throw new Exception("Arguments sign is not valid");
            }
        }

        public string GetContent(string templateFilePath)
        {
            if (IsTemplateExist(templateFilePath) == false)
            {
                throw new Exception("Template file is not exist.");
            }
            var tempalteText = File.ReadAllText(templateFilePath);
            return tempalteText;
        }

        private static List<string> getBetween(string strSource, string strStart, string strEnd)
        {
            List<string> strList = new List<string>();
            var flag = true;
            while (flag)
            {
                int Start, End;
                if (strSource.Contains(strStart) && strSource.Contains(strEnd))
                {

                    Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    var value = strSource.Substring(Start, End - Start);
                    strSource = strSource.Remove(0, End);
                    strList.Add(value);
                }
                else
                {
                    flag = false;
                }
            }

            return strList;

        }

        private List<string> GetMissedParameterList(Dictionary<string, string> argumentDic, string[] templateParameterList)
        {
            var model = templateParameterList.Except(argumentDic.Select(x => x.Key)).ToList();
            if (model.Count == 0)
                return null;
            return model;
        }

        private List<string> GetExtraParameter(Dictionary<string, string> argumentDic, string[] templateParameterList)
        {
            var model = argumentDic.Select(x => x.Key).Except(templateParameterList).ToList();
            if (model.Count == 0)
                return null;
            return model;
        }

        
    }
}
