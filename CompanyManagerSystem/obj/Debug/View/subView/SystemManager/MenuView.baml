   M S B A M L   `   `   `  ����O  KCompanyManagerSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:CompanyManagerSystem.View.subView.SystemManager/CompanyManagerSystem.View.subView.SystemManager  5      >    8CompanyManagerSystem.View.subView.SystemManager.MenuView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:CompanyManagerSystem.View.subView.SystemManager     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      I EDisabledCursor, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nulllibhttp://lan.design.com  5	        � DataContext  5      ��    Locator �� Source# [   �� Path$
 Menu�.��5      � $��20 10 20 20q�6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      .+�5   
   �� $��Hidden=�6   $��2��6<   $	��165��6M   $	��Top=�6]   $��Center=�6u    K� ZIndex$ 1��6�   .��5      �� .+�5      �� !  HandyControl.Controls.Growl   Token$ MenuSuccessMsg��6   $��Center=�6=   $��0 0 0 5q�6X   �� 5      $ MenuWarningMsg��6   $��Center=�6=   $��0 0 0 5q�6X   �� 5      $ MenuErrorMsg��6   $��Center=�6;   $��0 0 0 5q�6V   5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   
�������.+�5      �� $��首页��6   $��14(�6"   ���#97A8BE$
��Bold"�6E   $��Center=�6W   $��0 0 10 0q�6r   �� 5      $��14(�6   ���#c0c4cc$	����6;   $��/Themes/Style/#iconfont)�6K   $��Center=�6p   $��Center=�6�   �� 5       $��菜单中心��6   $��14(�6$   $
��Bold"�62   $��Center=�6D   $��10 0 0 0q�6_   5!      � 5#   
   $��1��6   $
��0 20q�6   .+�5$      ]� $	��0 5q�6   .+�5'      �  � Orientation$ 
Horizontal=�6B   $	��Top=�6[   $	��Top=�6s   $��0 0 0 10q�6�   y�6   �� *SearchPanelVis+.+�5*      #  HandyControl.Controls.TextBox  $
��Bold"�6>   $	��240��6P   $��32��6\   (  "HandyControl.Controls.TitleElement   Title$ 菜单名称��5+   !   '  !HandyControl.Controls.InfoElement	   Placeholder$	 请输入菜单名称��6=   $��Center=�5,   !   $��Center=�6<   ��5*   !   �� *SearchTitle+5,   <   $  HandyControl.Controls.ComboBox  5/      $��20 0 0 0q�6G   $	��240��6Y   $��32��6e   $ 菜单状态��50      $	 请输入状态��6;   $
��Bold"�6^   $��Center=�51      $��Center=�6:   ��5/   "   �� *SearchStatus+.@�52      �� $��启用��6'   �� 53      $��禁用��6'   54      �� 57        ButtonPrimary#��[ 6N   $��搜 索��58      $��73��6+   $��28��66   $��50 0 0 0q�6B   
 � Cursor$

 Hand��6T     SearchGeometry'  !HandyControl.Controls.IconElement   Geometry# [ 59      ��57      �� *ConditionalSearchMenuCommand+59      �� 5<      $��重置��6S   $��73��6`   $��28��6k   $

 Hand��5=        RotateRightGeometry# [ 6+   $��10 0 0 0q�6j   ��5<      �� *#!ResetConditionalSearchMenuCommand+5=   j   5?      � 5B      $	��Top=�6   $��0 5 0 0q�6/    5C      �� 5D      $��36 �6(   �� 5E      .+�5H      � .+�5I      �� $ 
Horizontal=�6%   $	��Top=�6>   .+�5L      ��   AddButtonStyle#��[ 6L   $��28��5M   %   $��73��61   $

 Hand��6<   ��5L   %   �� *AddMenuInfoCommand+.��5N   "   �� $ 
Horizontal=�6-   .+�5O   &   �� $��-5 0 5 0q�60   $��14(�6B   $	����6P   $��/Themes/Style/#iconfont)�6`   $��Center=�5P   0   $��Center=�6K   6j   �� 5Q   &   $��新增��60   $��Center=�6:   6W   5R   #   5S      d� 5V        FoldToggleButtonStyle#��[ 6Y   $��展开/折叠��5W   +   $��10,0,0,0q�6;   $	��100��6M   $��28��6Y   $

 Hand��6e    d� 	IsChecked 5V   +   �� *FoldToggleButtonChecked+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5X   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5Y   &      	EventName$ Check��65   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5Z   *   2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
   
  Command 6@   �� *FoldMenuInfoCommand+5[   '     5\   &   $ UnCheck��65   . 5]   *   
   6@   �� *UnFoldMenuInfoCommand+5^   '   5`      5a      �� 5d      $ 
Horizontal=�6%   $	��Top=�6>   $��Right=�6V   .+�5e      ��   CornerRadiusButtonStyle#��[ 6U   $

 Hand��5f   )   "  HandyControl.Controls.Poptip   HitMode$ Hover=�67      	Placement$	 Top=�6Q      Content$ 隐藏搜索��6k   ��5e   %   �� *ChangeSearchPanelVisCommand+.��5g   "   �� $	����6,   $��/Themes/Style/#iconfont)�6<   $��Center=�6a   $��Center=�6|   5h      �� 5j      #��[ 6%   $

 Hand��6V   $��10 0 0 0q�6d   $ 刷新��5k   %   $	 Top=�6<   $ Hover=�6V   .��5l   "   �� $	����6,   $��/Themes/Style/#iconfont)�6<   $��Center=�6a   $��Center=�6|   5m      5n      5p      � 5r      $��1��6   $��10 0 0 0q�6(   .+�5s      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     HeadersVisibility$ Column=�6?      RowHeaderWidth$ 60Q�6Z     DataGridColumnHeaderStyle   ColumnHeaderStyle# [ 5u   #     DataGridRowStyle   RowStyle# [ 6b    !	 DataGridTextCenterColumnStyle   	CellStyle# [	 5v   #   $
��Left=�6^      
IsReadOnly .    SelectionUnit$ FullRow=�5w   5   ��5t   #   �� *
MenuList+ �� SelectedItem 6D   �� *SelectedMenu+   Columns 5x      4  .System.Windows.Controls.DataGridTemplateColumn  5z   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 菜单名称��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 6G       CellTemplate  5{   &   �� 5|   *   .R�5}   .   �� $ 
Horizontal=�69   $
��Left=�6R   $��	-40 0 0 0q�6m   .+�5~   2   �� ��69   �� *
MarginLeft+d� 5   2    
 MenuToggleButtonStyle#��[
 5�   C    5   ?   �� *	IsChecked+! �� Mode$! TwoWay=�" �� UpdateSourceTrigger$" PropertyChanged=�y�5�   r   �� *IsVisibility+ 5�   6     5�   :   $ Checked��6I   . 5�   >   
   6T   �� *MenuCheckChangedCommand+5�   ;     5�   :   $ 	Unchecked��6I   . 5�   >   
   6T   �� *MenuCheckChangedCommand+5�   ;   5�   3   �� 5�   2   $��Center=�6X   ��6<   �� *
Menu.Title+6X   5�   /   5�   +   5�   #   0  *System.Windows.Controls.DataGridTextColumn  5�   "   $ 图标��65   #   FontSize$# 18Q�6A   $   
FontFamily$$ /Themes/Style/#iconfont)�6m   %   
IsReadOnly% . $ 80 5�   H   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 5�   O   �� *	Menu.Icon+5�   H     5�   "   $ 路径��65   % . $	 250 6v   & 6A   �� *Menu.NameSpace+6v     5�   "   $ 状态��69   % . $	 120 6W     5�   &   �� 5�   *   .R�5�   .     HandyControl.Controls.Tag  '   ShowCloseButton' .  ��65   �� *Menu.Status+  Boolean2StringConverter( �� 	Converter#( [ ) �� ConverterParameter$) 停用;正常��*   
IsSelected* 5�   M   �� *Menu.Status+5�   +   5�   #     5�   "   $ 创建时间��5�   5   $	 200 6C   & 5�   5   �� *Menu.insertTime++ �� StringFormat$+ yy-MM-dd HH:mm:ss��, �� ConverterCulture$, zh-CN��5�   C     5�   "   $ 操作��69   $ * 6E     5�   &   �� 5�   *   .R�5�   .   �   63   �� *Menu+# [  - � ColumnDefinitions- 5�   2   �� 5�   6   �� 5�   6   .+�5�   2   ��   OperateButtonStyle#��[ 6a   $	��5 0q�5�   9   $��39��6F   $��28��6Q   $

 Hand��6]   ��5�   9   �� *EditMenuInfoCommand+.��5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��-5 0 2 0q�6D   $��12(�6V   $	����6d   $��/Themes/Style/#iconfont)�6t   $��Center=�5�   D   $��Center=�6_   �� 5�   :   $��修改��6D   $��Center=�6N   5�   7   5�   3   �� 5�   2   $��1��69   #��[ 6s   $	��5 0q�5�   9   $��39��6F   $��28��6Q   $

 Hand��6]   ��5�   I   �� *DeleteMenuInfoCommand+.��5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��-5 0 2 0q�6D   $��12(�6V   $	����6d   $��/Themes/Style/#iconfont)�6t   $��Center=�6�   $��Center=�6�   �� 5�   :   $��删除��6D   $��Center=�6N   5�   7   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      