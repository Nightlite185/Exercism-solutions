class Badge {
    public String print(Integer id, String name, String department) {
        
        String id_final = id != null
            ? '[' + id.toString() + ']' + " - "
            : "";
        
        if (department == null)
            department = "OWNER";

        return id_final + name + " - " + department.toUpperCase();
    }
}
