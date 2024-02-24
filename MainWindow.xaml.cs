// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WpfApp2;
using WpfApp2.Model;


namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        
        List<Employee> employeeList = new List<Employee>();
        List<string> employeeData = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            initComp();
        }

        public void initComp()
        {
            radioButtonHourly.IsChecked =true;

        }

        private void radioButtonHourly_Checked(object sender, RoutedEventArgs e)
        {
            //if (radioButtonHourly.IsChecked == false)
            //{
            //    lblHWorked.Content = "Hourly Worked";
            //    lblHWages.Content = "Hourly Wages";
            //}

            //ar checkedButton = container.Children.OfType<RadioButton>().FirstOrDefault(r => (bool)r.IsChecked);

            HideCommissionLabels();
            HideWeeklySalaryLabels();
            ShowHourlyLabels();
        }

        private void radioButtonCommission_Checked(object sender, RoutedEventArgs e)
        {
            if(radioButtonCommission.IsChecked == true)
            {
                lblHWorked.Content = "Gross Sales";
                lblHWages.Content = "Comission Rate";

            }
            //// Show/hide relevant labels and textboxes for CommissionEmployee
            //HideHourlyLabels();
            //HideWeeklySalaryLabels();
            //ShowCommissionLabels();
        }

        // Helper methods to show/hide labels and textboxes for specific employee types

        private void ShowHourlyLabels()
        {
            //textBlockHoursWorked.Visibility = Visibility.Visible;
            //textBlockHourlyWage.Visibility = Visibility.Visible;
            //textBoxHoursWorked.Visibility = Visibility.Visible;
            //textBoxHourlyWage.Visibility = Visibility.Visible;
        }

        private void HideHourlyLabels()
        {
            //textBlockHoursWorked.Visibility = Visibility.Collapsed;
            //textBlockHourlyWage.Visibility = Visibility.Collapsed;
            //textBoxHoursWorked.Visibility = Visibility.Collapsed;
            //textBoxHourlyWage.Visibility = Visibility.Collapsed;
        }

        private void ShowCommissionLabels()
        {
            //textBlockHoursWorked.Text = "Gross Sales:";
            //textBlockHourlyWage.Text = "Commission Rate:";
            //textBlockHoursWorked.Visibility = Visibility.Visible;
            //textBlockHourlyWage.Visibility = Visibility.Visible;
            //textBoxHoursWorked.Visibility = Visibility.Visible;
            //textBoxHourlyWage.Visibility = Visibility.Visible;
        }

        private void HideCommissionLabels()
        {
           // //textBlockHoursWorked.Visibility = Visibility.Collapsed;
           //// textBlockHourlyWage.Visibility = Visibility.Collapsed;
           // textBoxHoursWorked.Visibility = Visibility.Collapsed;
           // textBoxHourlyWage.Visibility = Visibility.Collapsed;
        }

        private void HideWeeklySalaryLabels()
        {
            //textBlockHoursWorked.Visibility = Visibility.Collapsed;
            //textBlockHourlyWage.Visibility = Visibility.Collapsed;
            //textBoxHoursWorked.Visibility = Visibility.Collapsed;
            //textBoxHourlyWage.Visibility = Visibility.Collapsed;
        }



        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBoxName.Text))
                {
                    MessageBox.Show("EmployeeName Cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var uniqueID = GenerateUniqueId();
                var employeeName = textBoxName.Text;

                decimal federalTax = 0.20M;
                decimal hourWorked =  Convert.ToDecimal(textBoxHoursWorked.Text);
                decimal hourlyWage = Convert.ToDecimal(textBoxHourlyWage.Text);             

                Employee employee;

                if(radioButtonHourly.IsChecked == true)
                {
                    if(hourWorked<=0)
                    {
                        MessageBox.Show("Employee Houry worked invalid, enter positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }                    
                    employee = new HourlyEmployee
                    {
                    EmpType = EmployeeType.HourlyEmployee,
                    HoursWorked = hourWorked,
                    HourlyWage = hourlyWage,
                    ID = uniqueID,
                    Name = employeeName
                    };                  

                }
                else if(radioButtonCommission.IsChecked == true)
                {
                    employee = new CommissionEmployee
                    {
                    EmpType = EmployeeType.CommissionEmployee,
                    GrossSales = hourWorked,
                    CommissionRate = hourlyWage,
                    ID = uniqueID,
                    Name = employeeName
                };

                 
                    //comissionEmployee.grossEarning = hourlyWage * hourWorked;
                }
                else 
                {
                    employee = new SalariedEmployee
                    {
                    WeeklySalary = hourlyWage,
                    ID = uniqueID,
                    Name = employeeName

                    };
                           
                }

            
                string CompletedValue = uniqueID + " " + textBoxName.Text;
                employeeData.Add(CompletedValue);

                listBoxEmployees.ItemsSource = employeeData.ToList();

                employeeList.Add(employee);

            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {

            // Implement logic to clear all fields except ListBox
            textBoxName.Clear();
            textBoxHoursWorked.Clear();
            textBoxHourlyWage.Clear();
            textBoxGrossEarning.Clear();
            textBoxTax.Clear();
            textBoxNetEarning.Clear();
           
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void listBoxEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var employeInfo = listBoxEmployees.SelectedItem.ToString();

            if(employeInfo != "")
            {
                foreach (var item in employeeList)
                {
                    var empUni = item.ID + " " + item.Name;
                    if(empUni == employeInfo)
                    {
                        textBoxGrossEarning.Text = item.GrossEarning.ToString();
                        textBoxNetEarning.Text= item.NetEarning.ToString();
                        textBoxTax.Text= item.Tax.ToString();
                    }
                }
            }
            else
            {

                MessageBox.Show("Employee Information is not available");
            }
        
        }

        private void textBoxName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle changes in the Name TextBox

            // Basic validation: Ensure the Name is not empty
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxName.Clear(); // Clear the TextBox
                return;
            }

            // Additional validation or logic can be added as needed
        }

       

        private void textBoxHoursWorked_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle changes in the Hours Worked TextBox
            // You can add validation or other logic here
            if (double.TryParse(textBoxHoursWorked.Text, out double hoursWorked))
            {
                // Validation successful, you can use the 'hoursWorked' variable
                // Add your logic here
            }
            else
            {
                MessageBox.Show("Invalid input for Hours Worked. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxHoursWorked.Clear();
            }
        }

        private void textBoxHourlyWage_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle changes in the Hourly Wage TextBox
            // You can add validation or other logic here
            if (double.TryParse(textBoxHourlyWage.Text, out double hourlyWage))
            {
                // Validation successful, you can use the 'hourlyWage' variable
                // Add your logic here
            }
            else
            {
                MessageBox.Show("Invalid input for Hourly Wage. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxHourlyWage.Clear();
            }
        }

        private void textBoxGrossEarning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxTax_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxNetEarning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void radioButtonWeekly_Checked(object sender, RoutedEventArgs e)
        {

            if (radioButtonWeekly.IsChecked == true)
            {
                lblHWorked.Content = "Weekly Salary";
                lblHWages.Content = "Hourly Wage";

            }
        }

        ////private void textBoxGrossEarning_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        public static int GenerateUniqueId()
        {
          
            var rand = new Random();
             int randomNumber = rand.Next(1000, 9999); // Adjust the range as needed
          

            return randomNumber;
        }
    }



}
