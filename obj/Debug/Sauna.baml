   M S B A M L   `   `   `  ����B  >Alytalo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AlytaloAlytalo  5          Alytalo.Sauna   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Alytalo     5        N� Title$  Sauna��5	      .��5      � .+�5   
   � -   5         �Name$ gridSetSauna��5      $
��Left=�6%   $	��197��6@   $��	65,52,0,0q�6M   $	��Top=�6`   $	��176��6x   ���	#FF142055.+�5      �� -   5         ��Name$ imgSwitchOn��5      $
��Left=�6)   $��88��6D   $��	44,36,0,0q�6P   $	��Top=�6c   $��87��6{   $��assets/on.png��6�   6�   �� 5      -   5        $ imgSwitchOff��5      $
��Left=�6*   $��88��6E   $��	44,36,0,0q�6Q   $	��Top=�6d   $��87��6|   $��assets/off.png��6�   6�   �� 5      -   5         ��Name$ 
panelSauna��5      $��31��6-   $	��Top=�69   $	��176��6Q   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF000E11��6'    � Offset$
 0.17Q�69   � 5      $ 	#FF17456A��6'   $ 1Q�69   5      .+�5      �� -   5         ��Name$ lblSauna��5      $��Sauna��6*   $��35��6:   $��16(�6F   $
��Bold"�6T   
�������$��	58,0,49,0q�6y   5      �� 5      -   5        $ lblState��5      $�� ��6&   $
��Left=�61   $��
50,135,0,0q�6L   $	��Top=�6`   $��86��6x   ���	#FFFDFDFD6�   5      � 5   
   -   5        $ gridSaunaState��5      $
��Left=�6'   $	��197��6B   $��
291,52,0,0q�6O   $	��Top=�6c   $	��176��6{   ���	#FF142055.+�5      �� -   5        	 ��Name$	 txtSaunaTemp��5      $
��Left=�6,   $	��115��6G   $��	28,40,0,0q�6T   
 �� TextWrapping$

 Wrap=�6g   $	��Top=�6{   $	��123��6�   $��72(�6�    �� TextAlignment$ Center=�6�   
����������	#FF142055���	#FF1420556�   �� 5      -	   5        $ panelSaunanLampotila��5      $��31��67   $	��Top=�6C   $	��176��6[   ��5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ 	#FF000E11��6'   $
 0.17Q�69   � 5       $ 	#FF17456A��6'   $ 1Q�69   5!      .+�5#      �� -
   5        $ 	lblSauna1��5#      $��Saunan lämpötila��6+   $��35��6F   $��16(�6R   $
��Bold"�6`   
�������$��	19,0,10,0q�6�   5$      5%      5'      5(      