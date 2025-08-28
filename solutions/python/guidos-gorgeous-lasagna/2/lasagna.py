EXPECTED_BAKE_TIME = 40
'''just an expected bake time const'''
PREPARATION_TIME = 2
'''preparation minutes per layer'''

def bake_time_remaining(elapsed_time):
    '''calculating bake time remaining'''

    return EXPECTED_BAKE_TIME - elapsed_time


def preparation_time_in_minutes(layers_num):
    '''calculating preparation time'''
    return layers_num * PREPARATION_TIME


def elapsed_time_in_minutes(layers_num, elapsed_bake_time):
    '''calculating elapsed time of baking + prep'''
    return preparation_time_in_minutes(layers_num) + elapsed_bake_time
