using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color old;

    void Awake()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        old=sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(Pressed());
        }

            if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            AddScore();
            active = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
        {
            note=col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        active = false;
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;

    }
}
