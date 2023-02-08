using DotNetCommon.Data.Domain.Interfaces;

namespace SampleApp.Domain.Feedback;

public partial interface IFeedbackRepository : IEntityFrameworkBaseRepository<FeedbackEntity>
{
    Task<int> DeleteByEmail(string email);

    Task<FeedbackEntity> GetByEmail(string email, bool includeRelations = false);
}
