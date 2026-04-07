public class SalaryCalculator {
    public double salaryMultiplier(int daysSkipped) {
        return daysSkipped >= 5 ? 0.85 : 1;
    }

    public int bonusMultiplier(int productsSold) {
        return productsSold >= 20 ? 13 : 10;
    }

    public double bonusForProductsSold(int productsSold) {
        return productsSold * bonusMultiplier(productsSold);
    }

    public double finalSalary(int daysSkipped, int productsSold) {
        int baseSalary = 1000;
        int cap = 2000;

        double result = baseSalary 
            * salaryMultiplier(daysSkipped) 
            + bonusForProductsSold(productsSold);

        return Math.min(cap, result);
    } 
}