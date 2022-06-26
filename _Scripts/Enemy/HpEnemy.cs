using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpEnemy : MonoBehaviour
{
    public Slider sliderHP;
    public Vector3 offset;
    private void Awake()
    {
        this.sliderHP.gameObject.SetActive(false);
    }
    public void SetHealthStart(int health)
    {
        // khoi ta gia tri ban dau
        this.sliderHP.maxValue = health;
        this.sliderHP.value = health;
    }
    public void SetHealth(int health)
    {
        // so mau mat di
        this.sliderHP.value -= health;
        this.sliderHP.gameObject.SetActive(this.sliderHP.value < this.sliderHP.maxValue && this.sliderHP.maxValue > 30);
        if (this.sliderHP.value <= 0)
        {
            // hieu uwng
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        this.sliderHP.transform.position = Camera.main.WorldToScreenPoint(transform.position + this.offset);
    }

}
