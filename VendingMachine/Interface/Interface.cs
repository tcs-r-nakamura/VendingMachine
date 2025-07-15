namespace VendingMachineApp.Interfaces
{

    interface IProduct
    {
        string Name { get; }
        int Stock { get; }
        int Price { get; }
        string Unit { get; }
        bool CanBuy();
        void DecreaseStock();

    }
}
