using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        HttpClient loginClient;
        string userNameInput;
        string passWordInput;
        Uri address;

        public Page1()
        {
            InitializeComponent();
            loginClient = new HttpClient();
            address = new Uri("http://www.norskemagic.com/login.php");
            
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
                string loginParameters = "loginusername=" + userNameInput + "&password=" + passWordInput;
                postLogin(address, loginParameters);
            }

        }
        
        private async void postLogin(Uri addressIn, string parametersIn)
        {
            var respons = await loginClient.PostAsync(address, new HttpStringContent(parametersIn));
            MessageBox.Show(respons.Content.ToString());
        }

           
            
        
    }
}