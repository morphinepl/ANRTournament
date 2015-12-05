using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANRTournament.Objects
{
    public class LiguePoints
    {
        public Player Player { get; set; }

        public int PointsPlace { get; set; }
        public int PointsDraw { get; set; }
        public int PointsFactionCorpo { get; set; }
        public int PointsFactionRunner { get; set; }
        public int PointsLoose { get; set; }
        public int PointsParticipation { get; set; }
        public int PointsWin { get; set; }
        public int PointsWinBye { get; set; }
        public int PointsPlusMinus { get; set; }

        public int SumaricPoints
        {
            get { return PointsPlace + PointsDraw + PointsFactionCorpo + PointsFactionRunner + PointsLoose + PointsParticipation + PointsWin + PointsWinBye + PointsPlusMinus; }
        }
    }
}
