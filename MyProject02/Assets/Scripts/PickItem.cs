using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    private int scoreTomato = 0;
    private int scoreCabbage = 0;
    public int gold;
    private int score = 0;
    public Text TomatoScoreText;
    public Text CabbageScoreText;
    public Text ScoreText;
    public Text ObjectiveText;
    private AudioSource audioSource;
    public AudioClip itemSound;
    public AudioClip complateSound;
    public string nextLevel;
    CharacterMovement cMovement;
    Animator animator;
    public GameObject completeUI;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();

        TomatoScoreText.text = "Tomato x " + scoreTomato.ToString();
        CabbageScoreText.text = "Cabbage x " + scoreCabbage.ToString();
        ObjectiveText.text = "Objective \nCollect " + gold + " point";
        completeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider traget)
    {
        if (traget.gameObject.tag.Equals("Tomato"))
        {
            Destroy(traget.gameObject);
            scoreTomato += 1;
            TomatoScoreText.text = "Tomato x " + scoreTomato.ToString();
            audioSource.PlayOneShot(itemSound);
        }
        else if (traget.gameObject.tag.Equals("Cabbage"))
        {
            Destroy(traget.gameObject);
            scoreCabbage += 1;
            CabbageScoreText.text = "Cabbage x " + scoreCabbage.ToString();
            audioSource.PlayOneShot(itemSound);
        }
        ScoreText.text = ""+((scoreTomato * 5) + (scoreCabbage * 10));
        score = (scoreTomato * 5) + (scoreCabbage * 10);
        if (score >= gold)
        {
            
            completeUI.SetActive(true);
            cMovement.speed = 0;
            animator.SetBool("Moving", false);
            animator.SetBool("Running", false);
            audioSource.PlayOneShot(complateSound);
            //StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(nextLevel);
    }
}
