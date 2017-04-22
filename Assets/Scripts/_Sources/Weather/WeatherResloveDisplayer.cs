using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// flow of function in this class control by animator
/// </summary>
public class WeatherResloveDisplayer : MonoBehaviour{

    [Header("UI")]
    public Text WinnerName;
    public Text LoserName;

    public Text WoodValue;
    public Text WaterValue;
    public Text CoalValue;

    public Color ExtraColor;
    public Color StraveColor;

    [Header("Animator")]
    private const float ANIMATION_TIME = 0.5f;
    private float _startTime;
    private bool _isDecreaseValue;
    public Animator Animator;

    [Header("Test Value")]
    public int CostWood;
    public int CostWater;
    public int CostCoal;

    public int PayWood;
    public int PayWater;
    public int PayCoal;

    private int _currentWood, _currentWater, _currentCoal; //! prevent alway re allocate in update

    void Update(){
        if(_isDecreaseValue) {
            this._currentWood = CostWood - (int)(PayWood * ((Time.time - _startTime) / ANIMATION_TIME));
            this._currentWater = CostWater - (int)(PayWater * ((Time.time - _startTime) / ANIMATION_TIME));
            this._currentCoal = CostCoal - (int)(PayCoal * ((Time.time - _startTime) / ANIMATION_TIME));
            UpdateResourcesText(this._currentWood, this._currentWater, this._currentCoal);
        }
    }

    public void ResloveWeather() {
        ResloveWeather(this.CostWood,this.CostWater,this.CostCoal,
            this.PayWood,this.PayWater,this.PayWood
            ,"TEST FUNCTION");
    }

    /// <summary>
    /// Show Resolve weather this method just calculate win or lose result display
    /// by cost and pay value (all pay >= all cost)
    /// </summary>
    /// <param name="playerName">playName who show when end of result</param>
    public void ResloveWeather(int costWood, int costWater, int costCoal,
        int payWood, int payWater, int payCoal,
        string playerName) {
        this.CostWood = costWood;
        this.CostWater = costWater;
        this.CostCoal = costCoal;

        this.PayWood = payWood;
        this.PayWater = payWater;
        this.PayCoal = payCoal;

        this.WinnerName.text = playerName;
        this.LoserName.text = playerName;

        Debug.Log("Result > "+isClearWeather().ToString());
        Animator.SetBool("Win", isClearWeather());
        this.Animator.Play("ShowCostEstimate");
    }

    public void UpdateResourcesText(int wood,int water,int coal) {
        this.WoodValue.text = (wood < 0 ? "+" : "") + Math.Abs(wood);
        this.WoodValue.color = wood <= 0 ? ExtraColor : StraveColor;

        this.WaterValue.text = (water < 0 ? "+" : "") + Math.Abs(water);
        this.WaterValue.color = water <= 0 ? ExtraColor : StraveColor;

        this.CoalValue.text = (coal < 0 ? "+" : "") + Math.Abs(coal);
        this.CoalValue.color = coal <= 0 ? ExtraColor : StraveColor;
    }

    private bool isClearWeather() {
        return PayWood >= CostWood && PayWater >= CostWater && PayCoal >= CostCoal;
    }

    private void beginDecreaseCostValue() {
        _isDecreaseValue = true;
        _startTime = Time.time;
    }

    private void stopDecreaseCostValue() {
        _isDecreaseValue = false;
        UpdateResourcesText(CostWood - PayWood
            , CostWater - PayWater
            , CostCoal - PayCoal
        );
    }
    
    public void SpeedUp() {
        this.Animator.speed = 2;
    }
    
    public void NormalSpeed() {
        this.Animator.speed = 1;
    }
}
