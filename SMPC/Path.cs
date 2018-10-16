using System;
using System.Collections.Generic;
using System.IO;

namespace SMPC {
    public class Path {

        private List<Segment> segments = new List<Segment>();

        private double maxV, accel, width, height;

        public Path(double maxV, double accel, double width, double height) {
            this.maxV = maxV;
            this.accel = accel;
            this.width = width;
            this.height = height;
        }

        public void AddStraight(double deltaPos) {
            Segment seg = new Segment(SegmentType.Straight, maxV, maxV, deltaPos, deltaPos);
            segments.Add(seg);
        }

        public void AddCurveXLock(double deltaTheta, double deltaX) {
            double deltaY = deltaX * Math.Cos(ToRadians(Math.Abs(deltaTheta)));
            double radius = deltaY / Math.Sin(ToRadians(Math.Abs(deltaTheta)));

            double leftV, rightV, leftDist, rightDist;
            if (deltaTheta > 0) {
                leftV = maxV;
                rightDist = ArcLength(radius - (width / 2), deltaTheta);
                leftDist = ArcLength(radius + (width / 2), deltaTheta);
                rightV = (rightDist / leftDist) * maxV;
            } else {
                rightV = maxV;
                leftDist = ArcLength(radius - (width / 2), deltaTheta);
                rightDist = ArcLength(radius + (width / 2), deltaTheta);
                leftV = (leftDist / rightDist) * maxV;
            }

            Segment seg = new Segment(SegmentType.Curve, leftV, rightV, leftDist, rightDist);
            segments.Add(seg);
        }

        public void AddCurveYLock(double deltaTheta, double deltaY) {
            double deltaX = deltaY / Math.Cos(ToRadians(Math.Abs(deltaTheta)));
            double radius = deltaY / Math.Sin(ToRadians(Math.Abs(deltaTheta)));

            double leftV, rightV, leftDist, rightDist;
            if (deltaTheta > 0) {
                leftV = maxV;
                rightDist = ArcLength(radius - (width / 2), deltaTheta);
                leftDist = ArcLength(radius + (width / 2), deltaTheta);
                rightV = (rightDist / leftDist) * maxV;
            } else {
                rightV = maxV;
                leftDist = ArcLength(radius - (width / 2), deltaTheta);
                rightDist = ArcLength(radius + (width / 2), deltaTheta);
                leftV = (leftDist / rightDist) * maxV;
            }

            Segment seg = new Segment(SegmentType.Curve, leftV, rightV, leftDist, rightDist);
            segments.Add(seg);
        }

        public string[] PathReadout() {
            //Compile together the instructions from segments with the acceleration. give them beginning and ending velocities and end distances.

            return null;
        }

        public double ToRadians(double theta) { return (Math.PI / 180) * theta; }

        public double ArcLength(double radius, double theta) { return (theta / 360) * (Math.Pow(radius, 2) * Math.PI); }

    }
}
