def create_inventory(items: list) -> dict[str, int]:
    inv: dict = {}

    for item in items:
        inv[item] = inv.get(item, 0) + 1

    return inv


def add_items(inv, items):
    for item in items:
        inv[item] = inv.get(item, 0) + 1

    return inv

def decrement_items(inv, items):
    for item in items:
        if inv.get(item, 0) > 0:
            inv[item] -= 1

    return inv


def remove_item(inv: dict, item):
    inv.pop(item, None)
    return inv


def list_inventory(inv: dict):
    return [(k, v) for k, v in inv.items() if v > 0]