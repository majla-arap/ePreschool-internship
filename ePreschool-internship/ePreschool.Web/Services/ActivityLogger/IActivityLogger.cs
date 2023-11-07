using ePreschool.Core.Dto;

namespace ePreschool.Web.Services.ActivityLogger
{
    public interface IActivityLogger
    {
        Task CreateLog(LogDto log);
    }
}
