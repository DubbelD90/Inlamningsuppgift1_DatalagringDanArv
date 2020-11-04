using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SharedLibrary;
using SharedLibrary.Helpers;
using System.Threading.Tasks;
using Windows.Storage;
using System.Collections.ObjectModel;
using Windows.Storage.Streams;
using System.Xml;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        List<Person> persons = new List<Person>();
         
        StorageFolder storageFolder;
        StorageFile storageFile;

        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Funktioner för att skapa fil, lägga till text och läsa fil från picker

        private async Task GetFileContentAsync(string fileName)
        {
            tbListView.Text = await FileHelper.GetFileContentAsync(fileName);
        }
        /*
        private async Task CreateFileAsync()
        {
            //storageFolder = KnownFolders.DocumentsLibrary;
            //storageFile = await storageFolder.CreateFileAsync(_fileName, CreationCollisionOption.FailIfExists);
            //CreateFileAsync().GetAwaiter();
        }

        private async Task WriteToFileAsync()
        {
            //await FileIO.WriteTextAsync(storageFile, "");
            //WriteToFileAsync().GetAwaiter();
        }
        */

        #endregion


        #region Buttons
        private void btnAddJson_Click(object sender, RoutedEventArgs e)
        {
            //JsonService.WriteToFile();
            //JsonService.WriteToFile(@"C:\Users\dcloc\Documents\Persons.json", new Person(tbFirstName.Text, tbLastName.Text, Convert.ToInt32(tbAge.Text)));
        }
        private void btnAddCsv_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnAddXml_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAddTxt_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.List
            };
            picker.FileTypeFilter.Add(".csv");
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".json");
            picker.FileTypeFilter.Add(".txt");

            var file = await picker.PickSingleFileAsync();
            string FileName = file.Name;
            GetFileContentAsync(FileName).GetAwaiter();
        }
        private async void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            storageFolder = KnownFolders.DocumentsLibrary;

            if (tbFileName.Text != null)
            {
                if (cbFile.SelectedItem == null)
                {
                    tbListView.Text = "You need to choose a filetype!";
                }
                else if(cbFile.SelectedItem.ToString() == "json")
                {
                    try
                    {
                        storageFile = await storageFolder.CreateFileAsync($"{tbFileName.Text}.json", CreationCollisionOption.FailIfExists);
                        tbListView.Text = "File created";
                    }
                    catch
                    {
                    tbListView.Text = "File allready exists created";
                    }
                }
                else if (cbFile.SelectedItem.ToString() == "xml")
                {
                    try
                    {
                        storageFile = await storageFolder.CreateFileAsync($"{tbFileName.Text}.xml", CreationCollisionOption.FailIfExists);
                        tbListView.Text = "File created";
                    }
                catch
                    {
                        tbListView.Text = "File allready exists created";
                    }
                }
                else if (cbFile.SelectedItem.ToString() == "csv")
                {
                    try
                    {
                        storageFile = await storageFolder.CreateFileAsync($"{tbFileName.Text}.csv", CreationCollisionOption.FailIfExists);
                        tbListView.Text = "File created";
                    }
                    catch
                    {
                    tbListView.Text = "File allready exists created";
                    }
                }
                else if (cbFile.SelectedItem.ToString() == "txt")
                {
                    try
                    {
                        storageFile = await storageFolder.CreateFileAsync($"{tbFileName.Text}.txt", CreationCollisionOption.FailIfExists);
                        tbListView.Text = "File created";
                    }
                    catch
                    {
                        tbListView.Text = "File allready exists created";
                    }
                }
            }
            else
            {
                tbListView.Text = "You need to enter a name for the file!";
            }
        }
        #endregion
    }
}
