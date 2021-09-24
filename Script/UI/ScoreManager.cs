using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public Image[] FruitX = new Image[3];
    public Sprite FruitV;

    public int Cherry = 0; //
    public int Apple = 0; //
    public int Lemon = 0; //

    private void Start()
    {
        Cherry = 0;
        Apple = 0;
        Lemon = 0;
    }

    public void EatCherry(int value)
    {
        Cherry = Cherry + value;
        FruitX[0].sprite = FruitV;
    }

    public void EatApple(int value)
    {
        Apple = Apple + value;
        FruitX[1].sprite = FruitV;
    }

    public void EatLemon(int value)
    {
        Lemon = Lemon + value;
        FruitX[2].sprite = FruitV;
    }

}