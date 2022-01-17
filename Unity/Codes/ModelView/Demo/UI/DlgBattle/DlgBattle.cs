namespace ET
{
	public  class DlgBattle : Entity, IAwake
	{

		public DlgBattleViewComponent View { get => this.Parent.GetComponent<DlgBattleViewComponent>();} 

		 

	}
}
