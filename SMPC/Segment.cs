using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPC {
    public class Segment {

        public SegmentType segmentType;

        private double leftV, rightV,
                        leftDelta, rightDelta;

        public Segment(SegmentType segmentType, double leftV, double rightV, double leftDelta, double rightDelta) {
            this.segmentType = segmentType;
            this.leftV = leftV;
            this.rightV = rightV;
            this.leftDelta = leftDelta;
            this.rightDelta = rightDelta;
        }

        public string getInstruction() { return leftV + "," + rightV + "." + leftDelta + "," + leftV; }

    }
}
