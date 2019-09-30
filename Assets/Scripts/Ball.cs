using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public int points;
	
	private void OnTriggerEnter(Collider other)
	{
		PacMan_Controller player = other.GetComponent<PacMan_Controller>();
		if (player == null)
			return;

		SomethingSpecial(player);
		Destroy(gameObject);
	}
	
	protected virtual void	SomethingSpecial(PacMan_Controller player)
	{
		player.ourData.TakePoints(points);
	}

	
}
