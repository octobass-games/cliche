using UnityEngine;

[CreateAssetMenu]
public class Medals : ScriptableObject
{
    public Sprite miniBronzeEasyMedal;
    public Sprite miniSilverEasyMedal;
    public Sprite miniGoldEasyMedal;

    public Sprite miniBronzeNormalMedal;
    public Sprite miniSilverNormalMedal;
    public Sprite miniGoldNormalMedal;

    public Sprite miniBronzeHardMedal;
    public Sprite miniSilverHardMedal;
    public Sprite miniGoldHardMedal;

    public Sprite BronzeEasyMedal;
    public Sprite SilverEasyMedal;
    public Sprite GoldEasyMedal;

    public Sprite BronzeNormalMedal;
    public Sprite SilverNormalMedal;
    public Sprite GoldNormalMedal;

    public Sprite BronzeHardMedal;
    public Sprite SilverHardMedal;
    public Sprite GoldHardMedal;

    public Sprite EasyBronze(bool small) => small ? miniBronzeEasyMedal : BronzeEasyMedal;
    public Sprite EasySilver(bool small) => small ? miniSilverEasyMedal : SilverEasyMedal;
    public Sprite EasyGold(bool small) => small ? miniGoldEasyMedal : GoldEasyMedal;

    public Sprite NormalBronze(bool small) => small ? miniBronzeNormalMedal : BronzeNormalMedal;
    public Sprite NormalSilver(bool small) => small ? miniSilverNormalMedal : SilverNormalMedal;
    public Sprite NormalGold(bool small) => small ? miniGoldNormalMedal : GoldNormalMedal;

    public Sprite HardBronze(bool small) => small ? miniBronzeHardMedal : BronzeHardMedal;
    public Sprite HardSilver(bool small) => small ? miniSilverHardMedal : SilverHardMedal;
    public Sprite HardGold(bool small) => small ? miniGoldHardMedal : GoldHardMedal;
}