   M S B A M L   `   `   `  ����M  IDataBinding, Version=1.0.4720.20781, Culture=neutral, PublicKeyToken=null)clr-namespace:DataBindingDataBinding  5          DataBinding.VariedStyles   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:DataBinding     5        � Title$  VariedStyles��5      $	��420��6   $	��675��6&    � 	Resources 5         DefaultStyle �� 
TargetType �� Property �� Value  HighlightStyle��%  &	        &	 m     �� 5   
   " ��6%   .�5	      ��  � ��
 �����6+   �� 5
       � ��$ 2q�6(   5      �� 5   
   " ��6'   .�5      ��  � ��
 ��İ�6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 2q�6(   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $��* �6    6-   �� 5      $
��Auto �6    60   .+�5!      �� -   5        $��7,7,7,0q�5!      $��2q�6&   .��6O   Get Products6]   �� 5#      -   5        $��lstProducts��5#   5   $��1��6   $��7,3,7,10q�6#   $��Stretch=�6H    J� SnapsToDevicePixels . ��5%      6   0DataBinding.SingleCriteriaHighlightStyleSelector  5&         DefaultStyle# [  5'      	   HighlightStyle#	 [ 5(      
   PropertyToEvaluate$
 CategoryName��5)         PropertyValueToHighlight$ Travel��5*      5,      5.      �� 50      -   5        $��7,0,7,7q�50      $��3��6&   $��2q�63   .��6\   Change One Item6m   51      �� 53   
   $��1��6   $
��Left=�6'   $��Stretch=�6B   $��5��54      6    �� 56   
   $��1��6    �� Padding$ 7q�6!   $��7q�6-   
����İ�._�57      �  � DataContext 6   ��  �� ElementName$ lstProducts�� �� Path$ SelectedItem� 58      �� 59      $
��Auto �6'   66   �� 5:      6)    5<      �� 5=      $
��Auto �6$   64   �� 5>      $
��Auto �6$   64   �� 5?      $
��Auto �6$   64   �� 5@      $
��Auto �6$   64   �� 5A      $��* �6$   61   .+�5D      �� $��7q�6   Model Number:66   �� 5E      $��5q�6   $��1��6%   ��65   �� $ ModelNumber�6Y   �� 5F      $��7q�6   $��1��6'   Model Name:6A   �� 5G      $��5q�6   $��1��6%   $��1��62   ��6B   �� $ 	ModelName�6d   �� 5H      $��7q�6   $��2��6'   
Unit Cost:6@   �� 5I      $��5q�6   $��2��6%   $��1��62   ��6B   �� $ UnitCost�6c   �� 5J      $��7,7,7,0q�6   $��3��6-   Description:6H   �� 5K      $��7q�6   $��4��6%   $��0��62   $��2��6B    �� TextWrapping$
 Wrap=�5L      " �� VerticalScrollBarVisibility$ Visible=�6&   ��6L   �� $ Description�6p   5N      5O      5Q      5R      