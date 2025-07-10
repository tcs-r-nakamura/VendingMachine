using System;

class VendingMachine
{
    private int stock; //飲み物の在庫

    public VendingMachine(int stock)
    {
        this.stock = stock;
    }

    public void Buy()
    {
        if (stock == 0)
        {
            Console.WriteLine("売り切れ");
        }
        else if (stock >= 1)
        {
            stock--;
            Console.WriteLine("残り" + stock + "本");
        }
    }
}
class Program
{
    static void Main()
    {
        VendingMachine VM = new VendingMachine(2);
        VM.Buy();
    }
}