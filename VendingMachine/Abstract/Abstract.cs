using VendingMachineApp.Interfaces;

namespace VendingMachineApp.Abstract
{

    //抽象クラス・共通処理
    abstract class VendingMachineBase
    {   //商品のリスト生成
        protected List<IProduct> products = new List<IProduct>(); //リスト作成
        protected int insertedMoney = 0; //投入金額
        protected int totalSales = 0; //売上金

        //コンストラクタ
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
            //リストの情報をIProduct型のproductに入れる
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

            Console.WriteLine($"{product.Name}を購入しました。残り{product.Stock}{product.Unit}。残金: {insertedMoney}円");
            Console.WriteLine($"総売上高{totalSales}円");
        }
    }
}