using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public BethScript bethScript;
    public JerrysScript jerryrun1, jerryrun2, jerryrun3, jerryrun4, jerryrun5, jerryrun6;
    public GameObject[] waypoints;
    public GameObject Jerry, Jerry1, Jerry2, Beth;
    public AudioClip marco, comefindme, patronized, howSo, jerry, ridiculous, iLoveYouJerry, awwBeth, whoWantsTo, definitely, firstOne, tooHigh, tooHigh2;
    float speed = 0.7f;
    float accuracyWP = 0.2f;
    int currentWP = 0;
    bool isMoving = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
		if(waypoints.Length > 0)
        {
            float dist = Vector3.Distance(waypoints[currentWP].transform.position, transform.position);
            if (isMoving == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, Time.deltaTime * speed);
            }
            if (dist <= accuracyWP)
            {
                
                switch (currentWP)
                {
                    case 0:
                        {
                            AudioSource audio = Jerry.GetComponent<AudioSource>();
                            audio.PlayOneShot(marco);
                            float lengthOfSound = marco.length;
                            StartCoroutine(PlaySound(lengthOfSound));
                            break;
                        }
                    case 1:
                        {
                            isMoving = false;
                            AudioSource audio = this.GetComponent<AudioSource>();
                            audio.PlayOneShot(patronized);
                            float lengthOfSound = patronized.length;
                            StartCoroutine(PlaySound(lengthOfSound));
                            break;
                        }
                    case 2:
                        {
                            speed = 1.3f;
                            break;
                        }
                    case 3:
                        {
                            jerryrun1.beginJerrys();
                            jerryrun2.beginJerrys();
                            jerryrun3.beginJerrys();
                            jerryrun4.beginJerrys();
                            jerryrun5.beginJerrys();
                            jerryrun6.beginJerrys();
                            AudioSource audio = Jerry.GetComponent<AudioSource>();
                            audio.PlayOneShot(tooHigh2);
                            float lengthOfSound = tooHigh2.length;
                            StartCoroutine(PlaySound(lengthOfSound));
                            break;
                        }
                }

                if (currentWP >= waypoints.Length-1)
                {
                    isMoving = false;
                    //replay scene
                }else
                {
                    currentWP++;
                }
            }
        }
	}
    IEnumerator PlaySound(float time)
    {
        switch (currentWP) {
            case 0:
                {
                    yield return new WaitForSeconds(time);
                    AudioSource audio = Jerry1.GetComponent<AudioSource>();
                    audio.PlayOneShot(comefindme);
                    break;
                }
            case 1:
                {
                    yield return new WaitForSeconds(time);
                    bethScript.beginBeth();
                    AudioSource audio = Jerry.GetComponent<AudioSource>();
                    audio.PlayOneShot(howSo);
                    yield return new WaitForSeconds(howSo.length);
                    audio = Beth.GetComponent<AudioSource>();
                    audio.PlayOneShot(jerry);
                    yield return new WaitForSeconds(jerry.length);
                    audio = GetComponent<AudioSource>();
                    audio.PlayOneShot(ridiculous);
                    yield return new WaitForSeconds(ridiculous.length);
                    audio = Beth.GetComponent<AudioSource>();
                    audio.PlayOneShot(iLoveYouJerry);
                    yield return new WaitForSeconds(iLoveYouJerry.length);
                    audio = GetComponent<AudioSource>();
                    audio.PlayOneShot(awwBeth);
                    yield return new WaitForSeconds(awwBeth.length);
                    audio = Beth.GetComponent<AudioSource>();
                    audio.PlayOneShot(whoWantsTo);
                    yield return new WaitForSeconds(whoWantsTo.length);
                    audio = Jerry2.GetComponent<AudioSource>();
                    audio.PlayOneShot(definitely);
                    yield return new WaitForSeconds(definitely.length);
                    audio = Beth.GetComponent<AudioSource>();
                    audio.PlayOneShot(firstOne);
                    yield return new WaitForSeconds(firstOne.length);
                    audio = GetComponent<AudioSource>();
                    audio.PlayOneShot(tooHigh);
                    bethScript.beginBeth();
                    yield return new WaitForSeconds(tooHigh.length);
                    speed = 5.0f;
                    isMoving = true;
                    break;
                }
            case (3):
                {
                    yield return new WaitForSeconds(tooHigh2.length);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
                }
        }
    }
}
