namespace ET
{
	public  class DlgTest :Entity, IAwake
	{

		public DlgTestViewComponent View { get => this.Parent.GetComponent<DlgTestViewComponent>();} 

		 

	}
}
