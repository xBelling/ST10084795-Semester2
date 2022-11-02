using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ST10084795_ClassLibrary_Part2;

namespace ST10084795_POE_Part2
{
    public partial class TimeManagerWindow : Window
    {
        SemesterAndModule sam = new SemesterAndModule();
        public TimeManagerWindow()
        {
            InitializeComponent();

            //Databinding - SemesterAndModules class
            this.DataContext = sam;
            //Visibility of the objects on the self study calculator screen
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            l5.Visibility = Visibility.Hidden;
            l6.Visibility = Visibility.Hidden;
            l7.Visibility = Visibility.Hidden;
            l8.Visibility = Visibility.Hidden;
            l9.Visibility = Visibility.Hidden;
            l95.Visibility = Visibility.Hidden;
            txtWeeks.Visibility = Visibility.Hidden;
            dpSem.Visibility = Visibility.Hidden;
            txtCode.Visibility = Visibility.Hidden;
            txtName.Visibility = Visibility.Hidden;
            txtCredits.Visibility = Visibility.Hidden;
            txtClassHrs.Visibility = Visibility.Hidden;
            dpStudy.Visibility = Visibility.Hidden;
            txtStudyHrs.Visibility = Visibility.Hidden;
            AddModule.Visibility = Visibility.Hidden;
            SelfStudyDataGrid.Visibility = Visibility.Hidden;
            ViewModules.Visibility = Visibility.Hidden;

            TimeManagementEntities db = new TimeManagementEntities();

            //Loading data to Module Data Grid using LINQ
            var modules = from d in db.Modules
                          select d;

            this.ModuleDataGrid.ItemsSource = modules.ToList();

            //Loading data to the Self Study Data Grid using LINQ
            var selfStudy = from d in db.SelfStudies
                            select d;

            this.SelfStudyDataGrid.ItemsSource = selfStudy.ToList();
        }

        private void AddModule_Click(object sender, RoutedEventArgs e)
        {
            //Variable used for datatype validation
            int validate;
            if (txtWeeks.Text.Length == 0 || dpSem.Text.Length == 0 || txtCode.Text.Length == 0 ||
                txtName.Text.Length == 0 || !int.TryParse(txtCredits.Text, out validate) ||
                !int.TryParse(txtClassHrs.Text, out validate) || !int.TryParse(txtStudyHrs.Text, out validate) ||
                dpStudy.Text.Length == 0)
            {
                MessageBox.Show("Invalid Entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Creation of the object to the ADO.net model
                TimeManagementEntities db = new TimeManagementEntities();

                SemesterAndModule temp = new SemesterAndModule();

                temp.semWeeks = txtWeeks.Text;
                temp.semStart = dpSem.Text;
                temp.modCode = txtCode.Text;
                temp.modName = txtName.Text;
                temp.modCredits = txtCredits.Text;
                temp.modWeekClassHrs = txtClassHrs.Text;

                //Weekly study hours calculation method call
                temp.WeeklySSHrsCalc(Convert.ToDouble(sam.modCredits), Convert.ToDouble(sam.semWeeks),
                    Convert.ToDouble(sam.modWeekClassHrs));

                var moduleCodeCheck = from d in db.Modules
                                      where d.ModuleCode == this.txtCode.Text
                                      select d;

                int check = moduleCodeCheck.Count();
                if (check == 0)
                {
                    //Adding data to the Module Table
                    Module moduleObject = new Module()
                    {
                        StartDate = dpSem.Text,
                        TotalWeeks = Convert.ToInt32(txtWeeks.Text),
                        ModuleCode = txtCode.Text,
                        ModuleName = txtName.Text,
                        Credits = Convert.ToInt32(txtCredits.Text),
                        ClassHours = Convert.ToInt32(txtClassHrs.Text),
                        RequiredStudyHrs = temp.hrsReqCurrentWeek
                    };

                    // pass all textboxes into the db
                    db.Modules.Add(moduleObject);
                    db.SaveChanges();
                }

                //Current Week calculation method call
                temp.CurrentWeekCalc(Convert.ToDateTime(sam.semStart), Convert.ToDateTime(sam.hrsFinDate));
                
                //Remaining study hours calculation method call
                temp.RemainingSSHrsCalc(temp.hrsReqCurrentWeek, Convert.ToDouble(sam.hrsFinCurrentWeek));

                //Adding data to the Self Study Table
                SelfStudy selfStudyObject = new SelfStudy()
                {
                    ModuleCode = txtCode.Text,
                    Week = temp.currentWeek,
                    StudyDate = dpStudy.Text,
                    FinishedStudyHrs = Convert.ToInt32(sam.hrsFinCurrentWeek),
                    RemainingStudyHrs = temp.hrsRemCurrentWeek
                };
                // pass all textboxes into the db
                db.SelfStudies.Add(selfStudyObject);
                db.SaveChanges();

                //Loading data to Module Data Grid using LINQ
                var modules = from d in db.Modules
                              select d;

                this.ModuleDataGrid.ItemsSource = modules.ToList();

                //Loading data to the Self Study Data Grid using LINQ
                var selfStudy = from d in db.SelfStudies
                                select d;

                this.SelfStudyDataGrid.ItemsSource = selfStudy.ToList();

                txtWeeks.IsReadOnly = true;
                dpSem.IsEnabled = false;
            }
        }

        //Changing visibility of objects based on which screen is selected
        private void ViewModules_Selected(object sender, RoutedEventArgs e)
        {
            title.Visibility = Visibility.Visible;
            ModuleDataGrid.Visibility = Visibility.Visible;
            ViewSelfStudy.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;

            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            l5.Visibility = Visibility.Hidden;
            l6.Visibility = Visibility.Hidden;
            l7.Visibility = Visibility.Hidden;
            l8.Visibility = Visibility.Hidden;
            l9.Visibility = Visibility.Hidden;
            l95.Visibility = Visibility.Hidden;
            txtWeeks.Visibility = Visibility.Hidden;
            dpSem.Visibility = Visibility.Hidden;
            txtCode.Visibility = Visibility.Hidden;
            txtName.Visibility = Visibility.Hidden;
            txtCredits.Visibility = Visibility.Hidden;
            txtClassHrs.Visibility = Visibility.Hidden;
            dpStudy.Visibility = Visibility.Hidden;
            txtStudyHrs.Visibility = Visibility.Hidden;
            AddModule.Visibility = Visibility.Hidden;
            SelfStudyDataGrid.Visibility = Visibility.Hidden;
            ViewModules.Visibility = Visibility.Hidden;

            ViewSelfStudy.SelectedItem = null;
        }

        //Changing visibility of objects based on which screen is selected
        private void ViewSelfStudy_Selected(object sender, RoutedEventArgs e)
        {
            title.Visibility = Visibility.Hidden;
            ModuleDataGrid.Visibility = Visibility.Hidden;
            ViewSelfStudy.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;

            l2.Visibility = Visibility.Visible;
            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;
            l5.Visibility = Visibility.Visible;
            l6.Visibility = Visibility.Visible;
            l7.Visibility = Visibility.Visible;
            l8.Visibility = Visibility.Visible;
            l9.Visibility = Visibility.Visible;
            l95.Visibility = Visibility.Visible;
            txtWeeks.Visibility = Visibility.Visible;
            dpSem.Visibility = Visibility.Visible;
            txtCode.Visibility = Visibility.Visible;
            txtName.Visibility = Visibility.Visible;
            txtCredits.Visibility = Visibility.Visible;
            txtClassHrs.Visibility = Visibility.Visible;
            dpStudy.Visibility = Visibility.Visible;
            txtStudyHrs.Visibility = Visibility.Visible;
            AddModule.Visibility = Visibility.Visible;
            SelfStudyDataGrid.Visibility = Visibility.Visible;
            ViewModules.Visibility = Visibility.Visible;

            ViewModules.SelectedItem = null;
        }

        //Double click event on the Module data grid
        private void ModuleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.ModuleDataGrid.SelectedIndex >= 0)
            {
                if (this.ModuleDataGrid.SelectedItems.Count >= 0)
                {
                    if (this.ModuleDataGrid.SelectedItems[0].GetType() == typeof(Module))
                    {
                        Module d = (Module)this.ModuleDataGrid.SelectedItems[0];
                        this.txtCode.Text = d.ModuleCode;
                    }
                }
            }
        }

        //Delete Module from both datgrids and from the database
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Confirmation check
            MessageBoxResult msg = MessageBox.Show("Are you sure you want to delete this module? ",
                "Delete peron",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No);

            //if the user chooses yes 
            if (msg == MessageBoxResult.Yes)
            {
                //Using LINQ object to the DB
                TimeManagementEntities db = new TimeManagementEntities();
                var moduleDelete = from d in db.Modules
                                   where d.ModuleCode == this.txtCode.Text
                                   select d;
                Module moduleObject = moduleDelete.SingleOrDefault();
                if (moduleObject != null)
                {
                    db.Modules.Remove(moduleObject);
                    db.SaveChanges();
                }

                var selfStudyDelete = from d in db.SelfStudies
                                      where d.ModuleCode == this.txtCode.Text
                                      select d;

                while (selfStudyDelete.Count() >= 1)
                {
                    SelfStudy selfStudyObject = selfStudyDelete.First();

                    if (selfStudyObject != null)
                    {
                        db.SelfStudies.Remove(selfStudyObject);
                        db.SaveChanges();
                    }
                }

                //Loading data to Module Data Grid using LINQ
                var modules = from d in db.Modules
                              select d;

                this.ModuleDataGrid.ItemsSource = modules.ToList();

                //Loading data to the Self Study Data Grid using LINQ
                var selfStudy = from d in db.SelfStudies
                                select d;

                this.SelfStudyDataGrid.ItemsSource = selfStudy.ToList();
            }
        }
    }
}
