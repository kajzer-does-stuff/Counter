using Counter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models;

internal class Counter
{
    public string FileName { get; set; }
    public int StartingValue { get; set; } = 0;
    public int CurrentValue { get; set; } = 0;
    public string Name { get; set; } = "Counter";
    public int CounterID { get; set; } = 0;    
}
