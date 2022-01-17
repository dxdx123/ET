
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgLoginViewComponent : Entity, IAwake, IDestroy
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

		public UnityEngine.UI.InputField EInputField_Account
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputField_Account == null )
     			{
		    		this.m_EInputField_Account = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/EInputField_Account");
     			}
     			return this.m_EInputField_Account;
     		}
     	}

		public UnityEngine.UI.InputField EInputField_Password
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputField_Password == null )
     			{
		    		this.m_EInputField_Password = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/EInputField_Password");
     			}
     			return this.m_EInputField_Password;
     		}
     	}

		public UnityEngine.UI.Button EButton_LoginBtn
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_LoginBtn == null )
     			{
		    		this.m_EButton_LoginBtn = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_LoginBtn");
     			}
     			return this.m_EButton_LoginBtn;
     		}
     	}

		public UnityEngine.UI.Image EButton_LoginBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_LoginBtnImage == null )
     			{
		    		this.m_EButton_LoginBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_LoginBtn");
     			}
     			return this.m_EButton_LoginBtnImage;
     		}
     	}

		public UnityEngine.RectTransform m_EGBackGround = null;
		public UnityEngine.UI.InputField m_EInputField_Account = null;
		public UnityEngine.UI.InputField m_EInputField_Password = null;
		public UnityEngine.UI.Image m_EButton_LoginBtnImage = null;
		public UnityEngine.UI.Button m_EButton_LoginBtn = null;
		public Transform uiTransform = null;
	}
}
