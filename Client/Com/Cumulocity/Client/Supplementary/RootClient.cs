///
/// CumulocityCoreLibrary.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Net.Http;
using Client.Com.Cumulocity.Client.Api;

namespace Client.Com.Cumulocity.Client.Supplementary;

public sealed class RootClient : IRootClient
{
    private readonly Lazy<IRootClient.IApplicationsFactory> _lazyApplications;
    private readonly Lazy<IRootClient.IAlarmsFactory> _lazyAlarms;

    public RootClient(HttpClient httpClient)
    {
        _lazyApplications = new Lazy<IRootClient.IApplicationsFactory>(() => new ApplicationsFactory(httpClient));
        _lazyAlarms = new Lazy<IRootClient.IAlarmsFactory>(() => new AlarmsFactory(httpClient));
    }

    public IRootClient.IApplicationsFactory Applications => _lazyApplications.Value;
    //public MeasurementsFactory Measurements => new(_httpClient);
    public IRootClient.IAlarmsFactory Alarms => _lazyAlarms.Value;
    //public TenantsFactory Tenants => new(_httpClient);
    //public UsersFactory Users => new(_httpClient);
    //public AuditsFactory Audits => new(_httpClient);
    //public RealtimeNotificationsFactory RealtimeNotifications => new(_httpClient);
    //public EventsFactory Events => new(_httpClient);
    //public Notifications20Factory Notifications20 => new(_httpClient);
    //public RetentionsFactory Retentions => new(_httpClient);
    //public IdentityFactory Identity => new(_httpClient);
    //public DeviceControlFactory DeviceControl => new(_httpClient);
    //public InventoryFactory Inventory => new(_httpClient);

    public sealed class ApplicationsFactory : IRootClient.IApplicationsFactory
    {
        private readonly Lazy<IApplicationsApi> _lazyApplicationsApi;
        private readonly Lazy<IApplicationVersionsApi> _lazyApplicationVersionsApi;
        private readonly Lazy<IApplicationBinariesApi> _lazyApplicationBinariesApi;
        private readonly Lazy<IBootstrapUserApi> _lazyBootstrapUserApi;
        private readonly Lazy<ICurrentApplicationApi> _lazyCurrentApplicationApi;

        internal ApplicationsFactory(HttpClient httpClient)
        {
            _lazyApplicationsApi = new Lazy<IApplicationsApi>(() => new ApplicationsApi(httpClient));
            _lazyApplicationVersionsApi = new Lazy<IApplicationVersionsApi>(() => new ApplicationVersionsApi(httpClient));
            _lazyApplicationBinariesApi = new Lazy<IApplicationBinariesApi>(() => new ApplicationBinariesApi(httpClient));
            _lazyBootstrapUserApi = new Lazy<IBootstrapUserApi>(() => new BootstrapUserApi(httpClient));
            _lazyCurrentApplicationApi = new Lazy<ICurrentApplicationApi>(() => new CurrentApplicationApi(httpClient));
        }

        public IApplicationsApi ApplicationsApi => _lazyApplicationsApi.Value;
        public IApplicationVersionsApi ApplicationVersionsApi => _lazyApplicationVersionsApi.Value;
        public IApplicationBinariesApi ApplicationBinariesApi => _lazyApplicationBinariesApi.Value;
        public IBootstrapUserApi BootstrapUserApi => _lazyBootstrapUserApi.Value;
        public ICurrentApplicationApi CurrentApplicationApi => _lazyCurrentApplicationApi.Value;
    }

    //public sealed class MeasurementsFactory
    //{
    //    internal MeasurementsFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IMeasurementsApi MeasurementsApi => new MeasurementsApi(Instance.HttpClient);
    //}

    public sealed class AlarmsFactory : IRootClient.IAlarmsFactory
    {
        private readonly Lazy<IAlarmsApiV2> _lazyAlarmsApi;
        internal AlarmsFactory(HttpClient httpClient)
        {
            _lazyAlarmsApi = new Lazy<IAlarmsApiV2>(() => new AlarmsApiV2(httpClient));
        }

        public IAlarmsApiV2 AlarmsApi => _lazyAlarmsApi.Value;
    }

    //public sealed class TenantsFactory
    //{
    //    internal TenantsFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ITenantsApi TenantsApi => new TenantsApi(Instance.HttpClient);
    //    public ITenantApplicationsApi TenantApplicationsApi => new TenantApplicationsApi(Instance.HttpClient);
    //    public ITrustedCertificatesApi TrustedCertificatesApi => new TrustedCertificatesApi(Instance.HttpClient);
    //    public IDeviceStatisticsApi DeviceStatisticsApi => new DeviceStatisticsApi(Instance.HttpClient);
    //    public IUsageStatisticsApi UsageStatisticsApi => new UsageStatisticsApi(Instance.HttpClient);
    //    public IOptionsApi OptionsApi => new OptionsApi(Instance.HttpClient);
    //    public ILoginOptionsApi LoginOptionsApi => new LoginOptionsApi(Instance.HttpClient);
    //    public ISystemOptionsApi SystemOptionsApi => new SystemOptionsApi(Instance.HttpClient);
    //}

    //public sealed class UsersFactory
    //{
    //    internal UsersFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ICurrentUserApi CurrentUserApi => new CurrentUserApi(Instance.HttpClient);
    //    public IUsersApi UsersApi => new UsersApi(Instance.HttpClient);
    //    public IGroupsApi GroupsApi => new GroupsApi(Instance.HttpClient);
    //    public IRolesApi RolesApi => new RolesApi(Instance.HttpClient);
    //    public IInventoryRolesApi InventoryRolesApi => new InventoryRolesApi(Instance.HttpClient);
    //    public IDevicePermissionsApi DevicePermissionsApi => new DevicePermissionsApi(Instance.HttpClient);
    //}

    //public sealed class AuditsFactory
    //{
    //    internal AuditsFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IAuditsApi AuditsApi => new AuditsApi(Instance.HttpClient);
    //}

    //public sealed class RealtimeNotificationsFactory
    //{
    //    internal RealtimeNotificationsFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IRealtimeNotificationApi RealtimeNotificationApi => new RealtimeNotificationApi(Instance.HttpClient);
    //}

    //public sealed class EventsFactory
    //{
    //    internal EventsFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEventsApi EventsApi => new EventsApi(Instance.HttpClient);
    //    public IAttachmentsApi AttachmentsApi => new AttachmentsApi(Instance.HttpClient);
    //}

    //public sealed class Notifications20Factory
    //{
    //    internal Notifications20Factory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ISubscriptionsApi SubscriptionsApi => new SubscriptionsApi(Instance.HttpClient);
    //    public ITokensApi TokensApi => new TokensApi(Instance.HttpClient);
    //}

    //public sealed class RetentionsFactory
    //{
    //    internal RetentionsFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IRetentionRulesApi RetentionRulesApi => new RetentionRulesApi(Instance.HttpClient);
    //}

    //public sealed class IdentityFactory
    //{
    //    internal IdentityFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IIdentityApi IdentityApi => new IdentityApi(Instance.HttpClient);
    //    public IExternalIDsApi ExternalIDsApi => new ExternalIDsApi(Instance.HttpClient);
    //}

    //public sealed class DeviceControlFactory
    //{
    //    internal DeviceControlFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IOperationsApi OperationsApi => new OperationsApi(Instance.HttpClient);
    //    public IBulkOperationsApi BulkOperationsApi => new BulkOperationsApi(Instance.HttpClient);
    //    public IDeviceCredentialsApi DeviceCredentialsApi => new DeviceCredentialsApi(Instance.HttpClient);
    //    public INewDeviceRequestsApi NewDeviceRequestsApi => new NewDeviceRequestsApi(Instance.HttpClient);
    //}

    //public sealed class InventoryFactory
    //{
    //    internal InventoryFactory(HttpClient httpClient)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IManagedObjectsApi ManagedObjectsApi => new ManagedObjectsApi(Instance.HttpClient);
    //    public IBinariesApi BinariesApi => new BinariesApi(Instance.HttpClient);
    //    public IChildOperationsApi ChildOperationsApi => new ChildOperationsApi(Instance.HttpClient);
    //}
}