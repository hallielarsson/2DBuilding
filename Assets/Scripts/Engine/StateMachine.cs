using UnityEngine;
using System.Collections;
using System;

public class StateMachine {

	public State state;
	public ActionQueue changeStateCallbacks = new ActionQueue();
	public void BeginState(State pState) {
		if (state != null && state.endAction != null) {
			state.endAction();
		}
		changeStateCallbacks.Execute ();
		changeStateCallbacks.Clean ();
		state = pState;
		pState.startAction();
	}
	public void StateChangeCallback(Action pCallback, int pPriority = 65536) {
		changeStateCallbacks.AddAction (pPriority, pCallback);
	
	}

}
