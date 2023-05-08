using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model.AlarmObj;

namespace Client.Com.Cumulocity.Client.Api;

public interface IAlarmsApiV2
{
    Task<TAlarmResult?> CreateAlarm<TCreateAlarm, TAlarmResult>(TCreateAlarm body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
        where TCreateAlarm : CreateAlarm
        where TAlarmResult : AlarmResult;
}