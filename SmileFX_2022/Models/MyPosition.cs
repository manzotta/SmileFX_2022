using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{
    // Leginkább a Trade-hez áll közel...
    public class MyPosition
    {

        private Instrument underlyingInstrument;
        public Instrument UnderlyingInstrument { get => underlyingInstrument; set => underlyingInstrument = value; }

        private PositionType positionType;
        public PositionType PositionType { get => positionType; set => positionType = value; }

        private double strikePrice;
        public double StrikePrice { get => strikePrice; set => strikePrice = value; }

        private double lotSize;
        public double LotSize { get => lotSize; set => lotSize = value; }

        private bool isOpen;
        public bool IsOpen { get => isOpen; set => isOpen = value; }

        private double currentValue;
        public double CurrentValue { get => currentValue; set => currentValue = value; }

        private double finalValue;
        public double FinalValue { get => finalValue; set => finalValue = value; }


        // private String details;


        public MyPosition(Instrument underlyingInstrument, PositionType positionType, double lotSize)
        {
            this.UnderlyingInstrument = underlyingInstrument;
            this.PositionType = positionType;
            this.LotSize = lotSize;
            this.IsOpen = true;
            this.CurrentValue = 0.0;

        }



        /*
        public void updatePosValue()
        {
        if (this.type == PosType.BUY)
            currentValue = (underlyingInst.price!! - openPrice!!) * 100000 * lotSize;
        else if (this.type == PosType.SELL)
            currentValue = (openPrice!! - underlyingInst.price!!) * 100000 * lotSize;
        }


        fun updatePosValueV2(instrument: Instrument) {
        if (this.type == PosType.BUY)
            currentValue = (instrument.price - openPrice) * 100000 * lotSize;
        else if (this.type == PosType.SELL)
            currentValue = (openPrice - instrument.price) * 100000 * lotSize;
        }
        */

    }

    public enum PositionType
    {
        LONG,
        SHORT
    }

}
