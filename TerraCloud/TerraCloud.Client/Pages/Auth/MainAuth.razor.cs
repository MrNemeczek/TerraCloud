using Microsoft.AspNetCore.Components;
using System;
using System.Reflection.Metadata.Ecma335;

namespace TerraCloud.Client.Pages.Auth
{
    public class MainAuthBase : ComponentBase
    {
        protected void OnChange(int index)
        {
            Console.WriteLine($"Tab with index {index} was selected.");
        }

        protected void OnClick(string text)
        {
            Console.WriteLine("test");
        }
    }
}
