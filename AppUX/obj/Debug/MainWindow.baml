   M S B A M L   `   `   `  ����@  <AppUX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AppUXAppUX  5   	   7 clr-namespace:AppUX.Theme.WindowAppUX.Theme.Window  5   	   ;"clr-namespace:AppUX.Control.WindowAppUX.Control.Window  5	   	       AppUX.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.41.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:AppUX     5   	   2theme clr-namespace:AppUX.Theme.Window     5   	   6control"clr-namespace:AppUX.Control.Window     5	   	     � Language$  RU-ru�5   	   $	��600��5   	   $
��1080��5   	   $��Segoe UI)�5   	    � WindowStartupLocation$ CenterScreen=�6   #   AppUX.Theme.Window.RayeWindow   IsHeaderTextVisible .   J� SnapsToDevicePixels .    
HeaderIcon 5      F� 5   
    . $��28��6*   $��14��65    �� Stretch$
 Fill=�6A      	PathStyle#���   6P   ���������> @��� �� d�� �(͛ ,m� ����  �� �4� 8�� ��m� �� �D9� H�
�� H�
S>�� ��\4B� �\�� S>V(� Ӭ� �\c D9� �\c �m� V(� �4�� � �l� d�� �$� ��� �P�� &܄ <�&܄ ̾(��� �\�:<�� \�:Ę� ̾(Ty� �<��Y� P�� �Y� $� Ty� �8c� �ڷ ќJ� h� �*�� V(� Ӿ�s �\c BfC �\c ֚% V(� �e� �� e� 4B� ֚% �� �BfC H�
��s H�
*�� �� �`b� 8+� �FΆ  �� �����> @Ty� �vj �Y� �M �Y� /; Ty� ӦN) Ę� �N) <�� /; ��� ӊM &܄ vj &܄ ����> @��� 	6t      HeaderContent 5      � 5   
   $
��Left=�6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5       $��1* �6#   .+�5$      o� $��0��6   $��80��6#   
������ .@�5&      m�   file#���  6   $��30��6;   $��75��6G   $��27, 0, 0, 2q�6R     MenuItemTemplate1#���  6h     MenuItemStyle1#���  6�   .@�5(      m� -   5         m�Name$ 
OpenButton��5(        open#���  63     MenuItemTemplate2#���  6S     MenuItemStyle2#���  6�   	 m� Command	 6�   �� 
 �� Path$
 OpenCommand�6�   m� 5)      -   5        $ CloseButton��5)       	 close#���  64   #���  6U   #���  6�   	 6�   �� $
 GridClearCommand�6�   �� 5*      m� 5+      -   5        $ 
SaveButton��5+        save#���  63   #���  6S   #���  6�   	 6�   �� $
 SaveCommand�6�   5,      5.      �� 50      $��1��6    	 WindowButtonStyle#��� 	 6%   $��80��6{   
������  

 report#��� 
 6�   ��6Q   �� $
 OpenReportWindow�6�   �� 52      $��2��6   #��� 	 6%   $��80��6}   
������   settings#���  6�   ��6Q   �� $
 OpenSettingsWindow�6�   54      .��57      � .+�59   
   �   	GridStyle#���  6   $��0,0,0,22q�63   .+�5;      /   )AppUX.Control.Window.FilterDialogVertical  -   5          Name$ FilterDialog��5;   +    
 filter   HeaderContent# �  6A   $	��250��6V  $	��300��6c  $	��Top=�6o  $
��Left=�6�  $��0,5,0,0q�6�   K� ZIndex$ 10��6�     ListBoxContent 6j   �� *FilterContent+   ColumnSelected 6�   �� *FilterSelectedItem+ �� Mode$ TwoWay=�   SortMode	 6�   �� *SortModeArray+$ TwoWay=�
   	FilterBox 6�   �� *Filter+$ TwoWay=�   ButtonCommand 6(  �� $
 FilterCommand�6�  � 5=      $��	30,5,30,0q�6   $ 9��6&   .+�5?      &   System.Windows.Controls.DataGrid  -   5          Name$ 
ExcelTable��5?        DataGridStyle#���  6/      CanUserSortColumns .  ��6W   �� $
 
ExcelTable�$ TwoWay=���6�   Z� 6�   5A      5C      � 5E   
     FooterStyle#���  6   $��Bottom=�65   $��22��6P   .+�5G      �� $��10,2,0,0q�6:   $��12(�6M   $ 11��6[   ��6   �� $
 OpenFilePath�6[   5I      5K      5M      