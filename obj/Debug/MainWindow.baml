   M S B A M L   `   `   `  ����H  DRawJpgRemover, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:RawJpegRemoverRawJpegRemover  5   	       RawJpegRemover.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:RawJpegRemover     5   	     � Title$  JPG RAW Remover��5   	   $��292.987��6!   $��796.005��62   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��673* �6   �� 5      $
��107* �6   .+�5   
   �� -   5         ��Name$ jpgFolderSelectButton��5      $��Select JPG files folder��60   $
��Left=�6R   $��30��6m   $��	582,4,0,0q�6y   $	��Top=�6�   $	��188��6�   $��2��6�   �� 5   
   -   5        $ rawFolderSelectButton��5      $��Select RAW files folder��60   $
��Left=�6R   $��30��6m   $��
582,48,0,0q�6y   $	��Top=�6�   $	��188��6�   $��2��6�   �� 5   
   -   5         ��Name$ rawTypeSelector��5      $
��Left=�6,   $��582,103,0,0q�6G   $	��Top=�6\   $	��188��6t   $��2��6�   �� 5   
   -   5         ��Name$ jpgFolderSelectText��5      $
��Left=�61   $��20,8,0,0q�6L   $
��Wrap=�6^   $��Select JPG folder��6r   $	��Top=�6�   $��42��6�   $	��538��6�   �� 5   
   -   5        $ rawFolderSelectText��5      $
��Left=�61   $��	20,55,0,0q�6L   $
��Wrap=�6_   $��Select RAW folder��6s   $	��Top=�6�   $��43��6�   $	��538��6�   �� 5   
   -   5        $ rawFileTypeSelect��5      $
��Left=�6/   $��
20,103,0,0q�6J   $
��Wrap=�6^   $��Select your RAW file type��6r   $	��Top=�6�   �� 5   
   -   5        $ startOperation��5      $��Start delete files��6)   $
��Left=�6F   $��30��6a   $��280,210,0,0q�6m   $	��Top=�6�   $	��188��6�   6�   �� 5   
   -   5        $ credits��5      $
��Left=�6%   $��
10,224,0,0q�6@   $
��Wrap=�6T   $!��Created by: Dor Shtarker ©��6h   $	��Top=�6�   �� 5   
   -	   5         ��Name$ deleteSelection��5      $��Select deletion method��6,   $
��Left=�6L   $��56��6g   $��
20,139,0,0q�6s   $	��Top=�6�   $	��741��6�   $��2��6�   5      	� 5   
   -
   5         	�Name$ rawByJpg��5      $#��Delete Raw files By Jpg files��6(   $
��Left=�6P   $��
36,166,0,0q�6k   $	��Top=�6    d� 	IsChecked$
 TrueY�6�   	� 5   
   -   5        $ jpgByRaw��5      $#��Delete Jpg files By Raw files��6(   $
��Left=�6P   $��270,166,0,0q�6k   $	��Top=�6�   	� 5   
   -   5        $ 
bothDelete��5      $��Delete Raw and Jpg files��6*   $
��Left=�6M   $��517,166,0,0q�6h   $	��Top=�6}   5      5      