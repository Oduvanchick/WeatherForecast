   M S B A M L   `   `   `  ����J  FWeatherForecast, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WeatherForecast.ViewsWeatherForecast.Views  5      )    #WeatherForecast.Views.AddCityDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WeatherForecast.Views     5      $	��170��5      $	��300��6     � WindowStartupLocation$  CenterScreen=�5	      $��Sylfaen)�5
       � 	Resources 5         	AddButton �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers	 P� Property
 P� Value N� EnterActions	 �� To �� TargetProperty g� Duration N� ExitActions  CancelButton��%�  &	        &	 �    �� 5   
   " ��6"   .�5      ��  � ��
 �����6+   �� 5       � �� �#007bff6+   �� 5       � ��$
 15 5q�6(   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�64   �� 5       �@��TextAlignment$ Center=�68   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   # z��6K   $ 3��6o   ._�5      �� 5      5      5       5       P� 5!      	 �@J�IsMouseOver$

 True��61    5"      �� 5#      .��5$      �� .��5%   "   ��  Blue61   $( "Background.(SolidColorBrush.Color)�6;   $ 0:0:0.1D�6z   6�   5&      5'       5)      �� 5*      .��5+      �� .��5,   "   ��  #007bff61   $( "Background.(SolidColorBrush.Color)�6>   $ 0:0:0.1D�6}   6�   5-      5.      50      P� 51      	 � {�$
 False��6/   . �52      ��  �@J�Opacity$	 0.7Q�60   6>   53      55      �� 57   
   " ��6%   .�58      ��  � ��
 �����6+   �� 59       � ��
 �����6+   �� 5:       � ��$
 15 5q�6(   �� 5;       � ��$ Center=�62   �� 5<       � ��$ Center=�64   �� 5=       �@��TextAlignment$ Center=�68   �� 5>       �@�Cursor$
 Hand��6'   �� 5@       � �� 5A      �� 5B      " ��6&   .R�5C      �� #��z��6!   # z��6K   $ 3��6o   ._�5D      �� 5E      5F      5H       5J      P� 5K      	 �@J�IsMouseOver$

 True��61    5L      �� 5M      .��5N      �� .��5O   "   ��  Gray61   $( "Background.(SolidColorBrush.Color)�6;   $ 0:0:0.1D�6z   6�   5P      5Q       5S      �� 5T      .��5U      �� .��5V   "   ��  DarkGray61   $( "Background.(SolidColorBrush.Color)�6?   $ 0:0:0.1D�6~   6�   5W      5X      5Z      P� 5[      	 � {�$
 False��6/   . �5\      ��  �@J�Opacity$	 0.7Q�60   6>   5]      5_      5`      .��5a      � $��20q�6    � RowDefinitions 5b   
   �� 5c      $��20 �6   �� 5d      $��20 �6   �� 5e      $
��Auto �6   .+�5h   
   �� $��Input city name:��6   �� 5i   
   -   5         ��Name$ cityName��5i      $��1��6$   $	��230��61   � 5k   
   $��2��6   $��Right=�6!   $��0 10 0 0q�6=   .+�5l      �� -   5         �� 	IsDefault$
 True��5l      #��[  6&   $��60��5n      $��0 0 10 0q�6#   $	��ADD��5o      �� 5p       �� IsCancel$
 True��6   #��[ 6%   $��60��6K   $��Cancel��6Y   5q      5r      5s      