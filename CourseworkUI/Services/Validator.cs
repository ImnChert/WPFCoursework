using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;

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

		public Validator MaxCharacters(int count)
		{
			if (_text.Length > count)
				_success = false;
			return this;
		}

		public Validator OnlyText()
		{
			Regex regex = new Regex(@"[A-Z][a-z]");
			Match match = regex.Match(_text);

			if (!match.Success)
				_success = false;
			return this;
		}

		public Validator IsNotEmpty()
		{
			if (!_text.Any(t => t != ' ') || _text == null || _text == "")
				_success = false;
			return this;
		}

		public Validator CorrectUsername()
		{
			if (!Regex.IsMatch(_text, @"^\p{Lu}[\w\d\s_]{1,19}$"))
				_success = false;
			return this;
		}

		public void ValidateControl()
		{
			if (!_success)
			{
				ValidateControlError();
			}
			else
			{
				_control.ToolTip = null;
				_control.Background = Brushes.Transparent;
			}
		}

		public void ValidateControlError()
		{
			_control.ToolTip = "Invalid input";
			_control.Background = Brushes.IndianRed;
		}
	}
}
