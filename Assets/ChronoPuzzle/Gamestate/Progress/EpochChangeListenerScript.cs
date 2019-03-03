using UnityEngine;

namespace ChronoPuzzle.Gamestate.Progress {
	public class EpochChangeListenerScript : MonoBehaviour {

		public void epochChanged(Epoch epoch) {
			GetComponent<IEpochChangeListener>().epochChanged(epoch);
		}
		
	}
}
