using System.Windows.Controls;

namespace CourseworkUI.Services
{
	internal static class ControlValidationExtension
	{
		public static Validator Rules(this TextBox control) => new Validator(control, control.Text);
		public static Validator Rules(this PasswordBox control) => new Validator(control, control.Password);
		public static Display ShadowText(this TextBox control) => new Display(control, control.Text);
		public static Display ShadowText(this PasswordBox control) => new Display(control, control.Password);
		public static bool IsCorrect(this Control control) => control.ToolTip == null;
	}
}
