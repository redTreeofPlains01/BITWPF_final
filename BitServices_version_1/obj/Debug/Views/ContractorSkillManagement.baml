   M S B A M L   `   `   `  ����P  LBitServices_version_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BitServices_version_1.ViewsBitServices_version_1.Views  5      ;    5BitServices_version_1.Views.ContractorSkillManagement   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:BitServices_version_1.Views     5        N� Title$  ContractorSkillManagement��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   
�������$��2��68   .+�5      � 
������� 5      �� 5      $��2* �6'   �� 5      $	��300 �6'   .+�5      �� 
��� E��
�������$��10,0,0,0q�6G   $��0��5      $!��Contractor-Skill Management��6&   $��32(�6L   $��	ExtraBold"�6Z   $��Calibri Light)�6q   5      5      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dgContractors��5%   1      AutoGenerateColumns .  $��10, 10, 10, 10q�5$   /   $��1��5%      $��0��6    $��Visible=�5&      $��Visible=�5'       �� SelectedItem 5"      �� *SelectedContractor+��5#      �� *Contractors+ �� Mode$ TwoWay=�   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ ContractorID��6F   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6\   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *ContractorId+6h     5*      $ 	FirstName��6C   $	 * 6V   
 6%   �� *	FirstName+6b     5+      $ LastName��6B   $	 * 6T   
 6%   �� *
LastName+6`     5,      $	 DOB��6=   $	 * 6J   
 6%   �� *DOB+6V     5-      $ Phone��6?   $	 * 6N   
 6%   �� *Phone+6Z     5.      $ Email��6?   $	 * 6N   
 6%   �� *Email+6Z     5/      $ Address��6A   $	 * 6R   
 6%   �� *	Address+6^     50      $ Suburb��6@   $	 * 6P   
 6%   �� *Suburb+6\     51      $ PostCode��6B   $	 * 6T   
 6%   �� *
PostCode+6`     52      $ State��6?   $	 * 6N   
 6%   �� *State+6Z     54      $ Status��6@   $	 * 6P   
 6%   �� *Status+6\     55      $ Score��6?   $	 * 6N   
 6%   �� *Score+6Z   57        5;   
   -   5        $ dgContractorSkills��5;   G   $��1��6   $��1��6    ���	#FF9CB5BE$��0, 10, 10, 10q�6c    .  ��5=      �� *%#SelectedContractor.ContractorSkills+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5@        5A      $ Contractor Skills��6C   $	 * 6^   
 6%   �� *	SkillName+6^   5C      � 5I   
   $��2��6   $��2��6   $��10,10,10,10q�61    5J      �� 5K      �� 5L      $��389.6 �6#   .+�5N      � $��0��6   
������� 5O      �� 5P      $��1* �6'   �� 5Q      $��2* �6'    5S      �� 5T      $��1* �6$   �� 5U      $��1* �6$   �� 5V      $��1* �6$   �� 5W      $��1* �6$   �� 5X      $��1* �6$   5_      � 5d      $��1��6   
������� 5e      �� 5f      $��1* �6'   �� 5g      $��2* �6'    5i      �� 5j      $
��17.4 �6$   �� 5k      $
��33.8 �6$   �� 5l      $
��Auto �6$   �� 5m      $
��Auto �6$   �� 5n      $��52 �6$   �� 5o      .+�5s      �� -   5         ��Name$ cboSkillsList��5u      $��0��5t      $��0��6"   $��-135,10,259.6,0q�5v      $	��Top=�5w      $��22��5x       �� SelectedValue$ 	SkillName��5y       �� DisplayMemberPath$ 	SkillName��5z       J� RenderTransformOrigin$ 0.495,0.755&�5}      $��2��69   $��2��6M   ��5{      �� *Skills+$ TwoWay=� 5|      �� *SelectedSkill+$ TwoWay=���5~      �� 5       �� 
TargetType" ��6    .�5�      ��  �� Property � {� �� Value 5�      �� *	SkillName+$ TwoWay=�5�      5�      5�      �� 5�      $��Please Select A Skill��6   $��Calibri Light)�64   $
��Left=�6O   $��
130,10,0,0q�6j   $	��Top=�6~   5�      �� 5�   
   $��3��6   $��2��6"   ���	#FF8DC7DC$��	10,0,10,0q�6M   .+�5�      �  5�      �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   �� 5�      $��1* �6'   .+�5�      �� -   5         ��Name$ btnAddSkill��5�      $��5,5,5,0q�6S   $��15(�6d   $��	ADD SKILL��5�      $��0��6.   $��31��6>   $	��Top=�6J   ��5�   /   �� *AddSkillCommand+5�   J   �� 5�      -   5        $ btnDeleteSkill��5�      $��31��5�      $��5,5,5,0q�6%   $��15(�67   $��DELETE SKILL��6E   $��1��5�      ��5�   2   �� *DeleteCommand+5�      �� 5�      -   5        $ btNSaveContractorSkills��5�      $��5,5,5,0q�6;   $��15(�6M   $��SAVE SKILLS��5�      $��2��60   $��31��6@   $��Bottom=�5�      65   �� 5�      -   5        $ 	btnCancel��5�      $��5,5,5,0q�6-   $��31��6?   $��15(�6K   $��CANCEL��5�      $��3��6+   5�      5�      5�      5�      