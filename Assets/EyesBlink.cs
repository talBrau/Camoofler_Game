using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesBlink : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private float timeTillBlink;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        timeTillBlink =Random.Range(2, 4);
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTillBlink)
        {
            _animator.SetTrigger("blink");
            timer = 0;
            timeTillBlink =Random.Range(2, 4);
        }
        
        
        
    }

    private IEnumerator blinkInSec(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
