   M S B A M L   `   `   `  ���� I  ERawJpegRemover, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:RawJpegRemoverRawJpegRemover      RawJpegRemover.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:RawJpegRemover       � Title$  JPG RAW Remover��$��292.987��$��796.005��.���  � ColumnDefinitions �� $
��673* ��� $
��107* �.+��� -    ��Name$ jpgFolderSelectButton��$��Select JPG files folder��$
��Left=�$��30��$��	582,4,0,0q�$	��Top=�$	��188��$��2���� -   $ rawFolderSelectButton��$��Select RAW files folder��$
��Left=�$��30��$��
582,48,0,0q�$	��Top=�$	��188��$��2���� -    ��Name$ rawTypeSelector��$
��Left=�$��582,103,0,0q�$	��Top=�$	��188��$��2���� -    ��Name$ jpgFolderSelectText��$
��Left=�$��20,8,0,0q�$
��Wrap=�$��Please Select JPG folder��$	��Top=�$��42��$	��538���� -   $ rawFolderSelectText��$
��Left=�$��	20,55,0,0q�$
��Wrap=�$��Please select RAW folder��$	��Top=�$��43��$	��538���� -   $ rawFileTypeSelect��$
��Left=�$��
20,103,0,0q�$
��Wrap=�$&�� Please select your RAW file type��$	��Top=��� -   $ startOperation��$��Start delete files��$
��Left=�$��30��$��280,210,0,0q�$	��Top=�$	��188���� -   $ credits��$
��Left=�$��
10,224,0,0q�$
��Wrap=�$$��Created by: Dor Shtarker, 2019��$	��Top=��� -	    ��Name$ deleteSelection��$��Select deletion method��$
��Left=�$��56��$��
20,139,0,0q�$	��Top=�$	��741��$��2��	� -
    	�Name$ rawByJpg��$#��Delete Raw files By Jpg files��$
��Left=�$��
36,166,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�	� -   $ jpgByRaw��$#��Delete Jpg files By Raw files��$
��Left=�$��270,166,0,0q�$	��Top=�	� -   $ 
bothDelete��$��Delete Raw and Jpg files��$
��Left=�$��517,166,0,0q�$	��Top=�