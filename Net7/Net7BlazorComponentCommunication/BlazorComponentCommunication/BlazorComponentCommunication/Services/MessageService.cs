using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentCommunication.Services
{
    public class MessageService
    {
        public event Action? SaidSomething;


        public string Message { get; set; } = "...";

        public void SaySomething(string message){
            Message = message;
            SaidSomething?.Invoke();
        }


    }
}