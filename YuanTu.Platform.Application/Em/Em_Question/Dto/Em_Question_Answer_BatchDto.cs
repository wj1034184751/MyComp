using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Em
{
    public class Em_Question_Answer_BatchDto
    {
        public Em_Question Main { get; set; }

        public List<Em_Question_Answer> Details { get; set; }
    }
}
