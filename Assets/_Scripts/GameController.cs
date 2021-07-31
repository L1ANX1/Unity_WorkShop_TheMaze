using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isGameEnd = false;
    Vector3 bombPos = new Vector3(0, 10, 0);
    public int hp = 1;

    public GameObject gameResultPanel;
    public Text resultText;
    public GameObject[] gems;

    public GameObject bombPrefab;
    public GameObject player;


    // Start is called before the first frame update
    void Start() {
        gameResultPanel.SetActive(false);
        InvokeRepeating("GenerateBomb", 2, 2);
        showHpUI();
    }

    // Update is called once per frame
    void Update() {
    }

    public void OnRetryButtonClick() {
        SceneManager.LoadScene("TheMaze");
    }

    void showHpUI() {
        for ( int i = 0; i < gems.Length; i++ ) {
            if ( i + 1 <= hp ) {
                gems[i].SetActive(true);
            } else {
                gems[i].SetActive(false);
            }
        }
    }

    public void EditHp(int value) {
        hp += value;
        if ( hp <= 0 ) {
            // game end
            GameEnd(false);
        } else {
            if ( hp > gems.Length ) {
                 hp = gems.Length;
            }
        }
        showHpUI();
    }

    public void GameEnd(bool isWin = true) {
        gameResultPanel.SetActive(true);
        isGameEnd = true;
        if ( isWin ) {
            resultText.text = "YOU Win";
        } else {
            resultText.text = "YOU LOSE";
        }
        CancelInvoke("GenerateBomb");

    }
    public void GenerateBomb() {
        bombPos.x = player.transform.position.x;
        bombPos.z = player.transform.position.z;
        GameObject.Instantiate(bombPrefab, bombPos, Quaternion.identity);
    }
}
