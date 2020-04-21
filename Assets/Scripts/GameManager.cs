using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int numberOfCollectable = 0;
    public float timeRemaining = 20f;
    public UIManager uIManager;
    public FPController player;


    private void Awake()
    {
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPController>();
    }

    public void CollisionDetected(Collision collision,FPController player)
    {

        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            numberOfCollectable += 1;
            uIManager.ShowScore(numberOfCollectable);
        }
        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            Debug.Log("eeeeeeeeeee");
            uIManager.ShowGameOver();
            player.isDead = true;
        }
    }
    private void FixedUpdate()
    {
        if (timeRemaining <= 0.0f)
        {
            timeRemaining = 0;
            uIManager.ShowGameOver();
            uIManager.UpdateTime(timeRemaining);
            player.isDead = true;
        }
        else
        {
            timeRemaining -= Time.deltaTime;
            uIManager.UpdateTime(timeRemaining);
        }
    }

}
