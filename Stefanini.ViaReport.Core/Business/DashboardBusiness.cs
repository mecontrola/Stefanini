using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private const int WEEKS_GROUP_BY = 2;
        private const int DAYS_REMOVE = 120;

        private readonly ISettingsService settingsService;
        private readonly IDeliveryLastCycleService deliveryLastCycleService;
        private readonly IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService;
        private readonly IIssuesEpicByLabelService issuesEpicByLabelService;
        private readonly IGenerateWeeksFromRangeDateHelper generateWeeksFromRangeDateHelper;
        private readonly IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper;

        public DashboardBusiness(ISettingsService settingsService,
                                 IDeliveryLastCycleService deliveryLastCycleService,
                                 IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService,
                                 IIssuesEpicByLabelService issuesEpicByLabelService,
                                 IGenerateWeeksFromRangeDateHelper generateWeeksFromRangeDateHelper,
                                 IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper)
        {
            this.settingsService = settingsService;
            this.deliveryLastCycleService = deliveryLastCycleService;
            this.issuesResolvedInDateRangeService = issuesResolvedInDateRangeService;
            this.issuesEpicByLabelService = issuesEpicByLabelService;
            this.generateWeeksFromRangeDateHelper = generateWeeksFromRangeDateHelper;
            this.issueDtoToIssueInfoDtoMapper = issueDtoToIssueInfoDtoMapper;
        }

        public async Task<DashboardDto> GetData(string project, string quarter, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);
            var rangeDate = generateWeeksFromRangeDateHelper.GenerateList(DateTime.Now.AddDays(-DAYS_REMOVE), DateTime.Now, WEEKS_GROUP_BY);
            var data = await issuesResolvedInDateRangeService.GetData(settings.Username,
                                                                      settings.Password,
                                                                      project,
                                                                      rangeDate.Values.First().Item1,
                                                                      rangeDate.Values.Last().Item2,
                                                                      cancellationToken);

            var epics = await issuesEpicByLabelService.GetData(settings.Username,
                                                               settings.Password,
                                                               project,
                                                               new[] { quarter },
                                                               cancellationToken);

            return new()
            {
                Throughput = OrganizeThroughputData(rangeDate, data),
                QuarterEpics = OrganizeEpicData(epics),
            };
        }

        private DashboardInfoDto OrganizeThroughputData(IDictionary<string, Tuple<DateTime, DateTime>> rangeDate, SearchDto data)
            => new()
            {
                Average = CalculateAverage(data.Total, rangeDate.Count),
                Items = rangeDate.Select(itm => GenerateItem(itm, data))
                                 .ToList()
            };

        private DashboardInfoItemDto GenerateItem(KeyValuePair<string, Tuple<DateTime, DateTime>> itm, SearchDto data)
        {
            var itens = data.Issues
                            .Where(issue => GetResolvedDate(issue)?.Date >= itm.Value.Item1.Date
                                         && GetResolvedDate(issue)?.Date <= itm.Value.Item2.Date)
                            .Select(issue => issueDtoToIssueInfoDtoMapper.ToMap(issue));

            return new()
            {
                Date = itm.Value.Item1,
                Value = itens?.Count() ?? 0,
                Issues = (itens ?? Array.Empty<IssueInfoDto>()).ToList()
            };
        }

        private static decimal CalculateAverage(long total, int count)
            => ((decimal)total / (decimal)count);

        private static DateTime? GetResolvedDate(IssueDto issue)
            => issue.Fields.Resolutiondate?.Date
            ?? issue.Fields.Customfield_14503.ToDateTime();

        private DashboardInfoDto OrganizeEpicData(SearchDto epics)
            => new()
            {
                Average = epics.Issues.Count,
                Items = epics.Issues.Select(x => new DashboardInfoItemDto
                {
                    Issues = new List<IssueInfoDto> { issueDtoToIssueInfoDtoMapper.ToMap(x) },
                    Value = x.Fields.Customfield_15703.ToDecimal().GetValueOrDefault()
                }).ToList()
            };

        public async Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);

            return await deliveryLastCycleService.GetData(settings.Username, settings.Password, project, initDate, endDate, cancellationToken);
        }
    }
}