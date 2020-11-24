/*
Взять за основу задачу 6. Должно быть не менее 3 классов, которые наследуются от абстрактного класса. 
Используя рефлексию реализовать возможность создания  и вызова методов данных классов на форме. 
Написать код, который принимает путь к библиотеке классов и ищет все классы, которые реализуют интерфейс.  
Далее получают всю информацию о данных классах, и возвращают список из названий классов. 
На форме реализовать «дроплаун» с названиями классов. 
При выборе класса на форму должны динамически подгружаться все методы класса с возможностью ввода параметров пользователем. 
При нажатии кнопки «Выполнить» должен создаваться объект и выполняться выбранный метод.
*/

using System;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using Csh_7_library;

namespace Csh_7
{
    public partial class MainWindow : Window
    {
        private Reflection Reflection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            var pathToDirectory = PathToLib.Text;
            var interfaceName = InterfaceName.Text;
            var inpHandler = new FileManager();
            var preparedFileNames = inpHandler.GetStringFromDir(pathToDirectory);
            Reflection = new Reflection(interfaceName);
            string[] classesImplementedInterface = Reflection.GetNamesOfInterface(preparedFileNames);

            Classes.Items.Clear();
            foreach (var curr in classesImplementedInterface)
            {
                Classes.Items.Add(curr);
            }
        }

        private void Class_Selected(object sender, RoutedEventArgs e)
        {


            Methods.Items.Clear();
            foreach (var currMethodNameParams in Reflection.GetClassMethods(Classes.SelectedItem.ToString()))
            {
                string parameters = "";
                foreach (var param in currMethodNameParams.Value)
                {
                    parameters += param + "; ";
                }

                Methods.Items.Add(currMethodNameParams.Key + "( " + parameters + ")");
            }

            Constructors.Items.Clear();
            foreach (var currConstructorNameParams in Reflection.GetClassConstructors(Classes.SelectedItem.ToString()))
            {
                string parameters = "";
                foreach (var param in currConstructorNameParams.Value)
                {
                    parameters += param + "; ";
                }

                Constructors.Items.Add(Classes.SelectedItem.ToString() + "( " + parameters + ")");
            }

        }

        private void BTNOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                PathToLib.Text = dialog.FileName;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reflection.CreateInstance(Classes.SelectedItem.ToString(), ConstructorParams.Text);
            }
            catch (Exception) { }
        }

        private void Invoke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currMethodInfoFromForm = Methods.SelectedItem.ToString();
                var selectedMethodName = Regex.Replace(currMethodInfoFromForm, "\\(.*\\)", "");

                OutputText.AppendText(Reflection.InvokeMethod(Classes.SelectedItem.ToString(), selectedMethodName, MethodParams.Text) + "\n");
            }
            catch (Exception) { }
        }

        private void InterfaceName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void PathToLib_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}