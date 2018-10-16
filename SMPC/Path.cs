using System;
using System.Collections.Generic;
using System.IO;

namespace SMPC {
    public class Path {

        private List<Segment> segments = new List<Segment>();

        private double maxV, accel;

        public Path(double maxV, double accel) {
            this.maxV = maxV;
            this.accel = accel;
        }

        public void AddStraight(double deltaPos) {

        }

        public void AddCurveXLock(double deltaTheta, double deltaX) {
            double deltaY = deltaX * Math.Cos(ToRadians(deltaTheta));
            double radius = deltaY / Math.Sin(ToRadians(deltaTheta));
        }

        public void AddCurveYLock(double deltaTheta, double deltaY) {

        }

        public double ToRadians(double theta) {
            return (Math.PI / 180) * theta;
        }

    }
}
