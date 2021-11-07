using System;

namespace OctoType.Timing {

    public static class TimingChecker {

        public static Timings checkTiming(float actionTime, float targetTime) {
            float diff = Math.Abs(actionTime - targetTime);
            if(diff <= (float) Timings.MARVELOUS) {
                return Timings.MARVELOUS;
            } else if(diff <= (float) Timings.PERFECT) {
                return Timings.PERFECT;
            } else if(diff <= (float) Timings.GREAT) {
                return Timings.GREAT;
            } else if(diff <= (float) Timings.GOOD) {
                return Timings.GOOD;
            } else if(diff <= (float) Timings.BAD) {
                return Timings.BAD;
            } else {
                return Timings.MISS;
            }
        }
    }
}
