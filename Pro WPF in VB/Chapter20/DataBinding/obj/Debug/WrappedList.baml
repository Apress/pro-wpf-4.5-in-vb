   M S B A M L   `   `   `  ����M  IDataBinding, Version=1.0.4720.20781, Culture=neutral, PublicKeyToken=null)clr-namespace:DataBindingDataBinding  5          DataBinding.WrappedList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:DataBinding     5        � Title$  WrappedList��5   	   $	��326��6   $	��471��6*    � 	Resources 5      $   DataBinding.ImagePathConverter   ImagePathConverter  ItemTemplate � ColumnDefinitions z� SharedSizeGroup �� Property �� Value �� CornerRadius �� Path �� 	Converter��%�  &	        &	      7     5   
   6@   �� 5
   
   .R�5      �  5      �� 5      $ SingleWidthColumn��6'   6M   ��5      �� 5      .�5      ��  � ��
 �   �6Q   5      .+�5      �� $��5q�6   $��1q�6$   
�����F�$ 4��5      ._�5      �� $��3q�6!   .+�5      �� $��Center=�6D   ��6$   �� $ 	ModelName�6c   �� 5      $	��100��5      ��5       �� $ ProductImagePath�8   5      5      5      5      5       5"      .��5#      � 	 � RowDefinitions	 5$   
   �� 5%      $
��Auto �6   6,   �� 5&      6   .+�5(   
   �� -   5        $��7,7,7,0q�5(      $��2q�6"   .��6K   Get Products6Y   �� 5)   
   -   5        $��lstProducts��5)   O   
 � IsSharedSizeScope
 . $��1��60   $��7,3,7,10q�6=   #��[ 6b   $��Disabled=�5*       J� SnapsToDevicePixels . ��5+      �� 5,      .R�5-      � 6"   5.      50      51      52      