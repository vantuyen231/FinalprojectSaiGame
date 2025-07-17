using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SliderAbstact : SaiBehavior
{
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        this.slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    protected virtual void OnSliderValueChanged(float value)
    {
        //
    }
}