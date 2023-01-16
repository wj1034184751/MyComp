namespace YuanTu.Platform.Session
{
    /// <summary>
    ///  扩展 AbpSession
    /// </summary> 
    public class NullAbpSessionEx 
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullAbpSessionEx Instance { get; } = new NullAbpSessionEx();
         
        public virtual long? OrgId { get; set; }

        public virtual string OrgIds { get; set; }
          
        private NullAbpSessionEx()
        { 
        }
    }
}