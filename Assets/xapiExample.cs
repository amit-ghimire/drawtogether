using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xapiExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        xAPIManager.SendLaunchStatment(SceneManager.GetActiveScene().name, System.DateTime.Now);   
    }
}
