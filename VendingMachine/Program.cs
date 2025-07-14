using System;
using System.Collections.Generic;
/*セッターとゲッターをつかう
 * ポリモーフィズムを利用する
 * カプセル化する*/
interface IProduct
{
    string Name { get; }
    int Stock { get; }
    int Price { get; }
    string unit { get; }
    bool CanBuy();
    void DecreaseStock();

}
class Product : IProduct
{
    public string Name { get; private set; } //商品名
    public int Stock { get; private set; } //在庫数
    public int Price { get; private set; } //値段
    public string unit { get; private set; } //単位

    //コンストラクタ
    public Product(string name, int stock, int price, string unit)
    {
        Name = name;
        Stock = stock;
        Price = price;
        this.unit = unit;
    }
    //購入可能か判断するメソッド
    public bool CanBuy()
    {   //1以上ならtrue、0以下ならfalseを返す
        return Stock > 0;
    }
    //在庫を一つ減らす
    public void DecreaseStock()
    {
        Stock--;
    }

}
//抽象クラス・共通処理
abstract class VendingMachineBase
{   //商品のリスト生成
    protected List<IProduct> products = new List<IProduct>(); //リスト作成
    protected int insertedMoney = 0; //投入金額
    protected int totalSales = 0; //売上金


    public VendingMachineBase()
    {
        KProducts();
    }
    protected abstract void KProducts();
    public void InsertMoney(int money)
    {   //引数を足していく
        insertedMoney += money;
        Console.WriteLine($"{money}円を投入しました。現在の投入額: {insertedMoney}円");

    }//購入メソッド
    public void Buy(int index)
    {//負数入力または、範囲外の場合
        if (index < 0 || index >= products.Count)
        {
            Console.WriteLine("指定された商品は存在しません。");
            return;
        }
        //リストの情報をProduct型のproductに入れる
        IProduct product = products[index];
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
        //投入金額メソッド
        //在庫を減らすメソッドを呼び出す
        product.DecreaseStock();
        //投入金額-価格
        insertedMoney -= product.Price;
        //売上
        totalSales += product.Price;

        Console.WriteLine($"{product.Name}を購入しました。残り{product.Stock}{product.unit}。残金: {insertedMoney}円");
        Console.WriteLine($"総売上高{totalSales}円");
    }
}

class DrinkVendingMachine : VendingMachineBase
{
    protected override void KProducts()
    {  //商品名・在庫・値段をリストに加える
        products.Add(new Product("ファンタ", 10, 160,"本"));
        products.Add(new Product("グレープ", 10, 170, "本"));
        products.Add(new Product("コーラ", 10, 180, "本"));
    }
}
class SnackVendingMachine : VendingMachineBase
{
    protected override void KProducts()
    { //商品名・在庫・値段をリストに加える
        products.Add(new Product("アルフォート", 4, 120, "個"));
        products.Add(new Product("雪の宿", 6, 130, "個"));
        products.Add(new Product("ムーンライト", 8, 250, "個"));
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("飲料用自動販売機");
        VendingMachineBase DVM = new DrinkVendingMachine();
        DVM.InsertMoney(500);
        DVM.Buy(0);
        DVM.Buy(1);
        DVM.Buy(2);

        Console.WriteLine("軽食用自動販売機");
        VendingMachineBase SVM = new SnackVendingMachine();
        SVM.InsertMoney(500);
        SVM.Buy(0);
        SVM.Buy(1);
        SVM.Buy(2);
    }
}

