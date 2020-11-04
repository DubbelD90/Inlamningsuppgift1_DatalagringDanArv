using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;
using Windows.UI.Xaml.Shapes;

namespace SharedLibrary.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> GetFileContentAsync(string fileName)
        {
            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
            StorageFile storageFile = await storageFolder.GetFileAsync(fileName);

            string text = await FileIO.ReadTextAsync(storageFile);

            var ext = fileName.Split('.');

            if (storageFile != null)
            {
                if (ext[1] == "json")
                {
                    //var json = JsonConvert.DeserializeObject<dynamic>(text);
                    //return json;

                    return await FileIO.ReadTextAsync(storageFile);
                }
                else if (ext[1] == "xml")
                {
                    /*
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(text);

                    foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                    {
                        string textoutput = node.InnerText;

                        return node.InnerText;

                    }
                    */
                    return await FileIO.ReadTextAsync(storageFile);
                    
                }
                else if (ext[1] == "csv")
                {
                    //CSVService.ReadCsvFromFile(text);
                    /*
                    var lines = (await FileIO.ReadLinesAsync(storageFile)).ToList();

                    foreach (var line in lines)
                    {
                        var data = line.Split(';');
                        return $"{data[0]} {data[1]} { data[2]}";
                    }
                    */
                    //await FileIO.ReadLinesAsync(storageFile);
                }
                else if (ext[1] == "txt")
                {
                    return await FileIO.ReadTextAsync(storageFile);
                }

            }
            else
            {
                return "Failed. Try choosing one of following filetypes: Json, XML, CSV or txt";
            }

            return await FileIO.ReadTextAsync(storageFile);
            /*
            if (storageFile != null)
            {

                if (storageFile.ContentType == "text/xml")
                {
                    string text = await FileIO.ReadTextAsync(storageFile);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(text);

                    foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                    {
                        string textoutput = node.InnerText;

                        try
                        {
                            tbListView.Text = textoutput;
                        }
                        catch { }
                    }
                }
                else if (file.ContentType == "application/json")
                {
                    var path = storageFile.Path;
                    string text = await FileIO.ReadTextAsync(storageFile);
                    var obj = JsonConvert.DeserializeObject<dynamic>(text);

                    try
                    {
                        tbListView.Text = obj.message;
                    }
                    catch { }
                }
            }
            else
            {
                this.tbListView.Text = "Operation cancelled";
            }
            */
        }
    }
}
