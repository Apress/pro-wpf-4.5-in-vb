   M S B A M L   `   `   `  ����M  IDataBinding, Version=1.0.4720.20781, Culture=neutral, PublicKeyToken=null)clr-namespace:DataBindingDataBinding  5      &     DataBinding.ComboBoxSelectionBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:DataBinding     5        � Title$  ComboBoxSelectionBox��5      $	��300��6"   $	��300��6/    � 	Resources 5      $   DataBinding.ImagePathConverter   ImagePathConverter��%   &	          5      6<   5	      .��5      �� $��5q�6   .+�5      �� -   5        $��lstProducts��5   5   $��5q�6    J� SnapsToDevicePixels . $��Stretch=�6H    �� 
IsEditable 5      ��  �� ElementName$ chkIsEditable�� �� Path$ 	IsChecked� �� 
IsReadOnly 5      �� $ chkIsReadOnly��$ 	IsChecked� w� TextPath 5      �� $ txtTextSearchPath��$
 Text���5      �� 5   
   .�5      ��  �� Property � ��	 �� Value$	 0q�6.   6:   
 �� Triggers
 5      P� 5       P� Property �@��
IsSelected P� Value . . �5      ��  � ��
	 �  ��6:   5      P� 5       �@��IsHighlighted . . �5      ��  � ��
	 �z���6:   5      5      ��5      �� 5   
   .R�5       � $��0q�6   
�������.+�5!      �� $��5q�6   $��1q�6    
�����F� �� CornerRadius$ 4��5)      ��5"      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��$ 
Background�._�5*      � $��3q�6    � RowDefinitions 5+      �� 5,      6$   �� 5-      6$    � ColumnDefinitions 5/      �� 50      6'   �� 51      $
��Auto �6%   64   .+�53      �� $
��Bold"�6   ��6.   �� $ ModelNumber�6R   �� 54      $��1��6   ��6)   �� $ 	ModelName�6K   �� 55      $��1��6   $��2��6(   $��50��69   ��6E   �� $ ProductImagePath� �� 	Converter# [  6�   56      57      58      59      5;      �� 5=      -   5        $��chkIsEditable��5=      $��5q�6$   .��6/   
IsEditable6;   �� 5>      -   5        $��chkIsReadOnly��5>      $��5q�6$   .��6/   
IsReadOnly6;   �� 5?      $��5q�6   TextSearch.TextPath: �� 5A      -   5        $��txtTextSearchPath��5A      $	��150��6)   6c   5B      5D      5E      