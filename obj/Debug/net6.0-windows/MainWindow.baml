   M S B A M L   `   `   `  ����G  Csticky-notes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:sticky_notessticky_notes  5   	       sticky_notes.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:sticky_notes     5   	   -   5          � Title$  StickyNotes��5   	   $	��450��6   $	��800��6*    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   'm�       �� 5   
   " m�6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      .+�5   
   o� -   5        $��MainMenu��5      $��0��6   $��0��6,   
���   �$��1q�6P   
�������.@�5      m� $
��File��6   $��25��6%   .@�5      m� -   5        $��Open...��5       m� InputGestureText$ Ctrl+O��6-   6G   m� 5      -   5        $
��Save��5      $ Ctrl+S��6*   6D   m� 5       -   5        $��	SaveAs...��5       $ Ctrl+Shft+S��60   6O   5!      m� 5"      -   5        $��NewNoteButton��5"      $��25��6,   $��New Note��6H   5#      �� 5%   
   -   5         ��Name$ NotesCanvas��5&   	   $��1��5%      $
��Auto��5'   	   $	��800��5(   	   5*      5+      