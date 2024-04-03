using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetscene : MonoBehaviour
{
    public string currentscene; 
    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset()
    {
        currentscene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentscene);
    }
}
