using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _webPainelVerisys.DTO
{
    public class dtoResponse
    {
        public dtoResponse()
        { }

        private String _Result;
        public String Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private Int32 _ResultCode;
        public Int32 ResultCode
        {
            get { return _ResultCode; }
            set { _ResultCode = value; }
        }
    }
}
