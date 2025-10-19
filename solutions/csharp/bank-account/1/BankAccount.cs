public class BankAccount
{
    private decimal _balance;
    private bool isOpen = false;
    private readonly object balance_lock = new();
    public void Open()
        => isOpen = isOpen
            ? throw new InvalidOperationException("cannot open an account that was already open")
            : true;


    public void Close()
    {
        isOpen = !isOpen
            ? throw new InvalidOperationException("cannot close an account that was already closed")
            : false;

        lock (balance_lock)
            _balance = 0m;   
    }

    public decimal Balance
    {
        get
        {
            if (!isOpen)
                throw new InvalidOperationException("cannot check balance when account is closed");
            
            lock (balance_lock)
                return _balance;
        }
    }

    public void Deposit(decimal change)
    {
        if (!isOpen)
            throw new InvalidOperationException("cannot deposit money when account is closed");

        if (change <= 0)
            throw new InvalidOperationException("cannot deposit money of value 0 or negative");
        
        lock (balance_lock)
            _balance += change;
    }
    public void Withdraw(decimal change)
    {
        if (!isOpen)
            throw new InvalidOperationException("cannot withdraw money when account is closed");

        if (change > _balance || change <= 0)
            throw new InvalidOperationException("change must be higher than 0 and lower than current balance.");
            
        lock (balance_lock)
            _balance -= change;
    }
}
