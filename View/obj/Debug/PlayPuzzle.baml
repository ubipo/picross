   M S B A M L   `   `   `  ????c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      ? ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView 5      %clr-namespace:View.Util	View.Util 5      -clr-namespace:View.ControlsView.Controls 5	      1clr-namespace:View.ConvertersView.Converters 5
      /clr-namespace:View.BehaviorsView.Behaviors 5         View.PlayPuzzle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      $localclr-namespace:View     5      (utilclr-namespace:View.Util     5      0controlsclr-namespace:View.Controls     5	      4
convertersclr-namespace:View.Converters     5
      2	behaviorsclr-namespace:View.Behaviors     5        ? 	Resources  5       ?? 
TargetType   SquareElement ?? Property ?? Value ?? RelativeSource  View.Util.BindingProxy 	 proxy   Data??%?   &	        &	 ?     ?? 5      " ??6
   .?5      ??  ? ?? 6    ?? *ActualHeight+ ?? *Self+?? 5       ? ?? 6!   ?? *ActualWidth+ ?? *Self+5        5       6$   ?? 5      .??5      ??  ?? Orientation$ Vertical=?6   $??Center=?6%   $??Center=?6B   .+?5      ?? $ 
Horizontal=?6   .+?5      "  View.Controls.PiCrossControl  -   5          Name$ picrossControl??5         Grid 64   ?? *Grid+	   RowConstraints	 6J   ?? *RowConstraints+
   ColumnConstraints
 6t   ?? *ColumnConstraints+   	Thumbnail 5      ?? 5      #??[  6   $??64??69   $	??5 5q?6G   ??5      !? 5       j? TileMode$
 None=?6    j? Stretch$
 Fill=?6$    j? 
AlignmentX$
 Left=?63    j? 
AlignmentY$	 Top=?6E    !? Visual 5   	   ?? 5   
   $	??100??6   $	??100??6    J? Clip 5      ?? 5        ?? Path$ ContainsUnknowns.Value?6    ?? 	Converter 5!      &   View.Converters.BooleanConverter  5"         True 5#      B? 5$      .??5%      E?  E? 
StartPoint$	 0 0&?6   .??5&      ??  ?? Point$ 100 100&?6   5'      E? 5(      $
 50 0&?6   .??5)      ??  ?? Size$ 50 50??6    ?? SweepDirection$ 	Clockwise=?6*    ?? 
IsLargeArc .  ?? Point 5*      ?? 5+      $ Data.UnknownRatio.Value?6    ?? Source# [ 6;    5,      )  #View.Converters.ValueConverterGroup  5-      ) #View.Converters.RatioAngleConverter  5.      , &View.Converters.AngleLegPointConverter  5/         Center$ 50, 50??69      	LegLength$ 50Q?6I   * $View.Converters.PointStringConverter  50      51      53      55      ?? 56      $ 50 50&?6   57      58         False 5:      ?? 5;       ?? Rect$ 0 0 100 100?6"   5=      5?      ??5A      ?? 5B      $ IsSolved.Value?6    5C        5D      $ Images/seashell-nice.png??6*   $ Images/seashell.png??6J   5F      5H      5J   	   5L          SquareTemplate  5P      ?? 5Q      .R?5R      ?? $??32??6   $??32??6   
???   ?'  !View.Behaviors.MouseEnterBehavior!   MouseLeftPressedEnter! 5S      ?? *MarkFillLikeLastCmd+"   MouseRightPressedEnter" 5T      ?? *MarkEmptyLikeLastCmd+??5U      ?? 5V   	   $! PuzzleSquare.Contents.Value?6    5W   
   %	  View.Converters.SquareConverter	  5X      # 	  Empty$# White??6&   $ 	  Filled$$ #f8ff77??64   % 	  Unknown$
% Gray??6E   5Z   
   & J? InputBindings& 5\      d? 5]   	   ' d? Gesture$' 	LeftClicka?6   ( ?? Command( 6*   ?? *MarkFillCmd+d? 5^   	   $' 
RightClicka?6   ( 6+   ?? *MarkEmptyCmd+5`      5a      )   RowConstraintsTemplate) 5e      ?? 5f      .R?5g      ?? ??6   ?? *Values+??5h      ?? 5i   	   .R?5j   
   ?? $ 
Horizontal=?6   ??5k      ?? 5l      $ IsSatisfied.Value?6    5m        5n      $ #36a334??6*   $ #169cba??69   5p      5r      5s   
   ??5u      ?? 5v   	   .R?5w   
   ?? $??32??6   $??32??6   $??4q?6(   ._?5x      ?? $??Center=?6,   $??Center=?6G   ??6   ?? *Value+6G   ??5y      ?? 5z      $ IsSatisfied.Value?6    5{        5|      $ #36a334??6*   $ #169cba??69   5~      5?      5?   
   5?      5?       *   ColumnConstraintsTemplate* 5?      ?? 5?      .R?5?      ?? ??6   ?? *Values+??5?      ?? 5?   	   .R?5?   
   ?? $ Vertical=?6   ??5?      ?? 5?      $ IsSatisfied.Value?6    5?        5?      $ #36a334??6*   $ #169cba??69   5?      5?      5?   
   ??5?      ?? 5?   	   .R?5?   
   ?? $??32??6   $??32??6   $??4q?6(   ._?5?      ?? $??Center=?6,   $??Center=?6G   ??6   ?? *Value+6G   ??5?      ?? 5?      $ IsSatisfied.Value?6    5?        5?      $ #36a334??6*   $ #169cba??69   5?      5?      5?   
   5?      5?      5?      5?      ]? 5?      $??Stretch=?6   ??.  .+?5?      ?? $
??Left=?6   $
??Back??6"   $
??Auto??61   ??6>   ?? *	BackCmd+?? 5?      $??Right=?6   $??	View time??6#   $
??Auto??67   ??6D   ?? *SaveTimeCmd+{?6d   ?? *IsSolved.Value+5?      r? 5?      -   5        + r?Name$+ SolvedSound??5?   +   , r? Source$, /Images/wave.mp3??6   - r? LoadedBehavior- 5?      ?? 5?      $ IsSolved.Value?6    5?        5?      $
 Play??6$   $
 Stop??60   6?   5?      5?      5?      5?      