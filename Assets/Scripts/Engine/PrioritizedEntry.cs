using UnityEngine;
using System.Collections;

public class PrioritizedEntry<T> {
	public T value;
	public int priority;

	public PrioritizedEntry(int pPriority, T pEntry) {
		value = pEntry;
		priority = pPriority;

	}
}
