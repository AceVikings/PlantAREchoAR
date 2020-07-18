using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("MarketScene");
    }

    public void back()
    {
        SceneManager.LoadScene("SimpleAR");
    }
}
