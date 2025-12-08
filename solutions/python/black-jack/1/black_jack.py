value10: list[str] = ['J', 'Q', 'K', '10']

def value_of_card(card: str) -> int:
    if card in value10:
        return 10

    if card == 'A':
        return 1

    return int(card)

def higher_card(card_one: str, card_two: str) -> str | tuple:
    val_one: int = value_of_card(card_one)
    val_two: int = value_of_card(card_two)

    if val_one > val_two: 
        return card_one
    
    if val_one < val_two: 
        return card_two

    else: 
        return card_one, card_two

def value_of_ace(card_one: str, card_two: str) -> int:
    if card_one == 'A' or card_two == 'A':
        return 1
    
    if value_of_card(card_one) + value_of_card(card_two) + 11 > 21:
        return 1

    return 11

def is_blackjack(card_one: str, card_two: str) -> bool:
    has_ace: bool = card_one == 'A' or card_two == 'A'
    has_10: bool = card_one in value10 or card_two in value10

    return has_ace and has_10

def can_split_pairs(card_one: str, card_two: str) -> bool:
    return value_of_card(card_one) == value_of_card(card_two)

def can_double_down(card_one: str, card_two: str) -> bool:
    return 9 <= (value_of_card(card_one) + value_of_card(card_two)) <= 11