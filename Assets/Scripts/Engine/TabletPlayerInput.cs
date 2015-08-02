using UnityEngine;
using System.Collections;

public class TabletPlayerInput : PlayerInput {


	public bool mouseControl = true;
	static int NO_TOUCH = 0;
	static int TOUCH = 1;
	public Vector2 targetPoint = Vector2.zero;
	public float touchRadius = 0.5f;
	public GameObject touchObject;
	Camera cam;
	CircleCollider2D touchHitbox;
	int touchpointIndex;
	int state = NO_TOUCH;

	new void Start () {
		base.Start ();
		cam = Camera.main;
		GetTouchObject ();
	}
	
	void Update () {
		if (mouseControl) {
			UpdateMouse();
		} else {
			UpdateTouch();
		}
	}


	void UpdateTouch() {
		if (state == NO_TOUCH) {
			CheckNewTouches();
		}
		
		if (state == TOUCH) {
			UpdateTouchPos();
		}

	}

	void UpdateMouse() {
		if (state == NO_TOUCH) {
			CheckNewClick();
		}
		
		if (state == TOUCH) {
			UpdateMousePos();
		}

	}

	void CheckNewTouches() {
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				if (CheckHit (Input.GetTouch (i).position)) {
					state = TOUCH;
					controller.StartInput();
					touchpointIndex = i;
					break;
				}
			}
		}
	}
	void UpdateTouchPos() {
		if (Input.touchCount <= 0) {
			EndTouch();
			return;
		}
		Touch touch = Input.GetTouch (touchpointIndex);
		if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
			EndTouch();
			return;
		} else {
			MoveToTarget(cam.ScreenToWorldPoint(touch.position));
		}

	}

	void CheckNewClick() {
		if (Input.GetMouseButtonDown (0)) {
			print ("checking click..");
			if(CheckHit (Input.mousePosition)) {
				state = TOUCH;
				controller.StartInput ();
				print ("START INPUT");
			}
		}
	}
	
	void UpdateMousePos() {
		if (Input.GetMouseButtonUp (0)) {
			EndTouch ();
			return;
		} else {
			MoveToTarget(cam.ScreenToWorldPoint(Input.mousePosition));
		}
	}


	void EndTouch() {
		state = NO_TOUCH;
		controller.EndInput ();
		this.controller.Move (Vector2.zero);
	}


	void MoveToTarget(Vector2 pTargetPoint) {
		targetPoint = pTargetPoint;
		Vector2 delta = targetPoint - (Vector2) touchObject.transform.position;
		controller.Move (delta);
	}
	bool CheckHit(Vector2 touchPos) {
		Vector2 checkTargetPoint = cam.ScreenToWorldPoint(touchPos);
		Collider2D[] hits = Physics2D.OverlapCircleAll (checkTargetPoint, touchRadius);
		foreach (Collider2D hit in hits) {
			print ("checking hit...");
			if (hit != null && hit == touchHitbox) {
				targetPoint = checkTargetPoint;
				return true;
			}
		}
		return false;

	}

	void GetTouchObject() {
		if (touchObject == null) {
			touchObject = gameObject;
		}
		touchHitbox = touchObject.GetComponent<CircleCollider2D> ();
	}
	
}
