using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class environmentmanager : MonoBehaviour
{
  public GameObject Poor;
  public GameObject Better;
  public GameObject Good;
  public GameObject Perfect;
  public TextMeshProUGUI scoreText;
  public GameObject scorePopup;
  int Score = 0;
  float movetime = 0f;
  float idletime = 0f;

  [SerializeField] private Transform playerTf;

  void Update()
  {
    bool movementkey = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
    if (movementkey)
    {
      movetime += 10 * Time.deltaTime;
      idletime = 0f;
    }
    else
    {
      idletime += Time.deltaTime;
      movetime = 0f;
    }
    if (movetime > 5f)
    {
      Score += 10;
      movetime = 0f;
      Debug.Log("Score: " + Score);
      scoreText.text = "Score: " + Score;
      StartCoroutine(ShowScorePopup("+10"));
    }
    if (idletime > 5f)
    {
      Score -= 10;
      idletime = 0f;
      Debug.Log("Score: " + Score);
      scoreText.text = "Score: " + Score;
      StartCoroutine(ShowScorePopup("-10"));
    }
    updateEnvironment();

  }
  void updateEnvironment()
  {
    Debug.Log("Environment Update: Score = " + Score);
    if (Score < 10)
    {
      ActivateEnvironment(Poor);
      Debug.Log("Poor Environment Activated");
    }
    else if (Score >= 10 && Score < 20)
    {
      Debug.Log("Better Environment Activated");
      ActivateEnvironment(Better);
    }
    else if (Score >= 20 && Score < 30)
    {
      Debug.Log("Good Environment Activated");
      ActivateEnvironment(Good);
    }
    else
    {
      ActivateEnvironment(Perfect);
      Debug.Log("Perfect Environment Activated");
    }
  }
  void ActivateEnvironment(GameObject environment)
  {
    Poor.SetActive(false);
    Better.SetActive(false);
    Good.SetActive(false);
    Perfect.SetActive(false);
    environment.SetActive(true);
    Vector3 envPos = environment.transform.position;
    environment.transform.position = new Vector3(playerTf.position.x, envPos.y, envPos.z);
  }
  IEnumerator ShowScorePopup(string message)
  {
    scorePopup.SetActive(true);
    scorePopup.GetComponent<TextMeshProUGUI>().text = message;
    yield return new WaitForSeconds(1f);
    scorePopup.SetActive(false);
  }
}
