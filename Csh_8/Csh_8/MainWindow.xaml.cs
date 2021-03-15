using System;
using System.Windows;

namespace Csh_8
{
    public partial class MainWindow : Window
    {
        private Reflection Reflection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var pathToDirectory = "C:\\Users\\gorbushin_v_a\\source\\repos\\Csh_8\\Csh_8_library";
            var interfaceName = "IRaceElement";
            var inpHandler = new FileManager();
            var preparedFileNames = inpHandler.GetStringFromDir(pathToDirectory);
            Reflection = new Reflection(interfaceName);
            string[] classesImplementedInterface = Reflection.GetNamesOfInterface(preparedFileNames, pathToDirectory);

            Classes.Items.Clear();
            for (int i = 1; i<6; i++)
            {
                Classes.Items.Add(i);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(Classes.SelectedItem.ToString());
                Reflection.CreateAndInvokeMethod(n);
            }
            catch (Exception) { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Clear();
        }
    }
}