   M S B A M L   `   `   `  ����@  <AppUX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:AppUX.Settings.Navigation.ViewModels$AppUX.Settings.Navigation.ViewModels  5   	   /clr-namespace:AppUX.SettingsAppUX.Settings  5   	   7 clr-namespace:AppUX.Theme.WindowAppUX.Theme.Window  5	   	   #    AppUX.Settings.SettingsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.41.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   I
viewModels2clr-namespace:AppUX.Settings.Navigation.ViewModels     5   	   1settingsclr-namespace:AppUX.Settings     5   	   2theme clr-namespace:AppUX.Theme.Window     5	   	   $	��500��5
   	   $
��1000��6     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   $��Segoe UI)�5   	   #   AppUX.Theme.Window.RayeWindow   MinimizeBox .     MaximizeBox .   � ShowInTaskbar .   J� SnapsToDevicePixels . .��5      � -   5         �Name$ Settings��5         	GridStyle#���   6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $	��Top=�6   $��80��64   ���	#33000000.+�5      F� $��60��6   $��30��6    �� Stretch$
 Fill=�6*   
����������������> @��� �� d�� �(͛ ,m� ����  �� �4� 8�� ��m� �� �D9� H�
�� H�
S>�� ��\4B� �\�� S>V(� Ӭ� �\c D9� �\c �m� V(� �4�� � �l� d�� �$� ��� �P�� &܄ <�&܄ ̾(��� �\�:<�� \�:Ę� ̾(Ty� �<��Y� P�� �Y� $� Ty� �8c� �ڷ ќJ� h� �*�� V(� Ӿ�s �\c BfC �\c ֚% V(� �e� �� e� 4B� ֚% �� �BfC H�
��s H�
*�� �� �`b� 8+� �FΆ  �� �����> @Ty� �vj �Y� �M �Y� /; Ty� ӦN) Ę� �N) <�� /; ��� ӊM &܄ vj &܄ ����> @��� 	6F   5      � 5   
   $��1��6   $��
20,20,20,5q�6   	 � ColumnDefinitions	 5      �� 5      $	��140 �6#   �� 5      $��1* �6#   .+�5#      ��   BorderStyle#���  6   $��0��6;   $��2q�6K   
 �� CornerRadius$
 3��6_   $��2��6p   ._�5$      �  5%      �� 5&      $��10 �6(   �� 5'      $��22 �6(   �� 5(      $��22 �6(   �� 5)      $��22 �6(   �� 5*      $��22 �6(   �� 5+      $��1* �6(   .+�5.      ��   WindowButtonStyle#���  6E   $��1��6q   $��
0, 0, 0, 0q�6~   
������ ��6   �� *ShowLanguageCommand+.��5/      � $	��135��6   .+�50      ��   language#���  6(   $
��Left=�6J   $��Center=�6e   $��12(�6�   $��
5, 0, 0, 0q�6�   51      52      �� 54      #���  6B   $��2��6n   $��
0, 0, 0, 0q�6{   
������ ��6   �� *ShowThemeCommand+.��55      � $	��135��6   .+�56      ��   
colorTheme#���  6(   $
��Left=�6L   $��Center=�6g   $��12(�6�   $��
5, 0, 0, 0q�6�   57      58      �� 5:      #���  6A   $��3��6m   $��
0, 0, 0, 0q�6z   
������ ��6   �� *ShowFileCommand+.��5;      � $	��135��6   .+�5<      ��   fileSettings#���  6(   $
��Left=�6N   $��Center=�6i   $��12(�6�   $��
5, 0, 0, 0q�6�   5=      5>      �� 5@      #���  6B   $��4��6n   $��
0, 0, 0, 0q�6{   
������ ��6   �� *ShowAboutCommand+.��5A      � $	��135��6   .+�5B      ��  	 about#���  6(   $
��Left=�6G   $��Center=�6b   $��12(�6}   $��
5, 0, 0, 0q�6�   5C      5D      5F      5G      �� 5I      -   5         ��Name$ FrameContent��5I      $��1��5J      $��2��5K   2   5L      5M      5N      