using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static class DlgBattleSystem
	{

		public static void RegisterUIEvent(this DlgBattle self)
		{
			self.View.EButton_ExitBtnButton.AddListener(() => { self.OnExitClick(); });
		}

		public static void ShowWindow(this DlgBattle self, Entity contextData = null)
		{
		}

		public static void OnExitClick(this DlgBattle self)
		{
			QuitMapHelper.QuitMap(self.DomainScene());
		}

	}
}
