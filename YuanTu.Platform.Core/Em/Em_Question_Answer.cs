namespace YuanTu.Platform.Em
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YuanTu.Platform.Common;


    /// <summary>
    /// 题库答案
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 15:38:45
    /// </summary>
    public class Em_Question_Answer : CustomEntity<string>
    {

        private string _Caption;

        private int _Sort;

        private string _ImageAddress;

        private bool _IsAnswer;

        private string _Mid;

        /// <summary>
        /// 标题
        /// </summary>
        [Required()]
        [StringLength(128)]
        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        [Required()]
        public int Sort
        {
            get
            {
                return this._Sort;
            }
            set
            {
                this._Sort = value;
            }
        }

        /// <summary>
        /// 图文
        /// </summary>
        [StringLength(256)]
        public string ImageAddress
        {
            get
            {
                return this._ImageAddress;
            }
            set
            {
                this._ImageAddress = value;
            }
        }

        /// <summary>
        /// 是否答案
        /// </summary>
        [Required()]
        public bool IsAnswer
        {
            get
            {
                return this._IsAnswer;
            }
            set
            {
                this._IsAnswer = value;
            }
        }

        /// <summary>
        /// 题库Id
        /// </summary>
        [Required()]
        [StringLength(32)]
        public string Mid
        {
            get
            {
                return this._Mid;
            }
            set
            {
                this._Mid = value;
            }
        }
    }
}
