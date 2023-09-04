using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "2__MENUAL__")
        {
            Destroy(gameObject);
        }
    }

}
