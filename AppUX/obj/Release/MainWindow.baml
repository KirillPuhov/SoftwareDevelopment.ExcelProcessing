   M S B A M L   `   `   `  ���� @  <AppUX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AppUXAppUX  7 clr-namespace:AppUX.Theme.WindowAppUX.Theme.Window  ;"clr-namespace:AppUX.Control.WindowAppUX.Control.Window      AppUX.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.41.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:AppUX     2theme clr-namespace:AppUX.Theme.Window     6control"clr-namespace:AppUX.Control.Window       � Language$  RU-ru�$	��600��$
��1080�� � Title$ Excel Processing��$��Segoe UI)� � WindowStartupLocation$ CenterScreen=�#   AppUX.Theme.Window.RayeWindow   IsHeaderTextVisible .   J� SnapsToDevicePixels .    
HeaderIcon F�  . $��28��$��14�� �� Stretch$
 Fill=�   	PathStyle#���   ���������> @��� �� d�� �(͛ ,m� ����  �� �4� 8�� ��m� �� �D9� H�
�� H�
S>�� ��\4B� �\�� S>V(� Ӭ� �\c D9� �\c �m� V(� �4�� � �l� d�� �$� ��� �P�� &܄ <�&܄ ̾(��� �\�:<�� \�:Ę� ̾(Ty� �<��Y� P�� �Y� $� Ty� �8c� �ڷ ќJ� h� �*�� V(� Ӿ�s �\c BfC �\c ֚% V(� �e� �� e� 4B� ֚% �� �BfC H�
��s H�
*�� �� �`b� 8+� �FΆ  �� �����> @Ty� �vj �Y� �M �Y� /; Ty� ӦN) Ę� �N) <�� /; ��� ӊM &܄ vj &܄ ����> @��� 	   HeaderContent � $
��Left=� � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+�o� $��0��$��80��
������ .@�m�   file#���  $��30��$��75��$��27, 0, 0, 2q�  MenuItemTemplate1#���    MenuItemStyle1#���  .@�m� -   	 m�Name$	 
OpenButton��  open#���    MenuItemTemplate2#���    MenuItemStyle2#���  
 m� Command
 ��  �� Path$ OpenCommand�m� -   $	 CloseButton�� 	 close#���  #���  #���  
 �� $ GridClearCommand��� m� -   $	 
SaveButton��  save#���  #���  #���  
 �� $ SaveCommand��� $��1�� 	 WindowButtonStyle#��� 	 $��80��
������  

 report#��� 
 ���� $ OpenReportWindow��� $��2��#��� 	 $��80��
������   settings#���  ���� $ OpenSettingsWindow�.��� .+��   	GridStyle#���  $��0,0,0,22q�.+�/   )AppUX.Control.Window.FilterDialogVertical  -     Name$ FilterDialog�� 
 filter   HeaderContent# �  $	��250��$	��300��$	��Top=�$
��Left=�$��0,5,0,0q� K� ZIndex$ 10��   ListBoxContent �� *FilterContent+   ColumnSelected �� *FilterSelectedItem+ �� Mode$ TwoWay=�   SortMode	 �� *SortModeArray+$ TwoWay=�
   	FilterBox �� *Filter+$ TwoWay=�   ButtonCommand �� $ FilterCommand�� $��	30,5,30,0q�$ 9��.+�&   System.Windows.Controls.DataGrid  -     Name$ 
ExcelTable��  DataGridStyle#���     CanUserSortColumns .  ���� $ 
ExcelTable�$ TwoWay=���Z� �   FooterStyle#���  $��Bottom=�$��22��.+��� $��10,2,0,0q�$��12(�$ 11������ $ OpenFilePath�