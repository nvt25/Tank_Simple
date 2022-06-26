using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandle : MonoBehaviour
{
    public float hpMax;
    public float hpValue;
    public Slider hpSlider;
    public PlayerController playerController;
    public int idModel;
    public Transform lower;
    public Transform upper;
    private void Start()
    {
        this.hpValue = this.hpMax;
        this.hpSlider.maxValue = this.hpMax;
        this.hpSlider.value = this.hpMax;
        this.idModel = GameManager.instance.Sttsp;
        this.playerController = transform.parent.GetComponent<PlayerController>();
        ShowModeSelected();

    }
    private void FixedUpdate()
    {
        upper.position = Vector3.MoveTowards(upper.position, lower.position, 10);
    }
    private void ShowModeSelected()
    {
        this.playerController.Hulls[this.idModel].SetActive(true);
        this.playerController.Guns[this.idModel].SetActive(true);
        int lengthModel = this.playerController.Hulls.Count;
        
        
    }
    public void Chiu(int damager)
    {
        this.hpValue -= damager;
        this.hpSlider.value = this.hpValue;

    }
}
