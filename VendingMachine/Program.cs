using System;
using System.Collections.Generic;
/*セッターとゲッターをつかう
 * ポリモーフィズムを利用する
 * カプセル化する*/
class Product
{
    public string Name { get; private set; } //商品名
    public int Stock { get; private set; } //在庫数
    public int Price { get; private set; } //値段


    public Product(string name, int stock, int price)
    {
        Name = name;
        Stock = stock;
        Price = price;
    }
    public void Buy()
    {
        if (Stock >= 1)
        {
            Stock--;
            Console.WriteLine($"残り{Stock}本");
        }
        else
        {
            Console.WriteLine("売切れ");
        }
    }
}
    class VendingMachine
    {
        private List<Product> products = new List<Product>();
        private int insertedMoney = 0;
        private int totalMoney = 0;


        public VendingMachine()
        {
            products.Add(new Product("ファンタ",10,160));
            products.Add(new Product("グレープ", 10, 170));
            products.Add(new Product("コーラ", 10, 180));
        }
        public void InsertMoney(int money)
        {
            insertedMoney += money;
            Console.WriteLine($"{money}円を投入しました。現在の投入額: {insertedMoney}円");

        }

    }


class Program
{
    static void Main()
    {

        VendingMachine VM = new VendingMachine();
        VM.InsertMoney(500);
        VM.Buy();
    }
}
