namespace Application.Common
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
        public Link Link { get; set; }

    }
}
