using UnityEngine;

public class MagicSwitch : MonoBehaviour
{
    public GameObject[] magicIcons;
    public int selectedMagic = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectMagic();
    }

    // Update is called once per frame
    void Update()
    {
        MagicIconDisplay();

        int previousSelectedMagic = selectedMagic;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedMagic >= transform.childCount - 1)
            {
                selectedMagic = 0;
            }
            else
            {
                selectedMagic++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedMagic <= 0)
            {
                selectedMagic = transform.childCount - 1;
            }
            else
            {
                selectedMagic--;
            }
        }

        if(previousSelectedMagic != selectedMagic)
        {
            SelectMagic();
        }
    }

    void SelectMagic()
    {
        int i = 0;
        foreach (Transform magic in transform)
        {
            if(i== selectedMagic)
            {
                magic.gameObject.SetActive(true);
            }
            else
            {
                magic.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void MagicIconDisplay()
    {
        switch(selectedMagic)
        {
            case 0:
                magicIcons[0].SetActive(false);
                magicIcons[1].SetActive(true);
                magicIcons[2].SetActive(true);
                magicIcons[3].SetActive(false);
                magicIcons[4].SetActive(true);
                magicIcons[5].SetActive(false);
                break;
            case 1:
                magicIcons[0].SetActive(true);
                magicIcons[1].SetActive(false);
                magicIcons[2].SetActive(false);
                magicIcons[3].SetActive(true);
                magicIcons[4].SetActive(true);
                magicIcons[5].SetActive(false);
                break;
            case 2:
                magicIcons[0].SetActive(true);
                magicIcons[1].SetActive(false);
                magicIcons[2].SetActive(true);
                magicIcons[3].SetActive(false);
                magicIcons[4].SetActive(false);
                magicIcons[5].SetActive(true);
                break;

        }
    }

}
