using System;

public static class GlobalCountDown {

    static DateTime TimeStarted;
    static TimeSpan TotalTime;

    public static void StartCountDown(TimeSpan totalTime) {
        TimeStarted = DateTime.UtcNow;
        TotalTime = totalTime;
    }

    public static void StartCountUp() {
        TimeStarted = DateTime.UtcNow;
    }

    public static TimeSpan GetTime {
        get {
            TimeSpan result = TotalTime + (DateTime.UtcNow - TimeStarted);
            if (result.TotalSeconds <= 0)
                return TimeSpan.Zero;
            return result;
        }
    }

    public static TimeSpan TimeLeft {
        get {
            TimeSpan result = TotalTime - (DateTime.UtcNow - TimeStarted);
            if (result.TotalSeconds <= 0)
                return TimeSpan.Zero;
            return result;
        }
    }

    public static void Reset() {
        TotalTime = TimeSpan.Zero;
    }

}