   M S B A M L   `   `   `  ����H  DStoreDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:StoreDatabase;assembly=StoreDatabaseStoreDatabase  5       DataBinding*   $DataBinding.BindToObjectDataProvider   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Cdata2clr-namespace:StoreDatabase;assembly=StoreDatabase     5        � Title$  BindToObjectDataProvider��5      $	��450��6&   $	��400��63    � 	Resources 5       S� 
ObjectType   StoreDatabase.StoreDB S� 
MethodName   products S� IsAsynchronous��%M   &	        S� 5      "  6   $ GetProductsSlow��5	       . 6^   5
      .��5      �  � RowDefinitions 5      �� 5      $��* �6   6#   �� 5      $
��Auto �6   6&   �� 5      $��* �6   6#   .+�5      �  5      �� 5   
   $
��Auto �6   6(   �� 5   
   $��* �6   6%   �� 5   
   $
��Auto �6   6(   .+�5      �� $��5q�6   Wait for it ...6.   �� 5      -   5        $��lstProducts��5      $��1��6   $��5q�60    �� DisplayMemberPath$ 	ModelName��6;   ��5      ��  �� Source# [  6M   �� 5      $��2��6   $��Right=�6     �� Orientation$ 
Horizontal=�6<   .+�5   
   �� -   5        $��5q�5      $��2q�6   .��5   ,   Delete Selected6=   5    	   5!      �� 5#      $��1��6   $��Stretch=�6    $��Bottom=�6>   	 �� ResizeBehavior$	 PreviousAndNext=�6Y   $��5��5%      5&      �� 5'      $��2��6   
 �� Padding$
 7q�6   $��7q�6&   
����İ�._�5(      �  � DataContext 6   ��  �� ElementName$ lstProducts�� �� Path$ SelectedItem� � ColumnDefinitions 5)   
   �� 5*      $
��Auto �6   6,   �� 5+      6    5-   
   �� 5.      $
��Auto �6   6*   �� 5/      $
��Auto �6   6*   �� 50      $
��Auto �6   6*   �� 51      $
��Auto �6   6*   �� 52      $��* �6   6'   .+�55   
   �� $��7q�6   Model Number:6.   �� 56   
   $��5q�6   $��1��6   ��6-   �� $ ModelNumber�6Q   �� 57   
   $��7q�6   $��1��6   Model Name:69   �� 58   
   $��5q�6   $��1��6   $��1��6*   ��6:   �� $ 	ModelName�6\   �� 59   
   $��7q�6   $��2��6   
Unit Cost:68   �� 5:   
   $��5q�6   $��2��6   $��1��6*   ��6:   �� $ UnitCost�6[   �� 5;   
   $��7,7,7,0q�6   $��3��6%   Description:6@   �� 5<   
   $��7q�6   $��4��6   $��0��6*   $��2��6:    �� TextWrapping$
 Wrap=�5=      " �� VerticalScrollBarVisibility$ Visible=�6&   ��6L   �� $ Description�6p   5@   	   5A      5B      5C      