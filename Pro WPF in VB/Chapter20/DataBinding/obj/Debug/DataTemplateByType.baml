   M S B A M L   `   `   `  ����H  DStoreDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:StoreDatabase;assembly=StoreDatabaseStoreDatabase  5       DataBinding$   DataBinding.DataTemplateByType   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Cdata2clr-namespace:StoreDatabase;assembly=StoreDatabase     5        � Title$  DataTemplateByType��5      $	��420��6   $	��675��6,    � 	Resources 5       �� DataType   StoreDatabase.Product �� CornerRadius � RowDefinitions �� Path��%d  (��       5      *, +)�� 6
   "  6   .R�5	      �� $��3q�6   $��1q�6    
�����F�$ 4��5
      ._�5      � $��3q�6    5      �� 5      6*   �� 5      6*   .+�5      �� $
��Bold"�6    ��62   �� $ ModelNumber�6V   �� 5      $��1��6    ��6-   �� $ 	ModelName�6O   5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �  5      �� 5       $
��Auto �6    60   �� 5!      $��* �6    6-   .+�5$      �� -   5        $��7,7,7,0q�5$      $��2q�6&   .��6O   Get Products6]   �� 5%      -   5        $��lstProducts��5%   5   $��1��6   $��7,3,7,10q�6#   $��Stretch=�6H   5&      5)      �� 5+   
   $��1��6   $
��Left=�6'   $��Stretch=�6B   $��5��5,      6    �� 5.   
   $��1��6    �� Padding$ 7q�6!   $��7q�6-   
����İ�._�5/      �  � DataContext 6   �� 	 �� ElementName$	 lstProducts��$ SelectedItem� 50      �� 51      $
��Auto �6'   66   �� 52      6)    54      �� 55      $
��Auto �6$   64   �� 56      $
��Auto �6$   64   �� 57      $
��Auto �6$   64   �� 58      $
��Auto �6$   64   �� 59      $��* �6$   61   .+�5<      �� $��7q�6   Model Number:66   �� 5=      $��5q�6   $��1��6%   ��65   �� $ ModelNumber�6Y   �� 5>      $��7q�6   $��1��6'   Model Name:6A   �� 5?      $��5q�6   $��1��6%   $��1��62   ��6B   �� $ 	ModelName�6d   �� 5@      $��7q�6   $��2��6'   
Unit Cost:6@   �� 5A      $��5q�6   $��2��6%   $��1��62   ��6B   �� $ UnitCost�6c   �� 5B      $��7,7,7,0q�6   $��3��6-   Description:6H   �� 5C      $��7q�6   $��4��6%   $��0��62   $��2��6B   
 �� TextWrapping$

 Wrap=�5D      " �� VerticalScrollBarVisibility$ Visible=�6&   ��6L   �� $ Description�6p   5F      5G      5I      5J      