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
			self.View.EButton_LoginBtn.AddListenerAsync(() => { return self.OnLoginClick(); });
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
		}

		public static async ETTask OnLoginClick(this DlgLogin self)
		{
			try
			{
				int errorCode = await LoginHelper.Login(self.DomainScene(),
					ConstValue.LoginAddress,
					self.View.EInputField_Account.text,
					self.View.EInputField_Password.text);

				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				
				self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
				self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

	}
}
