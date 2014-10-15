using UnityEngine;
using System.Collections;
using AnimationOrTween;


public class TriggerAnimation : MonoBehaviour {


	public Animation target;
	public string clipName;
	public Direction playDirection = Direction.Forward;
	public bool resetOnPlay = false;
	public EnableCondition ifDisabledOnPlay = EnableCondition.DoNothing;

	public DisableCondition disableWhenFinished = DisableCondition.DoNotDisable;
	
public string callWhenFinished;
public GameObject eventReceiver;
	public ActiveAnimation.OnFinished onFinished;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log("RUNRUN");
        Play(true);
    }

	void Play (bool forward)
	{
		if (target == null) target = GetComponentInChildren<Animation>();

		if (target != null)
		{
			int pd = -(int)playDirection;
			Direction dir = forward ? playDirection : ((Direction)pd);
			ActiveAnimation anim = ActiveAnimation.Play(target, clipName, dir, ifDisabledOnPlay, disableWhenFinished);
			if (anim == null) return;
			if (resetOnPlay) anim.Reset();

			// Set the delegate
			anim.onFinished = onFinished;

			// Copy the event receiver
			if (eventReceiver != null && !string.IsNullOrEmpty(callWhenFinished))
			{
				anim.eventReceiver = eventReceiver;
				anim.callWhenFinished = callWhenFinished;
			}
			else anim.eventReceiver = null;
		}
	}
}
