   M S B A M L   `   `   `  ����O  KCompanyManagerSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CompanyManagerSystem.ViewCompanyManagerSystem.View  5   	   *    $CompanyManagerSystem.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:CompanyManagerSystem.View     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5          �Name$  mainWin��5   "    � Title$ 
MainWindow��5
   	    � WindowStartupLocation$ CenterScreen=�6   $	��700��5   	   $
��1420��6    � WindowStyle$
 None=�6#    � 
ResizeMode$ NoResize=�66   
������  � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main� � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ToggleButton.Checked��6   
 :� 
SourceName$
 toggle��6:   .[�5      �� .��5      �� .��5      r�  �� 
TargetName$ 	textBlock��67    �� TargetProperty$ (FrameworkElement.Margin)�6Y   .	�5      <  6System.Windows.Media.Animation.EasingThicknessKeyFrame   p� KeyTime$ 00:00:00.2000000��62    p� Value$ 14,0,0,0q�6M   5      U� 5      $ border��64   $ (FrameworkElement.Width)�6S   .\�5      9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 00:00:00.3000000��6/    O� Value$ 50Q�6J   5      5      5      5      :� 5   
   $	 ToggleButton.Unchecked��6   $
 toggle��6<   .[�5      �� .��5      �� .��5       r� $ 	textBlock��67   $ (FrameworkElement.Margin)�6Y   .	�5!        $ 00:00:00.2000000��62   $ 88,0,0,0q�6M   5"      U� 5#      $ border��64   $ (FrameworkElement.Width)�6S   .\�5$        $ 00:00:00.3000000��6/   $	 200Q�6J   5%      5&      5'      5(      .��5*      �� ���#334157
���   �$��1q�66   ._�5+   
   � 
������  � ColumnDefinitions 5,      �� 5-      $
��auto �6#   �� 5.       � RowDefinitions 50      �� 51      $��30��6    �� 52      $��60��6    �� 53      .+�57      � -   5         �Name$	 top��57   *   
�������$��2��67   .+�58      �� $��后台管理系统��6   $��16(�6*   $��SemiBold"�68   $��10 0 0 0q�6N   $��Center=�6`   �� 59       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Right=�6Q   .+�5;      �� -   5         ��Name$ MinBtn��5;        minStyle#��[ 6-    � Cursor$
 Hand��6O   .��5=      F� $��13��6   $��13��6*     WindowMinGeometry#��[ 66   ���#494949 �� Stretch$ Uniform=�6o    � ToolTip$ 	最小化��6�   5>      �� 5@      -   5        $ MaxBtn��5@        maxStyle#��[ 6-   $
 Hand��6O   .��5A      F� $��13��6   $��13��6*     WindowMaxGeometry#��[ 66   ���#494949$ Uniform=�6o   $ 	最大化��6�   5B      �� 5D      -   5        $ CloseBtn��5D        
closeStyle#��[ 6/   $
 Hand��6S   .��5E      F� -   5         F�Name$ 	closePath��5E      $��13��62   $��13��6=     CloseGeometry#��[ 6I   ���#494949$ Uniform=�6~   $ 关闭��6�   5F      5G      5H      �� 5K      -   5         ��Name$ border��5K      $��1��6%   $��0��62   $��2��6B   $	��200��5L      ���#334157$��Right=�6:   ._�5M      �  5N      �� 5O      $��60 �6(   �� 5P      .+�5S      �� -   5         ��Name$ 	textBlock��5S   0   $	����6    $��88 0 0 0q�6C   $��/Themes/Style/#iconfont)�5T       $��24(�6E     DefaultBrush#��[ 5U       $��Center=�6K   �� 5X      $��1��6!    6.   �� *
Navigation+# [  .+�5Z      	�  	� 	GroupName$ menuRadioGroup��6&     HomeRadioButtonStyle#��[ 6A   
 � Tag$	 ��5[   &   $��首页��65   $��14(�6B   ��6P   �� *HomeCommand+�� 5^      ��6'   �� *MenuBarList+��5_      �� 5a   "   .R�5b   &   9�  	 ExpanderStyle#��� 	 6/   ���#334157���#BFCBD9$��0q�5c   Y    9� 
IsExpanded 5b   W   �� *
IsExpanded+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5d   *   +  %Microsoft.Xaml.Behaviors.EventTrigger  5e   .       	EventName$  Expanded��6=   *  $Microsoft.Xaml.Behaviors.TriggerBase!   Actions.! 5f   2   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  "   Command" 6H   �� *MenuExpanderExpandedCommand+5g   /   ��5j   *   � 5k   .   $��50��63   $��0q�6?    5l   2   �� 5m   6   $��40 �6G   �� 5n   6   .+�5p   2   �� $��0��6<   $��18(�6g   $��/Themes/Style/#iconfont)�6u   ���#BFCBD9$��Center=�5q   Q   $��Center=�6n   ��5p   L   �� *	Menu.Icon+5q   n   �� 5r   2   $��1��6<   $��14(�6h   $��5 0 0 0q�6v   $��Center=�6�   ��6L   �� *
Menu.Title+6�   5s   /   ��5v   *   �� 5w   .   ��6;   �� *ChildMenuBarModel+��5x   2   �� 5y   6   .R�5z   :   	� $ menuRadioGroup��6F    
 ExpanderRadioButtonStyle#��� 
 6a    5{   F   �� *	Menu.Icon+��6`   �� *
Menu.Title+��6   �� *NavigateCommand+5|   7   5~   /   5�   '   5�   #   5�      5�      5�      5�      ]� 5�      $��1��6   $��1��6%   ���#334157��.  $��	0 0 -10 0q�6`   .+�5�      �� 
���   �$
��Left=�6-   $��1q�6C   d� 5�      -	   5        # d�Name$# toggle��5�        MyToggleButtonStyle#��[ 6/   $
��Left=�5�      $
 Hand��65   $
��10 0q�6C   $��20(�6Q   
�������$��0q�5�   2   �� 5�      -
   5        $ ��Name$$ photoComboBox��5�        PhotoComboBoxStyle#��[ 62   
�������$	��150��5�   .   $��14(�6:   $��Right=�6H   % �� Text% 5�   ^   �� *CurrentUserName+& �� Mode$& OneWay=�.@�5�      �� $��0q�6#   $��0q�6/    6C   �� *
Navigation+# [  .��5�      	� -   5        $ photoRadioButton��5�   &   $��个人中心��6C   $	��140��5�   &     PhotoRadioButtonStyle#��[ 62   ��5�   R   �� *PersonalCommand+��6v   �� *	Content+5�   a   5�      �� 5�      $��0q�6#   $��0q�6/    6C   �� *
Navigation+# [  .��5�      	� -   5        $ photoRadioButton��5�   &   $��系统设置��6C   $	��140��5�   &   #��[ 62   ' d� 	IsChecked' 5�   R   �� *IsOpen+( �� ElementName$( DrawerRight��5�   a   5�      �� 5�      $��0q�6#   $��0q�6/    6C   �� *
Navigation+# [  .��5�      	� -   5        $ photoRadioButton��5�   &   $��退出登录��6C   $	��140��5�   W   #��[ 6c   ��5�   R   �� *LogoutCommand+��5�   &   �� $( mainWin��5�   &   5�      5�      5�      � 5�      $��1��6   $��2��6#   
������� 5�      �� 5�      $	��33* �6$   �� 5�      $
��272* �6$   .+�5�      �� -   5        ) ��Name$) Pages��5�   !   $��2��5�   A    5�   0   �� *
Navigation+# [  ��5�   !   �� *CurrentView+6A   5�      "  HandyControl.Controls.Drawer  5�      -   5        *  Name$* DrawerRight��5�      +   MaskCanClose+ . ,   Content., 5�      �� $��1��6     RegionBrush#���  6&   $	��300��6Q   $��0 1 0 0q�5�        BorderBrush#���  63   ._�5�      � .+�5�      �� $��系统设置��6$   $��10 0 0 0q�60     TextBlockTitle#��[ 6B   $
��Left=�6k   5�      5�      5�      5�      5�      5�      