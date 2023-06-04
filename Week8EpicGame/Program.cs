
using System.Net.Http.Headers;

string folderPath = @"F:\ProgrammingLists";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";


string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] arenas = { "Giant's Deep", "Depths of Hell", "Aiur", "Kingdom Industries HQ", "Pools of Lua", "The Backyard" };



Random rnd = new Random();


string hero = arraySelector(heroes);
string villain = arraySelector(villains);
string arena = arraySelector(arenas);

int heroHp = hpCalculator(hero);
int heroStrikePower = heroHp;
int villainHp = hpCalculator(villain);
int villainStrikePower = villainHp;

Console.WriteLine($"Today {hero} (HP = {heroHp}) sets out for adventure!");
Console.WriteLine($"However, {villain} (HP = {villainHp}) tries to stop them!");
Console.WriteLine($"The showdown will be in/on {arena}!");


while (heroHp > 0 && villainHp > 0)
{
    heroHp = heroHp - Hit(villain, villainStrikePower);
    villainHp = villainHp - Hit(hero, heroStrikePower);
}

if (heroHp > 0)
{
    Console.WriteLine($"{hero} wins!");
}
else if (villainHp > 0)
{
    Console.WriteLine($"{villain} wins...");
}
else
{
    Console.WriteLine("Draw?! How could this happen?");
}

Console.WriteLine($"{hero} HP = {heroHp}");
Console.WriteLine($"{villain} HP = {villainHp}");

static string arraySelector(string[] givenArray)
{
    Random rnd = new Random();
    int itemIndex = rnd.Next(0, givenArray.Length);
    string character = givenArray[itemIndex];
    return character;
}

static int hpCalculator(string charName)
{
    if (charName.Length < 10 )
    {
        return 10;
    }
    else
    {
        return charName.Length;
    }
}

static int Hit(string charName, int characterHP)
{
    //Minu isiklik lahendus sellele, kui tekkis olukord kus characterHP < 0
    if (characterHP <= 0)
    {
        return 0;
    }

    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);
    if (strike == 0 )
    {
        Console.WriteLine($"Critical failure! {charName} missed!");
    }
    else if (strike == characterHP - 1 )
    {
        Console.WriteLine($"Critical hit! {charName} dealt maximum damage! ({strike})");
    }
    else
    {
        Console.WriteLine($"{charName} dealt {strike} damage!");
    }

    return strike;
}