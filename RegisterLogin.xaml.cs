using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10084795_POE_Part2
{
    public partial class RegisterLogin : Window
    {

        public RegisterLogin()
        {
            InitializeComponent();
        }

        //Password Hashing method
        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashedPassword);
        }

        //Register button click
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeManagementEntities db = new TimeManagementEntities();

            //LINQ - Checking if there is a match between Usernames in the db and the username being submitted
            var usernameCheck = from d in db.People
                                where d.Username == this.txtRegUse.Text
                                select d;

            int check = usernameCheck.Count();
            //Error displays if the username submitted for registration is in the database
            if (check >= 1) 
            {
                MessageBox.Show("Username not available!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Error displays if the password and confirm password fields do not match
            else if(!(txtRegPass.Text.Contains(txtConfirmPass.Text)))
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Registration successfull
            else
            {
                Person personObject = new Person()
                {
                    Username = txtRegUse.Text,
                    Password = HashPassword(txtRegPass.Text)
                };

                db.People.Add(personObject);
                db.SaveChanges();

                MessageBox.Show("Registration Successful!\n" +
                    "Login to access the Time Management App", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Login button click
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeManagementEntities db = new TimeManagementEntities();

            //Checking whether the username submitted for logging in is in the db
            var userFound = db.People.Any(u => u.Username == txtLogUse.Text);
            if (userFound)
            {
                var login = from d in db.People
                            where d.Username == txtLogUse.Text
                            select d;

                Person personObject = login.SingleOrDefault();

                if (personObject.Password.ToString().Contains(HashPassword(txtLogPass.Text)))
                {
                    MessageBox.Show("Login Successful, Welcome "+ personObject.Username +" ! ","Error", 
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    //If login Successfull, TimeMangerWindow is displayed
                    TimeManagerWindow tMWin = new TimeManagerWindow();
                    tMWin.Show();
                    this.Close();
                }
                //User found - incorrect password used
                else
                {
                    MessageBox.Show("Incorrect Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            //Username not found
            else
            {
                MessageBox.Show("Username not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
