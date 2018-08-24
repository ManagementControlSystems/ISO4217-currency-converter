using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MCS.ISOCurrencyService
{
    [XmlRoot(ElementName = "CcyNtry")]
    public class CcyNtry
    {
        [XmlElement(ElementName = "CtryNm")]
        public string CtryNm { get; set; }
        [XmlElement(ElementName = "Ccy")]
        public string Ccy { get; set; }
        [XmlElement(ElementName = "CcyNbr")]
        public string CcyNbr { get; set; }
        [XmlElement(ElementName = "CcyMnrUnts")]
        public string CcyMnrUnts { get; set; }
        [XmlElement(ElementName = "CcyNm")]
        public CcyNm CcyNm { get; set; }
    }

    [XmlRoot(ElementName = "CcyNm")]
    public class CcyNm
    {
        [XmlAttribute(AttributeName = "IsFund")]
        public string IsFund { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CcyTbl")]
    public class CcyTbl
    {
        [XmlElement(ElementName = "CcyNtry")]
        public List<CcyNtry> CcyNtry { get; set; }
    }

    [XmlRoot(ElementName = "ISO_4217")]
    public class ISO_4217
    {
        [XmlElement(ElementName = "CcyTbl")]
        public CcyTbl CcyTbl { get; set; }
        [XmlAttribute(AttributeName = "Pblshd")]
        public string Pblshd { get; set; }
    }
}
