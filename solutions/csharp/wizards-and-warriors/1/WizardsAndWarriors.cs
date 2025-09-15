abstract class Character
{

    protected readonly string characterType;
    protected bool vulnerable = false;

    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return vulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool spellPrepared = false;

    public Wizard() : base("Wizard")
    {
        vulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        return spellPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        vulnerable = false;
        spellPrepared = true;
    }
}
