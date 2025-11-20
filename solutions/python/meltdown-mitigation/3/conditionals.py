def is_criticality_balanced(temp, neutrons_emitted):
    return(
        temp < 800
        and neutrons_emitted > 500
        and temp * neutrons_emitted < 500000
    )

def reactor_efficiency(voltage, current, theoretical_max_power):
    generated_power = voltage * current
    ef = (generated_power/theoretical_max_power) * 100
    
    if ef >= 80:
        return "green"
    
    elif 60 <= ef < 80:
        return "orange"
    
    elif 30 <= ef < 60:
        return "red"
    
    return "black"

def fail_safe(temp, neutrons_produced_per_second, threshold):
    x = temp * neutrons_produced_per_second
    perc = x / threshold * 100

    if perc < 90:
        return "LOW"
    
    elif perc > 110:
        return "DANGER"
    
    return "NORMAL"