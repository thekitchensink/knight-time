﻿using UnityEngine;
using System.Collections;

class cell
{
	public bool left;
	public bool right;
	public bool top;
	public bool bottom;

  public int group;

  public bool pickup;

  public cell()
  {
  }

  public cell(bool L, bool R, bool T, bool B, int G)
  {
    left = L;
    right = R;
    top = T;
    bottom = B;
    group = G;

    int aRand = Random.Range(0, 10);
    if(aRand == 1)
    {
      pickup = true;
    }
    else
    {
      pickup = false;
    }
  }
}

public class Generation : MonoBehaviour {

    private bool hasntGoal = true;
    private int randGoalx;
    private int randGoaly;

    public int xDense = 4;
    public int yDense = 3;

    public GameObject thegoal;
    public GameObject walls;
    public GameObject Pickup;

    public int width, height;
    public float topLeftX, topLeftZ, hallSize, yheight, floor;

    private cell[,] dungeon;

    private int Height;
    private int Width;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("FPSController").GetComponent<Transform>().position = new Vector3(topLeftX, floor + height/2.0f ,topLeftZ);
        randGoalx = Random.Range((int)(2.0f*(width - 1)/3.0f), width- 1);// = Random.Range((int)((2.0f * (float)(width) / 3.0f) * (2.0f * (float)(height) / 3.0f)), (width - 1) * (height - 1));
        randGoaly = Random.Range((int)(2.0f * (height - 1) / 3.0f), height - 1);
        generateMap(width, height);
        buildMap(topLeftX, topLeftZ, hallSize, yheight, floor);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void generateMap(int width, int height)
  {
    if (xDense <= 1) xDense = 4;
    if (yDense <= 1) yDense = 3;

    dungeon = new cell[width, height];

    this.Height = height;
    this.Width = width;
    
    //needs to be at least 3 by 3
    if (width < 3 && height < 3)
      return;
		
    //initialize everyting to null
    for (int j = 0; j < height; ++j)
    {
      for (int i = 0; i < width; ++i)
      {
         dungeon[j, i] = null;      
      }
    }

    for (int j = 0; j < height; ++j)
    {
      //generate first row
      for (int i = 0; i < width; ++i)
      {
        if(dungeon[j, i] == null)
          dungeon[j, i] = new cell( true, true, true, true, j * width + i ); 
      }

      //randomly merge adjacent sets
      for (int i = 1; i < width; ++i)
      {
        int choice = Random.Range((int)0, (int)xDense);
        if (choice == 1)
        {
          dungeon[j, i - 1].right = false;
          dungeon[j, i].left = false;

          dungeon[j, i].group = dungeon[j, i - 1].group;
        }
      }

      //at least once for each group, add extentions going down
      if(j+1 < height)
      {
        int last = -1;
        for (int i = 0; i < width; ++i)
        {
          int current = dungeon[j, i].group;
          bool has = false;
          while (!has && current != last)
          {
            for (int k = 0; (k < width); ++k)
            {
              int choice = Random.Range((int)0, (int)yDense);
              if (choice == 1 && dungeon[j, k].group == current)
              {
                //extend the bottom
                dungeon[j, k].bottom = false;

                dungeon[j + 1, k] = new cell(true, true, false, true, current);

                has = true;

                last = current;
              }
            }
          }

        }
      }


    }
	}   


  void buildMap(float topLeftX, float topLeftZ, float hallSize, float height, float floor)	
  {
    float t = topLeftX;

        for (int j = 0; j < this.Height; ++j)
        {
            for (int i = 0; i < this.Width; ++i)
            {
                //left wall.
                if (dungeon[j, i].left)
                {
                    GameObject left = GameObject.Instantiate(walls);
                    left.GetComponent<Transform>().position = new Vector3(topLeftX - hallSize / 2, floor + height / 2.0f - 0.001f, topLeftZ);
                    left.GetComponent<Transform>().localScale = (new Vector3(hallSize * left.GetComponent<Transform>().localScale.x,
                        height * left.GetComponent<Transform>().localScale.y, hallSize * left.GetComponent<Transform>().localScale.z));
                }

                if (dungeon[j, i].right)
                {
                    GameObject right = GameObject.Instantiate(walls);
                    right.GetComponent<Transform>().position = new Vector3(topLeftX + hallSize / 2, floor + height / 2.0f - 0.001f, topLeftZ);
                    right.GetComponent<Transform>().localScale = (new Vector3(hallSize * right.GetComponent<Transform>().localScale.x,
                         height * right.GetComponent<Transform>().localScale.y, hallSize * right.GetComponent<Transform>().localScale.z));
                }

                if (dungeon[j, i].bottom)
                {
                    GameObject bottom = GameObject.Instantiate(walls);//GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bottom.GetComponent<Transform>().position = new Vector3(topLeftX, floor + height / 2.0f - 0.001f, topLeftZ - hallSize / 2);
                    bottom.GetComponent<Transform>().Rotate(0.0f, 00.0f, 90.0f);
                    bottom.GetComponent<Transform>().localScale = (new Vector3(hallSize * bottom.GetComponent<Transform>().localScale.x,
                         height * bottom.GetComponent<Transform>().localScale.y, hallSize * bottom.GetComponent<Transform>().localScale.z));
                }

                if (dungeon[j, i].top)
                {
                    GameObject top = GameObject.Instantiate(walls);
                    top.GetComponent<Transform>().position = new Vector3(topLeftX, floor + height / 2.0f - 0.001f, topLeftZ + hallSize / 2);
                    top.GetComponent<Transform>().Rotate(0.0f, 0.0f, 90.0f);
                    top.GetComponent<Transform>().localScale = (new Vector3(hallSize * top.GetComponent<Transform>().localScale.x,
                        height * top.GetComponent<Transform>().localScale.y, hallSize * top.GetComponent<Transform>().localScale.z));
                }

                topLeftX += hallSize;

                GameObject theFloor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                theFloor.GetComponent<Transform>().position = new Vector3(topLeftX - hallSize, floor, topLeftZ);
                theFloor.GetComponent<Transform>().localScale = new Vector3(hallSize, 0.001f, hallSize);
                Material newat = Resources.Load("dungeonfloor") as Material;
                theFloor.GetComponent<Renderer>().material = newat;
                theFloor.layer = LayerMask.NameToLayer("Player");

                GameObject theCeil = GameObject.CreatePrimitive(PrimitiveType.Cube);
                theCeil.GetComponent<Transform>().position = new Vector3(topLeftX - hallSize, floor + height * 1.15f, topLeftZ);
                theCeil.GetComponent<Transform>().localScale = new Vector3(hallSize, 0.001f, hallSize);
                theCeil.GetComponent<Renderer>().material = newat;
                theCeil.layer = LayerMask.NameToLayer("Player");

                if(randGoalx == i && randGoaly == j )
                {
                    hasntGoal = false;
                    GameObject goal = GameObject.Instantiate(thegoal);
                    goal.GetComponent<Transform>().position = new Vector3(topLeftX - hallSize, floor + height * 0.25f, topLeftZ);
                }

                if (dungeon[j, i].pickup)
                {
                    GameObject pick = GameObject.Instantiate(Pickup);
                    pick.GetComponent<Transform>().position = new Vector3(topLeftX - hallSize, floor + height * 0.25f, topLeftZ);
                }
            }
            topLeftZ -= hallSize;
            topLeftX = t;
        }

    }
}
