   M S B A M L   `   `   `  ����P  LCustomControls, Version=1.0.4626.26562, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CustomControls;assembly=CustomControlsCustomControls  5   	    CustomControlsClient5   /CustomControlsClient.FlipPanelAlternateTemplate   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Dlib4clr-namespace:CustomControls;assembly=CustomControls     5   	     � Title$   FlipPanelAlternateTemplate��5      $	��300��6(   $	��300��65    � 	Resources 5         AlternateTemplate �� 
TargetType   CustomControls.FlipPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty	 W� To	 � RowDefinitions
   CornerRadius �� CornerRadius J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius   FrontContent �� Stretch d�Name J� RenderTransformOrigin �� ScaleY   BackContent��%g  &	        �� 5   
   "  64   .R�5      �  5	        5
      
ViewStates��. 5        
Normal��. 5      �� .��5   "   W� $ FrontContentTransform��62   $ ScaleY�5      $ 1X�6;   6E   W� 5   "   $ FrontContentEffect��62   $ Radius�5      $ 0X�6;   6E   W� 5   "   $ BackContentTransform��62   $ ScaleY�5      $ 0X�6;   6E   W� 5   "   $ BackContentEffect��62   $ Radius�5      $ 30X�6;   6F   5      5        5      Flipped��. 5      �� .��5   "   W� $ FrontContentTransform��62   $ ScaleY�5      $ 0X�6;   6E   W� 5!   "   $ FrontContentEffect��62   $ Radius�5"      $ 30X�6;   6F   W� 5$   "   $ BackContentTransform��62   $ ScaleY�5%      $ 1X�6;   6E   W� 5'   "   $ BackContentEffect��62   $ Radius�5(      $ 0X�6;   6E   5)      5*      5+      	 50      �� 51      $
��Auto �6$   64   �� 52      $
��Auto �6$   64   .+�56      �� #��z��6   #��z��57      # z
 58      #��z��59      z�5;      �� 5<      FrontContentTransform��6J    5>        5?      FrontContentEffect��$ 0Q�6A   6N   ._�5B      � 	 5C      �� 5D      6.   �� 5E      $
��Auto �6,   6<   .+�5G      �� #��z 5H      5I      �� 5K      $��1��6$   $
 Fill=�61   
����İ�6X   d� 5L      $ 
FlipButton��64   $��1��6'   $��5q�6H   $
��15,0q�6S   $��˄��5M      $
��Bold"�6*   $��12(�6<   $��Right=�6J   5N      5O      5Q      �� 5T      #��z��6   #��z��5U      # z
 5V      #��z��5W      $	 0,1&�66   z�5X      �� 5Y      BackContentTransform��$ 0Q�6G   6T    5[        5\      BackContentEffect��$ 30Q�6@   6N   ._�5_      � 	 5`      �� 5a      $
��Auto �6,   6<   �� 5b      6.   .+�5e      �� $
 Fill=�6$   
����İ�6K   d� 5f      $ FlipButtonAlternate��6'   $��5q�6D   $
��15,0q�6O   $��˅��5g      $
��Bold"�6*   $��12(�6<   $��Right=�6J   5h      �� 5j      $��1��6+   #��z 5k      5l      5n      5p      5r      5t      5u      .��5w      � -   5         �Name$ 
LayoutRoot��5w      
�������.+�5x   
     -   5          Name$ panel��5x      
��� ���$��3q�6@   $
 4��6T   $��10q�6e   #��[  5y       5z      �� 5{      $��6q�6   .+�5|      �� $
��Wrap=�6    $��3q�64   $��16(�6?   
��� ���*(This is the front side of the FlipPanel.6�   �� 5}      $��3q�6   $��3q�6(   $��
Button One��64   6K   �� 5~      $��3q�6   $��3q�6(   $��
Button Two��64   6K   �� 5      $��3q�6   $��3q�6(   $��Button Three��64   6M   �� 5�      $��3q�6   $��3q�6(   $��Button Four��64   6L   5�       5�      � 5�      $��6q�6   	 5�      �� 5�      $
��Auto �6(   68   �� 5�      6*   .+�5�      �� $
��Wrap=�6    $��3q�64   $��16(�6?   
���� ��)'This is the back side of the FlipPanel.6�   �� 5�      -   5        $��2��5�      $��3q�6*   $��10q�65   $��Flip Back to Front��6B   $��Center=�6_   $��Center=�6|   6�   5�      5�      5�      5�      