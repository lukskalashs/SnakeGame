   M S B A M L   `   `   `  ����	  Snake    Snake.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$  Snake��5      $	��500��6   $	��800��6   $	��300��5   	   $	��300��6      BackgroundColor#��[  5        	TextColor#��[ 5        MainFont#��[ 5       � WindowStartupLocation$ CenterScreen=�5	       � Icon$ SnakeAssets/icon.ico��5
      .��5      (� .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      �� -   5         ��Name$ 	ScoreText��5      $��Center=�5      $��Center=�5      $��SCORE O��5      $��22(�5      $��10q�5      �� 5   	   -   5         ��Name$ 
GridBorder��5      $��1��5        GridLineColor#��[ 5      $	��1.5q�5      $��Center=�5   
   $��Center=�5    
    �� EdgeMode$ Aliased=�5!      $��
20,0,20,20q�5"      ._�5#      A� -   5         A�Name$ GameGrid��5#      $	��400��5$   	   $	��400��5%   	     GridBackgroundColor#��[ 5&   	    J� SnapsToDevicePixels . 	 �� BitmapScalingMode$	 HighQuality=�5(   	   5)      5*   
   �� 5,      -   5        $ Overlay��5,      $��1��5-        OverlayColor#��[ 5.      $ Aliased=�52      ��5/      �� 
 �� Path$
 ActualWidth� �� ElementName$ 
GridBorder����50      �� $
 ActualHeight�$ 
GridBorder����51      �� $
 Margin�$ 
GridBorder��._�53      �� -   5        $ OverlayText��53      $��PRESS ANY KEY TO START��54      $��26(�55      $��Center=�56      $��Center=�57      $
��Wrap=�58      5:      5>      5?      5@      