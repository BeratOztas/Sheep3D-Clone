using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform[] spikes;
    [SerializeField]
    private GameObject coinPrefab;
    private bool fallDown;
    void Start()
    {
        ActivePlatform();
    }

    void ActiveSpike()
    {
        int index = Random.Range(0, spikes.Length);
        spikes[index].gameObject.SetActive(true);//the spikes we've chosen we change visible.
        spikes[index].DOLocalMoveY(0.7f, 1.4f).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(3f, 5f));


    }//Activespike
    void AddCoin()
    {
        GameObject c = Instantiate(coinPrefab);
        c.transform.position = transform.position;
        c.transform.SetParent(transform);
        c.transform.DOLocalMoveY(1f, 0f);

    }//coin
    void ActivePlatform()
    {
        int chance = Random.Range(0, 10);
        if (chance > 7)
        {
            int type = Random.Range(0, 9);
            switch (type)
            {
                case 0:
                    fallDown = true;
                    break;
                case 1:
                    fallDown = true;
                    break;
                case 2:
                    AddCoin();
                    break;
                case 3:
                    ActiveSpike();
                    break;
                case 4:
                    AddCoin();
                    break;
                case 5:
                    ActiveSpike();
                    break;
                case 6:
                    fallDown = true;
                    break;
                case 7:
                    fallDown = true;
                    break;
                case 8:
                    ActiveSpike();
                    break;
            }
        }
    }//active Platform
    void InvokeFalling()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (fallDown)
            {
                fallDown = false;
                Invoke("InvokeFalling", 1f);
            }
        }
        
    }
}//class
