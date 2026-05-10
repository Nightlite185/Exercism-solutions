import java.util.HashMap;
import java.util.Map;

public class DialingCodes {

    private Map<Integer, String> map = new HashMap<>();

    public Map<Integer, String> getCodes() {
        return map;
    }

    public void setDialingCode(Integer code, String country) {
        map.put(code, country);
    }

    public String getCountry(Integer code) {
        return map.get(code);
    }

    public void addNewDialingCode(Integer code, String country) {
        if (map.values().contains(country)) 
            return;

        map.putIfAbsent(code, country);
    }

    public Integer findDialingCode(String country) {
        for (var kvp : map.entrySet())
            if (kvp.getValue().equals(country))
                return kvp.getKey();

        return null;
    }

    public void updateCountryDialingCode(Integer code, String country) {
        for (var kvp : map.entrySet()) {

            if (kvp.getValue().equals(country)){
                map.remove(kvp.getKey());

                map.put(code, country);
                return;
            }
        }
    }
}
