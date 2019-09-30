using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacMan_Map : MonoBehaviour
{
	public PacManData 	playerData;
	
	public GameObject	mapElemPrefab;
	public Transform 	mapHolder;
	public float 	tileOffset;
	public MapElement[][]	entireMap;
	private int[][]     	mapPref;


	
	
	public void     GenerateMap()
	{
		mapPref = new int[30][];
		mapPref[0] = new []		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		mapPref[1] = new []		{1,4,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,4,1};
		mapPref[2] = new [] 	{1,0,1,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[3] = new [] 	{1,0,1,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[4] = new [] 	{1,0,1,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,0,4,1,1,0,1};
		mapPref[5] = new [] 	{1,0,1,1,4,0,0,1,1,0,0,0,4,1,1,4,0,0,0,1,1,1,1,0,1,1,0,1};
		mapPref[6] = new [] 	{1,0,1,1,0,1,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,0,1};
		mapPref[7] = new [] 	{1,0,1,1,0,1,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,1};
		mapPref[8] = new [] 	{1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,0,1};
		mapPref[9] = new [] 	{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[10] = new []	{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,0,0,1};
		mapPref[11] = new []	{1,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1};
		mapPref[12] = new []	{1,1,1,0,1,1,0,1,1,0,1,1,1,2,2,1,1,1,0,1,1,0,1,1,0,1,1,1};
		mapPref[13] = new []	{1,1,1,0,1,1,0,1,1,0,1,2,2,2,2,2,2,1,0,1,1,0,1,1,0,1,1,1};
		mapPref[14] = new []	{5,0,0,0,0,0,0,1,1,0,1,2,2,2,2,2,2,1,0,1,1,0,0,0,0,0,0,5};
		mapPref[15] = new []	{1,1,1,0,1,1,1,1,1,0,1,2,2,2,2,2,2,1,0,1,1,1,1,1,0,1,1,1};
		mapPref[16] = new []	{1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1};
		mapPref[17] = new []	{1,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,1};
		mapPref[18] = new []	{1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1};
		mapPref[19] = new []	{1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1};
		mapPref[20] = new []	{1,0,0,0,0,0,0,1,1,0,0,0,0,0,3,0,0,0,0,1,1,0,0,0,0,0,0,1};
		mapPref[21] = new []	{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[22] = new []	{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[23] = new []	{1,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,1,1,0,1};
		mapPref[24] = new []	{1,0,1,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[25] = new []	{1,0,1,1,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,0,0,0,0,0,1};
		mapPref[26] = new []	{1,0,0,0,0,0,0,1,1,0,0,0,4,1,1,4,0,0,0,1,1,0,1,1,1,1,0,1};
		mapPref[27] = new []	{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1};
		mapPref[28] = new []	{1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,1};
		mapPref[29] = new []	{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};

		ballCount = 0;
		entireMap = new MapElement[mapPref.Length][];	
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			entireMap[y] = new MapElement[mapPref[y].Length];
			while (x < entireMap[y].Length)
			{
				Vector3 newPos = new Vector3(mapHolder.position.x + tileOffset * x, 0,
					mapHolder.position.z - tileOffset * y);
				MapElement curElem  = Instantiate(mapElemPrefab, newPos, new Quaternion(), mapHolder).GetComponent<MapElement>();
				entireMap[y][x] = curElem;
				switch (mapPref[y][x])
				{
					case 0:
						curElem.state = "path";
						ballCount++;
						break;
					case 1:
						curElem.state = "wall";
						break;
					case 2:
						curElem.state = "ghost";
						break;
					case 3:
						curElem.state = "pacman";
						ballCount++;
						break;
					case 4:
						curElem.state = "bigPath";
						ballCount++;
						break;
					case 5:
						curElem.state = "exit";
						break;
				}

				curElem.ShowState();
				curElem.posY = y;
				curElem.posX = x;
				
				x++;
			}
			y++;
		}

	}

	public void 	MakeNodes()
	{
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			while (x < entireMap[y].Length)
			{
				MapElement thisElem = entireMap[y][x];
				thisElem.nodes = new MapElement[4];

				if (y > 0)
					thisElem.nodes[0] = entireMap[y - 1][x];
				if (y < entireMap.Length - 1)
					thisElem.nodes[2] = entireMap[y + 1][x];
				if (x > 0)
					thisElem.nodes[3] = entireMap[y][x - 1];
				if (x < entireMap[y].Length - 1)
					thisElem.nodes[1] = entireMap[y][x + 1];
				
				x++;
			}

			y++;
		}
		
	}
	
	
	
	public void 	UnmarkAllTiles()
	{
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			while (x < entireMap[y].Length)
			{
				MapElement tempElement = entireMap[y][x];
				
				// For Wave Search Algorithm
				tempElement.stage = -1;
				tempElement.waveNum = -1;
				x++;
			}

			y++;
		}
	}
	
	// Show Matrix
	void ShowMatrix()
	{
		string arr = "";
			
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			while (x < entireMap[y].Length)
			{
				if (entireMap[y][x].waveNum == -1)
					arr += ",_";
				else
					arr += "," + entireMap[y][x].waveNum;		
				x++;
			}
			arr += "\n";
			y++;
		}
		print(arr);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	public GameObject 			pacmanPrefab;
	[HideInInspector] public PacMan_Controller 	currPacman;
	private int 	ballCount;
	
	private void 	SpawnPacman()
	{
		// TODO kill pacman
	
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			while (x < entireMap[y].Length)
			{
//				Debug.Log("x " + x + " y " + y);
				MapElement thisElem = entireMap[y][x];
				if (thisElem.state == "pacman")
				{
					currPacman = Instantiate(pacmanPrefab, thisElem.transform.position,
						new Quaternion(), mapHolder).GetComponent<PacMan_Controller>();

					currPacman.posY = y;
					currPacman.posX = x;
					currPacman.ourMap = this;
					currPacman.nextPos = thisElem.transform.position;
					currPacman.ourData = playerData;
					
					playerData.ballsLeft = ballCount;
					playerData.ourPacman = currPacman;
					playerData.ourMap = this;
					playerData.gameUI.gameObject.SetActive(true);
					playerData.winUI.gameObject.SetActive(false);
					return;
				}
				
				x++;
			}

			y++;
		}
	}

	
	
	public GameObject 	ghostPrefab;
	[HideInInspector] 	public Ghost 	currGhost;
	
	private Ghost SpawnGhost()
	{
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			while (x < entireMap[y].Length)
			{
				MapElement thisElem = entireMap[y][x];
				if (thisElem.state == "ghost")
				{
					currGhost = Instantiate(ghostPrefab, thisElem.transform.position,
						new Quaternion(), mapHolder).GetComponent<Ghost>();

					currGhost.posY = y;
					currGhost.posX = x;
					currGhost.ourMap = this;
					currGhost.nextPos = thisElem.transform.position;
					
					return currGhost;
				}
				
				x++;
			}

			y++;
		}

		return null;
	}
	
	
	
	
	
	
	
	
	
	
	public void KillAllTiles()
	{
		if (entireMap == null)
			return;
		
		// To prevent spawning ghosts when in menu
		isGame = false;
		
		int y = 0;
		while (y < entireMap.Length)
		{
			int x = 0;
			while (x < entireMap[y].Length)
			{
				if (entireMap[y][x] != null)
					Destroy(entireMap[y][x].gameObject);
				x++;
			}
			y++;
		}

		// Kills all Ghosts
		if (allGhosts != null)
		{
			foreach (Ghost curGhost in allGhosts)
			{
				Destroy(curGhost.gameObject);
			}
			allGhosts.RemoveRange(0, allGhosts.Count);
			spawnTimer = 0;
		}
		
	}
	
	
	
	public void StartAGame()
	{
		KillAllTiles();
		GenerateMap();
		MakeNodes();
		playerData.ShowHighScore();
		
		SpawnPacman();
		allGhosts = new List<Ghost>();
		isGame = true;
	}



	public int 				ghostCount = 3;
	private List<Ghost>		allGhosts;
	
	public float 			spawnDelay = 5f;
	private float 			spawnTimer;

	public Text 			timerText;
	
	[HideInInspector] public bool isGame = false;		
	private void Update()
	{
		if (isGame == false)
			return;
		
		
		if (spawnTimer > spawnDelay)
		{
			allGhosts.Add(SpawnGhost());
			print("list count " + allGhosts.Count + "  ghost Count " + ghostCount);
			if (allGhosts.Count >= ghostCount)
			{
				spawnTimer = -1;
				timerText.text = "All Ghosts Spawned";
			}
			else
				spawnTimer = 0;
		}
		if (spawnTimer > -1)
		{
			spawnTimer += Time.deltaTime;
			timerText.text = "New Ghost Spawn in: " + (spawnDelay - spawnTimer);
		}
		
	}
}
