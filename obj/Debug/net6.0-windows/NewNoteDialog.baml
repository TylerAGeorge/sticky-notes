   M S B A M L   `   `   `  ����G  Csticky-notes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:sticky_notessticky_notes  5   	        sticky_notes.NewNoteDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,localclr-namespace:sticky_notes     5   	     � Title$  New Note��5   	   $	��250��6   $	��400��6'    � 
ResizeMode$ NoResize=�63   .��5      �  � RowDefinitions 5   
   �� 5	      $	��150 �6   �� 5
      $��25 �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ NewNoteTextbox��5      $��0��6*    �� TextWrapping$
 Wrap=�67   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      	� -   5        $��YellowRadio��5      $��25��6-   ���#FEFF64���#FEFF646d   	� 5      -   5        $��	PinkRadio��5      $��25��6+   
�������
�������6_   	� 5      -   5        $��
GreenRadio��5      $��25��6,   ���#64FF68���#64FF686c   	� 5      -   5        $��OrangeRadio��5      $��25��6-   ���#FF9A32���#FF9A326d   	� 5      -   5        $��	BlueRadio��5      $��25��6+   ���#64C5FF���#64C5FF6b   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   .+�5      �� -   5        $��CancelButton��5      $��Cancel��6)   6:   �� 5      -   5        $��	NewButton��5      $��CreateNewNote��6&   6>   5      5      5      