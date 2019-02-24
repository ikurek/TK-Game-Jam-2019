using System.Collections;
using System.Collections.Generic;
using Progress;
using UnityEngine;

public class RoomManager : MonoBehaviour {
	public GameObject firstEpochScenery;
	public GameObject secondEpochScenery;
	public GameObject thirdEpochScenery;
	public GameObject fourthEpochScenery;
	public GameObject finalEpochScenery;

	private EpochChangeListenerScript[] listenerScripts;

	private void Awake() {
		listenerScripts = FindObjectsOfType<EpochChangeListenerScript>();
	}

	public void prepareEpoch(Epoch epoch) {
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

		// tell everything to enable or disable itself
		foreach (var script in listenerScripts) {
			script.epochChanged(epoch);
		}

	}
}
