using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float m_minSpeed = -0.1f;
	public float m_maxSpeed = -0.3f;
	private float m_speed = 0.0f;

	void Start () 
	{
		m_speed = Random.Range (m_minSpeed, m_maxSpeed);
	}

	void Update () 
	{
		transform.Translate (new Vector2 (m_speed, 0));
	}
}
