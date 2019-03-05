using ChronoPuzzle.Gamestate.Progress;
using UnityEngine;

namespace ChronoPuzzle.World.Environment {

	public class RoomManager : MonoBehaviour, IEpochChangeListener {
		
		[SerializeField]
		private GameObject firstEpochScenery;
		[SerializeField]
		private GameObject secondEpochScenery;
		[SerializeField]
		private GameObject thirdEpochScenery;
		[SerializeField]
		private GameObject fourthEpochScenery;
		[SerializeField]
		private GameObject finalEpochScenery;

		public void epochChanged(Epoch epoch) {
			prepareEpoch(epoch);
		}

		private void prepareEpoch(Epoch epoch) {
			// hide environment
			firstEpochScenery.SetActive(false);
			secondEpochScenery.SetActive(false);
			thirdEpochScenery.SetActive(false);
			fourthEpochScenery.SetActive(false);
			finalEpochScenery.SetActive(false);
		
			// show the right environment
			switch (epoch) {
				case Epoch.First:
					firstEpochScenery.SetActive(true);
					break;
				case Epoch.Second:
					secondEpochScenery.SetActive(true);
					break;
				case Epoch.Third:
					thirdEpochScenery.SetActive(true);
					break;
				case Epoch.Fourth:
					fourthEpochScenery.SetActive(true);
					break;
				case Epoch.Final:
					finalEpochScenery.SetActive(true);
					break;
			}
		}

	}

}
