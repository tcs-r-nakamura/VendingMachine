using VendingMachineApp.Abstract;
using VendingMachineApp.VendingMachines;
namespace VendingMachineApp
{

    /*セッターとゲッターをつかう
     * ポリモーフィズムを利用する
     * カプセル化する*/

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

            while (true)
            {
            }
        }
    }
}