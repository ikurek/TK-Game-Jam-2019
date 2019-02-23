using System;
using System.Collections.Generic;
using UnityEngine;

namespace World {
	
	public class InputDispatcher : MonoBehaviour {
		
		private readonly Dictionary<KeyCode, LinkedList<Action<KeyCode>>> keyDownHandlers = new Dictionary<KeyCode, LinkedList<Action<KeyCode>>>();
		private readonly Dictionary<KeyCode, LinkedList<Action<KeyCode>>> keyUpHandlers = new Dictionary<KeyCode, LinkedList<Action<KeyCode>>>();
		
		private void Update() {
			// Scan registered key inputs and invoke handlers
			
			foreach (var entry in keyDownHandlers) {
				if (Input.GetKeyDown(entry.Key)) {
					foreach (var handler in entry.Value) {
						handler(entry.Key);
					}
				}
			}
			
			foreach (var entry in keyUpHandlers) {
				if (Input.GetKeyUp(entry.Key)) {
					foreach (var handler in entry.Value) {
						handler(entry.Key);
					}
				}
			}
		}
		
		public void AddKeyDownHandler(KeyCode keyCode, Action<KeyCode> handler) {
			LinkedList<Action<KeyCode>> list;
			try {
				list = new LinkedList<Action<KeyCode>>();
				keyDownHandlers.Add(keyCode, list);
			}
			catch (ArgumentException) {
				list = keyDownHandlers[keyCode];
			}
			
			list.AddLast(handler);
		}
		
		public void AddKeyUpHandler(KeyCode keyCode, Action<KeyCode> handler) {
			LinkedList<Action<KeyCode>> list;
			try {
				list = new LinkedList<Action<KeyCode>>();
				keyUpHandlers.Add(keyCode, list);
			}
			catch (ArgumentException) {
				list = keyDownHandlers[keyCode];
			}
			
			list.AddLast(handler);
		}
		
	}
	
}
