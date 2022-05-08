using System.Windows.Controls;
using System.Windows.Media;

namespace CourseworkUI.Services
{
	internal class Validator
	{
		private Control _control;
		private string _text;

		private bool _success = true;

		public Validator(Control control, string text)
		{
			_control = control;
			_text = text;
		}

		public Validator MinCharacters(int count)
		{
			if (_text.Length < count)
				_success = false;
			return this;
		}

		public void Validate()
		{
			if (!_success)
			{
				_control.ToolTip = "Invalid input";
				_control.Background = Brushes.DarkRed;
			}
			else
			{
				_control.ToolTip = null;
				_control.Background = Brushes.Transparent;
			}
		}
	}
}
