   M S B A M L   `   `   `  ����@  <AppUX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AppUXAppUX  5   	       AppUX.SplashScreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.41.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:AppUX     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�6   
������� � AllowsTransparency .  � Title$ SplashScreen��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�5   	    J� SnapsToDevicePixels .  � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&   	 W� From$	 0X�6J   	
 W� To$
 1X�6S    g� Duration$ 0:0:0.5D�6Z    g� FillBehavior$ HoldEnd=�6m   5      5      5      .��5      �� $��Center=�6   
�������$��0,193q�6?   .+�5   
   ]� .+�5      � $
��Left=�6   $	��432��6.   ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      :� 5      $ Loaded��6+   [�5   "   �� 5   &   .��5    *   �� .��5!   .   W� $ 0:0:0.8D�6>   $ Width�6Q   $	
 342X�6s   5"   +   5#   '   5%      5'      .+�5)      (� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6,   :x,http://schemas.microsoft.com/winfx/2006/xaml     6n    (� Stretch$ Uniform=�6   $��64��6�   $��64��6�   $��Right=�6�   $��Center=�6�   .��5*      �� $��23��6   $��23��6)   .+�5+      F�  . ���������> @��� �� d�� �(͛ ,m� ����  �� �4� 8�� ��m� �� �D9� H�
�� H�
S>�� ��\4B� �\�� S>V(� Ӭ� �\c D9� �\c �m� V(� �4�� � �l� d�� �$� ��� �P�� &܄ <�&܄ ̾(��� �\�:<�� \�:Ę� ̾(Ty� �<��Y� P�� �Y� $� Ty� �8c� �ڷ ќJ� h� �*�� V(� Ӿ�s �\c BfC �\c ֚% V(� �e� �� e� 4B� ֚% �� �BfC H�
��s H�
*�� �� �`b� 8+� �FΆ  �� �����> @Ty� �vj �Y� �M �Y� /; Ty� ӦN) Ę� �N) <�� /; ��� ӊM &܄ vj &܄ ����> @��� 	
���   �6s  5,      5-      5.      � 5/      $��Right=�6   $	��650��6/   ��50      �� 51      " �6    52      :� 53      $ Loaded��6+   [�54   "   �� 55   &   .��56   *   �� .��57   .   W� $ 0:0:0.8D�6>   $ Width�6Q   $	
 455X�6s   58   +   59   '   5;      5=      .+�5?      �� $��Excel Processing��6   $��26(�64   $��Segoe UI)�6B   $
��Left=�6X   $��Center=�6s   ���	#FF0C0C0C$
��0,14q�6�   5@      5A      5B      5C      