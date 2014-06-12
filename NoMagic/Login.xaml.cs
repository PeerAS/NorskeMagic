using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Web.Http;

namespace NoMagic
{
    public partial class Page1 : PhoneApplicationPage
    {
        HttpWebRequest loginClient;
        string userNameInput;
        string passWordInput;
        Uri address;

        public Page1()
        {
            InitializeComponent();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userNameInput = userNameBox.Text;
            passWordInput = passwordBox.Password;


            if(userNameInput.Length == 0 || passWordInput.Length == 0)
            {
                MessageBox.Show("You have forgotten to specify a username/password");
            }
            else
            {
                address = new Uri("http://www.norskemagic.com/login.php");
                loginClient = (HttpWebRequest)WebRequest.Create(address);
                loginClient.ContentType = "application/x-www-form-urlencoded";
                loginClient.Method = "POST";

                string postData = "loginusername=" + userNameInput + "&password=" + passWordInput;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                loginClient.ContentLength = byteArray.Length;

                //Stream dataStream = loginClient.GetRequestStreamAsync();
                

            }

        }


        
           
            
        
    }
}