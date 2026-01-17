using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonLogic : MonoBehaviour
{
    [SerializeField] AudioClip personSFX;
    [SerializeField] public GameObject package;
    private Progress progress;

    // Start is called before the first frame update
    void Start()
    {
        progress = GameObject.FindGameObjectWithTag(GameConstants.TAG_PROGRESS).GetComponent<Progress>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_PLAYER)
        {
            GamePlay.SmthHappened(gameObject, personSFX);
            GamePlay.SetActiveSmth(package);
            progress.addProgress();
        }
    }
}
