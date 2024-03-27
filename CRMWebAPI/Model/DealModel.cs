namespace CRMWebAPI.Model
{
    public class DealModel
    {
            public string ProjectName { get; set; }
            public string DealNumber { get; set; }
            public string AccountManager { get; set; }
            public DateTime? FinalSubmissionDate { get; set; }
            public string CustomerName { get; set; }
            public string CustomerLocation { get; set; }
            public string ImplementationDeliveryLocation { get; set; }
            public DateTime? PublishDate { get; set; }
            public DateTime? TenderQualificationDate { get; set; }
            public DateTime? QueriesSubmissionDate { get; set; }
            public string Competitors { get; set; }
            public string ScopeBrief { get; set; }
            public string Challenges { get; set; }
            public string ABC { get; set; }
            public string SiteSurveyInfo { get; set; }

    }
}
