   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b   ComboBoxToggleButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType � RowDefinitions � ColumnDefinitions �� Triggers P� Property P� Value	 �� 
TargetName  ComboBoxTemplate
 �Name J� SnapsToDevicePixels �Name � AllowsTransparency �� Mode �� RelativeSource ��Name �� CornerRadius ��Name �� ClearTypeHint ��Name ��Name �� ElementName ��Name-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation d�Name �� Text d� 	IsChecked ��Name# �� SelectionBoxItemStringFormat �� ContentStringFormat �� SelectionBoxItemTemplate  �� SelectionBoxItem! J� IsHitTestVisible" P� 
SourceName# ]� 
Conditions$ �� Property% �� Value  PhotoComboBoxStyle$  HandyControl.Controls.ComboBox  ComboBoxExtend& �� BasedOn(  "HandyControl.Controls.TitleElement�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     0hc'https://handyorg.github.io/handycontrol  1system&clr-namespace:System;assembly=mscorlib  %�
  &	        &	 �    7   &	 ;    7  '  	    7  �� "  d�.���  � ��$ Center=���  � ��$ Center=���  � ��$ 0 0 0 5q���  � ��
 �  ����  � �� �� " d�.R�� $
��grid��
������  �� �� $��3 � �� $��20 ��� $��5* ��� $��10 ��� $��1* ��� $��20 �.+��� $��0��$��1��#��z��#��z��$��Right=��� $��	textblock��$��0��$��3�����#909399$	����$��/Themes/Style/#iconfont)�#��z��$
��Left=� P�  �@J�IsMouseOver . . ��� $
	 grid�� � �� �#293446��  �@�Cursor$
 Hand��P�  �@J�IsMouseOver .  . ��� $
	 grid�� � �� �#334157P�  �@d�	IsChecked$
 trueY�. ��� $	 	textblock�� � ��$	 ��P�  �@d�	IsChecked$ FalseY�. ��� $	 	textblock�� � ��$	 ���� " ��.R�� $
 templateRoot�� .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��$��1q�$��Bottom=�#��� .����� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��� .+��� $ dropDownBorder��$��0 5 0 0q�$ 3��#��� ��#��� ��$��1q�._��� $ DropDownScrollViewer��.��� $

 grid��$ Enabled=�.+��� $ canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $ 
opaqueRect������ *
Background+$ dropDownBorder������ *ActualHeight+$ dropDownBorder������ *ActualWidth+$ dropDownBorder���� $ ItemsPresenter��$ 	Contained=�# z d� $ toggleButton��8��  #��z #��z��#��z��#��z��#��z��$��2�� �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $ contentPresenter��# z #��z #��z  #��z��#��z��! .  #��z��# z #��z�� P� $" 
PART_Popup�� �@�HasDropShadow . P�  �@��HasItems .  . ��� $	 dropDownBorder�� � ��$ 95��]� # �� $ �@��
IsGrouping% . �� "$ �@%�IsVirtualizingWhenGrouping% .  ./���  � �� .  P� $" DropDownScrollViewer�� � �� .  . ��� $	 
opaqueRect�� �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� $	 
opaqueRect�� �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left�� "  ��.���  � ��
 �������  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 6,3,5,3q���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��8   �� "   8&   .���  �@ TitlePlacement$
 Left=���  �@ 
TitleWidth$ 80 ���  �@ HorizontalAlignment$ Right=���  � ��$
 15 0q���  � ��$	 Top=���  � ��$ 13(���  � �� �#606266��  � ��$ 36����  � ��$
 10 0q���  �@�Cursor$
 Hand��