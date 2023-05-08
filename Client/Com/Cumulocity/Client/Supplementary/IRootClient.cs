using Client.Com.Cumulocity.Client.Api;

namespace Client.Com.Cumulocity.Client.Supplementary;

public interface IRootClient
{
    IApplicationsFactory Applications { get; }

    public interface IApplicationsFactory
    {
        IApplicationsApi ApplicationsApi { get; }
        IApplicationVersionsApi ApplicationVersionsApi { get; }
        IApplicationBinariesApi ApplicationBinariesApi { get; }
        IBootstrapUserApi BootstrapUserApi { get; }
        ICurrentApplicationApi CurrentApplicationApi { get; }
    }

    public interface IAlarmsFactory
    {
        IAlarmsApiV2 AlarmsApi { get; }
    }
}