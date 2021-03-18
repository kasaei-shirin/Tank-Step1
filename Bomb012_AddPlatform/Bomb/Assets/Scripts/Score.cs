using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using TMPro;

public class Score : MonoBehaviour
{
    // refrence to teh two different objects 
    public GameObject player1;
    public GameObject enemy1;
    // variable to keep the last object
    public GameObject lastPlayer;
    public GameObject lastEnemy;
    // Varable to keep the Text of Canvas for show the score of Enemy and player
    public Text scorePlayer;
    public Text scoreEnemy;
    // count the number of objects that destrpied total
    int countPlayerWin, countEnemyWin = 0;
    //List of enemy
    public TriggerEnemy[] allEnemys;
    public TriggerPlayer[] allPlayer;
    //Refrence to the level complete menu to present score of Enemy and Player
    public TextMeshProUGUI scoreEnemyTotal, scorePlayerTotal;
    //
    public GameObject levelComplete;

    void Start()
    {
        // Two first object produced one time and copied to the last variables
        //   lastPlayer = Instantiate(player1, new Vector3(5f, 0.5f, -14f), transform.rotation);
        //  lastEnemy = Instantiate(enemy1, new Vector3(1f, 0.5f, 5f), transform.rotation);
    }


    void Update()
    {
        allEnemys = GameObject.FindObjectsOfType<TriggerEnemy>();
        allPlayer = GameObject.FindObjectsOfType<TriggerPlayer>();
        #region //these two if calculate which person computer or player destroy the objects then count the destroy item and destroy the another one object and intiliaze the new object for both enemy and player
        // if plyaer destroy objects of Enemy
        if (allEnemys.Length == 0)
        {
            countPlayerWin++;
            //   Share.destroy_enemy = false;
            scorePlayer.text = "Player Score: " + countPlayerWin.ToString();
          scorePlayerTotal.text= "Player Score: " + countPlayerWin.ToString();

            foreach (TriggerPlayer currentPlayer in allPlayer)
                Destroy(currentPlayer.gameObject);

            int rand = Random.Range(0, 11);
            for (int i = 0; i< rand; i++) {
                // new position in each part of filed for enemy and player 
                Vector3 positionplayer = new Vector3(Random.Range(115, 890) + Random.Range(0, 20), 40f, Random.Range(108, 440) + Random.Range(0, 20));
                Vector3 positionenemy = new Vector3(Random.Range(115, 890) + Random.Range(0, 20), 40f, Random.Range(544, 900) + Random.Range(0, 20));
                Instantiate(player1, positionplayer, transform.rotation);
                Instantiate(enemy1, positionenemy, Quaternion.Euler(0, -Input.compass.trueHeading + 180, 0));
            }
            levelComplete.SetActive(true);
            Share.attackButton = false;
        }
        //If Enemy destroy all objects of player
        if (allPlayer.Length == 0)
        {
           // Debug.Log("It works");
            countEnemyWin++;
            //  Share.ListPlayerDestroy = false;
            scoreEnemy.text = "Enemy Score: " + countEnemyWin.ToString();
            scoreEnemyTotal.text = "Enemy Score: " + countEnemyWin.ToString();
            foreach (TriggerEnemy currentEnemy in allEnemys)
            {
                Destroy(currentEnemy.gameObject);



                // Vector3 positionplayer = new Vector3(Random.Range(-23, 22), 0.5f, Random.Range(-21, 0));
                // Vector3 positionenemy = new Vector3(Random.Range(-23, 22), 0.5f, Random.Range(0, 22));
                // lastPlayer = Instantiate(player1, positionplayer, transform.rotation);
                // lastEnemy = Instantiate(enemy1, positionenemy, transform.rotation);

            }
            int rand = Random.Range(0, 11);
            for (int i = 0; i < rand; i++)
            {

                Vector3 positionplayer = new Vector3(Random.Range(115, 890) + Random.Range(0, 20), 40f, Random.Range(108, 440) + Random.Range(0, 20));
                Vector3 positionenemy = new Vector3(Random.Range(115, 890) + Random.Range(0, 20), 40f, Random.Range(544, 900) + Random.Range(0, 20));
                Instantiate(player1, positionplayer, transform.rotation);
                Instantiate(enemy1, positionenemy, Quaternion.Euler(0, -Input.compass.trueHeading + 180, 0));
            }

            #endregion
            levelComplete.SetActive(true);
            Share.attackButton = false;
        }
    }
}