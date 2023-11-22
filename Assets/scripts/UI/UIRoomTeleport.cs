using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIRoomTeleport : MonoBehaviour
{


    [SerializeField] ButtonInteractible[] xrButtons;
    [SerializeField] GameObject[] spawnPoints;

    [SerializeField] float spwanHeight = 0.605f;
    [SerializeField] GameObject xrOrign;

    private void Start()
    {
        foreach (var button in xrButtons)
        {
            button.selectEntered.AddListener(buttonPressed);
        }
    }

    private void buttonPressed(SelectEnterEventArgs arg0)
    {
        string btnText = arg0.interactableObject.transform.gameObject.GetComponentInChildren<TMP_Text>().text;
        if (btnText.Equals("room 1"))
        {
            UnityEngine.Vector3 room1Position = spawnPoints[0].transform.position;
            xrOrign.transform.position = new Vector3(
                room1Position.x,
                spwanHeight,
                room1Position.z
            );
        }
        else if (btnText.Equals("room 2"))
        {
            UnityEngine.Vector3 room1Position = spawnPoints[1].transform.position;
            xrOrign.transform.position = new Vector3(
                room1Position.x,
                spwanHeight,
                room1Position.z
            );
        }


    }
}
