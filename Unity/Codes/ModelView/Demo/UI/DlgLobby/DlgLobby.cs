namespace ET
{
	public  class DlgLobby : Entity, IAwake
	{

		public DlgLobbyViewComponent View { get => this.Parent.GetComponent<DlgLobbyViewComponent>();} 

		 

	}
}
