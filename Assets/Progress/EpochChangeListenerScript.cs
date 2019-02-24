using UnityEngine;

namespace Progress {
	public class EpochChangeListenerScript : MonoBehaviour {

		public void epochChanged(Epoch epoch) {
			GetComponent<IEpochChangeListener>().epochChanged(epoch);
		}
		
	}
}
