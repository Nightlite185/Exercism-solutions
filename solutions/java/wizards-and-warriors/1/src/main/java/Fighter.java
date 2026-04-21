class Fighter {
    protected boolean vulnerable = false;

    boolean isVulnerable() {
        return true;
    }

    public int getDamagePoints(Fighter fighter) {
        return 1;
    }
}

class Warrior extends Fighter {
    
    @Override public String toString() {
        return "Fighter is a Warrior";
    }

    @Override public boolean isVulnerable() {
        return false;
    }

    @Override public int getDamagePoints(Fighter target) {
        return target.isVulnerable() ? 10 : 6;
    }
}

class Wizard extends Fighter {
    private boolean spellPrepared = false;

    @Override public String toString(){
        return "Fighter is a Wizard";
    }

    @Override public boolean isVulnerable(){
        return !spellPrepared;
    }

    @Override public int getDamagePoints(Fighter target) {
        return spellPrepared ? 12 : 3;
    }

    public void prepareSpell() {
        spellPrepared = true;
    }
}