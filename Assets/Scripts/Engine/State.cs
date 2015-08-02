using System;
public class State {
	public Action startAction;
	public Action endAction;
	
	public State(Action pStart, Action pEnd) {
		startAction = pStart;
		endAction = pEnd;
	}
}