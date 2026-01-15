using UnityEngine;
using UnityEngine.UI;

public class GaussianSplatSettings : MonoBehaviour
{
    [Range(0.1f, 2.0f)]
    public float m_SplatScale = 1.0f;

    

    public void SetSplatScale(float value)
    {
        m_SplatScale = value;
    }
}