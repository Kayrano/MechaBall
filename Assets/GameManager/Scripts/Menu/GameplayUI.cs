using UnityEngine.UI;
using UnityEngine;
using Character;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private PlayerScript playerS;
    [SerializeField] private Canvas controllerCanvas;
    [SerializeField] private Button pauseButton;

    [SerializeField] private Image Heart1;
    [SerializeField] private Image Heart2;
    [SerializeField] private Image Heart3;


    private void Start()
    {
       
        if(playerS.playerI._device == PlayerInput.DeviceType.PC)
        {
            controllerCanvas.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if(GameManager.Instance.CurrentGameState != GameManager.GameState.RUNNING)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }


        switch (playerS.currentHealth)
        {
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);

                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
        }
    }

    



}
