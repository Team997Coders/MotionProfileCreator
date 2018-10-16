using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPC {
    public class SegmentType {

        public static SegmentType Curve = new SegmentType(1),
                                    Straight = new SegmentType(0);

        public int type;

        public SegmentType(int type) {
            this.type = type;
        }

    }
}
