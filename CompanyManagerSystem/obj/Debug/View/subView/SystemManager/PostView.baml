   M S B A M L   `   `   `  ����O  KCompanyManagerSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:CompanyManagerSystem.View.subView.SystemManager/CompanyManagerSystem.View.subView.SystemManager  5      >    8CompanyManagerSystem.View.subView.SystemManager.PostView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Ilocal=clr-namespace:CompanyManagerSystem.View.subView.SystemManager  5      I EDisabledCursor, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nulllibhttp://lan.design.com  5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5	        � DataContext  5      ��    Locator �� Source# [   �� Path$
 Post�.��5      � $��20 10 20 20q�6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      .+�5   
   �� $��2��6   $	��165��6(   $��Hidden=�68   $��Center=�5      $	��Top=�64    K� ZIndex$ 1��6L   .��5      �� $	��Top=�6   $��5q�61   .+�5      �� $��5q�6   !  HandyControl.Controls.Growl   Token$ PostSuccessMsg��6(   �� 5      $��5q�6   $ PostWarningMsg��6(   �� 5      $��5q�6   $ PostErrorMsg��6(   5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   
�������$	��Top=�6A   .+�5      �� $��首页��6   $��14(�6"   $
��Bold"�60   ���#97A8BE$��Center=�6W   $��0 0 10 0q�6r   �� 5       ���#c0c4cc$	����6-   $��/Themes/Style/#iconfont)�6=   $��14(�6b   $��Center=�5!      $��Center=�63   �� 5"      $��岗位管理��6   $��14(�6$   $
��Bold"�62   $��Center=�6D   $��10 0 0 0q�6_   5#      � 5&   
   $��1��6   $
��0 20q�6   .+�5'      ]� $	��0 5q�6   .+�5*      �  � Orientation$ 
Horizontal=�6   $	��Top=�6[   $	��Top=�5+      $��0 0 0 10q�61   y�5*   5   �� *SearchPanelVis+.+�5.      #  HandyControl.Controls.TextBox  $��0 5 0 0q�6A   $
��Bold"�6R   $	��240��6d   $��32��6p   (  "HandyControl.Controls.TitleElement   Title$ 岗位名称��5/   !   	   TitlePlacement$
	 Left=�6=   '  !HandyControl.Controls.InfoElement
   Placeholder$
 请输入岗位名称��6b   ��5.   !   �� *SearchPostName+5/   b   $  HandyControl.Controls.ComboBox  52      $��20 5 0 0q�6I   $
��Bold"�6[   $	��240��6m   $��32��6y   $ 岗位状态��53   "   $
	 Left=�6>   $
 请输入岗位状态��6c    �� SelectedValue 52   "   �� *SearchStatus+.@�54      �� $��启用��6'   �� 55      $��禁用��6'   56      �� 59      $ 
Horizontal=�6!   .+�5:      &   HandyControl.Controls.DatePicker     ShowClearButton . $��20 5 5 0q�6?   $ 创建时间��6Q   $
��Bold"�6m   $	��200��6   $��32��6�   $
	 Left=�5;   K   $
 开始时间��6p   (  "System.Windows.Controls.DatePicker   SelectedDate 6(   �� *	StartDate+6p   #  HandyControl.Controls.Divider  5<         
LineStroke
 �   �   LineStrokeThickness$ 1Q�68   $��10��6P   $��Center=�6[   $��0 5 0 0q�6v     5=       . $��20 5 5 0q�6?   $
��Bold"�6Q   $	��200��6c   $��32��6o   $
	 Left=�5>   I   $
 结束时间��6n    6(   �� *	EndDate+6n   5?      �� 5B        ButtonPrimary#��[ 6N   $��73��6u   $��28��6�   $��搜索��5C      $��50 5 0 0q�6*     SearchGeometry'	  !HandyControl.Controls.IconElement 	  Geometry# [ 6<    � Cursor$
 Hand��6v   ��5B      �� *ConditionalSearchPostCommand+5C   v   �� 5D      $��重置��6S   $��73��6`   $��28��6k   $��10 5 0 0q�6w     RotateRightGeometry# [ 5E      $
 Hand��6\   ��5D      �� *#!ResetConditionalSearchPostCommand+5E   \   5F      � 5I      $��0 5 0 0q�6   $	��Top=�6(    5J      �� 5K      $��36 �6(   �� 5L      .+�5P      � .+�5Q      �� $ 
Horizontal=�6%   $	��Top=�6>   $  ��6V   .+�5S      ��   AddButtonStyle#��[ 6L   $��10 0 0 0q�6t   $��73��5T   %   $��28��60   $
 Hand��6<   ��5S   %   �� *AddPostInfoCommand+.��5U   "   �� $ 
Horizontal=�6-   .+�5V   &   �� $	����60   $��/Themes/Style/#iconfont)�6@   $��14(�6e   $��-5 0 5 0q�5W   0   $��Center=�6B   $��Center=�6]   �� 5X   &   $��新增��60   $��Center=�6:   5Y   #   5Z      �� 5]        EditButtonStyle#��[ 6M   $��10 0 0 0q�6v   $��EditNotOnlyOnePost��5^   %   $��28��6K   $��73��6W   ��5]   %   �� *EditPostInfoCommand+{�5_   !   �� *SelectedPosts+  ObjectToBoolConverter �� 	Converter# [  �� ConverterParameter$ EditBtnEnabled�� �� Mode$ TwoWay=�.��5`   "   �� $ 
Horizontal=�6-   .+�5a   &   �� $
��Bold"�60   $	����6B   $��/Themes/Style/#iconfont)�6R   $��-5 0 5 0q�6w   $��Center=�5b   0   $��Center=�6K   �� 5c   &   $��修改��60   $��Center=�6:   5d   #   5e      �� 5h      $��DeleteNotOnlyOnePost��6O     DelButtonStyle#��[ 6w   $��28��6�   $��10 0 0 0q�6�   $��78��5i   |   $
 Hand��6�   ��5h   %   �� *DeletePostInfoCommand+{�5i   %   �� *SelectedPost+  Object2BooleanConverter# [ .��5j   "   �� $ 
Horizontal=�6-   .+�5k   &   �� $��14(�60   $	����6>   $��/Themes/Style/#iconfont)�6N   $��Center=�6s   $��Center=�6�   $��-5 0 5 0q�6�   �� 5l   &   $��删除��60   $��Center=�6:   5m   #   5n      �� 5q       	 ExportButtonStyle#��[	 6%   $��10,0,0,0q�6P   $��73��6b   $��28��6m   $
 Hand��6y   .��5r   "   �� $ 
Horizontal=�6-   .+�5s   &   �� $��-5 0 5 0q�60   $��12(�6B   $	����6P   $��/Themes/Style/#iconfont)�6`   $��Center=�6�   $��Center=�6�   6�   �� 5t   &   $��Center=�60   导出6O   5u   #   5v      5w      �� 5z      $ 
Horizontal=�6%   $��Center=�6>   $��Right=�6Y   .+�5{      ��  
 CornerRadiusButtonStyle#��[
 6U   $
 Hand��5|   (   "
  HandyControl.Controls.Poptip 
  Content$ 隐藏搜索��66    
  HitMode$ Hover=�6O    
  	Placement$	 Top=�6i   $��10 0 0 0q�6�   ��5{   %   �� *ChangeSearchPanelVisCommand+.��5}   "   �� $	����6,   $��/Themes/Style/#iconfont)�6<   $��Center=�6a   $��Center=�6|   5~      �� 5      #��[
 6%   $
 Hand��6V   $ 刷新��5�   %   $ Hover=�6<   $	 Top=�6V   $��10 0 0 0q�6p   .��5�   "   �� $	����6,   $��/Themes/Style/#iconfont)�6<   $��Center=�6a   $��Center=�6|   5�      5�      5�      � 5�      $��1��6   $��10 0 0 0q�6(    5�      �� 5�      $��9* �6,   �� 5�      $
��1.5* �6,   .+�5�      &   System.Windows.Controls.DataGrid  -   5           AutoGenerateColumns .  "   VerticalScrollBarVisibility$ Hidden=�5�   ?      HeadersVisibility$	 All=�6d      RowHeaderWidth$ 60Q�5�   #     DataGridColumnHeaderStyle   ColumnHeaderStyle# [ 6]     DataGridRowStyle   RowStyle# [ 5�   #    ! DataGridTextCenterColumnStyle   	CellStyle# [ 6P      
IsReadOnly .     SelectionUnit$  FullRow=�5�   P   $
��Left=�6h   ��5�   |   �� *
PostList+! �� SelectedItem! 5�   7   �� *SelectedPost+"   RowHeaderTemplate" 5�      �� 5�   "   .R�5�   &   �� # d� 	IsChecked# 6/   �� *
IsSelected+$ �� RelativeSource$ �� % �� AncestorType$% DataGridRowL�5�   #   &   Columns& 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn'   Header$' 岗位名称��65   (   Width5  /System.Windows.Controls.DataGridLengthConverter$	( 150 6e   1  +System.Windows.Controls.DataGridBoundColumn)   Binding) 6C   �� *Post.PostName+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   $' 状态��69   $	( 120 6E   *   
IsReadOnly* . +   CellTemplate+ 5�   &   �� 5�   *   .R�5�   .     HandyControl.Controls.Tag  ,   ShowCloseButton, .  ��6M   �� *Post.Status+  Boolean2StringConverter# [ $ 停用;正常��-   
IsSelected- 6�   �� *Post.Status+5�   +   5�   #     5�   "   $' 创建时间��65   $	( 200 6C   ) 6O   �� *Post.insertTime+. �� StringFormat$. yyyy-MM-dd HH:mm:ss��/ �� ConverterCulture$/ zh-CN��  5�   "   $' 操作��69   $( * 6E   + 5�   &   �� 5�   *   .R�5�   .   �   63   �� *Post+# [  0 � ColumnDefinitions0 5�   2   �� 5�   6   �� 5�   6   �� 5�   6   .+�5�   2   ��   OperateButtonStyle#��[ 6a   $��39��5�   9   $��28��6D   $
 Hand��6P   $	��5 0q�6^   ��5�   9   �� *EditPostInfoCommand+.��5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��14(�6D   $	����6R   $��/Themes/Style/#iconfont)�6b   $��Center=�6�   $��Center=�6�   $��-5 0 2 0q�6�   �� 5�   :   $��修改��6D   $��Center=�6N   5�   7   5�   3   �� 5�   2   $��1��69   #��[ 6s   $��39��5�   9   $��28��6D   $
 Hand��6P   $	��5 0q�6^   $��DeleteOnlyOnePost��6k   ��5�   I   �� *DeletePostInfoCommand+.��5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��14(�6D   $	����6R   $��/Themes/Style/#iconfont)�6b   $��Center=�6�   $��Center=�6�   $��-5 0 2 0q�6�   �� 5�   :   $��删除��6D   $��Center=�6N   5�   7   5�   3   5�   /   5�   +   5�   #   5�      � 5�      $��1��6   .+�5�      �� $ 
Horizontal=�6)   $��Right=�6B   $
��0 10q�6^   .+�5�   "   �� $	��共��6,   $��Center=�65   $��14(�6P   �� 5�   "   $��Center=�6H   $	��5 0q�6c   ��6,   �� *
TotalCount+6c   �� 5�   "   $	��条��6,   $��Center=�65   $��0 0 10 0q�6P   �� 5�   "   $��每页��6,   $��Center=�66   �� 5�   "   $! 0��6{   $
 Hand��5�   +   $��Center=�69   $	��5 0q�6T   ��5�   +   �� *PerPageCountList+ 6T   �� *PerPageCount+*  $Microsoft.Xaml.Behaviors.Interaction1   Triggers1 5�   &   +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   *   2   	EventName$2 SelectionChanged��69   *  $Microsoft.Xaml.Behaviors.TriggerBase3   Actions.3 5�   .   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  4   Command4 6D   �� *PerPageCountChangedCommand+5�   +   5�   #   �� 5�   "   $	��条��6,   $��14(�65   $��Center=�6C   $��0 0 10 0q�6^   &   HandyControl.Controls.Pagination  5�   "   5   IsJumpEnabled5 . $
 Hand��5�   E   6   	PageIndex6 5�   0   �� *CurrentPage+$ TwoWay=�7   MaxPageCount7 6_   �� *TotalPageCount+8   DataCountPerPage8 6�   �� *PerPageCount+1 5�   &     5�   *   $2 PageUpdated��69   .3 5�   .     4 6D   �� *PageUpdatedCommand+5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      