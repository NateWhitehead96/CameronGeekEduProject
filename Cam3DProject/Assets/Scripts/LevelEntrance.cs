using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntrance : MonoBehaviour
{
    [SerializeField] public Transform player; // the portal looks at our player
    [SerializeField] public int levelToLoad; // we can know what level to load up
    public int unlock; // what the levels beaten needs to be to show this portal
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.levelsBeaten < unlock) // if we havent beaten up to this level, then hide it
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player); // constantly look at player
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            SceneManager.LoadScene(levelToLoad); // load the appropriate level
        }
    }
}
