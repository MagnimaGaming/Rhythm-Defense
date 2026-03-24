using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
  public UIManager uiManager;
  bool isGameOver = false;

  void OnCollisionEnter(Collision collision)
  {
    if (!isGameOver && collision.gameObject.CompareTag("Enemy"))
    {
      isGameOver = true;
      uiManager.GameOver();
    }
  }

}
