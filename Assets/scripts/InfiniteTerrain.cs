using UnityEngine;
using System.Collections;
using System;

public class InfiniteTerrain : MonoBehaviour
{
	public GameObject PlayerObject;

    //[SerializeField]
    //Transform Playertransform;
    float repRate = 0.12f;
    [SerializeField]
    GameObject zombie;
    //public Collider zombieCollider;
    //public Collider personCollider;
    System.Random rnd;
    Vector3 lastp;
    //private Rigidbody rb;
    Vector3 playerPosition;

    [SerializeField]
    Transform fo;
    private Terrain[,] _terrainGrid = new Terrain[3,3];
    float z,x;

    void Start ()
	{
        //rb = box.GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(0f, 0f, 100f);

        lastp = fo.transform.position;

        InvokeRepeating("creatingzombie",  0f, repRate);
        /*InvokeRepeating("creatingbox1", 0f, repRate);
        InvokeRepeating("creatingbox2", 0f, repRate);
        InvokeRepeating("creatingbox3", 0f, repRate);*/
        


        Terrain linkedTerrain = gameObject.GetComponent<Terrain>();
		
		_terrainGrid[0,0] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[0,1] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[0,2] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[1,0] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[1,1] = linkedTerrain;
		_terrainGrid[1,2] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[2,0] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[2,1] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
		_terrainGrid[2,2] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();

		UpdateTerrainPositionsAndNeighbors();
	}

    private void creatingzombie()
    {

        //Vector3 lastpos = Playertransform.transform.position;
        GameObject _objectt = Instantiate(zombie) as GameObject;
      //  _objectt.transform.rotation = new Quaternion (0f, 0f, 0f,0f);
        _objectt.transform.position = lastp + new Vector3(x, -lastp.y, z + 60f);
        lastp = fo.transform.position;
    }

    /*private void creatingbox1()
    {

        //Vector3 lastpos = Playertransform.transform.position;
        GameObject _objectt = Instantiate(zombie) as GameObject;
        // _objectt.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        _objectt.transform.position = lastp + new Vector3(-(5 * x), -lastp.y, z + 60f);
        lastp = fo.transform.position;
    }

    private void creatingbox3()
    {

        //Vector3 lastpos = Playertransform.transform.position;
        GameObject _objectt = Instantiate(box) as GameObject;
        // _objectt.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        _objectt.transform.position = lastp + new Vector3((2*x), -lastp.y, z + 60f);
        lastp = fo.transform.position;
    }
    private void creatingbox2()
    {
       
        //Vector3 lastpos = Playertransform.transform.position;
        GameObject _objectt = Instantiate(box) as GameObject;
       // _objectt.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        _objectt.transform.position = lastp + new Vector3(-(2*x), -lastp.y, z + 60f);
        lastp = fo.transform.position;
    }*/

    private void UpdateTerrainPositionsAndNeighbors()
	{
		_terrainGrid[0,0].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x - _terrainGrid[1,1].terrainData.size.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z + _terrainGrid[1,1].terrainData.size.z);
		_terrainGrid[0,1].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x - _terrainGrid[1,1].terrainData.size.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z);
		_terrainGrid[0,2].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x - _terrainGrid[1,1].terrainData.size.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z - _terrainGrid[1,1].terrainData.size.z);
		
		_terrainGrid[1,0].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z + _terrainGrid[1,1].terrainData.size.z);
		_terrainGrid[1,2].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z - _terrainGrid[1,1].terrainData.size.z);
		
		_terrainGrid[2,0].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x + _terrainGrid[1,1].terrainData.size.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z + _terrainGrid[1,1].terrainData.size.z);
		_terrainGrid[2,1].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x + _terrainGrid[1,1].terrainData.size.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z);
		_terrainGrid[2,2].transform.position = new Vector3(
			_terrainGrid[1,1].transform.position.x + _terrainGrid[1,1].terrainData.size.x,
			_terrainGrid[1,1].transform.position.y,
			_terrainGrid[1,1].transform.position.z - _terrainGrid[1,1].terrainData.size.z);
		
		_terrainGrid[0,0].SetNeighbors(             null,              null, _terrainGrid[1,0], _terrainGrid[0,1]);
		_terrainGrid[0,1].SetNeighbors(             null, _terrainGrid[0,0], _terrainGrid[1,1], _terrainGrid[0,2]);
		_terrainGrid[0,2].SetNeighbors(             null, _terrainGrid[0,1], _terrainGrid[1,2],              null);
		_terrainGrid[1,0].SetNeighbors(_terrainGrid[0,0],              null, _terrainGrid[2,0], _terrainGrid[1,1]);
		_terrainGrid[1,1].SetNeighbors(_terrainGrid[0,1], _terrainGrid[1,0], _terrainGrid[2,1], _terrainGrid[1,2]);
		_terrainGrid[1,2].SetNeighbors(_terrainGrid[0,2], _terrainGrid[1,1], _terrainGrid[2,2],              null);
		_terrainGrid[2,0].SetNeighbors(_terrainGrid[1,0],              null,              null, _terrainGrid[2,1]);
		_terrainGrid[2,1].SetNeighbors(_terrainGrid[1,1], _terrainGrid[2,0],              null, _terrainGrid[2,2]);
		_terrainGrid[2,2].SetNeighbors(_terrainGrid[1,2], _terrainGrid[2,1],              null,              null);
	}

    private void OnTriggerEnter (Collider coll)
    {

    }


    void Update ()
	{
        

        //rb.AddForce(0f, 0f, 100f);
        rnd = new System.Random();
        z = rnd.Next(0, 50);
        x = rnd.Next(-50, 50);
        playerPosition = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y, PlayerObject.transform.position.z);
		Terrain playerTerrain = null;
		int xOffset = 0;
		int yOffset = 0;
		for (int x = 0; x < 3; x++)
		{
			for (int y = 0; y < 3; y++)
			{
				if ((playerPosition.x >= _terrainGrid[x,y].transform.position.x) &&
					(playerPosition.x <= (_terrainGrid[x,y].transform.position.x + _terrainGrid[x,y].terrainData.size.x)) &&
					(playerPosition.z >= _terrainGrid[x,y].transform.position.z) &&
					(playerPosition.z <= (_terrainGrid[x,y].transform.position.z + _terrainGrid[x,y].terrainData.size.z)))
				{
					playerTerrain = _terrainGrid[x,y];
					xOffset = 1 - x;
					yOffset = 1 - y;
					break;
				}
			}
			if (playerTerrain != null)
				break;
		}
		
		if (playerTerrain != _terrainGrid[1,1])
		{
			Terrain[,] newTerrainGrid = new Terrain[3,3];
			for (int x = 0; x < 3; x++)
				for (int y = 0; y < 3; y++)
				{
					int newX = x + xOffset;
					if (newX < 0)
						newX = 2;
					else if (newX > 2)
						newX = 0;
					int newY = y + yOffset;
					if (newY < 0)
						newY = 2;
					else if (newY > 2)
						newY = 0;
					newTerrainGrid[newX, newY] = _terrainGrid[x,y];
				}
			_terrainGrid = newTerrainGrid;
			UpdateTerrainPositionsAndNeighbors();
		}
	}
}
