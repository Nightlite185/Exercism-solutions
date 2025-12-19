def get_coordinate(record: tuple[str, str]) -> str:
    return record[1]


def convert_coordinate(coord: str):
    return tuple(coord)


def compare_records(azara_record, rui_record):
    return tuple(azara_record[1]) == rui_record[1]


def create_record(azara_record, rui_record):
    if compare_records(azara_record, rui_record):
        return azara_record + rui_record

    return "not a match"


def clean_up(combined_record_group: tuple[tuple]):
    results: list[str] = []

    for record in combined_record_group:
        results.append(str((record[0],) + record[2:]))

    return "\n".join(results) + '\n'