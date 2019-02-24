using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : InteractiveObject {

	public Vector2 teleportExitPosition;
	public Doorway otherEnd;
	public string characterTag = "Player";

	public override void activate(GameObject activator) {
		if (activator.CompareTag(characterTag)) {
			otherEnd.acceptEntityTeleport(activator);
		}
	}

	public override void pickup(GameObject parentGameObject) {}

	public override void drop(GameObject exParentGameObject) {}

	public void acceptEntityTeleport(GameObject entity) {
		entity.transform.position = teleportExitPosition;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawIcon(teleportExitPosition, "point.png");
	}
}
