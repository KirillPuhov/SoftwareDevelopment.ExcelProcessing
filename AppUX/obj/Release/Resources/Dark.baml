   M S B A M L   `   `   `  ���� @  <AppUX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AppUX.Control.WindowAppUX.Control.Window  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.41.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DefaultRadioButton  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius A�Name �� Triggers P� Property	 P� Value
 �� 
TargetName  WindowButtonStyle �Name :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� AutoReverse g� Duration g� FillBehavior  RoundedButton �� Padding  TextBlockStyle  HyperlinkStyle  	PathStyle  ControlStyle+    %AppUX.Control.Window.WindowControlBox  	GridStyle  FooterStyle 	 DataGridStyle&   System.Windows.Controls.DataGrid 
 BorderStyle)  #System.Windows.Controls.DataGridRow �� Triggers*  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader �� Orientation K� IsItemsHost  MenuItemTemplate1 J� Opacity J� SnapsToDevicePixels � ColumnDefinitions �� HeaderStringFormat �� ContentStringFormat �Name � AllowsTransparency �� RelativeSource ��Name  �� 
ResourceId! �� TypeInTargetAssembly" �� ClearTypeHint# ��Name$ �� ElementName% ��Name-  'System.Windows.Input.KeyboardNavigation&   DirectionalNavigation' � IsSharedSizeScope(   TabNavigation  MenuItemStyle1  MenuItemStyle2  MenuItemTemplate2) z� SharedSizeGroup* ��Name+ m� Icon, F�Name- ��Name. m� InputGestureText/ ]� 
Conditions0 �� Property1 �� Value  GroupBoxStyle2 � RowDefinitions3 J� OpacityMask4 `� ConverterParameter5 `� 	Converter6 �� Path  StyleListBoxItem�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     .control"clr-namespace:AppUX.Control.Window  %�  &	        &	 #    &	 .    '�� �    &	 �    '�� �    &	     &	 )    &	 N    &	 x    &	 �    &		 �    &	
 �    '      '  <	    '  �	    '  f
    'o� �
    &	 l    &	 �    &	 �    &	 "    &	 �    &	 :    �� "  	�.���  � �� �� " 	�.R�� .+��� $ radioButtonBorder�����	#33000000$��1q�$ 3�����	#33000000._�� $��Right=�$	��Top=�$��3q�.+�A� 
�������$��18��$��Center=����	#33000000$��1��$��Center=�$��18��A� $ Check��
���   �$��10��$��Center=�
���   �$��0��$y�Hidden=�$��Center=�$��10���� $��Center=�$��Center=� P�  �@d�	IsChecked$
	 TrueY�. ��� $
 Check�� � y�$ Visible=�P�  �@d�	IsChecked$	 FalseY�. ��� $
 Check�� � y�$ Hidden=��� "  ��.���  � ��
 �������  � �� �� " ��.R�� #��z��.+�� $
 Grid�����	#00000000.+��� #��z��$��Center=�$��Center=� :� $ Click��[��� .���� $
 Grid��$ Background.Color�.���� $ 	#33000000X� . $ 0:0:0.2D�:� $ 
MouseEnter��[��� .���� $
 Grid��$ Background.Color�.���� $ 	#19000000X�$ HoldEnd=�$ 0:0:0.1D�:� $ 
MouseLeave��[��� .���� $
 Grid��$ Background.Color�.���� $ 	#00000000X�$ HoldEnd=�$ 0:0:0.1D��� "  ��.���  � ��
 �������  � �� �� " ��.R��� $ roundedButtonBorder��$ 3�����	#00000000���	#99FFFFFF$��1q�$ 2q�._�� #��z��.+�� $
 Grid�����	#00000000.+��� #��z��$��Center=�$��Center=� :� $ Click��[��� .���� $
 Grid��$ Background.Color�.���� $ 	#33000000X� . $ 0:0:0.2D�:� $ 
MouseEnter��[��� .���� $
 Grid��$ Background.Color�.���� $ 	#19000000X�$ HoldEnd=�$ 0:0:0.1D�:� $ 
MouseLeave��[��� .���� $
 Grid��$ Background.Color�.���� $ 	#00000000X�$ HoldEnd=�$ 0:0:0.1D��� "  ��.���  � ��
 ������� "  ��.���  � ��
 ������� "  ��.���  � ��
 ������� "  ��.���  � ��
 ������� "  F�.���  � ��
 ������� "    .���  �@  Fill
 ������� "  �.���  � �� �#383B40�� "  �.���  � ��
 ������� "   .���  � �� �#383B40�� "  ��.���  � ��
 ������� "   .���  � ��
 �������  � ��$ 25����  � ��$ Stretch=� P�  �@ 
IsSelected	 . . ���  � �� �	#2BFFFFFFP�  �@��AlternationIndex$	 0��. ���  � �� �	#2BFFFFFFP�  �@��AlternationIndex$	 1��. ���  � �� �	#2BFFFFFF�� "    P�  �@ 
IsSelected	 . . ���  � �� �	#66000000��  � ��
 �   ��� "   .���  � �� �#383B40��  � ��
 �������  � �� �	#2BFFFFFF��  � ��$ 	5,-1,5,-1q���  � ��$ 25����  � ��$
 auto����  � ��$ Center=��� "   .���  � �� �	#2BFFFFFF�� "  o�.���  �@�OverridesDefaultStyle . ��  �@J�SnapsToDevicePixels . ��  � ��
 �������  � �� �� " o�.R��� $ MainMenu��
������ ._��� }�. $ 
Horizontal=� . �� " m�.R��� $ templateRoot��$ 0��$��0q�$ 1Q�#��z�� . ._�� $��Center=� �� $
��auto ��� $
��auto �.+��� #��z��#��z��$��1��# z $��Header��#��z����. # z � $ 
PART_Popup�� . |�.  #��� -�$��Bottom=����� *IsSubmenuOpen+ �� *TemplatedParent+.���� $ SubMenuBorder�����	#33000000$��1q�
�������$ 2q�$��0,30,0,0q�._��� $ SubMenuScrollViewer����C� *�� $  MenuScrollViewer��"! �+.��� $" Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $# 
OpaqueRect������ *
Background+$$ SubMenuBorder������ *ActualHeight+$$ SubMenuBorder������ *ActualWidth+$$ SubMenuBorder���� $% ItemsPresenter��$& Cycle=�' . # z $( Cycle=� P� " �@m�IsSuspendingPopupAnimation	 . . ��� $
 
PART_Popup�� � ��$
 None=�:� $ 
MouseEnter��[��� .���� $ templateRoot��$ Background.Color�.���� $ 	#19000000X�$ HoldEnd=�$ 0:0:0.1D�:� $ 
MouseLeave��[��� .���� $ templateRoot��$ Background.Color�.���� $ 	#00000000X�$ HoldEnd=�$ 0:0:0.1D��� "  m�.���  � ��
 ������� "  m�.���  � ��
 �   ��� " m�.R��� $ templateRoot��#��z��#��z��#��z�� . ._�� $��-1q� �� $��22��$) MenuItemIconColumnGroup��$
��Auto ��� $��13 ��� $��* ��� $��30 ��� $) MenuItemIGTColumnGroup��$
��Auto ��� $��20 �.+��� $
* Icon��#��z+ $
��Icon��$��Center=�$��16��$��3q�# z $��Center=�$��16���� $ 
GlyphPanel�����	#FF26A0DA$��1q����	#3D26A0DA}�.  $��Center=�$��22��$��-1,0,0,0q�$y�Hidden=�$��Center=�$��22��._�F� $, Glyph��T������� �O �`�G �ڊ � �D �ڊ �    �XO � � �g5 ���A  ] ������� @    р�� �O ���	#FF212121$��LeftToRight=�$��11��$��10���� $* menuHeaderContainer��#��z��#��z��$��2��# z $��Header��$
��Left=�#��z����. # z $��Center=��� $- menuGestureText��$��4��#��z��$	 0.7Q�#��z. $��Center=� P� 	 Z�  �@m�Icon. ��� $

 Icon�� � y�$ 	Collapsed=�P�  �@m�	IsChecked	 . . ��� $
 
GlyphPanel�� � y�$ Visible=��� $

 Icon�� � y�$ 	Collapsed=�P�  �@m�IsHighlighted	 . . ��� $
 templateRoot�� � �� �	#19000000�� $
 templateRoot�� � �� �	#19000000�� $
 menuHeaderContainer�� � ��
 �   �P�  � {�	 .  . ��� $
 templateRoot�� � �� �	#33000000�� $
 Glyph�� � �� �	#33000000]� / �� 0 �@m�IsHighlighted1 . �� 0 � {�1 .  ./��� $
 templateRoot�� � �� �	#0A000000�� $
 templateRoot�� � �� �	#21000000�� "  ��.���  � ��
 �������  � ��
 �������  � ��$ 1q���  � �� �� " ��.R��  .  �� $��* ��� $��* ��� $��* ��� $��* �2 �� $��* ��� $��* ��� $��* ��� $��* �.+��� 
�������$��2q�$ 3��$��4��$��4��3 `� $4 10��5 �� .1��� $$ Header��$6 ActualWidth��� $6 ActualWidth� �� *Self+�� $6 ActualHeight� �� *Self+�� $ Header��$��1��$��1��$��10, -9.5, 0, 0q�$
��Left=�$	��Top=�._��� $��Header����. # z �� $��2��$��1��$��1��#��z��# z �� "  ��.���  � ��
 �������  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$ 7q� . #��z��._���  P�  �@J�IsMouseOver	 . . ��� $
 Border�� � �� �	#19000000P�  �@��
IsSelected	 . . ��� $
 Border�� � �� �	#33000000