using System;
using System.Collections;
using System.Collections.Generic;

public class PrioritizedQueue<T> : ICleanable
{
	public List<PrioritizedEntry<T>> entries = new List<PrioritizedEntry<T>>();
	public Action<T> executeAction;
	
	public PrioritizedQueue(Action<T> pExecuteAction) {
		executeAction = pExecuteAction;
	}
	public void Clean() {
		entries.Clear ();
		executeAction = null;
	}

	public void Execute() {
		entries.Sort ();
		foreach (PrioritizedEntry<T> entry in entries) {
			executeAction(entry.value);
		}
	}
	
	public int Count() {
		return entries.Count;
	}

	public PrioritizedEntry<T> Add(T pT) {
		PrioritizedEntry<T> pe = new PrioritizedEntry<T> (1000, pT);
		entries.Add (pe);
		return pe;
	}

	public void Add(PrioritizedEntry<T> pEntry) 
	{	entries.Add (pEntry);
	}


	public void Remove(PrioritizedEntry<T> pEntry) {
		entries.Remove (pEntry);
	}

	public static void CleanFunc(ICleanable pEntry) {
		pEntry.Clean ();
	}
}


