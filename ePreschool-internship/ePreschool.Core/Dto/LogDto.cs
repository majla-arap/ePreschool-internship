using ePreschool.Core.Enumerations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class LogDto : BaseDto
    {
        public LogDto(LogType logType, string tableName, int? rowId, string title, string message, Exception exception = null)
        {
            Title = title;
            Message = message;
            Type = logType;
            RowId = rowId;
            TableName = tableName;
            ExceptionMessage = exception?.Message;
            ExceptionStackTrace = exception?.StackTrace;

        }

        public string Title { get; set; }
        public string Message { get; set; }
        public int? RowId { get; set; }
        public string TableName { get; set; }
        public int? UserId { get; set; }
        public string ReferrerUrl { get; set; }
        public string CurrentUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public LogType Type { get; set; }


    }
}
