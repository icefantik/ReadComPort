   M S B A M L   `   `   `  ����F  BReadComPort, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ReadComPortReadComPort  5   	       ReadComPort.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ReadComPort     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��530 �6   �� 5      $	��155 �6   �� 5      $��3 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��20* �6   �� 5      $
��385* �6   .+�5   
   �� -   5         ��Name$ StartReadData��5      $��0��6D   $��0��6T   $��Start��6a   �� 5   
   -   5        $ StopReadData��5      $��1��6B   $
��Stop��6O   �� 5   
   -   5         ��Name$ BoxComPorts��5      $��2��6(   68   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridPort��5         
IsReadOnly$
 True��6)      AutoGenerateColumns$ False��6;   $��1��6W   $��3��6g      DComPort#���   6x   5      5      