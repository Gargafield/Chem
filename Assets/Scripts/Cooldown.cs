using System;
using System.Threading.Tasks;

public class Cooldown
{
    public float Duration { get; set; }
    public bool IsReady = true;
    
    public Cooldown(float duration) {
        Duration = duration;
    }
    
    public bool LockIfReady() {
        if (IsReady) {
            IsReady = false;
            Task.Delay(TimeSpan.FromSeconds(Duration)).ContinueWith(t => IsReady = true);
            
            return true;
        }
        return false;
    }
}
