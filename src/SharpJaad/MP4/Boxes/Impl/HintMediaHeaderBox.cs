﻿namespace SharpJaad.MP4.Boxes.Impl
{
    /**
     * The hint media header contains general information, independent of the
     * protocol, for hint tracks.
     *
     * @author in-somnia
     */
    public class HintMediaHeaderBox : FullBox
    {
        private long _maxPDUsize, _avgPDUsize, _maxBitrate, _avgBitrate;

        public HintMediaHeaderBox() : base("Hint Media Header Box")
        { }

        public override void Decode(MP4InputStream input)
        {
            base.Decode(input);

            _maxPDUsize = input.ReadBytes(2);
            _avgPDUsize = input.ReadBytes(2);

            _maxBitrate = input.ReadBytes(4);
            _avgBitrate = input.ReadBytes(4);

            input.SkipBytes(4); //reserved
        }

        /**
         * The maximum PDU size gives the size in bytes of the largest PDU (protocol
         * data unit) in this hint stream.
         */
        public long GetMaxPDUsize()
        {
            return _maxPDUsize;
        }

        /**
         * The average PDU size gives the average size of a PDU over the entire
         * presentation.
         */
        public long GetAveragePDUsize()
        {
            return _avgPDUsize;
        }

        /**
         * The maximum bitrate gives the maximum rate in bits/second over any window
         * of one second.
         */
        public long GetMaxBitrate()
        {
            return _maxBitrate;
        }

        /**
         * The average bitrate gives the average rate in bits/second over the entire
         * presentation.
         */
        public long GetAverageBitrate()
        {
            return _avgBitrate;
        }
    }
}
