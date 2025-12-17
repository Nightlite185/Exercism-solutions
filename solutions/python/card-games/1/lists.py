def get_rounds(number: int) -> list[int]:
    return [number, number+1, number+2]

def concatenate_rounds(rounds_1: list[int], rounds_2: list[int]) -> list[int]:
    return rounds_1 + rounds_2


def list_contains_round(rounds: list[int], number: int) -> bool:
    return number in rounds


def card_average(hand: list[int]) -> float:
    return sum(hand) / len(hand)


def approx_average_is_average(hand: list[int]) -> bool:
    first: float = (hand[0] + hand[-1]) / 2
    second : float = hand[len(hand) // 2]
    
    avg: float = card_average(hand)

    return first == avg or second == avg


def average_even_is_average_odd(hand: list[int]) -> bool:
    even_i_cards: list[int] = hand[0::2]
    odd_i_cards: list[int] = hand[1::2]

    return (sum(even_i_cards) / len(even_i_cards)) == (sum(odd_i_cards) / len(odd_i_cards))

def maybe_double_last(hand: list[int]) -> list[int]:
    hand[-1] = 22 if hand[-1] == 11 else hand[-1]

    return hand