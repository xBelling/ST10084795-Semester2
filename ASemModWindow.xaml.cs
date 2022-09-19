using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
using POE_PartOne_ST10084795_ClassLibrary;

namespace POE_PartOne_ST10084795
{
    //Class for the Add Semester Window
    public partial class ASemModWindow : Window
    {

        //Object of the SemesterAndModules Class creation
        SemesterAndModule sam = new SemesterAndModule();

        public ASemModWindow()
        {
            InitializeComponent();

            //Databinding - SemesterAndModules class
            this.DataContext = sam;

            lb.Visibility = Visibility.Hidden;
            b4.Visibility = Visibility.Hidden;

        }

        //Add New Module Button
        private void AddModuleButton(object sender, RoutedEventArgs e)
        {
            //Variable used for datatype validation
            int validate;

            //Error Message if an invalid entry for total semester weeks is entered
            if (tb1.Text.Length == 0)
            {
                MessageBox.Show("Total weeks in the semester entry is invalid!", "Error");
            }
            //Error Message if an invalid entry for start of semester is entered
            else if (dp1.Text.Length == 0)
            {
                MessageBox.Show("Select a date for the start of the current semester!", "Error");
            }
            //Error Message if an invalid entry for the module code is entered
            else if (tb2.Text.Length == 0)
            {
                MessageBox.Show("Module Code cannot be left blank!", "Error");
            }
            //Error Message if an invalid entry for the module name is entered
            else if (tb3.Text.Length == 0)
            {
                MessageBox.Show("Module Name cannot be left blank!", "Error");
            }
            //Error Message if an invalid entry for the module credits is entered
            else if (!int.TryParse(tb4.Text, out validate))
            {
                MessageBox.Show("Module Credits entry is invalid!", "Error");
            }
            //Error Message if an invalid entry for the weekly module class hours is entered
            else if (!int.TryParse(tb5.Text, out validate))
            {
                MessageBox.Show("Weekly module class hours entry is invalid!", "Error");
            }
            //Error Message if an invalid entry for the Number of hours is entered
            else if (!int.TryParse(tb6.Text, out validate))
            {
                MessageBox.Show("Number of hours studied entry is invalid!", "Error");
            }
            //Error Message if an invalid entry for the date that the studied work was completed is entered
            else if (dp2.Text.Length == 0)
            {
                MessageBox.Show("Select a date for when the module was studied!", "Error");
            }
            //If there are no invalid entries - data is added to the datagrid
            else
            {
                SemesterAndModule temp = new SemesterAndModule();

                temp.semWeeks = tb1.Text;
                temp.semStart = dp1.Text;
                temp.modCode = tb2.Text;
                temp.modName = tb3.Text;
                temp.modCredits = tb4.Text;
                temp.modWeekClassHrs = tb5.Text;

                //Weekly study hours calculation method call
                temp.WeeklySSHrsCalc(Convert.ToDouble(sam.modCredits), Convert.ToDouble(sam.semWeeks), Convert.ToDouble(sam.modWeekClassHrs));

                //Remaining study hours calculation method call
                temp.RemainingSSHrsCalc(temp.hrsReqCurrentWeek,  Convert.ToDouble(sam.hrsFinCurrentWeek));

                //Current Week calculation method call
                temp.CurrentWeekCalc(Convert.ToDateTime(sam.semStart), Convert.ToDateTime(sam.hrsFinDate));

                //Values added to the list to be displayed on the listbox
                sam.hrsRemList.Add(temp.hrsRemCurrentWeek + " Hours of self study time remaining for " + temp.modName + " in week " +
                    temp.currentWeek + " of the current semester.");

                //Values are added to the datagrid
                dg.Items.Add(temp);

                
                //the textboxes are reset
                tb2.Clear();
                tb3.Clear();
                tb4.Clear();
                tb5.Clear();
                tb6.Clear();
                dp2.Text = Convert.ToString(DateTime.Now);

                tb1.IsReadOnly = true;
                dp1.IsEnabled = false;

            }
        }

        //Clears the datagrid, textboxes, datepickers and hours of self study remaining list when the ResetButton is selected
        private void ResetGridButton(object sender, RoutedEventArgs e)
        {
            //Confirmation of grid reset
            if (MessageBox.Show("Are you sure you want to delete all of the items in the table?",
                "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                dg.Items.Clear();
                sam.hrsRemList.Clear();

                //Clears all of the text boxes and date pickers
                tb1.Clear();
                dp1.Text = Convert.ToString(DateTime.Now);
                tb2.Clear();
                tb3.Clear();
                tb4.Clear();
                tb5.Clear();
                tb6.Clear();
                dp2.Text = Convert.ToString(DateTime.Now);

                tb1.IsReadOnly = false;
                dp1.IsEnabled = true;
            }
        }

        //Menu Button - takes user back to the menu screen
        private void MenuButton(object sender, RoutedEventArgs e)
        {
            //Confirmation of returning to the menu
            if (MessageBox.Show("Are you sure you want to return to the menu?\n" +
                "All information in the table will be lost.", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MenuWindow menWin = new MenuWindow();
                menWin.Show();
                this.Close();
            }
        }

        //View the list of modules sorted using LINQ
        private void ViewHoursButton(object sender, RoutedEventArgs e)
        {
            if (dg.Items.Count == 0)
            {
                MessageBox.Show("Add a module first!", "Error");
            }
            else
            {
                lb.Visibility = Visibility.Visible;
                b4.Visibility = Visibility.Visible;

                dg.Visibility = Visibility.Hidden;
                b3.Visibility = Visibility.Hidden;

                tb2.IsReadOnly = true;
                tb3.IsReadOnly = true;
                tb4.IsReadOnly = true;
                tb5.IsReadOnly = true;
                tb6.IsReadOnly = true;

                dp2.IsEnabled = false;

                b1.IsEnabled = false;

                lb.Items.Clear();

                //List box items sorted to display the module with the most self study hours remaining first
                var ordering =
                from value in sam.hrsRemList
                orderby value descending
                select value;

                foreach (var item in ordering)
                {
                    lb.Items.Add(item.ToString());
                }
            }
        }
        //Takes the user back to the adding modules screen
        private void BackButton(object sender, RoutedEventArgs e)
        {
            lb.Visibility = Visibility.Hidden;
            b4.Visibility = Visibility.Hidden;

            b3.Visibility = Visibility.Visible;
            dg.Visibility= Visibility.Visible;

            tb2.IsReadOnly = false;
            tb3.IsReadOnly = false;
            tb4.IsReadOnly = false;
            tb5.IsReadOnly = false;
            tb6.IsReadOnly = false;

            dp2.IsEnabled = true;

            b1.IsEnabled = true;
        }
    }
}
