import java.util.HashSet;
import java.util.List;
import java.util.Set;

class GottaSnatchEmAll {

    static Set<String> newCollection(List<String> cards) {
        return new HashSet<>(cards);
    }

    static boolean addCard(String card, Set<String> collection) {
        return collection.add(card);
    }

    static boolean canTrade(Set<String> myCollection, Set<String> theirCollection) {
        var myCopy = new HashSet<>(myCollection);
        var theirCopy = new HashSet<>(theirCollection);

        myCopy.removeAll(theirCollection);
        theirCopy.removeAll(myCollection);

        return !myCopy.isEmpty() && !theirCopy.isEmpty();
    }

    static Set<String> commonCards(List<Set<String>> collections) {
        var result = new HashSet<String>();

        if (collections.isEmpty()) 
            return result;

        result.addAll(collections.getFirst());
        collections.forEach(result::retainAll);

        return result;
    }

    static Set<String> allCards(List<Set<String>> collections) {
        var result = new HashSet<String>();
        collections.stream().forEach(result::addAll);

        return result;
    }
}