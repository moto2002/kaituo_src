using Assets.Scripts.Tool;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRpgCamera : MonoBehaviour
{
	public enum RotationControlType
	{
		Swipe,
		TwoTouchRotate,
		Drag
	}

	public enum PanControlType
	{
		Swipe,
		Drag
	}

	public EnableController enableController;

	public LayerMask collisionLayers = default(LayerMask);

	public LayerMask avoidanceLayers = default(LayerMask);

	[HideInInspector]
	public float collisionBuffer = 0.2f;

	public LayerMask collisionAlphaLayers = default(LayerMask);

	[HideInInspector]
	public float collisionAlpha = 0.15f;

	[HideInInspector]
	public float collisionFadeSpeed = 10f;

	[HideInInspector]
	public float avoidanceSpeed = 0.5f;

	[HideInInspector]
	public Transform target;

	[HideInInspector]
	public string targetTag = string.Empty;

	[HideInInspector]
	public Vector3 targetOffset = default(Vector3);

	[HideInInspector]
	public bool smoothOffset = true;

	[HideInInspector]
	public float smoothOffsetSpeed = 5f;

	[HideInInspector]
	public bool relativeOffset = true;

	[HideInInspector]
	public bool useTargetAxis;

	[HideInInspector]
	public bool softTracking;

	[HideInInspector]
	public float softTrackingRadius = 3f;

	[HideInInspector]
	public float softTrackingSpeed = 3f;

	[HideInInspector]
	public bool allowMouseDrag;

	[HideInInspector]
	public MouseButton mouseDragButton = MouseButton.None;

	[HideInInspector]
	public Vector2 mouseDragSensitivity = new Vector2(15f, 15f);

	[HideInInspector]
	public bool allowEdgeMovement;

	[HideInInspector]
	public bool allowEdgeKeys;

	[HideInInspector]
	public bool lockToTarget;

	[HideInInspector]
	public bool limitBounds;

	[HideInInspector]
	public Vector3 boundOrigin = default(Vector3);

	[HideInInspector]
	public Vector3 boundSize = default(Vector3);

	[HideInInspector]
	public float edgePadding = 20f;

	[HideInInspector]
	public float scrollSpeed = 10f;

	[HideInInspector]
	public KeyCode keyFollowTarget = KeyCode.Space;

	[HideInInspector]
	public KeyCode keyMoveUp = KeyCode.W;

	[HideInInspector]
	public KeyCode keyMoveDown = KeyCode.S;

	[HideInInspector]
	public KeyCode keyMoveLeft = KeyCode.A;

	[HideInInspector]
	public KeyCode keyMoveRight = KeyCode.D;

	[HideInInspector]
	public bool showEdges;

	[HideInInspector]
	public Texture2D edgeTexture;

	[HideInInspector]
	public bool allowRotation = true;

	[HideInInspector]
	public string mouseHorizontalAxis = "Mouse X";

	[HideInInspector]
	public string mouseVerticalAxis = "Mouse Y";

	[HideInInspector]
	public bool invertRotationX;

	[HideInInspector]
	public bool invertRotationY;

	[HideInInspector]
	public bool mouseLook;

	[HideInInspector]
	public bool disableWhileUnlocked = true;

	[HideInInspector]
	public bool useJoystick;

	[HideInInspector]
	public Vector2 joystickSensitivity = new Vector2(1f, 1f);

	[HideInInspector]
	public string joystickHorizontalAxis = "JoystickHorizontal";

	[HideInInspector]
	public string joystickVerticalAxis = "JoystickVertical";

	[HideInInspector]
	public bool allowRotationLeft = true;

	[HideInInspector]
	public bool allowRotationMiddle = true;

	[HideInInspector]
	public bool allowRotationRight = true;

	[HideInInspector]
	public Vector2 originRotation = default(Vector2);

	[HideInInspector]
	public bool returnToOrigin;

	[HideInInspector]
	public bool returnToOriginOnKey;

	[HideInInspector]
	public KeyCode returnToOriginKey;

	[HideInInspector]
	public bool stayBehindTarget;

	[HideInInspector]
	public bool stayBehindTargetOnKey;

	[HideInInspector]
	public KeyCode stayBehindTargetKey;

	[HideInInspector]
	public KeyCode setOriginKey;

	[HideInInspector]
	public bool setOriginLeft;

	[HideInInspector]
	public bool setOriginMiddle;

	[HideInInspector]
	public bool setOriginRight;

	[HideInInspector]
	public float minAngle = -85f;

	[HideInInspector]
	public float maxAngle = 85f;

	[HideInInspector]
	public float rotationSmoothing = 5f;

	[HideInInspector]
	public bool autoSmoothing = true;

	[HideInInspector]
	public float returnSmoothing = 5f;

	[HideInInspector]
	public float returnDelay;

	[HideInInspector]
	public Vector2 rotationSensitivity = new Vector2(5f, 5f);

	[HideInInspector]
	public bool lockCursor = true;

	[HideInInspector]
	public bool lockLeft = true;

	[HideInInspector]
	public bool lockMiddle = true;

	[HideInInspector]
	public bool lockRight = true;

	[HideInInspector]
	public bool allowRotationKeys = true;

	[HideInInspector]
	public KeyCode keyRotateUp = KeyCode.Keypad5;

	[HideInInspector]
	public KeyCode keyRotateDown = KeyCode.Keypad2;

	[HideInInspector]
	public KeyCode keyRotateLeft = KeyCode.Keypad1;

	[HideInInspector]
	public KeyCode keyRotateRight = KeyCode.Keypad3;

	[HideInInspector]
	public Vector2 rotationKeySensitivity = new Vector2(3f, 3f);

	[HideInInspector]
	public bool rotateObjects;

	[HideInInspector]
	public List<Transform> objectsToRotate = new List<Transform>();

	[HideInInspector]
	public bool autoAddTargetToRotate;

	[HideInInspector]
	public bool rotateObjectsLeft;

	[HideInInspector]
	public bool rotateObjectsMiddle;

	[HideInInspector]
	public bool rotateObjectsRight;

	[HideInInspector]
	public bool allowZoom = true;

	[HideInInspector]
	public float distance = 7f;

	[HideInInspector]
	public float minDistance = 1f;

	[HideInInspector]
	public float maxDistance = 10f;

	[HideInInspector]
	public float zoomSpeed = 1f;

	[HideInInspector]
	public float zoomSmoothing = 5f;

	[HideInInspector]
	public bool invertZoom;

	[HideInInspector]
	public bool fadeObjects;

	[HideInInspector]
	public float fadeDistance = 1f;

	[HideInInspector]
	public List<Renderer> objectsToFade = new List<Renderer>();

	[HideInInspector]
	public bool autoAddTargetToFade;

	[HideInInspector]
	public bool allowZoomKeys = true;

	[HideInInspector]
	public KeyCode keyZoomIn = KeyCode.Home;

	[HideInInspector]
	public KeyCode keyZoomOut = KeyCode.End;

	[HideInInspector]
	public float keyZoomDelay = 0.5f;

	[HideInInspector]
	public bool allowTouch;

	[HideInInspector]
	public float touchSensitivity = 0.7f;

	[HideInInspector]
	public SimpleRpgCamera.RotationControlType mobileRotationType = SimpleRpgCamera.RotationControlType.Drag;

	[HideInInspector]
	public float mobileRotationDelay = 0.5f;

	[HideInInspector]
	public float mobileSwipeActiveTime = 0.5f;

	[HideInInspector]
	public float mobileSwipeMinDistance = 150f;

	[HideInInspector]
	public Vector2 mobileSwipeRotationAmount = new Vector2(45f, 45f);

	[HideInInspector]
	public SimpleRpgCamera.PanControlType mobilePanType = SimpleRpgCamera.PanControlType.Drag;

	[HideInInspector]
	public int mobilePanningTouchCount = 3;

	[HideInInspector]
	public float mobilePanSwipeActiveTime = 0.5f;

	[HideInInspector]
	public float mobilePanSwipeMinDistance = 150f;

	[HideInInspector]
	public Vector2 mobilePanSwipeDistance = new Vector2(5f, 5f);

	[HideInInspector]
	public float mobileZoomDeadzone = 7f;

	[HideInInspector]
	public float mobileZoomSpeed = 0.25f;

	private float _oldDistance;

	private Vector3 _currentOffset = default(Vector3);

	private Quaternion _oldRotation = default(Quaternion);

	private Vector2 _angle = default(Vector2);

	private float _zoomInTimer;

	private float _zoomOutTimer;

	private float _touchTimer;

	private float _touchDistance;

	private bool _mobileSwipe;

	private float _mobileSwipeStartTime;

	private Vector2 _mobileSwipeStart = default(Vector2);

	private float _mobileAngle;

	private bool _mobilePanSwipe;

	private float _mobilePanSwipeStartTime;

	private Vector2 _mobilePanSwipeStart = default(Vector2);

	private List<Material> _fadedMats = new List<Material>();

	private List<Material> _activeFadedMats = new List<Material>();

	private bool _controllable = true;

	private bool _userInControl;

	private float _returnTimer;

	private bool _avoidingObject;

	private bool _avoidingLeft;

	private Transform _t;

	private Transform _focalPoint;

	public bool Controllable
	{
		get
		{
			return this._controllable;
		}
		set
		{
			this._controllable = value;
		}
	}

	public Vector2 CurrentRotation
	{
		get
		{
			return this._angle;
		}
		set
		{
			this._angle = value;
			Quaternion quaternion = Quaternion.Euler(this._angle.y, this._angle.x, 0f);
			Quaternion oldRotation = (!this.useTargetAxis || !this.target) ? quaternion : (this.target.rotation * quaternion);
			this._oldRotation = oldRotation;
		}
	}

	public float CurrentDistance
	{
		get
		{
			return this._oldDistance;
		}
		set
		{
			this._oldDistance = value;
			this.distance = this._oldDistance;
		}
	}

	public void SetRpgCameraEnable(bool value)
	{
		base.enabled = value;
	}

	private void Awake()
	{
		this.enableController = new EnableController(new Action<bool>(this.SetRpgCameraEnable));
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
		this._t = base.transform;
		this._oldDistance = this.distance;
		this._angle = this.originRotation;
		this._currentOffset = this.targetOffset;
		this.CreateFocalPoint();
		this.Automagics();
		Quaternion quaternion = Quaternion.Euler(this._angle.y, this._angle.x, 0f);
		Quaternion quaternion2 = (!this.useTargetAxis || !this.target) ? quaternion : (this.target.rotation * quaternion);
		this._t.position = this._focalPoint.position - quaternion2 * Vector3.forward * this.distance;
		this._t.LookAt(this._focalPoint.position, (!this.useTargetAxis || !this.target) ? Vector3.up : this.target.TransformDirection(Vector3.up));
		this._oldRotation = quaternion2;
	}

	private void Update()
	{
		this._userInControl = false;
		bool flag = Screen.lockCursor;
		if (this._controllable && this.allowRotation && (this.useJoystick || (this.mouseLook && ((this.disableWhileUnlocked && flag) || !this.disableWhileUnlocked)) || (this.allowRotationLeft && Input.GetMouseButton(0)) || (this.allowRotationMiddle && Input.GetMouseButton(2)) || (this.allowRotationRight && Input.GetMouseButton(1)) || (this.allowTouch && Input.touchCount > 0)))
		{
			this._userInControl = true;
			this._returnTimer = 0f;
			float num = 0f;
			float num2 = 0f;
			if (this.allowTouch && Application.isMobilePlatform)
			{
				if (this.mobileRotationType == SimpleRpgCamera.RotationControlType.Swipe && Input.touchCount == 1)
				{
					Touch touch = Input.GetTouch(0);
					switch (touch.phase)
					{
					case TouchPhase.Began:
						this._mobileSwipe = true;
						this._mobileSwipeStart = touch.position;
						this._mobileSwipeStartTime = Time.time;
						break;
					case TouchPhase.Moved:
					case TouchPhase.Stationary:
						if (this._mobileSwipe && Time.time - this._mobileSwipeStartTime > this.mobileSwipeActiveTime)
						{
							this._mobileSwipe = false;
						}
						break;
					case TouchPhase.Ended:
						if (this._mobileSwipe)
						{
							Vector2 vector = new Vector2(Mathf.Abs(touch.position.x - this._mobileSwipeStart.x), Mathf.Abs(touch.position.y - this._mobileSwipeStart.y));
							Vector2 vector2 = default(Vector2);
							if (vector.x > this.mobileSwipeMinDistance)
							{
								vector2.x = Mathf.Sign(touch.position.x - this._mobileSwipeStart.x);
								vector2.x = ((!this.invertRotationX) ? vector2.x : (-vector2.x));
							}
							if (vector.y > this.mobileSwipeMinDistance)
							{
								vector2.y = Mathf.Sign(touch.position.y - this._mobileSwipeStart.y);
								vector2.y = ((!this.invertRotationY) ? vector2.y : (-vector2.y));
							}
							this._angle.x = this._angle.x + this.mobileSwipeRotationAmount.x * vector2.x;
							this._angle.y = this._angle.y + this.mobileSwipeRotationAmount.y * vector2.y;
						}
						this._mobileSwipe = false;
						break;
					}
				}
				else if (this.mobileRotationType == SimpleRpgCamera.RotationControlType.TwoTouchRotate && Input.touchCount == 2)
				{
					Touch touch2 = Input.GetTouch(0);
					Touch touch3 = Input.GetTouch(1);
					if (touch2.phase == TouchPhase.Began || touch3.phase == TouchPhase.Began)
					{
						this._mobileAngle = this.GetAngle(touch2.position, touch3.position);
					}
					else if (touch2.phase == TouchPhase.Moved || touch3.phase == TouchPhase.Moved)
					{
						float angle = this.GetAngle(touch2.position, touch3.position);
						float num3 = this._mobileAngle - angle;
						if (num3 > 180f)
						{
							num3 = 360f - num3;
						}
						else if (num3 < -180f)
						{
							num3 += 360f;
						}
						this._angle.x = this._angle.x + num3;
						this._mobileAngle = angle;
					}
				}
				else if (this.mobileRotationType == SimpleRpgCamera.RotationControlType.Drag && Input.touchCount == 1)
				{
					Touch touch4 = Input.GetTouch(0);
					if (touch4.phase == TouchPhase.Began)
					{
						this._touchTimer = 0f;
					}
					else if (touch4.phase == TouchPhase.Moved || touch4.phase == TouchPhase.Stationary)
					{
						if (this._touchTimer >= this.mobileRotationDelay)
						{
							num += touch4.deltaPosition.x * this.touchSensitivity;
							num2 += touch4.deltaPosition.y * this.touchSensitivity;
						}
						else
						{
							this._touchTimer += Time.deltaTime;
						}
					}
				}
			}
			else if ((this.mouseLook && ((this.disableWhileUnlocked && flag) || !this.disableWhileUnlocked)) || (this.allowRotationLeft && Input.GetMouseButton(0)) || (this.allowRotationMiddle && Input.GetMouseButton(2)) || (this.allowRotationRight && Input.GetMouseButton(1)))
			{
				num = Input.GetAxis(this.mouseHorizontalAxis) * this.rotationSensitivity.x;
				num2 = Input.GetAxis(this.mouseVerticalAxis) * this.rotationSensitivity.y;
			}
			if (this.useJoystick)
			{
				num += Input.GetAxis(this.joystickHorizontalAxis) * this.joystickSensitivity.x;
				num2 += Input.GetAxis(this.joystickVerticalAxis) * this.joystickSensitivity.y;
			}
			this._angle.x = this._angle.x + num * (float)((!this.invertRotationX) ? 1 : -1);
			this._angle.y = Mathf.Clamp(this._angle.y - num2 * (float)((!this.invertRotationY) ? 1 : -1), this.minAngle, this.maxAngle);
			this.ClampAngle(ref this._angle);
			if (Input.GetKey(this.setOriginKey) || (this.setOriginLeft && Input.GetMouseButton(0)) || (this.setOriginMiddle && Input.GetMouseButton(2)) || (this.setOriginRight && Input.GetMouseButton(1)))
			{
				this.originRotation = this._angle;
			}
			bool flag2 = this.lockCursor && (this.mouseLook || (this.lockLeft && Input.GetMouseButton(0)) || (this.lockMiddle && Input.GetMouseButton(2)) || (this.lockRight && Input.GetMouseButton(1)));
			Screen.lockCursor = flag2;
			if (this.rotateObjects && (this.mouseLook || (this.rotateObjectsLeft && Input.GetMouseButton(0)) || (this.rotateObjectsMiddle && Input.GetMouseButton(2)) || (this.rotateObjectsRight && Input.GetMouseButton(1))))
			{
				this.RotateObjects();
			}
		}
		else if (this._controllable && this.allowRotationKeys && (Input.GetKey(this.keyRotateUp) || Input.GetKey(this.keyRotateDown) || Input.GetKey(this.keyRotateLeft) || Input.GetKey(this.keyRotateRight)))
		{
			this._userInControl = true;
			this._returnTimer = 0f;
			int num4 = (Input.GetKey(this.keyRotateLeft) && Input.GetKey(this.keyRotateRight)) ? 0 : ((!Input.GetKey(this.keyRotateLeft)) ? ((!Input.GetKey(this.keyRotateRight)) ? 0 : -1) : 1);
			this._angle.x = this._angle.x + (float)num4 * this.rotationKeySensitivity.x * (float)((!this.invertRotationX) ? 1 : -1);
			int num5 = (Input.GetKey(this.keyRotateUp) && Input.GetKey(this.keyRotateDown)) ? 0 : ((!Input.GetKey(this.keyRotateUp)) ? ((!Input.GetKey(this.keyRotateDown)) ? 0 : 1) : -1);
			this._angle.y = Mathf.Clamp(this._angle.y - (float)num5 * this.rotationKeySensitivity.y * (float)((!this.invertRotationY) ? 1 : -1), this.minAngle, this.maxAngle);
			this.ClampAngle(ref this._angle);
		}
		else
		{
			this._userInControl = false;
			if (Input.GetKey(this.setOriginKey))
			{
				this.originRotation = this._angle;
			}
			if (this.returnToOrigin)
			{
				if (this._returnTimer >= this.returnDelay)
				{
					if (!this.returnToOriginOnKey || (this.returnToOriginOnKey && Input.GetKey(this.returnToOriginKey)))
					{
						this._angle = this.originRotation;
					}
				}
				else
				{
					this._returnTimer += Time.deltaTime;
				}
			}
			if (this.target && this.stayBehindTarget)
			{
				if (this._returnTimer >= this.returnDelay)
				{
					if (!this.stayBehindTargetOnKey || (this.stayBehindTargetOnKey && Input.GetKey(this.stayBehindTargetKey)))
					{
						this._angle.x = this.target.rotation.eulerAngles.y;
					}
				}
				else
				{
					this._returnTimer += Time.deltaTime;
				}
			}
			Screen.lockCursor = false;
		}
		float num6 = 0f;
		if (this._controllable)
		{
			if (this.allowZoom)
			{
				if (this.allowTouch && Application.isMobilePlatform)
				{
					if (Input.touchCount == 2)
					{
						this.zoomSpeed = this.mobileZoomSpeed;
						Touch touch5 = Input.GetTouch(0);
						Touch touch6 = Input.GetTouch(1);
						if (touch5.phase == TouchPhase.Began || touch6.phase == TouchPhase.Began || (touch5.phase == TouchPhase.Stationary && touch6.phase == TouchPhase.Stationary))
						{
							this._touchDistance = Vector2.Distance(touch5.position, touch6.position);
						}
						else if (touch5.phase == TouchPhase.Moved || touch6.phase == TouchPhase.Moved)
						{
							float num7 = Vector2.Distance(touch5.position, touch6.position);
							if (Mathf.Abs(num7 - this._touchDistance) >= this.mobileZoomDeadzone)
							{
								num6 = num7 - this._touchDistance;
							}
						}
					}
				}
				else
				{
					num6 = Input.GetAxis("Mouse ScrollWheel");
				}
			}
			if (this.allowZoomKeys)
			{
				if (Input.GetKey(this.keyZoomIn))
				{
					if (this._zoomInTimer < this.keyZoomDelay)
					{
						this._zoomInTimer += Time.deltaTime;
					}
				}
				else
				{
					this._zoomInTimer = 0f;
				}
				if (Input.GetKey(this.keyZoomOut))
				{
					if (this._zoomOutTimer < this.keyZoomDelay)
					{
						this._zoomOutTimer += Time.deltaTime;
					}
				}
				else
				{
					this._zoomOutTimer = 0f;
				}
				if (Input.GetKey(this.keyZoomIn) && Input.GetKey(this.keyZoomOut))
				{
					this._zoomInTimer = 0f;
					this._zoomOutTimer = 0f;
				}
				if (Input.GetKeyDown(this.keyZoomIn) || this._zoomInTimer >= this.keyZoomDelay)
				{
					num6 = 1f;
				}
				if (Input.GetKeyDown(this.keyZoomOut) || this._zoomOutTimer >= this.keyZoomDelay)
				{
					num6 = -1f;
				}
			}
		}
		this.distance = Mathf.Clamp(this.distance + ((num6 == 0f) ? 0f : ((num6 >= 0f) ? ((!this.invertZoom) ? (-this.zoomSpeed) : this.zoomSpeed) : ((!this.invertZoom) ? this.zoomSpeed : (-this.zoomSpeed)))), this.minDistance, this.maxDistance);
		if (this._focalPoint)
		{
			if (this._controllable && (this.allowEdgeMovement || this.allowEdgeKeys || this.allowMouseDrag))
			{
				Vector3 mousePosition = Input.mousePosition;
				Vector3 point = default(Vector3);
				if (this.allowTouch && Application.isMobilePlatform)
				{
					if (this.mobilePanType == SimpleRpgCamera.PanControlType.Swipe)
					{
						if (Input.touchCount > 0)
						{
							Touch touch7 = Input.GetTouch(0);
							switch (touch7.phase)
							{
							case TouchPhase.Began:
								this._mobilePanSwipe = true;
								this._mobilePanSwipeStart = touch7.position;
								this._mobilePanSwipeStartTime = Time.time;
								break;
							case TouchPhase.Moved:
							case TouchPhase.Stationary:
								if (this._mobilePanSwipe && Time.time - this._mobilePanSwipeStartTime > this.mobilePanSwipeActiveTime)
								{
									this._mobilePanSwipe = false;
								}
								break;
							case TouchPhase.Ended:
								if (this._mobilePanSwipe)
								{
									Vector2 vector3 = new Vector2(Mathf.Abs(touch7.position.x - this._mobilePanSwipeStart.x), Mathf.Abs(touch7.position.y - this._mobilePanSwipeStart.y));
									Vector2 vector4 = default(Vector2);
									if (Time.time - this._mobilePanSwipeStartTime <= this.mobilePanSwipeActiveTime)
									{
										if (vector3.x > this.mobilePanSwipeMinDistance)
										{
											vector4.x = Mathf.Sign(touch7.position.x - this._mobilePanSwipeStart.x);
										}
										if (vector3.y > this.mobilePanSwipeMinDistance)
										{
											vector4.y = Mathf.Sign(touch7.position.y - this._mobilePanSwipeStart.y);
										}
										point = new Vector3(vector4.x * this.mobilePanSwipeDistance.x, 0f, vector4.y * this.mobilePanSwipeDistance.y);
									}
									this._mobilePanSwipe = false;
								}
								break;
							}
						}
					}
					else if (this.mobilePanType == SimpleRpgCamera.PanControlType.Drag && Input.touchCount == this.mobilePanningTouchCount)
					{
						Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
						point = new Vector3(deltaPosition.x, 0f, deltaPosition.y);
					}
				}
				else
				{
					float num8 = (float)Screen.height - this.edgePadding;
					float num9 = this.edgePadding;
					float num10 = this.edgePadding;
					float num11 = (float)Screen.width - this.edgePadding;
					Rect rect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
					bool flag3 = rect.Contains(Input.mousePosition);
					if ((mousePosition.y >= num8 && this.allowEdgeMovement && flag3) || (Input.GetKey(this.keyMoveUp) && this.allowEdgeKeys))
					{
						point.z = -this.scrollSpeed;
					}
					else if ((mousePosition.y <= num9 && this.allowEdgeMovement && flag3) || (Input.GetKey(this.keyMoveDown) && this.allowEdgeKeys))
					{
						point.z = this.scrollSpeed;
					}
					if ((mousePosition.x <= num10 && this.allowEdgeMovement && flag3) || (Input.GetKey(this.keyMoveLeft) && this.allowEdgeKeys))
					{
						point.x = this.scrollSpeed;
					}
					else if ((mousePosition.x >= num11 && this.allowEdgeMovement && flag3) || (Input.GetKey(this.keyMoveRight) && this.allowEdgeKeys))
					{
						point.x = -this.scrollSpeed;
					}
					if (this.allowMouseDrag && Input.GetMouseButton((int)this.mouseDragButton))
					{
						point = new Vector3(Input.GetAxis(this.mouseHorizontalAxis) * this.mouseDragSensitivity.x, 0f, Input.GetAxis(this.mouseVerticalAxis) * this.mouseDragSensitivity.y);
					}
				}
				Vector3 forward = this._t.forward;
				forward.y = 0f;
				Quaternion rotation = Quaternion.FromToRotation(-Vector3.forward, forward);
				Vector3 a = rotation * point;
				this._focalPoint.position += a * Time.deltaTime;
				if (this.limitBounds)
				{
					Vector3 position = this._focalPoint.position;
					position.x = Mathf.Clamp(this._focalPoint.position.x, this.boundOrigin.x - this.boundSize.x / 2f, this.boundOrigin.x + this.boundSize.x / 2f);
					position.y = Mathf.Clamp(this._focalPoint.position.y, this.boundOrigin.y - this.boundSize.y / 2f, this.boundOrigin.y + this.boundSize.y / 2f);
					position.z = Mathf.Clamp(this._focalPoint.position.z, this.boundOrigin.z - this.boundSize.z / 2f, this.boundOrigin.z + this.boundSize.z / 2f);
					this._focalPoint.position = position;
				}
			}
			if (this.target && (Input.GetKey(this.keyFollowTarget) || this.lockToTarget || (!this.allowEdgeMovement && !this.allowEdgeKeys && !this.allowMouseDrag)))
			{
				Vector3 vector5 = this.target.rotation * this.targetOffset;
				if (!this.relativeOffset)
				{
					vector5 = this.targetOffset;
				}
				this._currentOffset = ((!this.smoothOffset) ? vector5 : Vector3.Lerp(this._currentOffset, vector5, this.smoothOffsetSpeed * Time.deltaTime));
				Vector3 vector6 = this.target.position + this._currentOffset;
				if (this.softTracking)
				{
					float num12 = Vector3.Distance(this._focalPoint.position, vector6);
					Vector3 vector7 = this._focalPoint.position;
					if (num12 > this.softTrackingRadius)
					{
						vector7 = Vector3.Lerp(this._focalPoint.position, this._focalPoint.position + (vector6 - this._focalPoint.position).normalized, Time.deltaTime * (num12 / this.softTrackingRadius) * this.softTrackingSpeed);
					}
					vector6 = vector7;
				}
				this._focalPoint.position = vector6;
			}
		}
		if (!this._focalPoint)
		{
			this.CreateFocalPoint();
		}
		if (!this.target && this.targetTag != string.Empty)
		{
			GameObject gameObject = GameObject.FindWithTag(this.targetTag);
			if (gameObject)
			{
				this.target = gameObject.transform;
				this.Automagics();
				this.MoveToTarget();
			}
		}
		if (this.fadeObjects)
		{
			foreach (Renderer current in this.objectsToFade)
			{
				if (current)
				{
					Material[] materials = current.materials;
					for (int i = 0; i < materials.Length; i++)
					{
						Material material = materials[i];
						Color color = material.color;
						color.a = Mathf.Clamp(this._oldDistance - this.fadeDistance, 0f, 1f);
						if (!this.fadeObjects)
						{
							color.a = 1f;
						}
						material.color = color;
					}
				}
			}
		}
		foreach (Material current2 in this._fadedMats)
		{
			if (!this._activeFadedMats.Contains(current2))
			{
				if (current2.color.a == 1f)
				{
					this._fadedMats.Remove(current2);
					break;
				}
				Color color2 = current2.color;
				color2.a = 1f;
				current2.color = Color.Lerp(current2.color, color2, Time.deltaTime * this.collisionFadeSpeed);
			}
		}
	}

	private void LateUpdate()
	{
		if (this.target && this._focalPoint)
		{
			if (!this._userInControl && Physics.Linecast(this._focalPoint.position, this._t.position, this.avoidanceLayers))
			{
				if (this._avoidingObject)
				{
					this._angle.x = this._angle.x + ((!this._avoidingLeft) ? this.avoidanceSpeed : (-this.avoidanceSpeed));
				}
				else
				{
					this._avoidingObject = true;
					RaycastHit raycastHit;
					bool flag = Physics.Linecast(this._focalPoint.position, this._t.position + Vector3.left, out raycastHit, this.avoidanceLayers);
					RaycastHit raycastHit2;
					bool flag2 = Physics.Linecast(this._focalPoint.position, this._t.position + Vector3.right, out raycastHit2, this.avoidanceLayers);
					if (flag && flag2)
					{
						float num = Vector3.Distance(raycastHit.point, this._t.position);
						float num2 = Vector3.Distance(raycastHit2.point, this._t.position);
						this._avoidingLeft = (num2 < num);
					}
					else if (flag2)
					{
						this._avoidingLeft = false;
					}
					else
					{
						this._avoidingLeft = true;
					}
				}
			}
			else
			{
				this._avoidingLeft = false;
				this._avoidingObject = false;
			}
			if (this.autoSmoothing)
			{
				this.rotationSmoothing = ((this.rotationSensitivity.x <= this.rotationSensitivity.y) ? this.rotationSensitivity.y : this.rotationSensitivity.x) + 3f;
				this.rotationSmoothing += ((!this.useJoystick) ? 0f : (((this.joystickSensitivity.x <= this.joystickSensitivity.y) ? this.joystickSensitivity.y : this.joystickSensitivity.x) + 3f));
			}
			Quaternion quaternion = Quaternion.Euler(this._angle.y, this._angle.x, 0f);
			Quaternion b = (!this.useTargetAxis) ? quaternion : (this.target.rotation * quaternion);
			Quaternion quaternion2 = Quaternion.Lerp(this._oldRotation, b, Time.deltaTime * ((!this._userInControl && this._returnTimer >= this.returnDelay) ? ((!this.returnToOrigin && !this.stayBehindTarget) ? this.rotationSmoothing : this.returnSmoothing) : this.rotationSmoothing));
			this._oldRotation = quaternion2;
			float num3 = Mathf.Lerp(this._oldDistance, this.distance, Time.deltaTime * this.zoomSmoothing);
			Vector3 end = this._focalPoint.position - quaternion2 * Vector3.forward * (this.distance + this.collisionBuffer);
			RaycastHit raycastHit3;
			if (Physics.Linecast(this._focalPoint.position, end, out raycastHit3, this.collisionLayers))
			{
				float num4 = Vector3.Distance(this._focalPoint.position, raycastHit3.point) - this.collisionBuffer;
				if (num3 > num4)
				{
					num3 = num4;
				}
			}
			this._oldDistance = num3;
			this._t.position = this._focalPoint.position - quaternion2 * Vector3.forward * num3;
			this._t.LookAt(this._focalPoint.position, (!this.useTargetAxis) ? Vector3.up : this.target.TransformDirection(Vector3.up));
			Ray ray = new Ray(this._focalPoint.position, this._t.position - this._focalPoint.position);
			RaycastHit[] array = Physics.RaycastAll(ray, this.distance, this.collisionAlphaLayers);
			this._activeFadedMats.Clear();
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit raycastHit4 = array2[i];
				Renderer component = raycastHit4.transform.GetComponent<Renderer>();
				if (component)
				{
					Material[] materials = component.materials;
					Material[] array3 = materials;
					for (int j = 0; j < array3.Length; j++)
					{
						Material material = array3[j];
						Color color = material.color;
						color.a = this.collisionAlpha;
						material.color = Color.Lerp(material.color, color, Time.deltaTime * this.collisionFadeSpeed);
						this._activeFadedMats.Add(material);
						if (!this._fadedMats.Contains(material))
						{
							this._fadedMats.Add(material);
						}
					}
				}
			}
		}
	}

	private void OnGUI()
	{
		if (this.allowEdgeMovement && this.showEdges && this.edgeTexture)
		{
			Rect position = new Rect(0f, 0f, (float)Screen.width, this.edgePadding);
			Rect position2 = new Rect(0f, (float)Screen.height - this.edgePadding, (float)Screen.width, (float)Screen.height);
			Rect position3 = new Rect(0f, 0f, this.edgePadding, (float)Screen.height);
			Rect position4 = new Rect((float)Screen.width - this.edgePadding, 0f, (float)Screen.width, (float)Screen.height);
			GUI.DrawTexture(position, this.edgeTexture);
			GUI.DrawTexture(position2, this.edgeTexture);
			GUI.DrawTexture(position3, this.edgeTexture);
			GUI.DrawTexture(position4, this.edgeTexture);
		}
	}

	private void OnDrawGizmos()
	{
		if (this.limitBounds)
		{
			Gizmos.DrawWireCube(this.boundOrigin, this.boundSize);
		}
		if (this.softTracking && this.target)
		{
			Gizmos.DrawWireSphere(this.target.position, this.softTrackingRadius);
		}
	}

	public void Automagics()
	{
		if (this.target)
		{
			if (this.autoAddTargetToRotate && !this.objectsToRotate.Contains(this.target))
			{
				this.objectsToRotate.Add(this.target);
			}
			if (this.autoAddTargetToFade)
			{
				Renderer[] componentsInChildren = this.target.GetComponentsInChildren<Renderer>();
				Renderer[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					Renderer item = array[i];
					if (!this.objectsToFade.Contains(item))
					{
						this.objectsToFade.Add(item);
					}
				}
			}
		}
	}

	public void RotateObjects()
	{
		foreach (Transform current in this.objectsToRotate)
		{
			current.rotation = Quaternion.Euler(0f, this._angle.x, 0f);
		}
	}

	private void CreateFocalPoint()
	{
		this._focalPoint = new GameObject
		{
			name = "_SRPGCfocalPoint"
		}.transform;
		this.MoveToTarget();
	}

	public void MoveToTarget()
	{
		if (this.target)
		{
			this._focalPoint.position = this.target.position + this.target.rotation * this.targetOffset;
		}
	}

	private void ClampAngle(ref Vector3 angle)
	{
		if (angle.x < -180f)
		{
			angle.x += 360f;
		}
		else if (angle.x > 180f)
		{
			angle.x -= 360f;
		}
		if (angle.y < -180f)
		{
			angle.y += 360f;
		}
		else if (angle.y > 180f)
		{
			angle.y -= 360f;
		}
		if (angle.z < -180f)
		{
			angle.z += 360f;
		}
		else if (angle.z > 180f)
		{
			angle.z -= 360f;
		}
	}

	private void ClampAngle(ref Vector2 angle)
	{
		if (angle.x < -180f)
		{
			angle.x += 360f;
		}
		else if (angle.x > 180f)
		{
			angle.x -= 360f;
		}
		if (angle.y < -180f)
		{
			angle.y += 360f;
		}
		else if (angle.y > 180f)
		{
			angle.y -= 360f;
		}
	}

	private float GetAngle(Vector2 fromVector2, Vector2 toVector2)
	{
		Vector2 vector = fromVector2 - toVector2;
		float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		return num + 180f;
	}
}
