   M S B A M L   `   `   `  ?????  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5      /clr-namespace:View.BehaviorsView.Behaviors  5          View.ChooseGame   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:View     5      2	behaviorsclr-namespace:View.Behaviors     5      .??5
      ??   ?? Orientation$  Vertical=?6   $??Center=?6%   $??Center=?6B   .+?5      ?? $??Center=?6
   $??20(?6'   .??65   Pieter's PiCross Puzzles6O   ?? 5      $  
Horizontal=?6   .+?5      ?? $??0,0,10,0q?6   $??5q?6    ??5      ?? 5      .??6   Play or edit6   .??5      ?? $  Vertical=?6   .+?5      ?? $
??Auto??6   $	??150??6u   $??Stretch=?6?   ??6   ?? *PuzzleEntries.Value+ ?? SelectedItem 6J   ?? *Selection.Value+??5      ?? 5   	   .R?5   
   ?? $
??Wrap=?6'   $??Stretch=?6;   ??6   ??  J? InputBindings 5      d? 5       d? Gesture$ LeftDoubleClicka?67    ?? Command 6   ?? *	PlayCmd+67   5      5   
   5      ?? 5      ??6   ?? *	PlayCmd+.??6,   Play!63   ?? 5      ??6   ?? *	EditCmd+.??6,   	Edit...65   5      5       ?? 5!      $  Vertical=?6   .+?5"      ?? $??5q?6   ??5#      ?? 5$      .??6   Create6   .??5&      ?? $  Vertical=?6   .+?5'      ]? .+?5(   	   ?? $  
Horizontal=?6   $
??Left=?6-   .+?5)   
   ?? .??6   Width6   ?? 5*   
    ?? 	MaxLength$ 2??6   '   !View.Behaviors.NumberOnlyBehavior   	IsEnabled . $??30??6N   $??Center=?6Y   $	??0,3q?6{   ??6?   ?? *CreateWidth+5+   
   ?? 5,   	   $  
Horizontal=?6   $??Right=?6-   .+?5-   
   ?? .??6   Height6   ?? 5.   
   $ 2??6    . $??30??6N   $??Center=?6Y   $	??0,3q?6{   ??6?   ?? *CreateHeight+5/   
   50   	   ]? 51      ??. .+?52   	   ?? $
??Left=?6   .??6%   Author6-   ?? 53   	   $??Right=?6   $??Center=?6k   $	??0,2q?6?   ??6(   ?? *CreateAuthor+ ?? UpdateSourceTrigger$ PropertyChanged=?6?   54   	   ?? 55      $??0,10,0,0q?6/   ??6   ?? *	CreateCmd+.??6A   Create puzzle6P   ?? 56      $
??Wrap=?65   $	??150??6I   
???  ????6   ?? *CreateErr.Value+6k    57      ?? 58   	   
 ?? Key$ Return??6    6!   ?? *	CreateCmd+5:      5;      ?? 5<      ??5=      ?? 5>      .??6   	Library6   .??5@      ?? $  Vertical=?6   .+?5A      ?? ??6   ?? *DeleteLibCmd+.??62   Delete all data6C   ?? 5B      ??6   ?? *PopulateLibCmd+.??64   Populate with mock data6M   5C      5D      5E      5F      5G      5H      