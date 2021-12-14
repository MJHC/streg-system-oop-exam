using StregSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.CLI
{
    public delegate void StregSystemEvent(string command);
    public interface IStregSystemUI
    {
        //void DisplayUserNotFound(string username); 
        //void DisplayProductNotFound(string product); 
        void DisplayProducts();
        void GetUserCommand();
        void DisplayUserInfo(User user); 
        void DisplayUserBuysProduct(BuyTransaction transaction); 
        void DisplayUserBuysProduct(int count, BuyTransaction transaction); 
        void DisplayInsufficientCash(User user, Product product); 
        void DisplayGeneralError(string errorString);
        void DisplayGeneralSuccess(string Success);
        void Start();
        void Close(); 
        event StregSystemEvent CommandEntered;
    }
}
