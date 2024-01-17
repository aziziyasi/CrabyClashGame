using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameOverButton : MonoBehaviour
{
   public void RestartButton(){
    SceneManager.LoadScene(2);
   }
}
