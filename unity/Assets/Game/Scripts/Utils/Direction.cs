using System;
using UnityEngine;

public enum Direction
{
	None, Up, Down
}

public static class DirectionExtensions {
	public static Vector3 ToVector3(this Direction myDirection) {
		Vector3 result;

		switch (myDirection) {
			case Direction.Up:
				result = Vector3.up;
				break;
			case Direction.Down:
				result = Vector3.down;
				break;
			default:
				result = Vector3.zero;
				break;
			}

		return result;
	}
}