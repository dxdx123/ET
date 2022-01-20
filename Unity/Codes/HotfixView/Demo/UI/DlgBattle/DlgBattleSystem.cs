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
			self.View.EButton_ExitBtnButton.AddListener(() => { self.OnExitClick().Coroutine(); });
		}

		public static void ShowWindow(this DlgBattle self, Entity contextData = null)
		{
		}

		public static async ETTask OnExitClick(this DlgBattle self)
		{
			await QuitMapHelper.QuitMap(self.ZoneScene());
		}

	}
}
