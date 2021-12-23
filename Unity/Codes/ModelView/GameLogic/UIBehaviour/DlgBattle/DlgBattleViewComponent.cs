
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgBattleViewComponent : Entity 
	{
		public UnityEngine.RectTransform EGBackGround
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGround == null )
     			{
		    		this.m_EGBackGround = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGround;
     		}
     	}

		public UnityEngine.UI.Button EButton_ExitBtn
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ExitBtn == null )
     			{
		    		this.m_EButton_ExitBtn = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_ExitBtn");
     			}
     			return this.m_EButton_ExitBtn;
     		}
     	}

		public UnityEngine.UI.Image EButton_ExitBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ExitBtnImage == null )
     			{
		    		this.m_EButton_ExitBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_ExitBtn");
     			}
     			return this.m_EButton_ExitBtnImage;
     		}
     	}

		public UnityEngine.RectTransform m_EGBackGround = null;
		public UnityEngine.UI.Image m_EButton_ExitBtnImage = null;
		public UnityEngine.UI.Button m_EButton_ExitBtn = null;
		public Transform uiTransform = null;
	}
}
