using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static class DlgLobbySystem
	{

		public static void RegisterUIEvent(this DlgLobby self)
		{
			self.View.EButton_EnterMap.AddListener(() => { self.OnEnterMapClick(); });
		}

		public static void ShowWindow(this DlgLobby self, Entity contextData = null)
		{
		}

		public static void OnEnterMapClick(this DlgLobby self)
		{
			EnterMapHelper.EnterMapAsync(self.ZoneScene()).Coroutine();
		}

	}
}
