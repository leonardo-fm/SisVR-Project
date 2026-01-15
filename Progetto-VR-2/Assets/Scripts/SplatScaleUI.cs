using GaussianSplatting.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class SplatScaleUI : MonoBehaviour
{
    public Slider scaleSlider;
    public Slider opacitySlider;

    public GaussianSplatRenderer splatRenderer;

    void Start()
    {
        if (scaleSlider != null && opacitySlider != null)
        {
            // Assicura che lo slider parta dal valore attuale dello splat
            if (splatRenderer != null)
                scaleSlider.value = splatRenderer.m_SplatScale;
                opacitySlider.value = splatRenderer.m_OpacityScale;

            // Aggiunge il listener che chiama UpdateSplatScale ogni volta che lo slider cambia
            scaleSlider.onValueChanged.AddListener(UpdateSplatScale);
            opacitySlider.onValueChanged.AddListener(UpdateSplatOpacity);
        } else
        {
            Debug.Log("Error, sliders not found");
        }
    }

    private void UpdateSplatScale(float value)
    {
        if (splatRenderer != null)
        {
            // Aggiorna la variabile nello splat renderer
            splatRenderer.m_SplatScale = Mathf.Clamp(value, 0.1f, 2.0f);
        }
    }

    private void UpdateSplatOpacity(float value)
    {
        if (splatRenderer != null)
        {
            // Aggiorna la variabile nello splat renderer
            splatRenderer.m_OpacityScale = Mathf.Clamp(value, 0.05f, 20.0f);
        }
    }

    public void SetActiveRenderer(GaussianSplatRenderer renderer)
    {
        splatRenderer = renderer;

        if (splatRenderer != null)
        {
            scaleSlider.value = splatRenderer.m_SplatScale;
            opacitySlider.value = splatRenderer.m_OpacityScale;
        }
    }
}