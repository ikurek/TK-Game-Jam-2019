using System;
using UnityEngine;
using World;

public class PlayerCharacter : MonoBehaviour {
	
	[Flags]
	private enum MovementDirection {
		None = 0,
		North = 1 << 0,
		East = 1 << 1,
		South = 1 << 2,
		West = 1 << 3
	}
	
	public float movementSpeed;
	
	private new Collider2D collider;
	private MovementDirection movementDirection = MovementDirection.None;
	
	private void Awake() {
		collider = GetComponent<Collider2D>();
		if (collider == null) {
			Debug.LogError("No Collider2D found in Player Character");
		}
	}
	
	private void Start() {
		InputDispatcher dispatcher = FindObjectOfType<InputDispatcher>(); 
		dispatcher.AddKeyDownHandler(KeyCode.W, keyCode => startMovement(MovementDirection.North));
		dispatcher.AddKeyDownHandler(KeyCode.D, keyCode => startMovement(MovementDirection.East));
		dispatcher.AddKeyDownHandler(KeyCode.S, keyCode => startMovement(MovementDirection.South));
		dispatcher.AddKeyDownHandler(KeyCode.A, keyCode => startMovement(MovementDirection.West));
		dispatcher.AddKeyUpHandler(KeyCode.W, keyCode => stopMovement(MovementDirection.North));
		dispatcher.AddKeyUpHandler(KeyCode.D, keyCode => stopMovement(MovementDirection.East));
		dispatcher.AddKeyUpHandler(KeyCode.S, keyCode => stopMovement(MovementDirection.South));
		dispatcher.AddKeyUpHandler(KeyCode.A, keyCode => stopMovement(MovementDirection.West));
	}
	
	private void Update() {
		Vector2 velocity = directionVector(movementDirection) * movementSpeed;
		Vector2 move = velocity * Time.deltaTime;
		
		/******************************************
		 * This here is magic that fixes Unity's bullshit collision detection
		 */
		RaycastHit2D[] hits = new RaycastHit2D[64];
		int numHits = collider.Cast(move.normalized, hits, move.magnitude);
		
		for (int i = 0; i < numHits; i++) {
			float collisionNormalDot = Vector2.Dot(move.normalized, hits[i].normal);
			move -= hits[i].normal * collisionNormalDot * move.magnitude; 
			
		}
		/******************************************
		 */
		
		transform.position += (Vector3) move;
	}
	
	private void startMovement(MovementDirection direction) {
		movementDirection |= direction;
	}
	
	private void stopMovement(MovementDirection direction) {
		movementDirection &= ~direction;
	}
	
	private Vector2 directionVector(MovementDirection direction) {
		Vector2 vec = Vector2.zero;
		if (direction != MovementDirection.None) {
			if (direction.HasFlag(MovementDirection.North)) vec += Vector2.up;
			if (direction.HasFlag(MovementDirection.East)) vec += Vector2.right;
			if (direction.HasFlag(MovementDirection.South)) vec += Vector2.down;
			if (direction.HasFlag(MovementDirection.West)) vec += Vector2.left;
			vec = vec.normalized;
		}
		return vec;
	}
	
}
