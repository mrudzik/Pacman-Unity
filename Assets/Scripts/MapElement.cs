using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElement : MonoBehaviour
{
	public string     state = "empty";

	public GameObject	wall;
	public GameObject 	path;
	public GameObject 	bigPath;
	public GameObject 	ghostPath;
	public GameObject 	exit;

	[HideInInspector]	public int posY;
	[HideInInspector]	public int posX;
	[HideInInspector] 	public MapElement[] nodes;

	
	public void     ShowState()
	{
		wall.SetActive(false);
		path.SetActive(false);
		bigPath.SetActive(false);
		ghostPath.SetActive(false);
		exit.SetActive(false);
		
		if (state == "path")
			path.SetActive(true);
		if (state == "bigPath")
			bigPath.SetActive(true);
		if (state == "wall")
			wall.SetActive(true);
		if (state == "ghost")
			ghostPath.SetActive(true);
		if (state == "pacman") // Must be a spawn
			path.SetActive(true);	
		if (state == "exit")
			exit.SetActive(true);
		
	}
	
	
	


// For Wave Search Stuff
	[HideInInspector] 	public int stage = -1;
	// stage states
	// -1	unprocessed
	// 0	waiting
	// 1	processed
	[HideInInspector] 	public int waveNum = -1;
	








}
