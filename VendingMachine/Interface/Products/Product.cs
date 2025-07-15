using VendingMachineApp.Interfaces;

namespace VendingMachineApp.Products
{

    class Product : IProduct
    {
        public string Name { get; private set; } //商品名
        public int Stock { get; private set; } //在庫数
        public int Price { get; private set; } //値段
        public string Unit { get; private set; } //単位

        //コンストラクタ
        public Product(string name, int stock, int price, string unit)
        {
            Name = name;
            Stock = stock;
            Price = price;
            Unit = unit;
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
}