using UnityEngine;

[CreateAssetMenu]
public class Medals : ScriptableObject
{
    public Sprite miniBronzeEasyMedal;
    public Sprite miniSilverEasyMedal;
    public Sprite miniGoldEasyMedal;
    public Sprite miniPlatEasyMedal;

    public Sprite miniBronzeNormalMedal;
    public Sprite miniSilverNormalMedal;
    public Sprite miniGoldNormalMedal;
    public Sprite miniPlatNormalMedal;

    public Sprite miniBronzeHardMedal;
    public Sprite miniSilverHardMedal;
    public Sprite miniGoldHardMedal;
    public Sprite miniPlatHardMedal;

    public Sprite BronzeEasyMedal;
    public Sprite SilverEasyMedal;
    public Sprite GoldEasyMedal;
    public Sprite PlatEasyMedal;

    public Sprite BronzeNormalMedal;
    public Sprite SilverNormalMedal;
    public Sprite GoldNormalMedal;
    public Sprite PlatNormalMedal;

    public Sprite BronzeHardMedal;
    public Sprite SilverHardMedal;
    public Sprite GoldHardMedal;
    public Sprite PlatHardMedal;

    public Sprite EasyBronze(bool small) => small ? miniBronzeEasyMedal : BronzeEasyMedal;
    public Sprite EasySilver(bool small) => small ? miniSilverEasyMedal : SilverEasyMedal;
    public Sprite EasyGold(bool small) => small ? miniGoldEasyMedal : GoldEasyMedal;
    public Sprite EasyPlat(bool small) => small ? miniPlatEasyMedal : PlatEasyMedal;

    public Sprite NormalBronze(bool small) => small ? miniBronzeNormalMedal : BronzeNormalMedal;
    public Sprite NormalSilver(bool small) => small ? miniSilverNormalMedal : SilverNormalMedal;
    public Sprite NormalGold(bool small) => small ? miniGoldNormalMedal : GoldNormalMedal;
    public Sprite NormalPlat(bool small) => small ? miniPlatNormalMedal : PlatNormalMedal;

    public Sprite HardBronze(bool small) => small ? miniBronzeHardMedal : BronzeHardMedal;
    public Sprite HardSilver(bool small) => small ? miniSilverHardMedal : SilverHardMedal;
    public Sprite HardGold(bool small) => small ? miniGoldHardMedal : GoldHardMedal;
    public Sprite HardPlat(bool small) => small ? miniPlatHardMedal : PlatHardMedal;
}