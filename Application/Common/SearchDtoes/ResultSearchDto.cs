using Domain.ProjectEnums;

namespace Application.Common.SearchDtoes
{
    public class ResultSearchDto
    {
        public int Page { get; set; }
        public int CountInPage { get; set; }
        public int CountAllItems { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public DateTime TimeCreate { get; set; }
        public Link Link { get; set; }

    }
}
