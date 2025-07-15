using VendingMachineApp.Abstract;
using VendingMachineApp.Products;

namespace VendingMachineApp.VendingMachines
{
    class DrinkVendingMachine : VendingMachineBase
    {
        protected override void KProducts()
        {  //商品名・在庫・値段をリストに加える
            products.Add(new Product("ファンタ", 10, 160, "本"));
            products.Add(new Product("グレープ", 10, 170, "本"));
            products.Add(new Product("コーラ", 10, 180, "本"));
        }
    }
}