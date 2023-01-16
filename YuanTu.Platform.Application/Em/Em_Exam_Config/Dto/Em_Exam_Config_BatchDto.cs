using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Em
{
    public class Em_Exam_Config_BatchDto
    {
        public Em_Exam_Config Main { get; set; }

        public List<Em_Exam_Outline_Config> Details { get; set; }

        public List<Em_Exam_Outline_Question_Config> Seconds { get; set; }
    }
}
