using UnityEngine;

public class MagicSwitch : MonoBehaviour
{
    public int selectedMagic = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectMagic();
    }

    // Update is called once per frame
    void Update()
    {

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
}
