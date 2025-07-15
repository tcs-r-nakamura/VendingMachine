using VendingMachineApp.Abstract;
using VendingMachineApp.Products;

namespace VendingMachineApp.VendingMachines
{
    class SnackVendingMachine : VendingMachineBase
    {
        protected override void KProducts()
        { //商品名・在庫・値段をリストに加える
            products.Add(new Product("アルフォート", 4, 120, "個"));
            products.Add(new Product("雪の宿", 6, 130, "個"));
            products.Add(new Product("ムーンライト", 8, 250, "個"));
        }
    }
}