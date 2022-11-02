using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (messageText.Text == "")
            {
                MessageBox.Show("No message in text Box!", "Warning!");

            }
            else
            {
                string message = messageText.Text;
                messageText.Text = "";
                if(localName.Text == "")
                {
                    MessageBox.Show("Please enter a name in the Local Name Textbox!", "Warning");
                    messageText.Text = message;
                }
                else
                {
                    string name = localName.Text;
                    chatBox.Text += name + ": " + message + "\n";
                }
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string status = "Server Enabled";

            ThreadStart CheckThread = delegate ()
            {
                Dispatcher.Invoke(new Action<string>(SendMessage), status);
            };


            new Thread(CheckThread).Start(); 
        }

        private void SendMessage(string status)
        {
            chatBox.Text += status + "\n";
        }
    }
}
