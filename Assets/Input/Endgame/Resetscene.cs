using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetscene : MonoBehaviour
{
    public string currentscene;

    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        currentscene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentscene);
        
    }
}
