   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��
Employees:��6   $
��Bold"�6&   $��10q�68   $��0��6D   $��0��6T   �� 5   
   -   5         ��Name$ textBlockEnteredText��5      $��10q�62   �� 5   
   -   5         ��Name$ listBoxEmployees��5      $��2��6,   $��
10,0,10,30q�6=   $��1��6Q   6^   �� 5   
   $��1��6   $��0��6%   $��10q�62   .+�5      �� �� 6   $�Select type of employee:��6   �� 6?   �� 6K   6R   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      	� -   5         	�Name$ radioButtonHourly��5      $��Hourly Paid��69    d� 	IsChecked$
 TrueY�6O   6`   	� 5      -   5        $ radioButtonCommission��5      $��Commission Based��6=   6X   	� 5       -   5        $ radioButtonWeekly��5       $��Weekly Salary��69   6Q   5!      5"      �� 5$   
   $��1��6   $��1��6%   $��10,10,54,10q�62   .+�5%      �� $'��!Input the employee's information:��6   $
��Bold"�6A   �� 5&      -   5         ��Name$ lblName��5&      $
��Name��6%   $��82��64   $
��Left=�6?   �� 5'      -   5        	 ��Name$	 textBoxName��5'      $	��187��6Q   $
��Left=�6]   �� 5(      -   5        $ 
lblHWorked��5(      $��Hours Worked��6(   $	��101��6?   $
��Left=�6K   �� 5)      -	   5        $	 textBoxHoursWorked��5)      $	��185��6_   $
��Left=�6k   �� 5*      -
   5        $ 	lblHWages��5*      $��Hourly Wages��6'   $	��109��6>   $
��Left=�6J   �� 5+      -   5        $	 textBoxHourlyWage��5+      $	��188��6]   $
��Left=�6i   5,      �� 50   
   $��1��6   $��1��6%   $��411,8,-246,147q�62   $��2��6J   .+�51      �� -   5        $��	Calculate��51      $��0,10,0,0q�6G   $��43��6Y   �� 52      -   5        $��Clear��52      $��0,5,0,0q�6?   $��41��6P   �� 53      -   5        $��Close��53      $��0,5,0,0q�6?   $��47��6P   54      �� 56   
   $��3��6   $��2��6%   $��10q�62   .+�57      �� $
��Bold"�6   �� 6+   $�Calculated Wage��6/   �� 6H   �� 6T   6[   �� 58      $
��Bold"�6   �� 6+   $�Gross Earnings: ��6/   6J   �� 59      -   5        $	 textBoxGrossEarning��59      
 �� 
IsReadOnly$

 True��63   $��0,5,0,5q�6E   ${�False��6�   �� 5:      $
��Tax:��6   �� 5;      -   5        $	 
textBoxTax��5;      $

 True��6*   $��0,5,0,5q�6<   ${�False��6r   �� 5<      $��Net Earning:��6   �� 5=      -   5        $	 textBoxNetEarning��5=      $

 True��61   $��0,5,0,5q�6C   ${�False��6�   5>      5@      5E      