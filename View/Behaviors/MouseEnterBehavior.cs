using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace View.Behaviors
{
	public class MouseEnterBehavior : Behavior<TextBox>
	{
		public static readonly DependencyProperty MouseEnterProperty =
		   DependencyProperty.RegisterAttached("MouseEnter",
											   typeof(ICommand),
											   typeof(MouseEnterBehavior),
											   new PropertyMetadata(null, MouseEnterChanged));

		public static ICommand GetMouseEnter(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(MouseEnterProperty);
		}

		public static void SetMouseEnter(DependencyObject obj, ICommand value)
		{
			obj.SetValue(MouseEnterProperty, value);
		}

		private static void MouseEnterChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			UIElement uiElement = obj as UIElement;

			if (uiElement != null)
				uiElement.MouseEnter += new MouseEventHandler(uiElement_MouseEnter);
		}


		public static ICommand GetMouseLeftPressedEnter(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(MouseLeftPressedEnterProperty);
		}

		public static void SetMouseLeftPressedEnter(DependencyObject obj, ICommand value)
		{
			obj.SetValue(MouseLeftPressedEnterProperty, value);
		}

		// Using a DependencyProperty as the backing store for MouseDownEnter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MouseLeftPressedEnterProperty =
			DependencyProperty.RegisterAttached("MouseLeftPressedEnter", typeof(ICommand), typeof(MouseEnterBehavior), new PropertyMetadata(null, MouseEnterChanged));


		public static ICommand GetMouseRightPressedEnter(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(MouseRightPressedEnterProperty);
		}

		public static void SetMouseRightPressedEnter(DependencyObject obj, ICommand value)
		{
			obj.SetValue(MouseRightPressedEnterProperty, value);
		}

		// Using a DependencyProperty as the backing store for MouseDownEnter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MouseRightPressedEnterProperty =
			DependencyProperty.RegisterAttached("MouseRightPressedEnter", typeof(ICommand), typeof(MouseEnterBehavior), new PropertyMetadata(null, MouseEnterChanged));


		private static void uiElement_MouseEnter(object sender, MouseEventArgs e)
		{
			UIElement uiElement = sender as UIElement;
			if (uiElement != null)
			{
				ICommand mouseEnter = GetMouseEnter(uiElement);
				if (mouseEnter != null)
				{
					mouseEnter.Execute(null);
				}

				ICommand mouseLeftPressedEnter = GetMouseLeftPressedEnter(uiElement);
				if (e.LeftButton == MouseButtonState.Pressed && mouseLeftPressedEnter != null)
				{
					
					mouseLeftPressedEnter.Execute(null);
				}

				ICommand mouseRightPressedEnter = GetMouseRightPressedEnter(uiElement);
				if (e.RightButton == MouseButtonState.Pressed && mouseRightPressedEnter != null)
				{
					
					mouseRightPressedEnter.Execute(null);
				}
			}
		}
	}
}
