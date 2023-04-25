﻿namespace SharpJaad.MP4.Boxes.Impl
{
    /**
 * The Copyright box contains a copyright declaration which applies to the
 * entire presentation, when contained within the Movie Box, or, when contained
 * in a track, to that entire track. There may be multiple copyright boxes using
 * different language codes.
 */
    public class CopyrightBox : FullBox
    {
        private string _languageCode, _notice;

        public CopyrightBox() : base("Copyright Box")
        { }

        public override void Decode(MP4InputStream input)
        {
            if (_parent.GetBoxType() == BoxTypes.USER_DATA_BOX)
            {
                base.Decode(input);
                //1 bit padding, 5*3 bits language code (ISO-639-2/T)
                _languageCode = Utils.GetLanguageCode(input.ReadBytes(2));

                _notice = input.ReadUTFString((int)GetLeft(input));
            }
            else if (_parent.GetBoxType() == BoxTypes.ITUNES_META_LIST_BOX) ReadChildren(input);
        }

        /**
         * The language code for the following text. See ISO 639-2/T for the set of
         * three character codes.
         */
        public string GetLanguageCode()
        {
            return _languageCode;
        }

        /**
         * The copyright notice.
         */
        public string GetNotice()
        {
            return _notice;
        }
    }
}
