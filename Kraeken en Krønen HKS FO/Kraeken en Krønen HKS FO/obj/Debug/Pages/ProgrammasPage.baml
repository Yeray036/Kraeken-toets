   M S B A M L   `   `   `  ����T  PKraeken en Krønen HKS FO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Kraeken_en_Krønen_HKS_FO.PagesKraeken_en_Krønen_HKS_FO.Pages  5      4    .Kraeken_en_Krønen_HKS_FO.Pages.ProgrammasPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Kraeken_en_Krønen_HKS_FO.Pages     5      U QMaterialDesignThemes.Wpf, Version=3.1.0.981, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N� Title$  ProgrammasPage��5	         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       N� 
Background �	#FF3F3F46  MaterialDesignFont N� 
FontFamily# �  5      .��5      � ���	#FF3F3F46 � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��0��6"   $��4��62   $
��10,0q�6F   .+�5!      �� -   5         ��Name$ SearchProgrammaTxt��5!   �   
�������$
��20px(�6)   ���	#FF62626A$
��auto��6P   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Zoek programma��6^   $��Center=�6�   5"      �� 5$   
   -   5        	 ��Name$	 SearchBtntitle��5$   W   $��Center=�6   $��Center=�63   $��Right=�6o   $��4��6�   $��0��6�   $��0,0,10,0q�6�   .��5%      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�62   .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6*   $
��auto��68   $
��auto��6F   5'      5(      �� 5*   
   $��1��6   $��0��6"   $��4��62   $
��10,0q�6F   .+�5+      �� -   5         ��Name$ GevondenProgrammaLabel��5+   U   $��Gevonden programmas��6   
�������$
��18px(�6E   6U   �� 5,      ���	#FF62626A$
��Auto=�62   $
��Auto=�6W   .��5-      &   System.Windows.Controls.DataGrid  -   5          Name$ DetailedProgrammaGrid��5-         AutoGenerateColumns .    CanUserAddRows .  ��6U   ��    Columns 5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Detailed Overzicht��61      CellTemplate 50      �� 51   "   .R�52   &   �� -   5        
�������$��	overzicht��52   @   $��0,0,5,0q�6T   6e   53   #   55      57      58      59      �� 5;   
   $��2��6   $��0��6"   $��4��62   $	��Top=�6F   .+�5<      �� ���	#FF62626A$
��Auto=�62   $
��Auto=�6W   .��5=      � -   5         �Name$ DetailedProgrammaPanel��5=      $��Center=�6<   5>      5?      5A      5B      