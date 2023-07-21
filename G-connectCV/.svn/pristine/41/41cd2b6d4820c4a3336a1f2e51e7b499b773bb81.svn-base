using AutoMapper;
using System;
using System.Net;
using System.Linq;
using App.Business.Base;
using App.Business.Utils;
using App.Business.Services.QTHT;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace App.Business.Services.QTHT2
{
    public class ClientsService : GenericServiceInt<Clients>, ClientsIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ClientsService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ClientsProfile>();
                //cfg.CreateMap<IDataRecord, ClientsDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<Clients> QueryBuilder(IQueryable<Clients> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Id = filter.Id + "";
                if (!string.IsNullOrEmpty(Id))
                {
                    var int_Id = int.Parse(Id);
                    query = query.Where(x => x.id == int_Id);
                }
                string Enabled = filter.Enabled + "";
                if (!string.IsNullOrEmpty(Enabled))
                {
                    var bool_Enabled = bool.Parse(Enabled);
                    query = query.Where(x => x.Enabled == bool_Enabled);
                }
                string ClientId = filter.ClientId + "";
                if (!string.IsNullOrEmpty(ClientId))
                {
                    ClientId = ClientId.ToLower().Trim();
                    query = query.Where(x => x.ClientId.ToLower().Contains(ClientId));
                }
                string ProtocolType = filter.ProtocolType + "";
                if (!string.IsNullOrEmpty(ProtocolType))
                {
                    ProtocolType = ProtocolType.ToLower().Trim();
                    query = query.Where(x => x.ProtocolType.ToLower().Contains(ProtocolType));
                }
                string RequireClientSecret = filter.RequireClientSecret + "";
                if (!string.IsNullOrEmpty(RequireClientSecret))
                {
                    var bool_RequireClientSecret = bool.Parse(RequireClientSecret);
                    query = query.Where(x => x.RequireClientSecret == bool_RequireClientSecret);
                }
                string ClientName = filter.ClientName + "";
                if (!string.IsNullOrEmpty(ClientName))
                {
                    ClientName = ClientName.ToLower().Trim();
                    query = query.Where(x => x.ClientName.ToLower().Contains(ClientName));
                }
                string Description = filter.Description + "";
                if (!string.IsNullOrEmpty(Description))
                {
                    Description = Description.ToLower().Trim();
                    query = query.Where(x => x.Description.ToLower().Contains(Description));
                }
                string ClientUri = filter.ClientUri + "";
                if (!string.IsNullOrEmpty(ClientUri))
                {
                    ClientUri = ClientUri.ToLower().Trim();
                    query = query.Where(x => x.ClientUri.ToLower().Contains(ClientUri));
                }
                string LogoUri = filter.LogoUri + "";
                if (!string.IsNullOrEmpty(LogoUri))
                {
                    LogoUri = LogoUri.ToLower().Trim();
                    query = query.Where(x => x.LogoUri.ToLower().Contains(LogoUri));
                }
                string RequireConsent = filter.RequireConsent + "";
                if (!string.IsNullOrEmpty(RequireConsent))
                {
                    var bool_RequireConsent = bool.Parse(RequireConsent);
                    query = query.Where(x => x.RequireConsent == bool_RequireConsent);
                }
                string AllowRememberConsent = filter.AllowRememberConsent + "";
                if (!string.IsNullOrEmpty(AllowRememberConsent))
                {
                    var bool_AllowRememberConsent = bool.Parse(AllowRememberConsent);
                    query = query.Where(x => x.AllowRememberConsent == bool_AllowRememberConsent);
                }
                string AlwaysIncludeUserClaimsInIdToken = filter.AlwaysIncludeUserClaimsInIdToken + "";
                if (!string.IsNullOrEmpty(AlwaysIncludeUserClaimsInIdToken))
                {
                    var bool_AlwaysIncludeUserClaimsInIdToken = bool.Parse(AlwaysIncludeUserClaimsInIdToken);
                    query = query.Where(x => x.AlwaysIncludeUserClaimsInIdToken == bool_AlwaysIncludeUserClaimsInIdToken);
                }
                string RequirePkce = filter.RequirePkce + "";
                if (!string.IsNullOrEmpty(RequirePkce))
                {
                    var bool_RequirePkce = bool.Parse(RequirePkce);
                    query = query.Where(x => x.RequirePkce == bool_RequirePkce);
                }
                string AllowPlainTextPkce = filter.AllowPlainTextPkce + "";
                if (!string.IsNullOrEmpty(AllowPlainTextPkce))
                {
                    var bool_AllowPlainTextPkce = bool.Parse(AllowPlainTextPkce);
                    query = query.Where(x => x.AllowPlainTextPkce == bool_AllowPlainTextPkce);
                }
                string RequireRequestObject = filter.RequireRequestObject + "";
                if (!string.IsNullOrEmpty(RequireRequestObject))
                {
                    var bool_RequireRequestObject = bool.Parse(RequireRequestObject);
                    query = query.Where(x => x.RequireRequestObject == bool_RequireRequestObject);
                }
                string AllowAccessTokensViaBrowser = filter.AllowAccessTokensViaBrowser + "";
                if (!string.IsNullOrEmpty(AllowAccessTokensViaBrowser))
                {
                    var bool_AllowAccessTokensViaBrowser = bool.Parse(AllowAccessTokensViaBrowser);
                    query = query.Where(x => x.AllowAccessTokensViaBrowser == bool_AllowAccessTokensViaBrowser);
                }
                string FrontChannelLogoutUri = filter.FrontChannelLogoutUri + "";
                if (!string.IsNullOrEmpty(FrontChannelLogoutUri))
                {
                    FrontChannelLogoutUri = FrontChannelLogoutUri.ToLower().Trim();
                    query = query.Where(x => x.FrontChannelLogoutUri.ToLower().Contains(FrontChannelLogoutUri));
                }
                string FrontChannelLogoutSessionRequired = filter.FrontChannelLogoutSessionRequired + "";
                if (!string.IsNullOrEmpty(FrontChannelLogoutSessionRequired))
                {
                    var bool_FrontChannelLogoutSessionRequired = bool.Parse(FrontChannelLogoutSessionRequired);
                    query = query.Where(x => x.FrontChannelLogoutSessionRequired == bool_FrontChannelLogoutSessionRequired);
                }
                string BackChannelLogoutUri = filter.BackChannelLogoutUri + "";
                if (!string.IsNullOrEmpty(BackChannelLogoutUri))
                {
                    BackChannelLogoutUri = BackChannelLogoutUri.ToLower().Trim();
                    query = query.Where(x => x.BackChannelLogoutUri.ToLower().Contains(BackChannelLogoutUri));
                }
                string BackChannelLogoutSessionRequired = filter.BackChannelLogoutSessionRequired + "";
                if (!string.IsNullOrEmpty(BackChannelLogoutSessionRequired))
                {
                    var bool_BackChannelLogoutSessionRequired = bool.Parse(BackChannelLogoutSessionRequired);
                    query = query.Where(x => x.BackChannelLogoutSessionRequired == bool_BackChannelLogoutSessionRequired);
                }
                string AllowOfflineAccess = filter.AllowOfflineAccess + "";
                if (!string.IsNullOrEmpty(AllowOfflineAccess))
                {
                    var bool_AllowOfflineAccess = bool.Parse(AllowOfflineAccess);
                    query = query.Where(x => x.AllowOfflineAccess == bool_AllowOfflineAccess);
                }
                string IdentityTokenLifetime = filter.IdentityTokenLifetime + "";
                if (!string.IsNullOrEmpty(IdentityTokenLifetime))
                {
                    var int_IdentityTokenLifetime = int.Parse(IdentityTokenLifetime);
                    query = query.Where(x => x.IdentityTokenLifetime == int_IdentityTokenLifetime);
                }
                string AllowedIdentityTokenSigningAlgorithms = filter.AllowedIdentityTokenSigningAlgorithms + "";
                if (!string.IsNullOrEmpty(AllowedIdentityTokenSigningAlgorithms))
                {
                    AllowedIdentityTokenSigningAlgorithms = AllowedIdentityTokenSigningAlgorithms.ToLower().Trim();
                    query = query.Where(x => x.AllowedIdentityTokenSigningAlgorithms.ToLower().Contains(AllowedIdentityTokenSigningAlgorithms));
                }
                string AccessTokenLifetime = filter.AccessTokenLifetime + "";
                if (!string.IsNullOrEmpty(AccessTokenLifetime))
                {
                    var int_AccessTokenLifetime = int.Parse(AccessTokenLifetime);
                    query = query.Where(x => x.AccessTokenLifetime == int_AccessTokenLifetime);
                }
                string AuthorizationCodeLifetime = filter.AuthorizationCodeLifetime + "";
                if (!string.IsNullOrEmpty(AuthorizationCodeLifetime))
                {
                    var int_AuthorizationCodeLifetime = int.Parse(AuthorizationCodeLifetime);
                    query = query.Where(x => x.AuthorizationCodeLifetime == int_AuthorizationCodeLifetime);
                }
                string ConsentLifetime = filter.ConsentLifetime + "";
                if (!string.IsNullOrEmpty(ConsentLifetime))
                {
                    var int_ConsentLifetime = int.Parse(ConsentLifetime);
                    query = query.Where(x => x.ConsentLifetime == int_ConsentLifetime);
                }
                string AbsoluteRefreshTokenLifetime = filter.AbsoluteRefreshTokenLifetime + "";
                if (!string.IsNullOrEmpty(AbsoluteRefreshTokenLifetime))
                {
                    var int_AbsoluteRefreshTokenLifetime = int.Parse(AbsoluteRefreshTokenLifetime);
                    query = query.Where(x => x.AbsoluteRefreshTokenLifetime == int_AbsoluteRefreshTokenLifetime);
                }
                string SlidingRefreshTokenLifetime = filter.SlidingRefreshTokenLifetime + "";
                if (!string.IsNullOrEmpty(SlidingRefreshTokenLifetime))
                {
                    var int_SlidingRefreshTokenLifetime = int.Parse(SlidingRefreshTokenLifetime);
                    query = query.Where(x => x.SlidingRefreshTokenLifetime == int_SlidingRefreshTokenLifetime);
                }
                string RefreshTokenUsage = filter.RefreshTokenUsage + "";
                if (!string.IsNullOrEmpty(RefreshTokenUsage))
                {
                    var int_RefreshTokenUsage = int.Parse(RefreshTokenUsage);
                    query = query.Where(x => x.RefreshTokenUsage == int_RefreshTokenUsage);
                }
                string UpdateAccessTokenClaimsOnRefresh = filter.UpdateAccessTokenClaimsOnRefresh + "";
                if (!string.IsNullOrEmpty(UpdateAccessTokenClaimsOnRefresh))
                {
                    var bool_UpdateAccessTokenClaimsOnRefresh = bool.Parse(UpdateAccessTokenClaimsOnRefresh);
                    query = query.Where(x => x.UpdateAccessTokenClaimsOnRefresh == bool_UpdateAccessTokenClaimsOnRefresh);
                }
                string RefreshTokenExpiration = filter.RefreshTokenExpiration + "";
                if (!string.IsNullOrEmpty(RefreshTokenExpiration))
                {
                    var int_RefreshTokenExpiration = int.Parse(RefreshTokenExpiration);
                    query = query.Where(x => x.RefreshTokenExpiration == int_RefreshTokenExpiration);
                }
                string AccessTokenType = filter.AccessTokenType + "";
                if (!string.IsNullOrEmpty(AccessTokenType))
                {
                    var int_AccessTokenType = int.Parse(AccessTokenType);
                    query = query.Where(x => x.AccessTokenType == int_AccessTokenType);
                }
                string EnableLocalLogin = filter.EnableLocalLogin + "";
                if (!string.IsNullOrEmpty(EnableLocalLogin))
                {
                    var bool_EnableLocalLogin = bool.Parse(EnableLocalLogin);
                    query = query.Where(x => x.EnableLocalLogin == bool_EnableLocalLogin);
                }
                string IncludeJwtId = filter.IncludeJwtId + "";
                if (!string.IsNullOrEmpty(IncludeJwtId))
                {
                    var bool_IncludeJwtId = bool.Parse(IncludeJwtId);
                    query = query.Where(x => x.IncludeJwtId == bool_IncludeJwtId);
                }
                string AlwaysSendClientClaims = filter.AlwaysSendClientClaims + "";
                if (!string.IsNullOrEmpty(AlwaysSendClientClaims))
                {
                    var bool_AlwaysSendClientClaims = bool.Parse(AlwaysSendClientClaims);
                    query = query.Where(x => x.AlwaysSendClientClaims == bool_AlwaysSendClientClaims);
                }
                string ClientClaimsPrefix = filter.ClientClaimsPrefix + "";
                if (!string.IsNullOrEmpty(ClientClaimsPrefix))
                {
                    ClientClaimsPrefix = ClientClaimsPrefix.ToLower().Trim();
                    query = query.Where(x => x.ClientClaimsPrefix.ToLower().Contains(ClientClaimsPrefix));
                }
                string PairWiseSubjectSalt = filter.PairWiseSubjectSalt + "";
                if (!string.IsNullOrEmpty(PairWiseSubjectSalt))
                {
                    PairWiseSubjectSalt = PairWiseSubjectSalt.ToLower().Trim();
                    query = query.Where(x => x.PairWiseSubjectSalt.ToLower().Contains(PairWiseSubjectSalt));
                }
                string Created = filter.Created + "";
                if (!string.IsNullOrEmpty(Created))
                {
                    var date_Created = DateTime.Parse(Created);
                    query = query.Where(x => x.Created == date_Created);
                }
                string bd_Created = filter.bd_Created + "";
                if (!string.IsNullOrEmpty(bd_Created))
                {
                    var bd_date_Created = DateTime.Parse(bd_Created);
                    query = query.Where(x => x.Created >= bd_date_Created);
                }
                string kt_Created = filter.kt_Created + "";
                if (!string.IsNullOrEmpty(kt_Created))
                {
                    var kt_date_Created = DateTime.Parse(kt_Created);
                    query = query.Where(x => x.Created <= kt_date_Created);
                }
                string Updated = filter.Updated + "";
                if (!string.IsNullOrEmpty(Updated))
                {
                    var date_Updated = DateTime.Parse(Updated);
                    query = query.Where(x => x.Updated == date_Updated);
                }
                string bd_Updated = filter.bd_Updated + "";
                if (!string.IsNullOrEmpty(bd_Updated))
                {
                    var bd_date_Updated = DateTime.Parse(bd_Updated);
                    query = query.Where(x => x.Updated >= bd_date_Updated);
                }
                string kt_Updated = filter.kt_Updated + "";
                if (!string.IsNullOrEmpty(kt_Updated))
                {
                    var kt_date_Updated = DateTime.Parse(kt_Updated);
                    query = query.Where(x => x.Updated <= kt_date_Updated);
                }
                string LastAccessed = filter.LastAccessed + "";
                if (!string.IsNullOrEmpty(LastAccessed))
                {
                    var date_LastAccessed = DateTime.Parse(LastAccessed);
                    query = query.Where(x => x.LastAccessed == date_LastAccessed);
                }
                string bd_LastAccessed = filter.bd_LastAccessed + "";
                if (!string.IsNullOrEmpty(bd_LastAccessed))
                {
                    var bd_date_LastAccessed = DateTime.Parse(bd_LastAccessed);
                    query = query.Where(x => x.LastAccessed >= bd_date_LastAccessed);
                }
                string kt_LastAccessed = filter.kt_LastAccessed + "";
                if (!string.IsNullOrEmpty(kt_LastAccessed))
                {
                    var kt_date_LastAccessed = DateTime.Parse(kt_LastAccessed);
                    query = query.Where(x => x.LastAccessed <= kt_date_LastAccessed);
                }
                string UserSsoLifetime = filter.UserSsoLifetime + "";
                if (!string.IsNullOrEmpty(UserSsoLifetime))
                {
                    var int_UserSsoLifetime = int.Parse(UserSsoLifetime);
                    query = query.Where(x => x.UserSsoLifetime == int_UserSsoLifetime);
                }
                string UserCodeType = filter.UserCodeType + "";
                if (!string.IsNullOrEmpty(UserCodeType))
                {
                    UserCodeType = UserCodeType.ToLower().Trim();
                    query = query.Where(x => x.UserCodeType.ToLower().Contains(UserCodeType));
                }
                string DeviceCodeLifetime = filter.DeviceCodeLifetime + "";
                if (!string.IsNullOrEmpty(DeviceCodeLifetime))
                {
                    var int_DeviceCodeLifetime = int.Parse(DeviceCodeLifetime);
                    query = query.Where(x => x.DeviceCodeLifetime == int_DeviceCodeLifetime);
                }
                string NonEditable = filter.NonEditable + "";
                if (!string.IsNullOrEmpty(NonEditable))
                {
                    var bool_NonEditable = bool.Parse(NonEditable);
                    query = query.Where(x => x.NonEditable == bool_NonEditable);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.ClientId.ToLower().Contains(search) 
                    || x.ProtocolType.ToLower().Contains(search) 
                    || x.ClientName.ToLower().Contains(search) 
                    || x.Description.ToLower().Contains(search) 
                    || x.ClientUri.ToLower().Contains(search) 
                    || x.LogoUri.ToLower().Contains(search) 
                    || x.FrontChannelLogoutUri.ToLower().Contains(search) 
                    || x.BackChannelLogoutUri.ToLower().Contains(search) 
                    || x.AllowedIdentityTokenSigningAlgorithms.ToLower().Contains(search) 
                    || x.ClientClaimsPrefix.ToLower().Contains(search) 
                    || x.PairWiseSubjectSalt.ToLower().Contains(search) 
                    || x.UserCodeType.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ClientsDTO))
            {
                ClientsDTO ClientsDTO = (ClientsDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ClientsDTO.ma.ToLower() && x.id != ClientsDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref Clients entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ClientsDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref Clients entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ClientsDTO))
            {

            }
        }

        //add more

    }
}

