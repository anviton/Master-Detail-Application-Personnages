   M S B A M L   `   `   `  ����D  @Vue_perso, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Vue_perso	Vue_perso  5   	       Vue_perso.NouveauPerso   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Vue_perso     5   	     � Title$,  &Enregistrement d'un nouveau personnage��5   	   $	��450��68   $	��800��6E   .��5
      ]� .+�5   
   �� $	��Top=�6   $��Center=�6%   $$��Enregistrement d'un personnage��6B   $
��25px(�6k   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Bottom=�6.   $��Right=�6F   $��15,10q�6b   .+�5      �� $��Enregistrer��6   $
��10,0q�6+   $��25��69   $
��10,0q�6E   �� 5      $��Annuler��6   $
��10,0q�6'   5      � 5   
    � ColumnDefinitions 5      �� 5      $	��25* �6#   �� 5      $	��75* �6#    � RowDefinitions 5      �� 5      $
��30px �6    �� 5      $
��30px �6    �� 5      $
��30px �6    �� 5      $
��30px �6    �� 5      $
��30px �6    �� 5      $
��30px �6    �� 5      $��30 �6    �� 5       $��5* �6    .+�5"      �� $��0��6   $��0��6&   $��Nom :��63   �� 5#      $��1��6   $��0��6&    �� TextWrapping$ NoWrap=�63   $
��Auto��6I   6X   �� 5%      $��0��6   $��1��6%   $��Image :��62   �� 5&      $��1��6   $��1��6%   $��Parcourir...��62   �� 5(      $��0��6   $��2��6&   $��Citations :��63   �� 5)      $��1��6   $��2��6&   $E��?Emplacement de saisie à modifier pour correspondre au contexte��63   $ NoWrap=�6y   $
��Auto��6�   ${�False��6�   �� 5+      $��0��6   $��3��6&   $��Jeux vidéos :��63   �� 5,      $��1��6   $��3��6&   $��Modifier...��63   �� 5.      $��0��6   $��4��6&   $��Thèmes musicaux :��63   �� 5/      -   5        $��ThemeButton��5/   I   $��1��6   $��4��6&   $��Modifier...��63   6\   �� 51      $��0��6   $��5��6&   $��Relations :��63   �� 52      $��1��6   $��5��6&   $��Modifier...��63   �� 54      $��0��6   $��6��6$   $��2��61   $��Description :��6E   �� 56      $��0��6   $��7��6&   $��2��63   $
 Wrap=�6G   " �� VerticalScrollBarVisibility$ Visible=�6[   $
��10,0q�6�   57      58      5:      