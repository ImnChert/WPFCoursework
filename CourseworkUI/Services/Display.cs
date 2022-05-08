using System.Windows.Controls;

namespace CourseworkUI.Services
{
	internal class Display
	{
		private Control _control;
		private string _text;

		public Display(Control control, string text)
		{
			_control = control;
			_text = text;
		}

		public void CheckLostFocus(string str)
		{
			if (_text == "" || _text == null)
				ChangeText(str);
		}

		public void CheckGotFocus(string str)
		{
			if (_text == str)
				ChangeText("");
		}

		private void ChangeText(string str)
		{
			if (_control is TextBox textBox)
				textBox.Text = str;
			else if (_control is PasswordBox passwordBox)
				passwordBox.Password = str;
		}
	}
}
