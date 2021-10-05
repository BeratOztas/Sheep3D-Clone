using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatformprefab, platformPrefab, endPlatformPrefab;
    private float blockWidth =0.5f ,blockHeight =0.2f;
    [SerializeField]
    private int amountToSpawn = 100;
    private int beginAmount = 0;
    private Vector3 lastPos;
    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    [SerializeField]
    private GameObject playerPrefab;

     void Awake()
    {
        InstantiateLevel();
    }

    void InstantiateLevel()
    {
        for(int i = beginAmount;i<amountToSpawn;i++)
        {
            GameObject newPlatform;
            if (i == 0)
            {
                newPlatform = Instantiate(startPlatformprefab);
            } else if(i == amountToSpawn - 1)
            {
                newPlatform = Instantiate(endPlatformPrefab);
                newPlatform.tag = "EndPlatform";
            }
            else
            {
                newPlatform = Instantiate(platformPrefab);
            }
            newPlatform.transform.parent = transform;//The newplatform we have insta it'll be child of levelgenerator obj.
            spawnedPlatforms.Add(newPlatform);//we have added to list maybe we wanna get index of newplatform.
            if(i == 0)
            {
                lastPos = newPlatform.transform.position;
                Vector3 temp = lastPos;
                temp.y += 0.1f;
                Instantiate(playerPrefab, temp, Quaternion.identity);
                //instantiate the player
                continue;//after we created the first platform we simply continue because we dont wanna set the obstancle.
            }
            int left = Random.Range(0, 2);//
            if(left == 0)//in 3d game to move left and right we changed X .
            {
                newPlatform.transform.position =
                new Vector3(lastPos.x - blockWidth, lastPos.y + blockHeight, lastPos.z);
            }
            else//in 3d game to move forward and backward we changed Z .
            {
                newPlatform.transform.position =
                 new Vector3(lastPos.x, lastPos.y + blockHeight, lastPos.z + blockWidth);
            }
            lastPos = newPlatform.transform.position;//get the lastpos obst lastprefab to add new platform. 

            //fancy animation
            if (i < 25)
            {
                float endPos = newPlatform.transform.position.y;
                newPlatform.transform.position =
                    new Vector3(newPlatform.transform.position.x,
                    newPlatform.transform.position.y - blockHeight * 3f,
                    newPlatform.transform.position.z);
                newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);
                //to look like wave our prefab we set delay from assets 
                // we keep the obst endpos then dolocalmove y we set the previous pozisyon look like wave
            }

        }//for loop



    }//instantiatelevel





}//class
