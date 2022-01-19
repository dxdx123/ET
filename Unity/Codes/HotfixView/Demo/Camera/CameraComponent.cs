using UnityEngine;

namespace ET
{
	[ObjectSystem]
	public class CameraComponentAwakeSystem : AwakeSystem<CameraComponent, Scene>
	{
		public override void Awake(CameraComponent self, Scene zoneScene)
		{
			self.Awake(zoneScene);
		}
	}

	[ObjectSystem]
	public class CameraComponentLateUpdateSystem : LateUpdateSystem<CameraComponent>
	{
		public override void LateUpdate(CameraComponent self)
		{
			self.LateUpdate();
		}
	}

	public class CameraComponent : Entity, IAwake, ILateUpdate, IAwake<Scene>
	{
		// 战斗摄像机
		public Camera mainCamera;

		public Unit Unit;

		public Camera MainCamera
		{
			get
			{
				return this.mainCamera;
			}
		}

		public void Awake(Scene zoneScene)
		{
			this.mainCamera = Camera.main;
			this.Unit = UnitHelper.GetMyUnitFromZoneScene(zoneScene);
		}

		public void LateUpdate()
		{
			// 摄像机每帧更新位置
			UpdatePosition();
		}

		private void UpdatePosition()
		{
			var mainCameraTransform = this.mainCamera.transform;
			Vector3 cameraPos = mainCameraTransform.position;
			var offsetX = 5; 
			var offsetY = 5;
			mainCameraTransform.position = new Vector3(this.Unit.Position.x - offsetX, offsetY, this.Unit.Position.z);

			var unitView = this.Unit.GetComponent<GameObjectComponent>();
			if (unitView != null)
			{
				mainCameraTransform.LookAt(unitView.GameObject.transform);
			}
		}
	}
}
