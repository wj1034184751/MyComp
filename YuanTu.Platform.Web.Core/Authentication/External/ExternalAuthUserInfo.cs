namespace YuanTu.Platform.Authentication.External
{
    public class ExternalAuthUserInfo
    {
        public string ProviderKey { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Surname { get; set; }

        public string Provider { get; set; }

        public long OrgId { get; set; }

        public string OrgIds { get; set; }
    }
}
