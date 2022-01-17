
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgBattleViewComponentAwakeSystem : AwakeSystem<DlgBattleViewComponent> 
	{
		public override void Awake(DlgBattleViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgBattleViewComponentDestroySystem : DestroySystem<DlgBattleViewComponent> 
	{
		public override void Destroy(DlgBattleViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
