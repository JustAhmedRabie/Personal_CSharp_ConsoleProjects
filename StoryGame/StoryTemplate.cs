namespace My_First_Project
{
    class StoryTemplate
    {
        public string Des { get; set; }
        public string Choices { get; set; }
        public string[] Inputs { get; set; }
        public StoryTemplate[] Branches { get; set; }
    }
}