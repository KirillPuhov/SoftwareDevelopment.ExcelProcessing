   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxToggleButtonHeader  �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius J� Opacity F�Name  HeaderComboBox �� 
TargetType �� Property �� Value	 �� 	ClickMode
 d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name  ComboBoxTextBox �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName P� 
SourceName  �� Triggers  ComboBoxToggleButtonFooter  FooterComboBox! �� Padding" ��Name  	GridStyle  DataGridStyle&   System.Windows.Controls.DataGrid  
LabelStyle  TextBoxStyle)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader# �� Orientation 	 MenuItemTemplate1$ �� HeaderStringFormat% �� ContentStringFormat& �Name' ��Name( �� 
ResourceId) �� TypeInTargetAssembly* �� ClearTypeHint+ ��Name, �� ElementName- ��Name. � IsSharedSizeScope/    TabNavigation 
 MenuItemTemplate20 z� SharedSizeGroup1 m� Icon2 ��Name3 m� InputGestureText4 ]� 
Conditions5 �� Property6 �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�4  &	        &	 4    7   7  &	 �
    &	 �    7  7  &	 @    '�� �    '�� �    &	 5    &	     &	 �    &	     '  �    '  w    '  +    '  ^     'o� �     &		  "    'm� +    &	
 Q+    �� 5      "  d�69   .R�5   
   �  5      �� 5      �� 5      $��20 �6#   .+�5
      �� $ Border��5      $��2��5      $ 0��5      
����������#808080$	 0.5Q�5      $��1q�5      �� 5      $��0��5      $ 0��5      $��1q�5      
����������#808080$	 0.5Q�5      $��0,0,1,0q�5      F� 5      $ Arrow��5      $��1��5      ���#808080$��Center=�5      $��Center=�5      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	5       5"      5#      �� 5%      " ��6#   .�5&   
   ��  �@J�SnapsToDevicePixels . 60   �� 5'   
    �@�OverridesDefaultStyle . 62   �� 5(   
    � ��$
 Auto=�6G   �� 5)   
    � ��$
 Auto=�6E   �� 5*   
    � �� . 6:   �� 5+   
    � ��$	 120��6%   �� 5,   
    � ��$ 20��6&   �� 5-   
    � ��
 �   �6'   �� 5.   
    � �� 5/      �� 50      "  ��6"   .R�51      � .+�52      d� $��ToggleButton��53      8��  $��2��55      |�.  $	 Press=�58      
 57      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+59      �� 5:      $��ContentSite��6+    .  #��z 6X   #��z 5;      #��z��5<      $��3,3,23,3q�5=      $��Center=�5>      $��Center=�5?      �� 5@      $ PART_EditableTextBox��6"   8�� $��Center=�5C      $��Center=�5D      $��3,3,23,3q�5E      |�. 
�������
��� � �$y�Hidden=�5I      # z 5J      ��5A      Z� 5J      � 5K      $��Popup��5L      $��Bottom=�5M      #��z 5N       . |�.  $��Slide=�5Q      .��5S      � $��DropDown��6#    . #��z 5U      #��z 5V      .+�5W   "   �� $ DropDownBorder��5X   !   
�������$��1q�5Z   !   ���#8888885[   !   �� 5\   "   $��4,6,4,6q�6/    . .��5]   &   ��  . $ 	Contained=�6D   5^   #   5_      5`      5a       5b      P� 5c       �@��HasItems .  . �5d      �� $ DropDownBorder��6%    � ��$ 95��6V   5e      P� 5f       � {� .  . �5g      ��  � �� �#8888886;   5h      P� 5i       �@��
IsGrouping . . �5j      ��  � �� .  6N   5k      P� 5l      $ Popup��6"    �@�AllowsTransparency . . �5m      �� $ DropDownBorder��6%    �@��CornerRadius$ 0��6Y   �� 5n      $ DropDownBorder��6%    � ��$ 0,2,0,0q�6S   5o      P� 5p       �@��
IsEditable . . �5q      ��  � �� .  6:   �� 5r      $ PART_EditableTextBox��6%    � y�$ Visible=�6]   �� 5s      $ ContentSite��6%    � y�$ Hidden=�6T   5t      5v      5x        5y   
   5{      �� 5      "  d�69   .R�5�   
   �  5�      �� 5�      �� 5�      $��20 �6#   .+�5�      �� $ Border��5�      $��2��5�      $ 0��5�      ���	#FF2E7D32���	#FF2E7D32$��1q�5�      �� 5�      $��0��5�      $ 0��5�      $��1q�5�      ���	#FF2E7D32���	#FF2E7D32$��0,0,1,0q�5�      F� 5�      $ Arrow��5�      $��1��5�      
�������$��Center=�5�      $��Center=�5�      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	5�      5�      5�      �� 5�      " ��6#   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@�OverridesDefaultStyle . 62   �� 5�   
    � ��$
 Auto=�6G   �� 5�   
    � ��$
 Auto=�6E   �� 5�   
    � �� . 6:   �� 5�   
    � ��$	 120��6%   �� 5�   
    � ��$ 20��6&   �� 5�   
    � ��
 �����6'   �� 5�   
    � �� 5�      �� 5�      "  ��6"   .R�5�      � .+�5�      d� $��ToggleButton��5�      8��  $��2��5�      |�.  $	 Press=�5�      
 5�      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5�      �� 5�      $��ContentSite��6+    .  #��z 6X   #��z 5�      #��z��5�      $��3,3,23,3q�5�      $��Center=�5�      $��Center=�5�      �� 5�      $ PART_EditableTextBox��6"   8�� $��Center=�5�      $��Center=�5�      $��3,3,23,3q�5�      |�. 
�������
��� � �$y�Hidden=�5�      # z 5�      ��5�      Z� 5�      � 5�      $��Popup��5�      $��Bottom=�5�      #��z 5�       . |�.  $��Slide=�5�      .��5�      � $��DropDown��6#    . #��z 5�      #��z 5�      .+�5�   "   �� $ DropDownBorder��5�   !   ���	#FF2E7D32$��1q�5�   !   ���#8888885�   !   �� 5�   "   $��4,6,4,6q�6/    . .��5�   &   ��  . $ 	Contained=�6D   5�   #   5�      5�      5�       5�      P� 5�       �@��HasItems .  . �5�      �� $ DropDownBorder��6%    � ��$ 95��6V   5�      P� 5�       � {� .  . �5�      ��  � �� �#8888886;   5�      P� 5�       �@��
IsGrouping . . �5�      ��  � �� .  6N   5�      P� 5�      $ Popup��6"    �@�AllowsTransparency . . �5�      �� $ DropDownBorder��6%    �@��CornerRadius$ 0��6Y   �� 5�      $ DropDownBorder��6%    � ��$ 0,2,0,0q�6S   5�      P� 5�       �@��
IsEditable . . �5�      ��  � �� .  6:   �� 5�      $ PART_EditableTextBox��6%    � y�$ Visible=�6]   �� 5�      $ ContentSite��6%    � y�$ Hidden=�6T   5�      5�      5�        5�   
   5�      �� 5�      "  ��6.   .R�5�   
   �� $ PART_ContentHost��6   |�.  #��z��6=   5�      �� 5�      " ��6*   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��
 �   �6'   �� 5   
    �@�OverridesDefaultStyle . 62   �� 5  
    � �� 5     �� 5     "  ��6"   .R�5     �� $��Border��6   $! 2q�5      . ._�5     �� 5      5	     P� 5
      �@��IsHighlighted . . �5     �� $ Border��6%    � ��
 �����6O   5     P� 5      � {� .  . �5     ��  � �� �#8888886;   5     5     5     5     �� 5     VSButton��" ��6   .�5  
   ��  � ��
 ���� 6'   �� 5  
    � �� �	#FF0C0C0C6'   �� 5  
    �@J�Opacity$ 1Q�6$   �� 5  
    � ��$ 12(�6%   �� 5  
    � ��$ 
./Segoe UI)�6'   �� 5  
    � �� 5      �� 5!     "  ��6"   .R�5"     �� $ 0��6   #��z��6.   ._�5#     � .+�5$     �� $" MyContentPresenter��6/   #��z��6K   $��Center=�6o   $��Center=�6�   $��0,0,0,0q�6�   5%     5&      5(     P� 5)      �@J�IsMouseOver . . �5*     ��  � ��
 �����6;   �� 5+      �@J�Opacity$	 0.5Q�68   �� 5,      � ��
 �����6;   5-     P� 5/      � �� . . �50     ��  � �� �	#FF2E7D326;   �� 51      �@J�Opacity$ 1Q�68   �� 52      � ��
 �����6;   53     55     57     58     �� 5<     " �6   .�5=  
   ��  � ��
 �����6'   5>     �� 5B     "  6"   .�5C  
   ��  � ��
 �����6'   5D     �� 5H     " ��6   .�5I  
   ��  � ��
 �   �6'   5J     �� 5N     " ��6!   .�5O  
   ��  � ��
 �����6'   �� 5P  
    � ��
 �   �6'   �� 5Q  
    � �� �#8080806(   5R     �� 5V     "  6   .�5W  
   ��  � ��
 �   �6'   �� 5X  
    � ��$ 25��6#   �� 5Y  
    � ��$ Stretch=�67     5[  
   P� 5\      �@ 
IsSelected . . �5]     ��  � ��
 �����6/   5^     P� 5`      �@��AlternationIndex$ 0��6?   . �5a     ��  � ��
 �����6/   5b     P� 5d      �@��AlternationIndex$ 1��6?   . �5e     ��  � ��
 �����6/   5f     5h     �� 5j     "  6     5k  
   P� 5l      �@ 
IsSelected . . �5m     ��  � �� �	#FF4D834D6/   �� 5n      � ��
 �����60   5o     5q     �� 5s     "  6   .�5t  
   ��  � ��
 �����6'   �� 5u  
    � ��
 �   �6'   �� 5v  
    � ��
 �����6(   �� 5w  
    � ��$ 	5,-1,5,-1q�6#   �� 5x  
    � ��$ 25��6#   �� 5y  
    � ��$
 auto��6"   �� 5z  
    � ��$ Center=�67   5{     �� 5}     "  6   .�5~  
   ��  � ��
 �����6'   5     �� 5�     " o�6"   .�5�  
   ��  �@�OverridesDefaultStyle . 62   �� 5�  
    �@J�SnapsToDevicePixels . 60   �� 5�  
    � ��
 �   �6'   �� 5�  
    � �� 5�     �� 5�     "  o�6"   .R�5�     �� $ MainMenu��6   
�������._�5�     �� }�. $# 
Horizontal=�69    . 6R   5�     5�     5�     5�     �� 5�     "  m�60   .R�5�  
   �� $ templateRoot��6   
�������$ 0��5�     $��1q�5�     $ 1Q�5�     #��z��5�      . ._�5�     � $��Center=�6    5�     �� 5�     $
��auto �6'   �� 5�     $
��auto �6'   .+�5�     �� #��z��6#   #��z��6V   $��1��6y   #% z$ 6�   $��Header��6�   #��z��6�   ��. # z 6  � 5�     $& 
PART_Popup��6    . |�.  #��� -�6�   $��Bottom=�6   ��6Y   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5�     �� $ SubMenuBorder��6   ���#808080$��1q�6J   
�������$! 2q�6v   ._�5�     �� $' SubMenuScrollViewer��6'   ��6D   C� *�� $( MenuScrollViewer��") �+.��5�     � $* Enabled=�6#   .+�5�  "   �� $
��Left=�6)   $��0��6D   $	��Top=�6O   $��0��6g   .+�5�  &   �� $+ 
OpaqueRect��60   ��6D   �� *
Background+$, SubMenuBorder����6{   �� *ActualHeight+$, SubMenuBorder����6�   �� *ActualWidth+$, SubMenuBorder��5�  #   �� 5�  "   $- ItemsPresenter��61   $ Cycle=�6I   . . # z 6�   $/ Cycle=�6�   5�     5�     5�     5�     5�     5�      5�  
   P� 5�     " �@m�IsSuspendingPopupAnimation . . �5�     �� $ 
PART_Popup��63    � ��$
 None=�6K   5�     P� 5�      �@m�IsHighlighted . . �5�     �� $ templateRoot��6/    � ��
 �����6I   �� 5�     $ templateRoot��60    � ��
 �����6J   �� 5�      � ��
 �����6/   �� 5�     $ templateRoot��6,    �@J�Opacity$	 0.5Q�6F   �� 5�     $ templateRoot��64    � ��$ 1q�6N   6Z   5�     P� 5�     $ SubMenuScrollViewer��62    � �� .  . �5�     �� $ 
OpaqueRect��6/    6G   �� *VerticalOffset+$, SubMenuScrollViewer�� �@��Top�� 5�     $ 
OpaqueRect��60    6H   �� *HorizontalOffset+$, SubMenuScrollViewer�� �@��Left5�     P� 5�      �@J�IsKeyboardFocusWithin . . �5�     �� $ templateRoot��6,    �@J�Opacity$ 1Q�6F   �� 5�     $ templateRoot��6/    � �� �	#FF4D834D6I   �� 5�     $ templateRoot��60    � �� �	#FF4D834D6^   �� 5�     $ templateRoot��64    � ��$ 1q�6N   6Z   5�     5�     �� 5�     " m�6&   .�5�  
   ��  � ��
 �   �6'   5�     �� 5�     "  m�60   .R�5�  
   �� $ templateRoot��6   #��z��6'   #��z��6S   #��z��6�    . ._�5�     � $��-1q�6    5�     �� 5�     $��22��6'   $0 MenuItemIconColumnGroup��65   $
��Auto �6_   �� 5�     $��13 �6'   �� 5�     $��* �6'   �� 5�     $��30 �6'   �� 5�     $0 MenuItemIGTColumnGroup��6'   $
��Auto �6P   �� 5�     $��20 �6'   .+�5�     �� $
" Icon��6#   #��z1 61   $
��Icon��6R   $��Center=�6g   $��16��6�   $��3q�6�   # z 6�   $��Center=�6�   $��16��6�   �� 5�     $ 
GlyphPanel��6   ���	#FF26A0DA$��1q�6E   ���	#3D26A0DA}�.  $��Center=�6�   $��22��6�   $��-1,0,0,0q�6�   $y�Hidden=�6�   $��Center=�6�   $��22��6�   ._�5�     F� $ Glyph��6   T������� �O �`�G �ڊ � �D �ڊ �    �XO � � �g5 ���A  ] ������� @    р�� �O ���	#FF212121$��LeftToRight=�6�   $��11��6�   $��10��6�   5�     �� 5�     $" menuHeaderContainer��6#   #��z��6@   #��z��6s   $��2��6�   #% z$ 6�   $��Header��6�   $
��Left=�6�   #��z��6  ��. # z 6Q  $��Center=�6�  �� 5�     $2 menuGestureText��6   $��4��65   #��z��6E   $	 0.7Q�6h   #��z3 6v   $��Center=�6�   5�     5�      5�  
   P� 5�      6&   Z�  �@m�Icon. �5�     �� $
 Icon��6/    � y�$ 	Collapsed=�6A   5�     P� 5�      �@m�	IsChecked . . �5�     �� $ 
GlyphPanel��6/    � y�$ Visible=�6G   �� 5�     $
 Icon��6/    � y�$ 	Collapsed=�6A   5�     P� 5�      �@m�IsHighlighted . . �5�     �� $ templateRoot��60    � �� �	#FF4D834D6J   �� 5�     $ templateRoot��6/    � �� �	#FF4D834D6I   �� 5�     $ menuHeaderContainer��69    � ��
 �����6Z   5�     P� 5�      � {� .  . �5�     �� $ templateRoot��6;    � �� �	#FF7070706U   �� 5�     $ Glyph��6)    � �� �	#FF7070706<   5�     ]� 5�     4 5�     �� 5�     5 �@m�IsHighlighted6 . 69   �� 5�     5 � {�6 .  65   ./�5�     �� $ templateRoot��6/    � �� �	#0A0000006I   �� 5�     $ templateRoot��60    � �� �	#210000006J   5�     5�     5�     