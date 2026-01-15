using UnityEngine;
using TMPro;
using GaussianSplatting.Runtime;

public class SplatObjectSwitcher : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;

    public GaussianSplatRenderer rendererA;
    public GaussianSplatRenderer rendererB;
    public GaussianSplatRenderer rendererC;

    public SplatScaleUI splatUI;

    void OnEnable()
    {
        if (dropdown == null)
            return;

        dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
        dropdown.onValueChanged.AddListener(OnDropdownChanged);

        OnDropdownChanged(dropdown.value);
    }

    void OnDropdownChanged(int index)
    {
        if (splatUI == null)
            return;

        if (objectA != null) objectA.SetActive(index == 0);
        if (objectB != null) objectB.SetActive(index == 1);
        if (objectC != null) objectC.SetActive(index == 2);

        if (index == 0 && rendererA != null)
            splatUI.SetActiveRenderer(rendererA);

        if (index == 1 && rendererB != null)
            splatUI.SetActiveRenderer(rendererB);

        if (index == 2 && rendererC != null)
            splatUI.SetActiveRenderer(rendererC);
    }
}
