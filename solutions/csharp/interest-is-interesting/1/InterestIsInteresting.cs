static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return
        (balance < 0) ? 3.213f :
        (balance < 1000) ? 0.5f :
        (balance >= 1000 && balance < 5000) ? 1.621f
        : 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        return balance * ((decimal)InterestRate(balance) / 100);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;

        while (balance < targetBalance)
        {
            years++;
            balance = AnnualBalanceUpdate(balance);
        }
        return years;
    }
}
