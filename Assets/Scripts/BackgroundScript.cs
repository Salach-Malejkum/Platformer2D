using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] bgTiles;
    // Start is called before the first frame update
    void Start()
    {
        bgTiles = GameObject.FindGameObjectsWithTag("BgTile");
        bgTiles = bgTiles.OrderBy(tiles => tiles.transform.position.x).ThenBy(tiles => transform.position.y).ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        GetCameraBounds();
    }

    void GetCameraBounds() {
        if(Input.GetKey(KeyCode.D))
        {
            if(bgTiles[bgTiles.Length-1].transform.position.x < mainCamera.transform.position.x + 8f)
            {
                for(int i = 0; i < 4; i++)
                {
                    bgTiles[i].transform.position = new Vector3(bgTiles[bgTiles.Length-1-i].transform.position.x + 2.8f, bgTiles[i].transform.position.y, 0f);
                }
                GameObject[] tempShift = new GameObject[bgTiles.Length];
                for(int i = 0; i < bgTiles.Length; i++)
                {
                    if(i+4 < bgTiles.Length)
                    {
                        tempShift[i] = bgTiles[i+4];
                    }
                    else 
                    {
                        tempShift[i] = bgTiles[i - bgTiles.Length + 4];
                    }
                }
                bgTiles = tempShift;
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(bgTiles[0].transform.position.x > mainCamera.transform.position.x - 8f)
            {
                for(int i = 0; i < 4; i++)
                {
                    bgTiles[bgTiles.Length-4+i].transform.position = new Vector3(bgTiles[i].transform.position.x - 2.8f, bgTiles[bgTiles.Length-4+i].transform.position.y, 0f);
                }
                GameObject[] tempShift = new GameObject[bgTiles.Length];
                for(int i = 0; i < bgTiles.Length; i++)
                {
                    if(i < 4)
                    {
                        tempShift[i] = bgTiles[bgTiles.Length-4+i];
                    }
                    else 
                    {
                        tempShift[i] = bgTiles[i-4];
                    }
                }
                bgTiles = tempShift;
            }
        }
        if(bgTiles[0].transform.position.y < mainCamera.transform.position.y + 2.8f)
        {
            for(int i = 3; i < bgTiles.Length; i = i + 4)
            {
                bgTiles[i].transform.position = new Vector3(bgTiles[i].transform.position.x, bgTiles[i-3].transform.position.y + 2.8f, 0f);
            }

            GameObject[] tempShift = new GameObject[bgTiles.Length];
            for(int i = 0; i < bgTiles.Length; i++)
            {
                if(i % 4 == 0)
                {
                    tempShift[i] = bgTiles[i+3];
                }
                else
                {
                    tempShift[i] = bgTiles[i-1];
                }
            }
            bgTiles = tempShift;
        }
        else if(bgTiles[3].transform.position.y > mainCamera.transform.position.y - 2.8f)
        {
            for(int i = 0; i < bgTiles.Length; i = i + 4)
            {
                bgTiles[i].transform.position = new Vector3(bgTiles[i].transform.position.x, bgTiles[i+3].transform.position.y - 2.8f, 0f);
            }

            GameObject[] tempShift = new GameObject[bgTiles.Length];
            for(int i = 0; i < bgTiles.Length; i++)
            {
                if((i-3)%4 == 0)
                {
                    tempShift[i] = bgTiles[i-3];
                }
                else
                {
                    tempShift[i] = bgTiles[i+1];
                }
            }
            bgTiles = tempShift;
        }
    }
    
}
