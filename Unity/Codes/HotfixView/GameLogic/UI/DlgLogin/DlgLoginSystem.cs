using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static class DlgLoginSystem
	{
		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.EButton_LoginBtn.AddListener(() => { self.OnLoginClick(); });
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
		}

		public static void OnLoginClick(this DlgLogin self)
		{
			//UIComponent.Instance.ShowWindow(WindowID.WindowID_Test);
			LoginHelper.Login(self.DomainScene(), ConstValue.LoginAddress,
				self.View.EInputField_Account.text, self.View.EInputField_Password.text);
			//UIComponent.Instance.CloseWindow(WindowID.WindowID_Login);
		}

	}
}
