   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b   ComboBoxToggleButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType � RowDefinitions � ColumnDefinitions �� Triggers P� Property P� Value	 �� 
TargetName  ComboBoxTemplate
 �Name J� SnapsToDevicePixels �Name � AllowsTransparency �� Mode �� RelativeSource ��Name �� CornerRadius ��Name �� ClearTypeHint ��Name ��Name �� ElementName ��Name-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation d�Name �� Text d� 	IsChecked ��Name# �� SelectionBoxItemStringFormat �� ContentStringFormat �� SelectionBoxItemTemplate  �� SelectionBoxItem! J� IsHitTestVisible" P� 
SourceName# ]� 
Conditions$ �� Property% �� Value  PhotoComboBoxStyle$  HandyControl.Controls.ComboBox  ComboBoxExtend& �� BasedOn(  "HandyControl.Controls.TitleElement�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0hc'https://handyorg.github.io/handycontrol  5      1system&clr-namespace:System;assembly=mscorlib  5      %K  &	        &	     7   &	 �    7  '  ?    7  �� 5      "  d�6.   .�5   
   ��  � ��$ Center=�65   �� 5   
    � ��$ Center=�67   �� 5   
    � ��$ 0 0 0 5q�6,   �� 5	   
    � ��
 �  ��6(   �� 5
   
    � �� 5      �� 5      " d�6"   .R�5      � $
��grid��6   
������  5      �� 5      �� 5      $��3 �6,    5      �� 5      $��20 �6/   �� 5      $��5* �6/   �� 5      $��10 �6/   �� 5      $��1* �6/   �� 5      $��20 �6/   .+�5      �� $��0��6$   $��1��61   #��z��6A   #��z��6b   $��Right=�6�   6�   �� 5      $��	textblock��6A   $��0��6$   $��3��61   ���#909399$	����6g   $��/Themes/Style/#iconfont)�6w   #��z��6�   $
��Left=�6�   6�   5       5      P� 5       �@J�IsMouseOver . . �5      �� $
	 grid��6K    � �� �#293446�� 5       �@�Cursor$
 Hand��67   5       P� 5!       �@J�IsMouseOver .  . �5"      �� $
	 grid��6K    � �� �#3341575#      P� 5$       �@d�	IsChecked$
 trueY�67   . �5%      �� $	 	textblock��6F    � ��$	 ��65   6F   5&      P� 5'       �@d�	IsChecked$ FalseY�67   . �5(      �� $	 	textblock��6F    � ��$	 ��65   6F   5)      5+      5-      5.      �� 5/      " ��6/   .R�50   
   � $
 templateRoot��6    .  51      �� 52      $��* �6#   �� 53      #��� r�6#   $��0 �6v   .+�55      � $ 
PART_Popup��6    . $��2��6B   $��1q�6�   $��Bottom=�6�   #��� .�6�   ��6V   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��56      � .+�57      �� $ dropDownBorder��6   $��0 5 0 0q�65   $ 3��6F   #��� ��6W   #��� ��6�   $��1q�6�   ._�58      �� $ DropDownScrollViewer��6'   .��59      � $

 grid��6#   $ Enabled=�61   .+�5:   "   �� $ canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5;   &   �� $ 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5<   #   �� 5=   "   $ ItemsPresenter��61   $ 	Contained=�6I   # z 6~   5>      5?      5@      5A      5B      d� 5C      $ toggleButton��6   8��  #��z 6d   #��z��6�   #��z��6�   #��z��6�   #��z��6  $��2��69   6M  �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� 5D      $ contentPresenter��6   # z 69   #��z 6~   #��z  6�   #��z��6�   #��z��6)  ! .  #��z��6�  # z 6�  #��z��6�  5E       5F   
   P� 5G      $" 
PART_Popup��6/    �@�HasDropShadow . 5H      P� 5I       �@��HasItems .  . �5J      �� $	 dropDownBorder��6+    � ��$ 95��6G   5K      ]� 5L      # 5M      �� 5N      $ �@��
IsGrouping% . 66   �� 5O      "$ �@%�IsVirtualizingWhenGrouping% .  6X   ./�5Q      ��  � �� .  6B   5R      P� 5S      $" DropDownScrollViewer��6?    � �� .  . �5T      �� $	 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5U      $	 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5V      5X      �� 5Y      "  ��6'   .�5Z   
   ��  � ��
 �����6'   �� 5[   
    � ��$
 Auto=�6G   �� 5\   
    � ��$
 Auto=�6E   �� 5]   
    � ��$ 6,3,5,3q�6$   �� 5^   
    � �� . 6:   �� 5_   
    �@��PanningMode$
 Both=�65   �� 5`   
    �@��IsFlicksEnabled .  63   �� 5a   
    � ��8   6%   5b      �� 5d      "   6   8&   .�5e   
   ��  �@ TitlePlacement$
 Left=�6:   �� 5f   
    �@ 
TitleWidth$ 80 �66   �� 5g   
    �@ HorizontalAlignment$ Right=�6@   �� 5h   
    � ��$
 15 0q�6$   �� 5i   
    � ��$	 Top=�6.   �� 5j   
    � ��$ 13(�6%   �� 5k   
    � �� �#6062666'   �� 5l   
    � ��$ 36��6#   �� 5m   
    � ��$
 10 0q�6#   �� 5n   
    �@�Cursor$
 Hand��6#   5o      5p      