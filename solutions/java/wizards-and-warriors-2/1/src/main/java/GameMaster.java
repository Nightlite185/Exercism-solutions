public class GameMaster {

    public String describe(Character c){
        return "You're a level " + c.getLevel() + ' ' + c.getCharacterClass() + " with " + c.getHitPoints() + " hit points.";
    }

    public String describe(Destination d){
        return "You've arrived at " + d.getName() + ", which has " + d.getInhabitants() + " inhabitants.";
    }

    public String describe(TravelMethod tr){
        var connector = (tr == TravelMethod.WALKING)
            ? " by " : " on ";

        return "You're traveling to your destination" + connector + tr.toString().toLowerCase() + '.';
    }

    public String describe(Character c, Destination dest, TravelMethod tr){
        return describe(c) + ' ' + describe(tr) + ' ' + describe(dest);
    }

    public String describe(Character c, Destination dest){
        return describe(c) + ' ' + describe(TravelMethod.WALKING) + ' ' + describe(dest);
    }
}