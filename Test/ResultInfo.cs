using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ResultInfo
    {
        private int arrayIndex;
        private string decisionText;
        private bool isBuyingDecision;
        private double lastPrice;
        private DateTime recordDate;

        public int getArrayIndex() { return this.arrayIndex; }
        public void setArrayIndex(int _arrayIndex) { this.arrayIndex = _arrayIndex; }
        public string getDecisionText() { return this.decisionText; }
        public void setDecisionText(string _decisionText) { this.decisionText = _decisionText; }
        public bool getBuyingDecision() { return this.isBuyingDecision; }
        public void setBuyingDecision(bool _isBuyingDecision) { this.isBuyingDecision = _isBuyingDecision; }
        public double getLastPrice() { return this.lastPrice; }
        public void setLastPrice(double _lastPrice) { this.lastPrice = _lastPrice; }
        public DateTime getRecordDate() { return this.recordDate; }
        public void setRecordDate(DateTime _recordDate) { this.recordDate = _recordDate; }
    }
}
