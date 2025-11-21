def add_prefix_un(word):
    return "un" + word


def make_word_groups(vocab_words:list[str]):
    prefix:str = vocab_words[0]

    return str.join(f" :: {prefix}", vocab_words)


def remove_suffix_ness(word:str):
    adj :str = word[:-4]

    if adj[-1] == 'i':
        adj = adj[:-1] + 'y'

    return adj

def adjective_to_verb(sentence:str, index:int):
    word : str = sentence.split()[index]

    word = word.removesuffix('.')

    return word + "en"