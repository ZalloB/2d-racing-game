using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle {

	private float velocity;
	private float control;
	private float aceleration;
	private float breakingReaction;

	public float Velocity
	{
		get {return velocity; }
		set {velocity = value; }
	}

	public float Control
	{
		get {return control; }
		set {control = value; }
	}

	public float Aceleration
	{
		get {return aceleration; }
		set {aceleration = value; }
	}

	public float BreakingReaction
	{
		get{return breakingReaction; }
		set{breakingReaction = value; }
	}
}
