using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJF_Simulation
{
    internal class Process
    {
    }
    public class ProcessData
    {
        public string ProcessID { get; set; }
        public float BurstTime { get; set; }
        public float ArrivalTime { get; set; }
        public float RemainingTime { get; set; }
        public float WaitingTime {  get; set; }
        public float AverageWaitingTime {  get; set; }
        public float CompletionTime {  get; set; }
        public float AverageCompletedTime { get; set; }
        public float TurnAroundTime {  get; set; }
        public float AverageTurnAroundTime { get;set; } 
        
    }
}
