import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

class AppointmentScheduler {

    private static final DateTimeFormatter APPOINTMENT_FORMATTER = 
        DateTimeFormatter.ofPattern("M/d/yyyy H:mm:ss");

    private static final DateTimeFormatter DESCRIPTION_FORMATTER = 
        DateTimeFormatter.ofPattern("EEEE, MMMM d, yyyy, 'at' h:mm a");

    public LocalDateTime schedule(String appointmentDateDescription) {
        return LocalDateTime.parse(appointmentDateDescription, APPOINTMENT_FORMATTER);
    }

    public boolean hasPassed(LocalDateTime appointmentDate) {
        return LocalDateTime.now().isAfter(appointmentDate);
    }

    public boolean isAfternoonAppointment(LocalDateTime appointmentDate) {
        int hour = appointmentDate.getHour();

        return hour >= 12 && hour < 18;
    }

    public String getDescription(LocalDateTime appointmentDate) {
        return "You have an appointment on " + DESCRIPTION_FORMATTER.format(appointmentDate) + '.';
    }

    public LocalDate getAnniversaryDate() {
        int year = LocalDate.now().getYear();

        return LocalDate.of(year, 9, 15);
    }
}
