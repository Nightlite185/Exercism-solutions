import static java.lang.Character.isDigit;
import static java.lang.Character.isLetter;
import static java.lang.Character.toUpperCase;

class SqueakyClean {
    static String clean(String identifier) {
        if (identifier.isEmpty()) 
            return identifier;
        
        var sb = new StringBuilder();

        boolean nextToUpper = false;

        for (int i = 0; i < identifier.length(); i++) {
            Character ch = identifier.charAt(i);

            if (isLetter(ch)){
                if (nextToUpper){
                    sb.append(toUpperCase(ch));
                    nextToUpper = false;
                }

                else sb.append(ch);
            }

            else if (isDigit(ch)){
                switch (ch){
                    case '4' -> sb.append('a');
                    case '3' -> sb.append('e');
                    case '0' -> sb.append('o');
                    case '1' -> sb.append('l');
                    case '7' -> sb.append('t');
                }
            }

            else switch (ch) {
                case '-' -> nextToUpper = true;
                case ' ' -> sb.append('_');
            }
        }

        return sb.toString();
    }
}