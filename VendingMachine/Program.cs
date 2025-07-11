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

    //コンストラクタ
    public Product(string name, int stock, int price)
    {
        Name = name;
        Stock = stock;
        Price = price;
    }
    //購入可能か判断するメソッド
    public bool CanBuy()
    {   //1以上ならture、0以下ならfalseを返す
        return Stock > 0;
    }
    //在庫を一つ減らす
    public void DecreaseStock()
    {
        Stock--;
    }

}
class VendingMachine
{   //商品のリスト生成
    private List<Product> products = new List<Product>(); //リスト作成
    private int insertedMoney = 0;　//投入金額
    private int totalSales = 0;　//売上金


    public VendingMachine()
    {   //商品名・在庫・値段をリストに加える
        products.Add(new Product("ファンタ", 10, 160));
        products.Add(new Product("グレープ", 10, 170));
        products.Add(new Product("コーラ", 10, 180));
    }
    //投入金額メソッド
    public void InsertMoney(int money)
    {   //引数を足していく
        insertedMoney += money;　
        Console.WriteLine($"{money}円を投入しました。現在の投入額: {insertedMoney}円");

    }//購入メソッド
    public void Buy(int index)
    {　　//負数入力または、範囲外の場合
        if (index < 0 || index >= products.Count)
        {
            Console.WriteLine("指定された商品は存在しません。");
            return;
        }
        //リストの情報をProduct型のproductに入れる
        Product product = products[index];
        //在庫がない場合(falesが返ってきた場合！でtureになる)
        if (!product.CanBuy())
        {
            Console.WriteLine($"{product.Name}は売り切れです。");
            return;
        }
        //投入金額より商品の値段が高かった場合
        if (insertedMoney < product.Price)
        {
            Console.WriteLine($"{product.Name}は{product.Price}円ですが、投入額が足りません。");
            return;
        }
        //在庫を減らすメソッドを呼び出す
        product.DecreaseStock();
        //投入金額-価格
        insertedMoney -= product.Price;
        //売上
        totalSales += product.Price;

        Console.WriteLine($"{product.Name}を購入しました。残り{product.Stock}本。残金: {insertedMoney}円");
    }
}


class Program
{
    static void Main()
    {

        VendingMachine VM = new VendingMachine();
        VM.InsertMoney(500);
        VM.Buy(0);
        VM.Buy(1);
        VM.Buy(2);
    }
}

