def round_scores(student_scores: list[float]) -> list[int]:
    return [round(s) for s in student_scores]


def count_failed_students(student_scores: list[int]) -> int:
    return len([s for s in student_scores if s <= 40])


def above_threshold(student_scores: list[int], threshold: int) -> list[int]:
    return [s for s in student_scores if s >= threshold]


def letter_grades(highest: int) -> list[int]:
    lowest = 41
    delta = round((highest - lowest) / 4)

    return list(range(lowest, highest, delta))

def student_ranking(student_scores: list[int], student_names: list[str]) -> list[str]:
    result: list[str] = []

    for i, score in enumerate(student_scores):
        result.append(f"{1+i}. {student_names[i]}: {score}")

    return result


def perfect_score(student_info: list[list[str | int]]) -> list[str | int]:
    for s in student_info:
        if s[1] == 100:
            return s

    return []