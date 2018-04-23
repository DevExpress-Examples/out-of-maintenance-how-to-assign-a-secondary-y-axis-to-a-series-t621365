using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondaryAxesSample.Model {
    public class CurrencyInfo {
        public CurrencyInfo(DateTime date, double value) {
            this.Date = date;
            this.Value = value;
            this.ChangeRate = 0;
        }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double ChangeRate { get; set; }

        public void UpdateChangeRate(CurrencyInfo prevInfo) {
            ChangeRate = 100 * ((this.Value / prevInfo.Value) - 1);
        }
    }

    public class ChartModel {
        public IReadOnlyList<CurrencyInfo> CurrencyInfos { get; private set; }
        public ChartModel () {
            CurrencyInfos = new List<CurrencyInfo>() {
                new CurrencyInfo(new DateTime(2018, 3, 29), 0.812219),
                new CurrencyInfo(new DateTime(2018, 3, 28), 0.808507),
                new CurrencyInfo(new DateTime(2018, 3, 27), 0.805010),
                new CurrencyInfo(new DateTime(2018, 3, 26), 0.805637),
                new CurrencyInfo(new DateTime(2018, 3, 25), 0.809225),
                new CurrencyInfo(new DateTime(2018, 3, 24), 0.809264),
                new CurrencyInfo(new DateTime(2018, 3, 23), 0.810088),
                new CurrencyInfo(new DateTime(2018, 3, 22), 0.810826),
                new CurrencyInfo(new DateTime(2018, 3, 21), 0.813835),
                new CurrencyInfo(new DateTime(2018, 3, 20), 0.813088),
                new CurrencyInfo(new DateTime(2018, 3, 19), 0.812814),
                new CurrencyInfo(new DateTime(2018, 3, 18), 0.813568),
                new CurrencyInfo(new DateTime(2018, 3, 17), 0.813531),
                new CurrencyInfo(new DateTime(2018, 3, 16), 0.812850),
                new CurrencyInfo(new DateTime(2018, 3, 15), 0.809969),
                new CurrencyInfo(new DateTime(2018, 3, 14), 0.807702),
                new CurrencyInfo(new DateTime(2018, 3, 13), 0.809091),
                new CurrencyInfo(new DateTime(2018, 3, 12), 0.811534),
                new CurrencyInfo(new DateTime(2018, 3, 11), 0.812401),
                new CurrencyInfo(new DateTime(2018, 3, 10), 0.812427),
                new CurrencyInfo(new DateTime(2018, 3, 9), 0.812363),
                new CurrencyInfo(new DateTime(2018, 3, 8), 0.808501),
                new CurrencyInfo(new DateTime(2018, 3, 7), 0.805534),
                new CurrencyInfo(new DateTime(2018, 3, 6), 0.807911),
                new CurrencyInfo(new DateTime(2018, 3, 5), 0.811605),
                new CurrencyInfo(new DateTime(2018, 3, 4), 0.811525),
                new CurrencyInfo(new DateTime(2018, 3, 3), 0.811609),
                new CurrencyInfo(new DateTime(2018, 3, 2), 0.813141),
                new CurrencyInfo(new DateTime(2018, 3, 1), 0.819303),
            };

            for (int i = 0; i < CurrencyInfos.Count - 1; ++i) {
                CurrencyInfos[i].UpdateChangeRate(CurrencyInfos[i + 1]);
            }

            var lastCurrency = new CurrencyInfo(new DateTime(2018, 2, 28), 0.818623);
            CurrencyInfos.Last().UpdateChangeRate(lastCurrency);
        }
    }
}
