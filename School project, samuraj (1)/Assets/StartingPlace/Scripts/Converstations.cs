using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Converstations : MonoBehaviour
{    //TRANSFORMS AND LAYERMASK
    [SerializeField] public Transform PlayerPos;
    [SerializeField] public Transform FirstSign;
    [SerializeField] public LayerMask Player;
    [SerializeField] public Transform ChooseDestination;

    //PHYSICS2D BOOLS
    bool PlayerCloseToFirstSign;
    bool PlayerCloseToDestinationChooser;
    bool PlayerCloseToFirstSignBool = false;
    bool PlayerCloseToDestinationChooserBool = false;
    bool DestinationChooserTextisActive;

    //TEXT AND BUTTON BOOLS
    [SerializeField] public GameObject DestinatioOpenE;
    [SerializeField] public GameObject DestinationChooserText;
    [SerializeField] public GameObject FirstSignE;
    [SerializeField] public GameObject FirstSignText;
    [SerializeField] public GameObject MoreShurikenText;

    //Random Bools
    Player player;

    //Random
    float showtext = 0;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        
        bool PlayerCloseToFirstSign = Physics2D.OverlapCircle(FirstSign.position, 0.85f, Player);
        bool PlayerCloseToDestinationChooser = Physics2D.OverlapCircle(ChooseDestination.position, 1.3f, Player);

        if (PlayerCloseToFirstSign)
        {
            PlayerCloseToFirstSignBool = true;
        }
        if (PlayerCloseToFirstSignBool)
        {
            FirstSignE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                FirstSignText.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                FirstSignText.SetActive(false);
            }
            if (PlayerCloseToFirstSign == false)
            {
                FirstSignText.SetActive(false);
                FirstSignE.SetActive(false);
            }
        }

        if (PlayerCloseToDestinationChooser)
        {
            PlayerCloseToDestinationChooserBool = true;
        }

        if (PlayerCloseToDestinationChooserBool)
        {
            DestinatioOpenE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DestinationChooserText.SetActive(true);
                DestinationChooserTextisActive = true;
            }
            if (DestinationChooserTextisActive)
            {
                DestinatioOpenE.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                DestinationChooserText.SetActive(false);
                DestinationChooserTextisActive = false;
            }
            if (PlayerCloseToDestinationChooser == false)
            {
                DestinationChooserTextisActive = false;
                DestinationChooserText.SetActive(false);
                DestinatioOpenE.SetActive(false);
            }

        }

        if (player.ThrowingStarAmount == 0 && (showtext == 0))
        {
            MoreShurikenText.SetActive(true);
            StartCoroutine(TextCD());

            IEnumerator TextCD()
            {
                yield return new WaitForSeconds(3);
                MoreShurikenText.SetActive(false);
                showtext += 1;
            }

        }
    }

    public void GoHuntingButton()
    {
        SceneManager.LoadScene("HuntingPlace");
    }
    public void GoToTownButton()
    {
        SceneManager.LoadScene("Birmingham");
        player.transform.position = new Vector2(-1, 0);
    }
    public void StayButton()
    {
        DestinationChooserText.SetActive(false);
    }
}
