using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("start");
    }
}
